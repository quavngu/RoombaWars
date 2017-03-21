using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private KeyCode[] controlls;
	public int playerNum;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		controlls = GameObject.FindGameObjectWithTag ("ControllProvider").gameObject.GetComponent<ControllsController> ().GetControlls (playerNum);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(controlls[0])) {
			//Move right
			this.transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
		}
		if (Input.GetKey (controlls[2])) {
			this.transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
		}
			if (Input.GetKeyDown (controlls[1])) {
			print ("Shoot");
		}
	}
}
