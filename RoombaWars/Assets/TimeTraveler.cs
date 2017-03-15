using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTraveler : MonoBehaviour {
	[Range(0,10)]
	public float scale = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = scale;
	}
}
