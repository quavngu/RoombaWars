using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargerWeaponController : MonoBehaviour {
	Transform weapon;
	public float sizeBoost;

	// Use this for initialization
	void Start () {
		weapon = transform.parent.FindChild ("Weapon");
		if (weapon != null) {
			weapon.gameObject.transform.localScale += new Vector3 (sizeBoost, sizeBoost, sizeBoost);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnDestroy () {
		if (weapon != null) {
			weapon.transform.localScale -= new Vector3 (sizeBoost, sizeBoost, sizeBoost);
		}
	}
}
