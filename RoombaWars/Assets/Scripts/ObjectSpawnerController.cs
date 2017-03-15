using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerController : MonoBehaviour {
	public GameObject fire;
	public float coolDown;
	public float fireLifeTime;
	public int yPos;

	private RoombaMovement parent;

	bool isOnCoolDown = false;

	// Use this for initialization
	void Start () {
		parent = GetComponentInParent<RoombaMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isOnCoolDown && parent.rotation == 0) {
			isOnCoolDown = true;
			StartCoroutine (StartFire ());
		}
	}

	private IEnumerator StartFire () {
		print ("Make fire");
		GameObject obj = Instantiate (fire);
		obj.transform.position = new Vector3 (this.transform.position.x, yPos, this.transform.position.z);
		Destroy (obj, fireLifeTime);
		yield return new WaitForSeconds (coolDown);
		isOnCoolDown = false;
	}
}
