using UnityEngine;
using System.Collections;

public class BackgroundContorller : MonoBehaviour {
	
	private GameObject camera;
	private Vector3 preCameraPosition;
	public float scrollSize = 0.1f; 

	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		preCameraPosition = camera.transform.position;
	}

	//背景スクロール
	// Update is called once per frame
	void Update () {
		if (preCameraPosition.x != camera.transform.position.x) {
			transform.Translate (-scrollSize, 0, 0);
		}
		preCameraPosition = camera.transform.position;
	}
}
