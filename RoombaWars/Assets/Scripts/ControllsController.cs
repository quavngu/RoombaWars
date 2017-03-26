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
		if (player == 3) {
			controlls [0] = KeyCode.J;
			controlls [1] = KeyCode.I;
			controlls [2] = KeyCode.L;
		}
		if (player == 4) {
			controlls [0] = KeyCode.Keypad1;
			controlls [1] = KeyCode.Keypad5;
			controlls [2] = KeyCode.Keypad3;
		}
		return controlls;
	}
}
