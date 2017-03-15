using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerController : MonoBehaviour {
	public GameObject spawnObj;
	public float coolDown;
	public float objLifeTime;
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
			StartCoroutine (SpawnObj ());
		}
	}

	private IEnumerator SpawnObj () {
		GameObject obj = Instantiate (spawnObj);
		obj.transform.position = new Vector3 (this.transform.position.x, yPos, this.transform.position.z);
		Destroy (obj, objLifeTime);
		yield return new WaitForSeconds (coolDown);
		isOnCoolDown = false;
	}
}
