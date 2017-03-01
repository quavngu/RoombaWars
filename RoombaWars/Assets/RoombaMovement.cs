using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaMovement : MonoBehaviour {
	Rigidbody rb;
	int rotation;
	float speed;
	bool isBacking;
	public float standardSpeed;

	// Use this for initialization
	void Start () {
		rotation = 0;
		isBacking = false;
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (!isBacking) {
			if (rotation != 0) {
				speed = 0f;
				if (rotation > 0) {
					rb.transform.Rotate (0f, 50f * standardSpeed * Time.deltaTime, 0f);
					rotation -= 1;
				} else if (rotation < 0) {
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
		StartCoroutine (back ());
		if (collision.collider.tag != "Ground") {
			if (rotation == 0) {
				rotation = Random.Range (-100, 100);
			}
		}
	}

	IEnumerator back() {
		isBacking = true;
		speed = -1f;
		yield return new WaitForSeconds (0.1f);
		isBacking = false;
		speed = standardSpeed;
	}
}
