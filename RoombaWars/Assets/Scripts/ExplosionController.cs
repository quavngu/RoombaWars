using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {
	public float damage;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Roomba")) {
			other.gameObject.GetComponent<RoombaMovement> ().TakeDamage (damage); 
		}
	}
}
