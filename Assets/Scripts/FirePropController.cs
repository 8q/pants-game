﻿using UnityEngine;
using System.Collections;

public class FirePropController : MonoBehaviour {

	private GameSystemScript gameSystemScript;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
		playerController = (PlayerController)(GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerController"));
		StartCoroutine(this.TimerMethod(0.01f, 
			() => {},
			() => {
				transform.Rotate(new Vector3(0f,0f,1f));
			},
			() => false,
			() => {}
		));
	}
	
//	// Update is called once per frame
//	void Update () {
//		transform.Rotate(new Vector3(0f,0f,1f));
//	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && playerController.IsInvincible == false) {
			playerController.IsInvincible = true;
			SEPlayer.Play(SEPlayer.SE.Bomb);
			gameSystemScript.DecreaseZanki ();
		}
	}
}
