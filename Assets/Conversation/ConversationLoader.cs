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
		GameObject player = GameObject.Find("Player");
		conversation = player.GetComponent<ConversationManager>();
		
		// fill in the initial reponses for the player and npc
		currentNode = conversation.AdvanceConversation();
		response1.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(1).GetComponent<Text>().text;
		response2.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(2).GetComponent<Text>().text;
		response3.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(3).GetComponent<Text>().text;
		nextPlayerReponse = 4;
		
		npcResponse.transform.GetComponent<Text>().text = currentNode.GetNpcResponses(1).GetComponent<Text>().text;
		nextNPCResponse = 2;
	}	
	
	// called when Leave Conversation is clicked
	public void Leave() {
		Destroy(gameObject);
	}
	
	// called when a response button is clicked
	public void LoadNewResponses() {
		currentNode = conversation.AdvanceConversation();
		npcResponse.transform.GetComponent<Text>().text = currentNode.GetNpcResponses(nextNPCResponse++).GetComponent<Text>().text;
		response1.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(1).GetComponent<Text>().text;
		response2.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(2).GetComponent<Text>().text;
		response3.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(3).GetComponent<Text>().text;
	}
	
}
