 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	//Public variables
	public float speed = 0;

	//Private variables
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		speed = 50;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate() {
		float move_horizontal = Input.GetAxis("Horizontal");
		float move_vertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(move_horizontal, 0.0f, move_vertical);
		rb.AddForce(movement * speed);

	}
}
