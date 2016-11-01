using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	public Sprite closeSprite;

	public Sprite openSprite;

	private GameSystemScript gameSystemScript;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = closeSprite;
		gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			GetComponent<SpriteRenderer> ().sprite = openSprite;
			StartCoroutine(this.DelayMethod(1.5f, () => {
				gameSystemScript.MoveNextPhase();
			}));
		}
	}
}
