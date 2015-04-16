// Leah Karasek

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConversationLoader : MonoBehaviour {

	public GameObject response1;
	public GameObject response2;
	public GameObject response3;
	public GameObject npcResponse;
		
	private int nextPlayerReponse;
	private int nextNPCResponse;
	private ConversationNode currentNode;
	private ConversationManager conversation;
	
	// Use this for initialization
	void Start () {
		// get the conversation manager, which holds the conversation, from the npc
		// right now, this only works with the general
		GameObject npc = GameObject.FindGameObjectWithTag("General");
		conversation = npc.GetComponent<ConversationManager>();
		
		// fill in the initial reponses for the player and npc
		LoadNewResponses(1);
		
		npcResponse.transform.GetComponent<Text>().text = currentNode.GetNpcResponses(1).GetComponent<Text>().text;
	}	
	
	// called when Leave Conversation is clicked
	public void Leave() {
		Destroy(gameObject);
	}
	
	public void Response1() {
		LoadNewResponses(1);
	}
	
	public void Response2() {
		LoadNewResponses(2);
	}
	
	public void Response3() {
		LoadNewResponses(3);
	}
	
	// called when a response button is clicked
	private void LoadNewResponses(int npcResponseNum) {
		response2.SetActive(true);
		response3.SetActive(true);
		// if there are no more conversation nodes, leave the conversation
		if ((currentNode = conversation.AdvanceConversation ()) == null) {
			Leave ();
			return;
		}
		
		// otherwise, load new responses from the currentNode
		npcResponse.transform.GetComponent<Text>().text = currentNode.GetNpcResponses(npcResponseNum).GetComponent<Text>().text;
		response1.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(1).GetComponent<Text>().text;
		// if response 2 is the same as 1, 1 is the only possible response, so set the other two inactive
		if (currentNode.GetPlayerResponse(2).GetComponent<Text>().text != response1.transform.FindChild("Text").GetComponent<Text>().text) {
			response2.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(2).GetComponent<Text>().text;
		}
		else {
			response2.SetActive(false);
			response3.SetActive (false);
		}
		// if response 3 is the same as 2, 1 and 2 are the only responses, so set 3 inactive
		if (currentNode.GetPlayerResponse(3).GetComponent<Text>().text != response1.transform.FindChild("Text").GetComponent<Text>().text &&
		    currentNode.GetPlayerResponse(3).GetComponent<Text>().text != response2.transform.FindChild("Text").GetComponent<Text>().text) {
			response3.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(3).GetComponent<Text>().text;
		}
		else {
			response3.SetActive(false);
		}
	}
		
}
