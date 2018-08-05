 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	//Public variables
	public float speed = 0;
	public float bounce = 0;
	//Private variables
	private Vector3 bounceVector;
	private float move_horizontal;
	private float move_vertical;
	private Vector3 movement;
	private Vector3 steering; 
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		speed = 30 * Time.deltaTime;
		bounce = 700 * Time.deltaTime; 
		bounceVector = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		move_horizontal = Input.GetAxis("Horizontal") * speed; 
		move_vertical = Input.GetAxis("Vertical") * speed;
		// movement = new Vector3(move_vertical + transform.position.x, transform.position.y, move_horizontal + transform.position.z);
		// if(move_horizontal != 0 || move_vertical != 0)
		// 	transform.position = movement; 
		if(move_horizontal != 0 || move_vertical != 0) {
			transform.Rotate(new Vector3(0, move_horizontal, 0));
		}
		
	}
	void FixedUpdate() {
	}

	//Detect the ground
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.name == "Plane") {
			Bounce();
		} 
	}

	void Bounce() {
		bounceVector = (Vector3.up) * bounce;
	}
}
