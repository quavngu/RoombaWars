using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoombaMovement : MonoBehaviour {
	private float stabDamage;
	private float swingRightDamage;
	private float swingLeftDamage;
	public float standardSpeed;
	public float fullHealth;

	Rigidbody rb;
	Canvas canvas;
	Slider slider;

	float health;
	int rotation;
	float speed;
	bool isBacking;

	// Use this for initialization
	void Start () {
		health = fullHealth;
		rotation = 0;
		isBacking = false;
		rb = GetComponent<Rigidbody> ();
		canvas = GetComponentInChildren<Canvas> ();
		slider = GetComponentInChildren<Slider> ();
		var weapon = GetComponentInChildren<WeaponController> ();
		stabDamage = weapon.stabDamage;
		swingLeftDamage = weapon.swingLeftDamage;
		swingRightDamage = weapon.swingRightDamage;
		standardSpeed -= weapon.weight;
		TakeDamage (0f);
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
		if (other.gameObject.CompareTag ("Roomba")) {
			//He is rotating
			if (rotation != 0 && !isBacking) {
				if (rotation > 0) {
					other.gameObject.GetComponent<RoombaMovement> ().TakeDamage (this.swingRightDamage);
				} else {
					other.gameObject.GetComponent<RoombaMovement> ().TakeDamage (this.swingLeftDamage);
				}
			}
			//He is not rotating
			else {
				other.gameObject.GetComponent<RoombaMovement> ().TakeDamage (this.stabDamage);
			}
		}
		MakeRotate ();
	}

	void MakeRotate() {
		StartCoroutine(Back());
		rotation = Random.Range (-100, 100);
	}

	void TakeDamage(float damage) {
		health -= damage;
		slider.value = health;
		if (health <= 0) {
			GetDestroyed ();
		}
	}

	void GetDestroyed () {
		Destroy (this.gameObject);
	}
}
