﻿using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {

	public Player player;
	// Use this for initialization
	void Start () {
		player.animation.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
