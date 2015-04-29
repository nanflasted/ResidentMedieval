using UnityEngine;
using System.Collections;

//Neutrals run away from enemies

public class Neutral : Unit {
	
	public NPCAnimationControl animControl;
	
	void Update () {
		//Check for units that are enemies and add them to the array of units this unit cares about (filters out other neutrals and friendlies)
		Unit[] targets = battleManager.enemyManager.units.ToArray();
		
		//Find the closest enemy
		Vector3[] distToEnemy = new Vector3[targets.Length];
		
		for (int i = 0; i < targets.Length; i++) {
			distToEnemy[i] = new Vector3(targets[i].transform.position.x - this.transform.position.x, 0, targets[i].transform.position.z - this.transform.position.z);
		}
		int num = -1;
		Vector3 shortestDist = new Vector3(10000,10000,10000);
		for (int i = 0; i < targets.Length; i++) {
			if (distToEnemy[i].magnitude < shortestDist.magnitude) {
				shortestDist = distToEnemy[i];
				num = i;
			}
		}

		if (num >= 0) {
			//Create a fake unit in the opposite direction of the closest unit and run towards that fake unit
			Vector3 opposite = new Vector3(this.transform.position.x - shortestDist.x * 2, 0, this.transform.position.z - shortestDist.z * 2);
			agent.SetDestination(opposite); // ANIMATION: walk/run
			anim.SetFloat("Speed", (agent.velocity.magnitude)/(agent.speed));
		} else {
			agent.Stop(); // ANIMATION: idle
			anim.SetFloat("Speed", 0f);
		}
	}
}
