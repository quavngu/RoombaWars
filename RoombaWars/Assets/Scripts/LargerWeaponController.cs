using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargerWeaponController : MonoBehaviour {
	GameObject weapon;
	public float sizeBoost;

	// Use this for initialization
	void Start () {
		weapon = transform.parent.FindChild ("Weapon").gameObject;
		weapon.transform.localScale += new Vector3 (sizeBoost, sizeBoost, sizeBoost);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnDestroy () {
		weapon.transform.localScale -= new Vector3 (sizeBoost, sizeBoost, sizeBoost);
	}
}
