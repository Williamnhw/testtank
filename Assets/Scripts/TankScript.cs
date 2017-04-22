using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour {
	
	public Sprite tank_L, tank_R, tank_U, tank_D;

	float speed  = 2.0f;

	public Vector2 direction = new Vector2(-1, 0);


	// Use this for initialization
	void Start () {
		onDirectionChange (direction);	
	}
	
	// Update is called once per frame
	void Update () {


		Vector2 temp;

		if (Input.GetKey(KeyCode.RightArrow)) {
			temp = transform.right;
			transform.position +=  Vector3.right * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			temp = -1 * transform.right;
			transform.position +=  Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			temp = transform.up;
			transform.position +=  Vector3.up * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			temp = -1 * transform.up;
			transform.position +=  Vector3.down * speed * Time.deltaTime;
		} else {
			temp = direction;
		}

		if (temp != direction) {
			onDirectionChange (temp);
		}

			
		// Shooting
//		bool shoot = Input.GetButtonDown ("Fire1");
		bool shoot = Input.GetButtonDown ("Fire2");

		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript> ();
			if (weapon != null) {
				weapon.direction = direction;
				weapon.Attack (false );
			}
		}
	}

	public void onDirectionChange(Vector2 dir) {
		direction = dir;
		if (direction == new Vector2(-1,0)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = tank_L;
		} else if (direction == new Vector2(1,0)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = tank_R;
		} else if (direction == new Vector2(0,1)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = tank_U;
		} else if (direction == new Vector2(0,-1)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = tank_D;
		}
	}
		



}
