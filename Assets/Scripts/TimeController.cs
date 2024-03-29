﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeController: MonoBehaviour {

	private Text timeText;

	public int remainTime;

	public float waitingTime;

	private GameSystemScript gameSystemScript;

	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text> ();
		gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
		StartCoroutine(this.TimerMethod(waitingTime, 
			() => {},
			() => {
				remainTime--;
				timeText.text = remainTime.ToString ();
			},
			() => remainTime == 0,
			() => {
				gameSystemScript.IsGameOver = true;
				gameSystemScript.MoveNextPhase();
			}
		));
	}
}
