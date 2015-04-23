//David Merriman
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//convo manager, holds a linked list containing conversation progression
public class ConversationManager : MonoBehaviour {

	public Text[] playerResponses;
	public Text[] npcResponses;
	
	private int conversationIndex = 0;
	private ArrayList list = new ArrayList();
	
	//initializes conversation progression (i.e builds list)
	void Start()
	{
		Text[] playerNodeResponses;
		Text[] npcNodeResponses;
		
		for(int i = 0; i < playerResponses.Length ; i += 3)
		{
			playerNodeResponses = new Text[3] {playerResponses[i], playerResponses[i + 1], playerResponses[i + 2]};
			npcNodeResponses = new Text[3] {npcResponses[i], npcResponses[i + 1], npcResponses[i + 2]};
			list.Add(new ConversationNode(playerNodeResponses, npcNodeResponses));
		}
	}
	
	//advances conversation to next node
	public ConversationNode AdvanceConversation()
	{
		if (conversationIndex > list.Count - 1) {
			return null;
		}
		return (ConversationNode)list[conversationIndex++];
	}
	
}

public class ConversationNode
{
	private Text[] playerResponses;
	private Text[] npcResponses;
	
	//all arrays should be size three
	public ConversationNode(Text[] playerResponses, Text[] npcResponses)
	{
		this.playerResponses = playerResponses;
		this.npcResponses = npcResponses;
	}
	
	//getters for player/npc responses, responseNumber should be between 1 and 3
	public Text GetPlayerResponse(int responseNumber)
	{
		return playerResponses[responseNumber - 1];
	}
	
	public Text GetNpcResponses(int responseNumber)
	{
		return npcResponses[responseNumber - 1];
	}
	
}