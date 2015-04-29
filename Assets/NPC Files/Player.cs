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

		isAttacking = weapon.GetComponent<Animator>().GetBool("Attacking");
		
		// find the npcs that can be talked to
		GameObject[] npcs = GameObject.FindGameObjectsWithTag("DialogueNPC");
		for (int i = 0; i < npcs.Length; i++) {		
			if (npcs[i] != null && Vector3.Distance(npcs[i].transform.position, gameObject.transform.position) <= conversationDistance && GameObject.FindGameObjectWithTag("DialogueCanvas") == null) {
				Instantiate(dialogueCanvas);
			}
		}
	}
	
}
