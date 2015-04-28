using UnityEngine;
using System.Collections;

public class MinimapUpdate : MonoBehaviour {
	
	public Transform target;
	
	void Update () {
		transform.position = new Vector3 (target.position.x - 300f, 20f, target.position.z);
		transform.GetChild(0).eulerAngles = new Vector3 (90f, 0f, (-1 * target.eulerAngles.y + 90));
	}
}
