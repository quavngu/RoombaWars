using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledgeHammer : MonoBehaviour {
	public static bool isQuitting = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy () {
		isQuitting = true;
	}
}
