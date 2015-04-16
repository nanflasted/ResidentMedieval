using UnityEngine;
using System.Collections;

public class Player : Friendly {

	public GameObject dialogueCanvas;
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
		
		GameObject npc = GameObject.FindGameObjectWithTag("DialogueNPC");
		if (Vector3.Distance(npc.transform.position, gameObject.transform.position) <= 5 && GameObject.Find("DialogueCanvas") == null) {
			Instantiate(dialogueCanvas);
		}
	}
}
