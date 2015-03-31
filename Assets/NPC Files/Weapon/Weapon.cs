﻿using UnityEngine;
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

		// checks that the wielder and the person hit are not on the same team
		if ((obj.gameObject.CompareTag("Ally") || obj.gameObject.CompareTag("Enemy"))
		    && !obj.gameObject.CompareTag(wielder.gameObject.tag)) {

			// damage the enemy
			obj.GetComponent<Unit>().DoDamage(damage);
		}
	}
}
