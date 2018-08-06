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
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		speed = 50 * Time.deltaTime;
		bounce = 700 * Time.deltaTime; 
		bounceVector = Vector3.zero;
		rb.drag = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void FixedUpdate() {
		move_horizontal = Input.GetAxis("Horizontal") * speed; 
		move_vertical = Input.GetAxis("Vertical") * speed;
		//movement = new Vector3(move_vertical + transform.position.x, transform.position.y, move_horizontal + transform.position.z);
		// if(move_horizontal != 0 || move_vertical != 0) {
		//  	transform.position = movement; 
		// 	transform.Rotate(new Vector3(0, move_horizontal, 0));
		// }
		movement = new Vector3(move_vertical, 0.0f, move_horizontal);

		rb.AddForce(movement, ForceMode.VelocityChange);

		//Limit velocity

		float velocityUp = rb.velocity.y;
		movement = Vector3.ClampMagnitude(rb.velocity, 5f);
		movement.y = velocityUp;
		rb.velocity = movement;
	}

	//Detect the ground
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.name == "Plane") {
			Bounce();
		} 
	}

	void Bounce() {
		//Default bounce
		bounceVector = (Vector3.up) * bounce;
		rb.AddForce(bounceVector, ForceMode.Impulse);
	}
}
