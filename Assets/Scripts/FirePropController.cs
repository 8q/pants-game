using UnityEngine;
using System.Collections;

public class FirePropController : MonoBehaviour {

	private GameSystemScript gameSystemScript;

	// Use this for initialization
	void Start () {
		gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0f,0f,1f));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			gameSystemScript.DecreaseZanki ();
		}
	}
}
