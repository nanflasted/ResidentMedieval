using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
public class SoldierAnimationControl : MonoBehaviour {

	public GameObject rightHand;
	public GameObject leftForearm;
	public GameObject leftHip;
	public Weapon weapon;
	public GameObject shield;
	
	private bool isSwordDrawn;
	
	private Animator anim; // a reference to the animator on the character
	private AnimatorStateInfo currentBaseState; // a reference to the current state of the animator, used for base layer
	
	/**
	static int idleState = Animator.StringToHash("Base Layer.Idle");
	static int movementState = Animator.StringToHash("Base Layer.Movement");
	static int drawSword1State = Animator.StringToHash("Base Layer.Draw Sword 1");
	static int drawSword2State = Animator.StringToHash("Base Layer.Draw Sword 2");
	static int sheathSword1State = Animator.StringToHash("Base Layer.Sheath Sword 1");
	static int sheathSword2State = Animator.StringToHash("Base Layer.Sheath Sword 2");
	static int sIdleState = Animator.StringToHash("Base Layer.S&S Idle 4");
	static int sMovementState = Animator.StringToHash("Base Layer.S&S Movement");
	static int sAttackState = Animator.StringToHash("Base Layer.S&S Slash");
	static int sReactionHitState = Animator.StringToHash("Base Layer.Reaction Hit");
	*/

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	
		weapon.transform.parent = leftHip.transform; //weapons initialize on the hip, must be drawn
		weapon.transform.localPosition = new Vector3(0,0,0);
		weapon.transform.localRotation = Quaternion.identity;
		shield.transform.parent = leftForearm.transform; //shields initialize on the left arm
		shield.transform.localPosition = new Vector3(0,0,0);
	
		isSwordDrawn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(isSwordDrawn){
			weapon.transform.parent = rightHand.transform; //keeps sword in hand
		}else{
			weapon.transform.parent = leftHip.transform; //keeps sword on hip
		}
		
		shield.transform.parent = leftForearm.transform; //so the shield stays in place
	}
	
	
	public void DrawSword(bool drawSword){
		isSwordDrawn = drawSword;
		anim.SetBool ("Draw Sword", isSwordDrawn);
		
		if(isSwordDrawn){
			weapon.transform.parent = rightHand.transform; //move sword to hand
			weapon.transform.localPosition = new Vector3(0,0,0);
		}else{
			weapon.transform.parent = leftHip.transform; //move sword to hip
			weapon.transform.localPosition = new Vector3(0,0,0);
		}
	}
	
}
