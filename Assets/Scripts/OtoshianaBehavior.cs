using UnityEngine;
using System.Collections;

public class OtoshianaBehavior : MonoBehaviour {

	private GameSystemScript gameSystemScript;

	// Use this for initialization
	void Start () {
		gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			gameSystemScript.IsGameOver = true;
			gameSystemScript.MoveNextPhase ();
		}
	}
}
