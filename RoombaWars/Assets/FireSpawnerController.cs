using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawnerController : MonoBehaviour {
	public GameObject fire;
	public float coolDown;
	public float fireLifeTime;

	bool isOnCoolDown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isOnCoolDown) {
			isOnCoolDown = true;
			StartCoroutine (StartFire ());
		}
	}

	private IEnumerator StartFire () {
		print ("Make fire");
		GameObject obj = Instantiate (fire);
		obj.transform.position = new Vector3 (this.transform.position.x, 0, this.transform.position.z); 
		Destroy (obj, fireLifeTime);
		yield return new WaitForSeconds (coolDown);
		isOnCoolDown = false;
	}
}
