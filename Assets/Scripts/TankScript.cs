using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour {

	public Vector2 speed = new Vector2(50,50);
	float speed2  = 2.0f;

	public string direction2 = "R";
	public Vector2 direction = new Vector2(-1, 0);

	public Sprite tank_L, tank_R, tank_U, tank_D;


	// Use this for initialization
//	void Start () {
//		direction = "R";
//	}
	
	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");


		string temp;
		Vector3 movement;

		if (Input.GetKey(KeyCode.RightArrow)) {
			temp = "R";
			direction = transform.right;
			transform.position +=  Vector3.right * speed2 * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			temp = "L";
			direction = -1 * transform.right;
			transform.position +=  Vector3.left * speed2 * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			temp = "U";
			direction = transform.up;
			transform.position +=  Vector3.up * speed2 * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			temp = "D";
			direction = -1 * transform.up;
			transform.position +=  Vector3.down * speed2 * Time.deltaTime;
		} else {
			temp = direction2;
		}

		if (temp != direction2) {
			onDirectionChange (temp);
		}

			
		// Shooting
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");

		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript> ();
			if (weapon != null) {
				weapon.direction = direction;
				weapon.Attack (false );
			}
		}

	}

	public void onDirectionChange(string dir) {
		direction2 = dir;
		if (dir == "L") {
			gameObject.GetComponent<SpriteRenderer> ().sprite = tank_L;
		} else if (dir == "R") {
			gameObject.GetComponent<SpriteRenderer> ().sprite = tank_R;
		} else if (dir == "U") {
			gameObject.GetComponent<SpriteRenderer> ().sprite = tank_U;
		} else if (dir == "D") {
			gameObject.GetComponent<SpriteRenderer> ().sprite = tank_D;
		}
	}
		
	

}
