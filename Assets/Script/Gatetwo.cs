using UnityEngine;
using System.Collections;

public class Gatetwo : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			StartCoroutine(ChangeLocation());
		}
	}
	
	public IEnumerator ChangeLocation() {
		float fadeTime = GameObject.FindGameObjectWithTag("ST").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(0);
	}
}