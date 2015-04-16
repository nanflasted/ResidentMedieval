using UnityEngine;
using System.Collections;

public class Player : Unit {

	public GameObject dialogueCanvas;
	
	void Start () {
		
	}
	
	
	void Update () {
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
		
		GameObject general = GameObject.FindGameObjectWithTag("General");
		//Vector3 debug = general.transform.position;
		if (Vector3.Distance(general.transform.position, gameObject.transform.position) <= 5 && GameObject.Find("DialogueCanvas") == null) {
			Instantiate(dialogueCanvas);
		}
	}
}
