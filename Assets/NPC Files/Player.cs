using UnityEngine;
using System.Collections;

public class Player : Friendly {

	public GameObject dialogueCanvas;
	public GameObject enterConversationButton;
	public int conversationDistance;
	
	void Start () {
		
	}
	
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			weapon.Swing();
		}
		Unit[] targets = new Unit[unitManager.units.Count];
		int counter = 0;
		for (int i = 0; i < unitManager.units.Count; i++) {
			if (unitManager.units[i].gameObject != null && unitManager.units[i].CompareTag("Enemy")) {
				targets[counter] = unitManager.units[i];
				counter++;
			}
		}
		
		if (Input.GetButtonDown("Fire1")) {
			weapon.Swing();
		}
		
		// find the npc that can be talked to
		GameObject npc = GameObject.FindGameObjectWithTag("DialogueNPC");
		Debug.Log("npc: " + npc);
		// display the enter conversation button
		if (Vector3.Distance(npc.transform.position, gameObject.transform.position) <= conversationDistance && GameObject.Find("DialogueCanvas") == null) {
			//Instantiate(enterConversationButton);
			Instantiate(dialogueCanvas);
		}
	}
	
	/*// if button is clicked, enter the conversation
	public void EnterConversation() {
		Instantiate(dialogueCanvas);
	}*/
}
