using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float damage;
	public Unit wielder;
	
	// Update is called once per frame
	void Update () {

	}

	public void Swing() {
		GetComponent<Animator>().SetTrigger("Attacking");
	}

	// if the weapon hits something
	public void OnTriggerEnter(Collider obj) {
		Debug.Log("0");
		if (wielder.isAttacking) {
			Debug.Log("1");
			// checks that the wielder and the person hit are not on the same team
			if ((obj.gameObject.CompareTag("Enemy") || obj.gameObject.CompareTag("Friendly") || obj.gameObject.CompareTag("Neutral"))
			    && !obj.gameObject.CompareTag(wielder.gameObject.tag)) {
				Debug.Log("2");
				if ((wielder is Player && obj.gameObject.CompareTag("Enemy")) || !(wielder is Player)) {
					// damage the enemy
					obj.GetComponent<Unit>().DoDamage(damage);
				}
			}
		}
	}
}
