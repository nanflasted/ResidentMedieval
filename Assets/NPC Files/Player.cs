using UnityEngine;
using System.Collections;

public class Player : Friendly {
	
	void Start () {
		
	}
	
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			weapon.Swing();
		}
	}
}
