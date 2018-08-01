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

	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		speed = 30 * Time.deltaTime;
		bounce = 200 * Time.deltaTime; 
		bounceVector = Vector3.up * bounce;
		move_horizontal = Input.GetAxis("Horizontal"); 
		move_vertical = Input.GetAxis("Vertical");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate() {
		Vector3 movement = new Vector3(move_horizontal, 0.0f, move_vertical);
		rb.AddForce(movement * speed, ForceMode.VelocityChange);
	}

	//Detect the ground
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.name == "Plane") {
			Bounce();
			//Debug.Log("Bouncing");
		} 
	}

	void Bounce() {
		rb.AddForce(bounceVector, ForceMode.VelocityChange);
	}
}
