using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private int numberOfPlayers;
	public GameObject player3;
	public GameObject player4;

	// Use this for initialization
	void Start () {
		if(Scenes.getParameter ("numberOfPlayers") != "")
			numberOfPlayers = int.Parse (Scenes.getParameter ("numberOfPlayers"));

		NumberOfPlayersPreparation ();
		print ("Number of players: " + numberOfPlayers);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void NumberOfPlayersPreparation() {
		if (numberOfPlayers < 4) {
			player4.SetActive (false);
		}
		if (numberOfPlayers < 3) {
			player3.SetActive (false);
		}
	}
}
