using UnityEngine;
using System.Collections;

public class BackgroundContorller : MonoBehaviour {
	
	private GameObject mcamera;
	private Vector3 preCameraPosition;
	public float scrollSize;

	public double scrollBorder = 0.01; //これ以上変化したとき背景をスクロールさせる

	// Use this for initialization
	void Start () {
		mcamera = GameObject.FindGameObjectWithTag("MainCamera");
		preCameraPosition = mcamera.transform.position;
	}

	//背景スクロール
	// Update is called once per frame
	void Update () {
		if (mcamera.transform.position.x - preCameraPosition.x > scrollBorder) {
			transform.Translate (-scrollSize, 0, 0);
		}
		preCameraPosition = mcamera.transform.position;
	}
}
