using UnityEngine;
using System.Collections;

public class MinimapUpdate : MonoBehaviour {

	public Transform target;

	void Update () {
		transform.position = new Vector3 (target.position.x - 200f, 100f, target.position.z);
	}
}
