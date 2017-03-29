using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilController : MonoBehaviour {
	public float slipperyness;
	public GameObject fire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.CompareTag ("Roomba")) {
			float rotateDeg = Random.Range (-slipperyness, slipperyness);
			other.GetComponentInChildren<Canvas> ().gameObject.transform.Rotate (0f, 0f, 50f * rotateDeg * Time.deltaTime);
			other.gameObject.transform.Rotate (0f, 50f * rotateDeg * Time.deltaTime, 0f);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Fire") || other.gameObject.CompareTag ("Explosion")) {
			StartCoroutine (Ignite ());
		}
	}

	IEnumerator Ignite() {
		yield return new WaitForSeconds (0f);
		GameObject obj = Instantiate (fire);
		obj.transform.position = new Vector3 (this.transform.position.x, 0, this.transform.position.z);
		Destroy (obj, 1);
		Destroy (this.gameObject);
	}
}