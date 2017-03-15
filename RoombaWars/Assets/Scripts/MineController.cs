using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour {
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy() {
		GameObject obj = Instantiate (explosion);
		obj.transform.position = new Vector3 (this.transform.position.x, 0, this.transform.position.z);
		Destroy (obj, 1);
	}
}
