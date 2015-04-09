using UnityEngine;
using System.Collections;

public class StartConversation : MonoBehaviour {

	public GameObject dialogueCanvas; 
	
	// Use this for initialization
	void Start () {
		Instantiate(dialogueCanvas);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
