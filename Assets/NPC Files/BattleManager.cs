using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {
	public UnitManager friendlyManager;
	public UnitManager enemyManager;
	public UnitManager neutralManager;
	public int numFriendlies;
	public int numEnemies;
	public int numNeutrals;

	private bool inProgress;

	// start the unitManagers spawning the units
	void Start () {
		inProgress = true;

		StartCoroutine(friendlyManager.SpawnUnits(numFriendlies, this));
		StartCoroutine(enemyManager.SpawnUnits(numEnemies, this));
		StartCoroutine(neutralManager.SpawnUnits(numNeutrals, this));
	}
	
	// check if one of the sides doesn't have any more combatants
	void Update () {
	/**
		if (inProgress == true) {
			if (friendlyManager.units.Count == 0) {
				Debug.Log ("You lost the battle!");
				inProgress = false;
			} else if (enemyManager.units.Count == 0) {
				Debug.Log ("You won the battle!");
				inProgress = false;
			}
		}
		*/
	}
}
