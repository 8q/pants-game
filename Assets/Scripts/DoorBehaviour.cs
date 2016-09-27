using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	public Sprite closeSprite;

	public Sprite openSprite;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = closeSprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			GetComponent<SpriteRenderer> ().sprite = openSprite;
		}
	}
}
