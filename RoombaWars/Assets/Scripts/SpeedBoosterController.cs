﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoosterController : MonoBehaviour {
	private RoombaMovement rm;
	bool isActive = false;
	bool isOnCoolDown = false;
	public float speedBoost;
	public float duration;
	public float coolDown;

	// Use this for initialization
	void Start () {
		rm = GetComponentInParent<RoombaMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActive && !isOnCoolDown) {
			isActive = true;
			StartCoroutine (BoostSpeed ());
		}
		if (!isActive && isOnCoolDown) {
			isActive = true;
			StartCoroutine (CoolDown ());
		}
	}

	private IEnumerator BoostSpeed() {
		print ("Boosting speed");
		rm.standardSpeed += speedBoost;
		yield return new WaitForSeconds (duration);
		rm.standardSpeed -= speedBoost;
		isOnCoolDown = true;
		isActive = false;
	}

	private IEnumerator CoolDown() {
		print ("Cooling Down");
		yield return new WaitForSeconds (coolDown);
		isOnCoolDown = false;
		isActive = false;
	}
}