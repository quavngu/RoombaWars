using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	int intensity;
	float height;

	// Use this for initialization
	void Start () {
		height = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Shake (float roughness) {
		intensity = (int)roughness;
		StartCoroutine (MoveCam (intensity));
		this.transform.position = new Vector3 (Random.Range (0, intensity), height, Random.Range (0, intensity));
	}

	private IEnumerator MoveCam(int intensity) {
		if (intensity > 0) {
			this.transform.position = new Vector3 (Random.Range (0, intensity), height, Random.Range (0, intensity));
			yield return new WaitForSeconds(0.5f);
			StartCoroutine(MoveCam(intensity));
			intensity--;
		}
	}
}
