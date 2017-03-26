using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	int intensity;
	float height;
	bool isShaking;

	// Use this for initialization
	void Start () {
		isShaking = false;
		height = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Shake (float roughness) {
		if ((int)roughness > intensity) { 
			intensity = (int)roughness;
			if (!isShaking) {
				isShaking = true;
				StartCoroutine (MoveCam ());
			}
		}
	}

	private IEnumerator MoveCam() {
		if (intensity > 0) {
			this.transform.position = new Vector3 (Random.Range (0, intensity/10f), height, Random.Range (0, intensity/10f));
			intensity--;
			yield return new WaitForSeconds (0.02f);
			StartCoroutine (MoveCam ());
		} else {
			this.transform.position = new Vector3 (0, height, 0);
			isShaking = false;
			yield return new WaitForSeconds (0f);;
		}
	}
}
