using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public void StartNewGame(string name) {
		Application.LoadLevel(name);
	}
}
