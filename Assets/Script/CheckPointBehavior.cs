using UnityEngine;
using System.Collections;
using System.IO;

public class CheckPointBehavior : MonoBehaviour {
	private bool saving;
	StreamWriter saver;
	StreamReader loader;
	// Use this for initialization
	void Start () {
		saving = false;
		Load();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Load()
	{
		Vector3 pos;
		if (File.Exists("sav.dat"))
		{
			loader = new StreamReader("sav.dat");
			loader.ReadLine();
			pos = Utilities.parseV3(loader.ReadLine());
			//pos.z = 0f;
			loader.ReadLine();
			loader.Close ();
		}
		else
		{
			pos = new Vector3(0f,10.45f,0f);
		}
		GameObject.Find("Player").transform.Translate(pos);
	}

	void Save(Collider other)
	{
		if (saving)
		{
			saver = new StreamWriter("sav.dat");
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
