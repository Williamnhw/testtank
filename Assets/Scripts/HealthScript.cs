﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

	public int hp = 2;

	public bool isBrick = true;

	void OnTriggerEnter2D(Collider2D otherCollider) {

		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> (); 

		if (shot != null) {
			if (shot.isBrickShot != isBrick) {
				hp -= shot.damage;

				Destroy (shot.gameObject);

				if (hp <= 0) {
					Destroy (gameObject);
				}
			}
		}

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
