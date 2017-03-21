using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {
	public List<GameObject> spawnObj;

	float objLifeTime;
	float coolDown;

	bool isOnCoolDown = false;

	// Use this for initialization
	void Start () {
		coolDown = 3f;
	}

	// Update is called once per frame
	void Update () {
		if (!isOnCoolDown) {
			isOnCoolDown = true;
			StartCoroutine (SpawnObj ());
		}
	}

	private IEnumerator SpawnObj () {
		objLifeTime = Random.Range (2, 10);
		coolDown = Random.Range (2, 7);
		GameObject obj = Instantiate (spawnObj[Random.Range(0, spawnObj.Capacity)]);
		obj.transform.position = gameObject.transform.position;
		Destroy (obj, objLifeTime);
		yield return new WaitForSeconds (coolDown);
		isOnCoolDown = false;
	}
}
