using UnityEngine;
using System.Collections;

public class ButtonLoader : MonoBehaviour {

	public void ContinueGame()
	{
		//Application.LoadLevel (1);
		Debug.Log ("continue game");
		Utilities.Load ();
		audio.Play ();
	}

	//load screen
	public void BeginGame()
	{
		//Application.LoadLevel (2);
		Debug.Log ("begin game");
		audio.Play ();
	}

	public void LoadGame()
	{
		//Application.LoadLevel (3);
		Debug.Log ("load game");

		audio.Play ();
	}

	public void DisplayOptions()
	{
		//Application.LoadLevel (4);
		Debug.Log ("display options");
		audio.Play ();
	}

	public void ExitGame()
	{
		//Application.Quit ();
		Debug.Log ("exit game");
	}
}
