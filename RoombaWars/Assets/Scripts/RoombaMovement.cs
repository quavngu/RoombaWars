﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoombaMovement : MonoBehaviour {
	private float stabDamage;
	private float swingRightDamage  = 0;
	private float swingLeftDamage = 0;
	public float originalSpeed = 0;
	public float fullHealth;
	public int rotation;
	public GameObject explosion;

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
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().AddRoomba (this.gameObject);
		originalSpeed = originalSpeed * transform.localScale.x;
		standardSpeed = originalSpeed;
		health = fullHealth;
		rotation = 0;
		isBacking = false;
		rb = GetComponent<Rigidbody> ();
		canvas = GetComponentInChildren<Canvas> ();
		slider = GetComponentInChildren<Slider> ();
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ();
		slider.value = health;

	}

	// Update is called once per frame
	void Update () {
		canvas.gameObject.transform.position = rb.transform.position;
		if (!isBacking) {
			if (rotation != 0) {
				speed = 0f;
				if (rotation > 0) {
					canvas.gameObject.transform.Rotate (0f, 0f, 50f * standardSpeed * Time.deltaTime);
					rb.transform.Rotate (0f, 50f * standardSpeed * Time.deltaTime, 0f);
					rotation -= 1;
				} else if (rotation < 0) {
					canvas.gameObject.transform.Rotate (0f, 0f, -50f * standardSpeed * Time.deltaTime);
					rb.transform.Rotate (0f, -50f * standardSpeed * Time.deltaTime, 0f);
					rotation += 1;
				}
				return;
			} else {
				speed = standardSpeed;
			}

		}
		if (rotation == 0 || isBacking) {
			rb.transform.position += rb.transform.forward * speed * Time.deltaTime;
		}
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
					other.gameObject.GetComponent<RoombaMovement> ().TakeDamage (this.swingRightDamage * (this.standardSpeed/10));
				} else {
					other.gameObject.GetComponent<RoombaMovement> ().TakeDamage (this.swingLeftDamage * (this.standardSpeed/10));
				}
			}
			//He is not rotating
			else {
				other.gameObject.GetComponent<RoombaMovement> ().TakeDamage (this.stabDamage * (this.standardSpeed/10));
			}
		}
		if (other.gameObject.CompareTag("Mine")) {
			other.gameObject.GetComponent<MineController> ().ExplodeNow ();
		}
		else if (!other.gameObject.CompareTag("Fire") && !other.gameObject.CompareTag("Explosion") && !other.gameObject.CompareTag("Oil") && !other.gameObject.CompareTag("PowerUp")) {
			MakeRotate ();
		}
		if (other.gameObject.CompareTag ("BackSender")) {
			rb.transform.position = new Vector3 (rb.transform.position.x * 0.9f, rb.transform.position.y * 0.9f, rb.transform.position.z * 0.9f);
		}
	}

	void MakeRotate() {
		StartCoroutine(Back());
		rotation = Random.Range (-10, 10);
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
		Die ();
	}

	public void Spawn(GameObject powerUp) {
		GameObject obj = Instantiate (powerUp.GetComponent<PowerUpController>().powerUp);
		obj.transform.localScale.Scale (new Vector3(rb.transform.localScale.x, rb.transform.localScale.x, rb.transform.localScale.x));
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

	public void Die () {
		GameObject obj = Instantiate (explosion);
		obj.transform.position = new Vector3 (this.transform.position.x, 0, this.transform.position.z);
		Destroy (obj, 1);
		Destroy (this.gameObject);
	}

}
