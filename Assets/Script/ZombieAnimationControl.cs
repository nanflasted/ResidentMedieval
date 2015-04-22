using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
public class ZombieAnimationControl : MonoBehaviour {


	private Animator anim; // a reference to the animator on the character
	
	private bool isAttacking;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		isAttacking = false;
	}
	
	public void Attack(bool attack){
		anim.SetBool ("Attack", attack);
		isAttacking = attack;
	}
	
	public void Die(bool die){
		anim.SetBool ("Dead", die);
	}
}
