﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float force;
	public Transform cam;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.maxAngularVelocity =100;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				transform.Translate(1.0f, 0.0f, 0.0f);
			}
		}
		
		if(Input.GetKey(KeyCode.A)) {
			rb.AddTorque(0,0,+force,ForceMode.Force);
		}
		if(Input.GetKey(KeyCode.D)) {
			rb.AddTorque(0,0,-force,ForceMode.Force);
		}
		
		if(Input.GetKey(KeyCode.W)) {
			rb.AddTorque(+force,0,0,ForceMode.Force);
		}
		
		if(Input.GetKey(KeyCode.S)) {
			rb.AddTorque(-force,0,0,ForceMode.Force);
		}
	}
}