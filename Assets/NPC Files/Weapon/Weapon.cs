using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float damage;
	public Unit wielder;

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	// go through the weapon swing animation
	public void Swing () {
		animator.SetTrigger("Attacking");
	}

	// if the weapon hits something
	public void OnTriggerEnter(Collider obj) {
		if (animator.GetBool("Attacking")) {
			// checks that the wielder and the person hit are not on the same team
			if ((obj.gameObject.CompareTag("Enemy") || obj.gameObject.CompareTag("Friendly") || obj.gameObject.CompareTag("Neutral"))
			    && !obj.gameObject.CompareTag(wielder.gameObject.tag)) {

				if ((wielder is Player && obj.gameObject.CompareTag("Enemy")) || !(wielder is Player)) {
					// damage the enemy
					obj.GetComponent<Unit>().DoDamage(damage);
				}
			}
		}
	}
}
