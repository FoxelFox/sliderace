using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	Transform flor;

	// Use this for initialization
	void Start () {
		flor = transform.Find("Floor").Find("floor");

		for(int i = 1; i < 5; ++i) {
			var f = Instantiate(flor);
			f.SetParent(flor.parent);
			f.transform.position = transform.position;
			f.transform.Translate(0, -i*32f, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
