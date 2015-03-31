using UnityEngine;
using System.Collections;

//Friendlies run towards enemies

public class Friendly : Unit {

	void Update () {
		//Check for units that are enemies and add them to the array of units this unit cares about (filters out other neutrals and friendlies)
		Unit[] targets = new Unit[unitManager.units.Length];
		int counter = 0;
		for (int i = 0; i < unitManager.units.Length; i++) {
			if (unitManager.units[i] != null && unitManager.units[i].CompareTag("Enemy")) {
				targets[counter] = unitManager.units[i];
				counter++;
			}
		}
		
		//Find the closest enemy
		Vector3[] distToEnemy = new Vector3[targets.Length];
		
		for (int i = 0; i < counter; i++) {
			distToEnemy[i] = new Vector3(targets[i].transform.position.x - this.transform.position.x, 0, targets[i].transform.position.z - this.transform.position.z);
		}
		int num = -1;
		Vector3 shortestDist = new Vector3(10000,10000,10000);
		for (int i = 0; i < counter; i++) {
			if (distToEnemy[i].magnitude < shortestDist.magnitude) {
				shortestDist = distToEnemy[i];
				num = i;
			}
		}

		// attack if close enough to target
		if (shortestDist.magnitude < attackDist) {
			weapon.Swing();
		}
		else if (num >= 0) {
			//Move to the closest enemy
			MoveTo (targets[num]);
		}
	}
}
