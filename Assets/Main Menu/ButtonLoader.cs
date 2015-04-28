using UnityEngine;
using System.Collections;

public class ButtonLoader : MonoBehaviour {
	public Camera cam;
	public void ContinueGame()
	{
		//Application.LoadLevel (1);
		Debug.Log ("continue game");
		cam.audio.Play ();
		Utilities.Load ();

	}

	//load screen
	public void BeginGame()
	{
		//Application.LoadLevel (2);
		Debug.Log ("begin game");
		cam.audio.Play ();
		Application.LoadLevel(4);

	}

	public void LoadGame()
	{
		//Application.LoadLevel (3);
		Debug.Log ("load game");

		cam.audio.Play ();
	}

	public void DisplayOptions()
	{
		//Application.LoadLevel (4);
		Debug.Log ("display options");
		cam.audio.Play ();
	}

	public void ExitGame()
	{
		//Application.Quit ();
		Debug.Log ("exit game");
	}
}
