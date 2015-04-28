using UnityEngine;
using System.Collections;

//Friendlies run towards enemies



public class Friendly : Unit {

	private SoldierAnimationControl controller;
	private bool isSwordDrawn;

	new void Start () {
		base.Start();
		controller = GetComponent<SoldierAnimationControl>();
	}

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
			transform.rotation = Quaternion.Euler(0, Quaternion.LookRotation(targets[num].transform.position - transform.position).eulerAngles.y, 0);
			controller.Attack(true);// ANIMATION: attack
			agent.Stop();
			anim.SetFloat("Speed", 0f); // should set the walking speed as a fraction of the max move speed
		} else if (num >= 0) {
			//Move to the closest enemy if further than attackDist
			controller.Attack(false);
			MoveTo (targets[num]);
			anim.SetFloat("Speed", (agent.velocity.magnitude)/(agent.speed));// ANIMATION: walk/run
		}
		else {
			agent.Stop(); // ANIMATION: idle or whatever
			controller.Attack(false);
		}
		
		
		
	}
	
	
	public void DrawSword(){
		
	}
	
	public void SheathSword(){
		
	}
}
