using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
public class NPCAnimationControl : MonoBehaviour {

	private Animator anim; // a reference to the animator on the character
	

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	public void Die(bool die){
		anim.SetBool ("Dead", die);
	}
}
