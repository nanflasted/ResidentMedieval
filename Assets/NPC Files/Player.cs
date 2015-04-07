using UnityEngine;
using System.Collections;

public class Player : Unit {
	
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
	}
}
