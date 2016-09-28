using UnityEngine;
using System.Collections;

public class BackgroundContorller : MonoBehaviour {
	
	private GameObject mcamera;
	private Vector3 preCameraPosition;
	public float scrollSize = 0.05f; 

	// Use this for initialization
	void Start () {
		mcamera = GameObject.FindGameObjectWithTag("MainCamera");
		preCameraPosition = mcamera.transform.position;
	}

	//背景スクロール
	// Update is called once per frame
	void Update () {
		if (preCameraPosition.x != mcamera.transform.position.x) {
			transform.Translate (-scrollSize, 0, 0);
		}
		preCameraPosition = mcamera.transform.position;
	}
}
