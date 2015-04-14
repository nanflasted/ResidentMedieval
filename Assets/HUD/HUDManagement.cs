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
	
	void Start () {

		healthBar.value = player.health;	//check units (player health might need rescaling)
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
		//location.text = level.ToString();
	}

	void Update () {

		healthBar.value = player.health;
		/*level = Application.loadedLevel;
		if (level == 0) {
			location.text = "Umbreland";
		} else {
			location.text = "somewhere else";
		}*/
		//scene = EditorApplication.currentScene;
		//location.text = scene;
		//location.text = level.ToString();
		if (healthBar.value == 0) {
			Debug.Log("Dead");	//testing - need to add resetting to 1 in unit class?
		}

		//if (inConversation) deactivate all HUD stuff and enable conversation HUD
	
	}

	public void decreaseHealth(float amount) {
		healthBar.value -= amount;	//check damage scaling
	}
}
