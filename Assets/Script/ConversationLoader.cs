using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConversationLoader : MonoBehaviour {

	public GameObject response1;
	public GameObject response2;
	public GameObject response3;
	public GameObject npcresponse;
	
	private int nextPlayerReponse;
	private int nextNPCResponse;
	
	// Use this for initialization
	void Start () {
		// get the conversation manager, which holds the conversation, from the player
		GameObject player = GameObject.Find("player");
		ConversationManager convo = player.GetComponent<ConversationManager>();
		
		// fill in the initial reponses for the player and npc
		ConversationNode currentNode = convo.AdvanceConversation();
		response1.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(1).ToString ();
		response2.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(2).ToString ();
		response3.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetPlayerResponse(3).ToString ();
		nextPlayerReponse = 4;
		
		npcresponse.transform.FindChild("Text").GetComponent<Text>().text = currentNode.GetNpcResponses(1).ToString ();
		nextNPCResponse = 2;
	}
	
	//TODO: set up the buttons so that they advance the conversation when clicked
	
	// Update is called once per frame
	void Update () {
	
	}
}
