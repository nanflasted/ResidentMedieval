using UnityEngine;
using System.Collections;

public class Player : Friendly {

	public GameObject dialogueCanvas;
	public GameObject enterConversationButton;
	public int conversationDistance;
	
	new void Start () {

	}
	
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			weapon.Swing();
		}
		
		// find the npc that can be talked to
		GameObject npc = GameObject.FindGameObjectWithTag("DialogueNPC");
		// display the enter conversation button
		if (npc != null && Vector3.Distance(npc.transform.position, gameObject.transform.position) <= conversationDistance && GameObject.FindGameObjectWithTag("DialogueCanvas") == null) {
			//Instantiate(enterConversationButton);
			Instantiate(dialogueCanvas);
		}
	}
	
	/*
	 * working on making the button do what it's supposed to - Leah 
	// if button is clicked, enter the conversation
	public void EnterConversation() {
		Debug.Log ("clicked");
		Destroy(enterConversationButton);
		Instantiate(dialogueCanvas);
	}
	*/
	
}
