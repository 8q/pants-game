using UnityEngine;
using System.Collections;

public class PantsComomScript : MonoBehaviour {

	public int pantsIndex;

	public Sprite[] sprites;

	private GameSystemScript gameSystemScript;

	// Use this for initialization
	void Start () {
		gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
		switch (ConstantValues.ROUTE) {
		case ConstantValues.RouteName.Airi:
			GetComponent<SpriteRenderer> ().sprite = sprites [0];
			break;
		case ConstantValues.RouteName.Mion:
			GetComponent<SpriteRenderer> ().sprite = sprites [1];
			break;
		case ConstantValues.RouteName.Umino:
			GetComponent<SpriteRenderer> ().sprite = sprites [2];
			break;
		default:
			GetComponent<SpriteRenderer> ().sprite = null;
			break;
		}

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy(gameObject);
			SEPlayer.Play(SEPlayer.SE.Pants);
			gameSystemScript.AddPantsCount (pantsIndex);
		}
	}
}
