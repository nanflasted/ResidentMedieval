using UnityEngine;
using System.Collections;
using System.IO;

public class CheckPointBehavior : MonoBehaviour {
	private bool saving;
	StreamWriter saver;
	// Use this for initialization
	void Start () {
		saving = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Save(Collider other)
	{
		if (saving)
		{
			saver = new StreamWriter("save.dat");
			saver.WriteLine("test saving");
			saver.WriteLine(other.rigidbody.transform.localPosition);
			saver.WriteLine ("testEnd");
			Debug.Log("Saved");
			saver.Close ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			saving = true;
			Save(other);
		}
	}

	void OnTriggerExit(Collider other)
	{
		saving = false;
	}
}
