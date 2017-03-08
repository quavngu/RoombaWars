using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {
	public float damage;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.CompareTag("Roomba")) {
			other.gameObject.GetComponent<RoombaMovement> ().TakeDamage (damage); 
		}
	}
}
