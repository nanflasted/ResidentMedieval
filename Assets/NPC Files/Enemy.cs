using UnityEngine;
using System.Collections;

//Enemies run towards Neutrals and Friendlies

public class Enemy : Unit {

	public Unit[] otherUnits;	//Other units in the scene
	
	void Update () {
		//Check for units that are friendlies or neutrals and add them to the array of units this unit cares about (filters out other enemies)
		Unit[] targets = new Unit[otherUnits.Length];
		int counter = 0;
		for (int i = 0; i < otherUnits.Length; i++) {
			if (otherUnits[i].CompareTag("Friendly") || otherUnits[i].CompareTag("Neutral")) {
				targets[counter] = otherUnits[i];
				counter++;
			}
		}
		
		//Find the closest enemy
		Vector3[] distToEnemy = new Vector3[targets.Length];
		
		for (int i = 0; i < counter; i++) {
			distToEnemy[i] = new Vector3(targets[i].transform.position.x - this.transform.position.x, 0, targets[i].transform.position.z - this.transform.position.z);
		}
		int num = 0;
		Vector3 shortestDist = new Vector3(10000,10000,10000);
		for (int i = 0; i < counter; i++) {
			if (distToEnemy[i].magnitude < shortestDist.magnitude) {
				shortestDist = distToEnemy[i];
				num = i;
			}
		}
		
		//Move to the closest enemy
		MoveTo (targets[num]);
	}
}
