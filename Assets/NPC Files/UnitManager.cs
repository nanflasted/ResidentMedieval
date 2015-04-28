using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour {
	public Unit unitPrefab;
	public GameObject[] spawnPoints;
	public int spawnDelay;
	public List<Unit> units;

	void Start() {

	}

	// spawn units, waiting the specified amount of time after each
	public IEnumerator SpawnUnits(int numUnits, BattleManager battleManager) {
		for (int i = 0; i < numUnits; i++) {
			SpawnUnit(numUnits, battleManager);
			yield return new WaitForSeconds(spawnDelay);
		}
	}

	// spawn a unit at a random spawn point
	private void SpawnUnit(int numUnits, BattleManager battleManager) {
		Unit unit = Instantiate(unitPrefab) as Unit;
		unit.battleManager = battleManager;
		units.Add(unit);
		
		GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		unit.gameObject.transform.position = spawnPoint.transform.position;
		unit.gameObject.SetActive(true);
	}
}