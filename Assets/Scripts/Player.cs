using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float force;
	public Transform cam;

	bool isOnGround;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision coll) {
		isOnGround = true;
	}

	void OnCollisionExit(Collision coll) {
		isOnGround = false;
	}


	void FixedUpdate() {
		force += 0.01f;
		rb.maxAngularVelocity = force;
		rb.AddTorque(+force,0,0,ForceMode.Force);

		foreach (Touch touch in Input.touches) {
			switch (touch.phase) {
			case TouchPhase.Moved: 
			case TouchPhase.Began:
			case TouchPhase.Stationary:
				if(touch.position.x / Screen.currentResolution.width < 0.5f) {
					rb.AddTorque(0,0,+force,ForceMode.Force);
				} else {
					rb.AddTorque(0,0,-force,ForceMode.Force);
				}
				break;
			}

		}
		
		if(Input.GetKey(KeyCode.A)) {
			rb.AddTorque(0,0,+force,ForceMode.Force);
		}
		if(Input.GetKey(KeyCode.D)) {
			rb.AddTorque(0,0,-force,ForceMode.Force);
		}


		if(isOnGround && Input.GetKey(KeyCode.Space)) {
			rb.AddForce( 0,4,0, ForceMode.Impulse);
		}

		

	}
}
