using UnityEngine;
using System.Collections;

public class MinimapUpdate : MonoBehaviour {

	public Transform target;

	void Update () {
		transform.position = new Vector3 (target.position.x - 300f, 20f, target.position.z);
	}
}
