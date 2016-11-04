using UnityEngine;
using System.Collections;

public class OtoshianaBehavior : MonoBehaviour {

	private GameSystemScript gameSystemScript;
	private GameObject player;

	// Use this for initialization
	void Start () {
		gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy (player.GetComponent<EdgeCollider2D> ());
			Destroy (player.GetComponent<CircleCollider2D> ());
			Destroy (player.GetComponent<CircleCollider2D> ());
			Destroy (player.GetComponent<BoxCollider2D> ());
			gameSystemScript.IsGameOver = true;
			gameSystemScript.MoveNextPhase ();
			SEPlayer.Play (SEPlayer.SE.Otoshiana);
		}
	}
}
