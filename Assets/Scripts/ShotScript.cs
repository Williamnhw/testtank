using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

	public int damage = 1;

	public bool isBrickShot = false;

	
	// Update is called once per frame
	void Update () {

		Destroy (gameObject, 7);

	}
}
