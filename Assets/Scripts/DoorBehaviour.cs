using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	public Sprite closeSprite;

	public Sprite openSprite;

	private GameSystemScript gameSystemScript;

	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = closeSprite;
		gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
		playerController = (PlayerController)(GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerController"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			GetComponent<SpriteRenderer> ().sprite = openSprite;
			playerController.enabled = false;
			StartCoroutine(this.DelayMethod(1.5f, () => {
				gameSystemScript.MoveNextPhase();
			}));
		}
	}
}
