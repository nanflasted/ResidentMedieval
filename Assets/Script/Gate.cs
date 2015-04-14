using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {


	public Transform target;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			StartCoroutine(ChangeLocation());
		}
	}

	public IEnumerator ChangeLocation() {
		target = gameObject.GetComponentInChildren<Transform>();
		float fadeTime = GameObject.FindGameObjectWithTag("ST").GetComponent<Fading>().BeginFade(1);
		GameObject.FindGameObjectWithTag("ST").GetComponent<Fading>().target = target;
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(1);	
	}
}
