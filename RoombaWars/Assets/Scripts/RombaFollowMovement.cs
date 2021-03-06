﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RombaFollowMovement : MonoBehaviour {
	private float stabDamage;
	private float swingRightDamage  = 0;
	private float swingLeftDamage = 0;
	public float originalSpeed = 0;
	public float fullHealth;
	public float rotation;
	private GameObject owner;

	Rigidbody rb;
	Canvas canvas;
	Slider slider;
	CameraController cam;

	float health;
	float speed;
	public float standardSpeed = 0;
	bool isBacking;

	// Use this for initialization
	void Start () {
		standardSpeed = originalSpeed;
		health = fullHealth;
		rotation = 0;
		isBacking = false;
		rb = GetComponent<Rigidbody> ();
		canvas = GetComponentInChildren<Canvas> ();
		slider = GetComponentInChildren<Slider> ();
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ();
		slider.value = health;
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().AddRoomba (this.gameObject);
		owner = transform.parent.GetComponentInChildren<PlayerMovement> ().gameObject.GetComponentInChildren<PickUpController>().gameObject;
	}

	// Update is called once per frame
	void Update () {
		canvas.gameObject.transform.position = rb.transform.position;
		if (!isBacking) {
			if (rotation != 0) {
				speed = 0f;
				float toRotate = standardSpeed * Time.deltaTime * 50;
				if (Mathf.Abs(toRotate) < Mathf.Abs(rotation)) {
					print ("here");
					toRotate = rotation;
				}
				RotateRoomba (toRotate);
				return;
			} else {
				speed = standardSpeed;
			}

		}
		if (rotation == 0 || isBacking) {
			rb.transform.position += rb.transform.forward * speed * Time.deltaTime;
		}
	}

	void RotateRoomba(float deg) {
		canvas.gameObject.transform.Rotate (0f, 0f, deg);
		rb.transform.Rotate (0f, deg, 0f);
		rotation -= deg;
	}

	void OnCollisionEnter(Collision collision) {

		if (!collision.collider.CompareTag("Ground")) {
			MakeRotate ();
		}
	}

	IEnumerator Back() {
		isBacking = true;
		speed = -1f;
		yield return new WaitForSeconds (0.6f);
		isBacking = false;
		speed = standardSpeed;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("PowerUp")) {
			Spawn (other.gameObject);
		}
		if (other.gameObject.CompareTag ("Roomba")) {
			//He is rotating
			if (rotation != 0 && !isBacking) {
				if (rotation > 0) {
					other.gameObject.GetComponent<RoombaMovement> ().TakeDamage (this.swingRightDamage * this.standardSpeed);
				} else {
					other.gameObject.GetComponent<RoombaMovement> ().TakeDamage (this.swingLeftDamage * this.standardSpeed);
				}
			}
			//He is not rotating
			else {
				other.gameObject.GetComponent<RoombaMovement> ().TakeDamage (this.stabDamage * this.standardSpeed);
			}
		}
		if (other.gameObject.CompareTag("Mine")) {
			Destroy(other.gameObject);
		}
		else if (!other.gameObject.CompareTag("Fire") && !other.gameObject.CompareTag("Explosion") && !other.gameObject.CompareTag("Oil")) {
			MakeRotate ();
		}
	}

	void MakeRotate() {
		StartCoroutine (Back ());
		Vector3 ownerPos = new Vector3 (owner.transform.position.x, 0, owner.transform.position.z);
		Vector3 roombaPos = new Vector3 (transform.position.x, 0, transform.position.z);
		rotation = Vector3.Angle (roombaPos, ownerPos);
		print (rotation);
	}

	public void TakeDamage(float damage) {
		cam.Shake (damage);
		health -= damage;
		slider.value = health;
		if (health <= 0) {
			GetDestroyed ();
		}
	}

	void GetDestroyed () {
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().RemoveRoomba (this.gameObject);
		Destroy (this.gameObject);
	}

	public void Spawn(GameObject powerUp) {
		GameObject obj = Instantiate (powerUp.GetComponent<PowerUpController>().powerUp);
		Destroy (powerUp);
		obj.transform.position = gameObject.transform.position;
		if (obj.gameObject.CompareTag ("Weapon")) {
			if (gameObject.GetComponentsInChildren<WeaponController> () != null) {
				foreach (WeaponController oldWeapon in gameObject.GetComponentsInChildren<WeaponController> ()) {
					standardSpeed = originalSpeed;
					Destroy (oldWeapon.gameObject);
				}
			}
			obj.transform.parent = gameObject.transform;
			obj.transform.localPosition = new Vector3 (0f, 0f, 0.5f);
			stabDamage = obj.GetComponent<WeaponController> ().stabDamage;
			swingLeftDamage = obj.GetComponent<WeaponController> ().swingLeftDamage;
			swingRightDamage = obj.GetComponent<WeaponController> ().swingRightDamage;
			standardSpeed -= obj.GetComponent<WeaponController> ().weight;
			obj.transform.localRotation = Quaternion.Euler(new Vector3 (90, 0, 0));
		} else {
			obj.transform.parent = gameObject.transform;
			obj.transform.localPosition = new Vector3 (0, 0, -1.5f);
			Destroy (obj, 10);
		}
	}
}