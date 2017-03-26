using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {
	public List<GameObject> spawnObj;
	public List<GameObject> weapons;

	public float objLifeTime;
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
		coolDown = Random.Range (2, 7);
		GameObject obj = Instantiate (spawnObj[Random.Range(0, spawnObj.Capacity)]);
		obj.transform.position = gameObject.transform.position;
		Destroy (obj, objLifeTime);
		StartCoroutine (SpawnWeapon ());
		yield return new WaitForSeconds (coolDown);
		isOnCoolDown = false;
	}

	private IEnumerator SpawnWeapon () {
		yield return new WaitForSeconds (1f);
		GameObject obj = Instantiate (weapons[Random.Range(0, weapons.Capacity)]);
		obj.transform.position = gameObject.transform.position;
		Destroy (obj, objLifeTime);
	}
}
