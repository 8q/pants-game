using UnityEngine;
using System.Collections;

public class HasamiBehaviour : MonoBehaviour {

	private GameSystemScript gameSystemScript;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
		playerController = (PlayerController)(GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerController"));
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && playerController.IsInvincible == false) {
			playerController.IsInvincible = true;
			GetComponent<AudioSource> ().Play ();
			Destroy (GetComponent<CircleCollider2D> ());
			GetComponent<SpriteRenderer> ().enabled = false;
			gameSystemScript.DecreaseZanki ();
		}
	}
}
