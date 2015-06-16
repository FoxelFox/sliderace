using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	Transform[] obstacles;
	

	// Use this for initialization
	void Start () {

		// get all obstacle childs
		obstacles = new Transform[transform.childCount];
		for( int i = 0; i < transform.childCount; ++i) {
			obstacles[i] = transform.GetChild(i);
		}

		foreach(Transform obs in obstacles) {
			for(int i = 0; i < 50; ++i) {
				float r = (Random.value - 0.5f);
				for(int j = 0; j < 2; ++j) {
					var o = Instantiate(obs);
					o.SetParent(transform);
					o.transform.position = transform.position;
					o.transform.Translate(r * 16 + (j - 0.5f) * 12,-i*64,0);
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
