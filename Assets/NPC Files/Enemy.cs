using UnityEngine;
using System.Collections.Generic;

//Enemies run towards Neutrals and Friendlies

public class Enemy : Unit {

	void Update () {
		//Check for units that are friendlies or neutrals and add them to the array of units this unit cares about (filters out other enemies)
		List<Unit> targetList = new List<Unit>();
		foreach (Friendly unit in battleManager.friendlyManager.units) {
			targetList.Add(unit);
		}
		foreach (Neutral unit in battleManager.neutralManager.units) {
			targetList.Add(unit);
		}
		Unit[] targets = targetList.ToArray();
		
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
		Debug.Log (InRange(shortestDist));
		if (InRange(shortestDist)) {
			weapon.Swing();
			//agent.Stop();
			agent.speed=0;
			anim.SetFloat("Speed", agent.speed);
		} else if (num >= 0) {
			//Move to the closest enemy if further than attackDist
			MoveTo (targets[num]);
			anim.SetFloat("Speed", agent.speed);
		}
		else {
			agent.Stop();
		}
	}
}
