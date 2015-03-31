using UnityEngine;
using System.Collections;

//Master class for NPC units
//Anything that should be done by all units should go here

public class Unit : MonoBehaviour {
	public float health;
	public Weapon weapon;
	public NavMeshAgent agent;
	public float attackDist;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();	//Give it access to the NavMesh
	}
	
	public void MoveTo(Unit target) {
		agent.SetDestination(target.transform.position);	//Move to the position of a specific unit
	}

	// an Attack() command has been sent, swing the weapon
	protected void Attack () {
		weapon.Swing();
	}

	// damages this unit
	public void DoDamage(float amount) {
		health -= amount;
		if (health <= 0f) {
			
			// "kill" the unit if it runs out of health
			Die();
		}
	}

	// kill the unit; later this should incorporate a death animation
	void Die() {
		Destroy(gameObject);
	}
}
