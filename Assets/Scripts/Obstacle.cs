using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public Transform[] obstacles;
	

	private void createWalls(Transform wall, int i) {

		Random.seed = (int)(Random.value * 10000);
		float r = (Random.value - 0.5f);
		for(int j = 0; j < 2; ++j) {
			var o = Instantiate(wall);
			//o.SetParent(transform);
			//o.transform.position = transform.position;
			o.transform.position = new Vector3(0,0,0);
			o.transform.Translate(r * 16 + (j - 0.5f) * 16,-i*16,0);
		}

	}

	private void createRamps(Transform ramp, int i) {
		Random.seed = (int)(Random.value * 10000);
		float r = (Random.value - 0.5f);

		var o = Instantiate(ramp);
		//o.SetParent(transform);
		//o.transform.position = transform.position;
		o.transform.position = new Vector3(0,0,0);
		o.transform.Translate(r * 32,-i*64,0);
	}

	private void createWallCluster(Transform cluster, int i) {
		var o = Instantiate(cluster);
		//o.SetParent(transform);

	}

	private void createObstacle(Transform obs, int i) {
		var o = Instantiate(obs);
		o.transform.position = new Vector3(0,0,0);
		o.transform.Translate(0,0,i*64);
	}

	// Use this for initialization
	void Start () {

		Random.seed = 1337;
		for(int i = 0; i < 200; ++i) {

			var obs = obstacles[(int)(Random.value * obstacles.Length - 0.5)];

			switch(obs.name) {
			case "wall1": createWalls(obs,i); break;
			case "ramp": createRamps(obs,i); break;
			case "wall_cluster": createWallCluster(obs,i); break;
			default: createObstacle(obs, i); break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
