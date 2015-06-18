using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {

	public Transform[] obstacles;
	public Transform player;

	private int lvl = 0;
	private Queue<Transform> obstacleQueue = new Queue<Transform>();

	private void createWalls(Transform wall) {

		Random.seed = (int)(Random.value * 10000);
		float r = (Random.value - 0.5f);
		for(int j = 0; j < 2; ++j) {
			var o = Instantiate(wall);
			//o.SetParent(transform);
			//o.transform.position = transform.position;
			o.transform.position = new Vector3(0,0,0);
			o.transform.Translate(r * 16 + (j - 0.5f) * 16,-16,0);
			obstacleQueue.Enqueue(o);
		}

	}

	private void createRamps(Transform ramp) {
		Random.seed = (int)(Random.value * 10000);
		float r = (Random.value - 0.5f);

		var o = Instantiate(ramp);
		//o.SetParent(transform);
		//o.transform.position = transform.position;
		o.transform.position = new Vector3(0,0,0);
		o.transform.Translate(r * 32,-64,0);
		obstacleQueue.Enqueue(o);
	}

	private void createWallCluster(Transform cluster) {
		var o = Instantiate(cluster);
		obstacleQueue.Enqueue(o);
		//o.SetParent(transform);

	}

	private void createObstacle(Transform obs) {
		var o = Instantiate(obs);
		o.transform.position = new Vector3(0,0,0);
		o.transform.Translate(0,0,64);
		obstacleQueue.Enqueue(o);
	}

	private void generateObstacles() {
		var obs = obstacles[(int)(Random.value * obstacles.Length - 0.5)];
		
		switch(obs.name) {
		case "wall1": createWalls(obs); break;
		case "ramp": createRamps(obs); break;
		case "wall_cluster": createWallCluster(obs); break;
		default: createObstacle(obs); break;
		}
	}

	private void moveObstacles() {
		var offset = new Vector3(0,0, 64);
		foreach ( Transform obs in obstacleQueue) {
			obs.position -= offset;
		}
	}

	// Use this for initialization
	void Start () {
		Random.seed = 1337;
		generateObstacles();
		moveObstacles();
		generateObstacles();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		if(player.position.z > 64) {
			var offset = new Vector3(0,0, 64);
			++lvl;
			SR.Score = lvl;
			// move player
			player.position -= offset;

			// remove obstacle from last lvl
			Destroy(obstacleQueue.Dequeue().gameObject);



			// move obstacles
			moveObstacles();

			// generate new obstacles
			generateObstacles();

		}
	}
}
