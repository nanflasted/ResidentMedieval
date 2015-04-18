using UnityEngine;
using System.Collections;

//Friendlies run towards enemies



public class Friendly : Unit {

	private bool isSwordDrawn;

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

		// attack if close enough to target
		if (InRange(shortestDist)) {
			weapon.Swing(); // ANIMATION: attack
			agent.Stop();
		}
		else if (num >= 0) {
			MoveTo (targets[num]); // ANIMATION: walk/run
		} else {
			agent.Stop(); // ANIMATION: idle
		}
		
		
		
	}
	
	
	public void DrawSword(){
		
	}
	
	public void SheathSword(){
		
	}
}
