using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {

	public GameObject player;

	void Start () {
		//player.animation.Play ();
		player.animation.Play ("overhead circle");
	}
	
	// Update is called once per frame
	void Update () {
		/*if (!animation.IsPlaying("overhead circle")) {
			anim.CrossFadeQueued("overhead circle", 0.3f, QueueMode.PlayNow);
		}*/
		if (!player.animation.isPlaying) {
			player.animation.Play("overhead circle");
		}
	}
}
