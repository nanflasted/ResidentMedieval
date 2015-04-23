﻿using UnityEngine;
using System.Collections;

public class CastleDoorOutside : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			StartCoroutine(ChangeLocation());
		}
	}
	
	public IEnumerator ChangeLocation() {
		GameObject.FindGameObjectWithTag("ST").GetComponent<Fading>().currentDestination = "castledoorinside";
		float fadeTime = GameObject.FindGameObjectWithTag("ST").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(4);	
	}
}
