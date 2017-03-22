using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {
	public GameObject powerUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		print (other.gameObject.tag);
		if (other.gameObject.CompareTag ("PowerUp")) {
			powerUp = other.gameObject.GetComponent<PowerUpController> ().powerUp;
			Destroy (other.gameObject);
		}
	}
}
