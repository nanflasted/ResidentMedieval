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
	public Button resumeGame;
	public bool isPaused;
	
	void Start () {

		healthBar.value = player.health / 100;	//check units (player health might need rescaling)
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
		location.text = scene;
		isPaused = false;
		//gamePaused.enabled = false;
		gamePaused.gameObject.SetActive(false);
		//exitGame.enabled = false;
		exitGame.gameObject.SetActive(false);
		resumeGame.gameObject.SetActive(false);
		pauseBackdrop.canvasRenderer.SetAlpha(0);
	}

	void Update () {

		healthBar.value = player.health / 100;
		if (healthBar.value == 0) {
			Debug.Log("Dead");	//testing - need to add resetting to 1 in unit class?
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}

		if (isPaused) {
			pauseBackdrop.canvasRenderer.SetAlpha (168);
			//gamePaused.enabled = true;
			gamePaused.gameObject.SetActive(true);
			//exitGame.enabled = true;
			exitGame.gameObject.SetActive(true);
			resumeGame.gameObject.SetActive(true);
			Time.timeScale = 0;
		} else {
			pauseBackdrop.canvasRenderer.SetAlpha (0);
			//gamePaused.enabled = false;
			gamePaused.gameObject.SetActive(false);
			//exitGame.enabled = false;
			exitGame.gameObject.SetActive(false);
			resumeGame.gameObject.SetActive(false);
			Time.timeScale = 1;
		}

		//if (inConversation) deactivate all HUD stuff and enable conversation HUD
	
	}

	public void decreaseHealth(float amount) {
		healthBar.value -= amount;	//check damage scaling
	}

	public void resume() {
		isPaused = false;
	}

	public void quitGame() {
		Application.LoadLevel(4);
		//Debug.Log("Exit Game");
	}
}
