using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class HUDManagement : MonoBehaviour {

	public Slider healthBar;
	public Text location;
	public Player player;
	public string scene;
	public int level;
	public RawImage pauseBackdrop;
	public Text gamePaused;
	public Button exitGame;
	public bool isPaused;
	
	void Start () {

		healthBar.value = player.health / 100;	//check units (player health might need rescaling)
		/*level = Application.loadedLevel;
		if (level == 0) {
			location.text = "Umbreland";
		} else {
			location.text = "somewhere else";
		}*/
		scene = EditorApplication.currentScene;
		if (scene == "Assets/HUD/HUD.unity") {
			scene = "Umbreland";
		} else if (scene == "Assets/Town2.unity") {
			scene = "Mocpack";
		} else if (scene == "Assets/nature1.unity") {
			scene = "Wilderness";
		} else {
			scene = "you broke something";
		}
		location.text = scene;	//requires renaming of scenes to appropriate town name
		isPaused = false;
		gamePaused.enabled = false;
		exitGame.enabled = false;
		pauseBackdrop.canvasRenderer.SetAlpha(0);
	}

	void Update () {

		healthBar.value = player.health / 100;
		if (healthBar.value == 0) {
			Debug.Log("Dead");	//testing - need to add resetting to 1 in unit class?
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = true;
		}

		if (isPaused) {
			pauseBackdrop.canvasRenderer.SetAlpha(168);
			gamePaused.enabled = true;
			exitGame.enabled = true;
		}

		//if (inConversation) deactivate all HUD stuff and enable conversation HUD
	
	}

	public void decreaseHealth(float amount) {
		healthBar.value -= amount;	//check damage scaling
	}
}
