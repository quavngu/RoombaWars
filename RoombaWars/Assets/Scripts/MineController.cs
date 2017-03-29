using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour {
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		StartCoroutine (Explode (10f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public IEnumerator Explode (float lifetime) {
		yield return new WaitForSeconds (lifetime);
		GameObject obj = Instantiate (explosion);
		obj.transform.position = new Vector3 (this.transform.position.x, 0, this.transform.position.z);
		Destroy (obj, 1);
	}

	public void ExplodeNow () {
		GameObject obj = Instantiate (explosion);
		obj.transform.position = new Vector3 (this.transform.position.x, 0, this.transform.position.z);
		Destroy (obj, 1);
		Destroy (this.gameObject);
	}
}
