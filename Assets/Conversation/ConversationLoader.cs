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
		// get the conversation manager, which holds the conversation, from the player
		GameObject player = GameObject.Find("player");
		conversation = player.GetComponent<ConversationManager>();
		
		// fill in the initial reponses for the player and npc
		currentNode = conversation.AdvanceConversation();
		response1.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(1).ToString ();
		response2.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(2).ToString ();
		response3.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(3).ToString ();
		nextPlayerReponse = 4;
		
		npcResponse.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetNpcResponses(1).ToString ();
		nextNPCResponse = 2;
	}	
	
	// called when Response 1 is clicked
	public void Response1() {
		Debug.Log ("one");
		LoadNewResponses();
	}
	
	// called when Response 2 is clicked
	public void Response2() {
		Debug.Log("two");
		LoadNewResponses();
	}
	
	// called when Response 3 is clicked
	public void Response3() {
		Debug.Log("three");
		LoadNewResponses();
	}
	
	// called when Leave Conversation is clicked
	public void Leave() {
		Destroy(gameObject);
	}
	
	private void LoadNewResponses() {
		currentNode = conversation.AdvanceConversation();
		npcResponse.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetNpcResponses(nextNPCResponse++).ToString ();
		response1.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(nextPlayerReponse++).ToString ();
		response2.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(nextPlayerReponse++).ToString ();
		response3.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(nextPlayerReponse++).ToString ();
	}
	
}
