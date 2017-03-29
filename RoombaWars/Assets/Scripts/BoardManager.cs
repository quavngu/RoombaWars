using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For this to work you have to turn off timetraveler
public class BoardManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		StartCoroutine (Intro ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Intro() {
		// Show ready to roomble
		yield return new WaitForSecondsRealtime(2f);
		GameObject.FindGameObjectWithTag("StartText").SetActive(false);
		Time.timeScale = 1;
	}
}
