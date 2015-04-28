using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Master class for NPC units
//Anything that should be done by all units should go here

[RequireComponent(typeof (Animator))]
public class Unit : MonoBehaviour {

	public HUDManagement HUDmanager; //used to alter health UI
	public float health;
	public Weapon weapon;
	public NavMeshAgent agent;
	public float attackDist; // minimum distance at which the unit will start attacking
	public float attackAngle; // minimum angle from the opponent at which the unit will start swinging
	public BattleManager battleManager;
	protected Animator anim;
	
	public void Start () {
		agent = GetComponent<NavMeshAgent>();	//Give it access to the NavMesh
		anim = GetComponent<Animator>();
	}

	public bool InRange(Vector3 target) {
		return (target.magnitude <= attackDist)/* && (Vector3.Angle(target, this.transform.forward) <= attackAngle)*/;
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

		//call to HUD to update health bar
		//HUDmanager.decreaseHealth(amount);
		health -= amount;
		if (health <= 0f) {
			
			// "kill" the unit if it runs out of health
			Die();
		}
	}

	// kill the unit; later this should incorporate a death animation
	public void Die() {
		battleManager.friendlyManager.units.Remove(this);
		battleManager.enemyManager.units.Remove(this);
		battleManager.neutralManager.units.Remove(this);

		Object.Destroy(this.gameObject); // ANIMATION: replace this with death animation probably
	}
}
