using UnityEngine;
using System.Collections;

//Master class for NPC units
//Anything that should be done by all units should go here

public class Unit : MonoBehaviour {

	public NavMeshAgent agent;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();	//Give it access to the NavMesh
	}
	
	public void MoveTo(Unit target) {
		agent.SetDestination(target.transform.position);	//Move to the position of a specific unit
	}
}
