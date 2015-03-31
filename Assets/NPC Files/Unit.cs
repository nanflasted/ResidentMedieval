using UnityEngine;
using System.Collections;

//Master class for NPC units
//Anything that should be done by all units should go here

public class Unit : MonoBehaviour {
	public float health;
	public Weapon weapon;
	public NavMeshAgent agent;
	public float attackDist;
	public float attackAngle;
	public UnitManager unitManager;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();	//Give it access to the NavMesh
	}

	public bool InRange(Vector3 target) {
		return (target.magnitude < attackDist) && (Vector3.Angle(target, this.transform.forward) < attackAngle);
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
