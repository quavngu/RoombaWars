using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickUpController : MonoBehaviour {
	public GameObject powerUp;

	private PlayerMovement parent;
	private Text powerUpText;

	// Use this for initialization
	void Start () {
		parent = gameObject.GetComponentInParent<PlayerMovement> ();
		if (parent.playerNum == 1) {
			GameObject temp = GameObject.Find ("Player1PowerUp");
			powerUpText = temp.GetComponent<Text> ();
			powerUpText.text = "Player 1 power: ";
		}else if (parent.playerNum == 2) {
			GameObject temp = GameObject.Find ("Player2PowerUp");
			powerUpText = temp.GetComponent<Text> ();
			powerUpText.text = "Player 2 power: ";
		}else if (parent.playerNum == 3) {
			GameObject temp = GameObject.Find ("Player3PowerUp");
			powerUpText = temp.GetComponent<Text> ();
			powerUpText.text = "Player 3 power: ";
		}else if (parent.playerNum == 4) {
			GameObject temp = GameObject.Find ("Player4PowerUp");
			powerUpText = temp.GetComponent<Text> ();
			powerUpText.text = "Player 4 power: ";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		print (other.gameObject.tag);
		if (other.gameObject.CompareTag ("PowerUp")) {
			powerUp = other.gameObject.GetComponent<PowerUpController> ().powerUp;
			powerUpText.text = other.name.Substring (0, other.name.Length - 7);
			Destroy (other.gameObject);
		}
	}
}
