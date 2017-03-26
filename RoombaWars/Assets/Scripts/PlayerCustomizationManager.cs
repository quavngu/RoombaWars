using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomizationManager : MonoBehaviour {
	private int numberOfPlayers;
	private int numberOfReadies;
	public GameObject menu1;
	public GameObject menu2;
	public GameObject menu3;
	public GameObject menu4;

	// Use this for initialization
	void Start () {
		if (Scenes.getParameter ("numberOfPlayers") != "") {
			numberOfPlayers = int.Parse (Scenes.getParameter ("numberOfPlayers"));
		}
		NumberOfMenuPreparation ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnReadyButtonClick() {
		print ("hi");
	}

	private void NumberOfMenuPreparation() {
		if (numberOfPlayers < 4) {
			menu4.SetActive (false);
		}
		if (numberOfPlayers < 3) {
			menu3.SetActive (false);
		}
	}
}
