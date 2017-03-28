using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
	// Use this for initialization

	private GameObject[] controlObjects;

	void Start () {
		controlObjects = GameObject.FindGameObjectsWithTag ("ControlScreen");
		foreach (GameObject i in controlObjects) {
			i.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToMainSceneWith2Players() {
		// How to use in next Scene
		// int numPlayers = (int) Scenes.getParam("numberOfPlayers");
		Scenes.Load ("Asgeir", "numberOfPlayers", "2");
	}

	public void ToMainSceneWith3Players() {
		Scenes.Load ("Asgeir", "numberOfPlayers", "3");
	}

	public void ToMainSceneWith4Players() {
		Scenes.Load ("Asgeir", "numberOfPlayers", "4");
	}

	public void EnterControls(){
		foreach (GameObject i in controlObjects) {
			i.SetActive(true);
		}
	}
		
	public void ExitControls(){
		foreach (GameObject i in controlObjects) {
			i.SetActive(false);
		}
	}

	public void Quit() {
		Application.Quit();
	}
}
