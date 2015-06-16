using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public Transform target;
	public float smooth;
	public float distance;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		//var t = target.position + (transform.position - target.position).normalized * distance;
		//t = new Vector3 (t.x, t.y + 0.5f, t.z);

	
		//transform.position = Vector3.Lerp (transform.position, t, Time.deltaTime * smooth);
		//transform.LookAt(target.position);
		transform.position = new Vector3(target.position.x, target.position.y +1.0f,target.position.z-5);

	}
}
