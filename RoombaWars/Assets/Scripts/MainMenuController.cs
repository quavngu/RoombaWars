using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToMainSceneWith2Players() {
		// How to use in next Scene
		// int numPlayers = (int) Scenes.getParam("numberOfPlayers");
		Scenes.Load ("PlayerCustomization", "numberOfPlayers", "2");
	}

	public void ToMainSceneWith3Players() {
		Scenes.Load ("PlayerCustomization", "numberOfPlayers", "3");
	}

	public void ToMainSceneWith4Players() {
		Scenes.Load ("PlayerCustomization", "numberOfPlayers", "4");
	}
}
