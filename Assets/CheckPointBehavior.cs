using UnityEngine;
using System.Collections;
using System.IO;

public class CheckPointBehavior : MonoBehaviour {
	public Player player;
	private bool saving;
	StreamWriter saver;
	// Use this for initialization
	void Start () {
		saving = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Save()
	{
		if (saving)
		{
			saver = new StreamWriter("save.dat");
			saver.WriteLine("test saving");
			saver.WriteLine(player.transform.localPosition);
			saver.WriteLine ("testEnd");
			Debug.Log("Saved");
		}
	}

	void OnCollisionEnter()
	{
		saving = true;
		Save();
	}

	void OnCollisionExit()
	{
		saving = false;
	}
}
