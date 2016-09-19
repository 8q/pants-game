﻿using UnityEngine;
using System.Collections;

public class PantsBehavior : MonoBehaviour {

	public int pantsIndex;

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
			Destroy(gameObject);
			gameSystemScript.AddPantsCount (pantsIndex);
		}
	}
}
