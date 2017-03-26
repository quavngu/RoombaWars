using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllsController : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public KeyCode[] GetControlls(int player) {
		KeyCode[] controlls = new KeyCode[3];
		if (player == 1) {
			controlls [0] = KeyCode.A;
			controlls [1] = KeyCode.W;
			controlls [2] = KeyCode.D;
		}
		if (player == 2) {
			controlls [0] = KeyCode.LeftArrow;
			controlls [1] = KeyCode.UpArrow;
			controlls [2] = KeyCode.RightArrow;
		}
		return controlls;
	}
}
