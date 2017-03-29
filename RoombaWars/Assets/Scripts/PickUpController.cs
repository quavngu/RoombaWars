using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickUpController : MonoBehaviour {
	public GameObject powerUp = null;
	public Vector3 oldScale = new Vector3(0,0,0);

	private PlayerMovement parent;
	private AudioSource parentAudioSource;

	// Use this for initialization
	void Start () {
		parent = gameObject.GetComponentInParent<PlayerMovement> ();
		parentAudioSource = gameObject.GetComponentInParent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("PowerUp") && other.gameObject.transform.parent == null) {
			Destroy (powerUp);
			GameObject obj = Instantiate (other.gameObject);
			oldScale = obj.transform.localScale;
			powerUp = obj;
			obj.gameObject.transform.parent = transform;
			obj.transform.position = transform.position;
			obj.transform.localPosition = new Vector3 (0.5f, 1f, 0f);
			parentAudioSource.Play ();
			Destroy (other.gameObject);
		}
	}
}
