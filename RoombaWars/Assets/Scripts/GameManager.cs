using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	private int numberOfPlayers;
	public GameObject player3;
	public GameObject player4;

	private List<GameObject> roombas;
	private GameObject[] endObjects;

	// Use this for initialization
	void Start () {
		endObjects = GameObject.FindGameObjectsWithTag ("EndScreen");
		foreach (GameObject i in endObjects) {
			i.SetActive(false);
		}
		roombas = new List<GameObject>();
		if (Scenes.getParameter ("numberOfPlayers") != "") {
			numberOfPlayers = int.Parse (Scenes.getParameter ("numberOfPlayers"));
		}
		NumberOfPlayersPreparation ();
		print ("Number of players: " + numberOfPlayers);
	}

	// Update is called once per frame
	void Update () {
		if (roombas.Count == 1) {
			FinishScreen (roombas [0].name);
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			Scenes.Load ("Asgeir", "numberOfPlayers", numberOfPlayers.ToString());
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Scenes.Load ("StartMenu");
		}
	}

	private void NumberOfPlayersPreparation() {
		if (numberOfPlayers < 4) {
			player4.SetActive (false);
		}
		if (numberOfPlayers < 3) {
			player3.SetActive (false);
		}
	}

	public void AddRoomba(GameObject roomba) {
		roombas.Add (roomba);
	}

	public void RemoveRoomba(GameObject roomba) {
		roombas.Remove (roomba);
	}

	void FinishScreen (string name) {
		Time.timeScale = 0;
		foreach (GameObject i in endObjects) {
			i.SetActive(true);
		}
		GameObject.Find ("InfoText").GetComponent<Text> ().text = "Winner: " + name;
	}
}
