using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private int numberOfPlayers;

	// Use this for initialization
	void Start () {
		if(Scenes.getParameter ("numberOfPlayers") != "")
			numberOfPlayers = int.Parse (Scenes.getParameter ("numberOfPlayers"));
		print ("Number of players: " + numberOfPlayers);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
