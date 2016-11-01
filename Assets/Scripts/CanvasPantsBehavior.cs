using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//ルート分岐したときのためにキャンバスのパンツの柄を変えるためスクリプト

public class CanvasPantsBehavior : MonoBehaviour {

	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		switch (ConstantValues.ROUTE) {
		case ConstantValues.RouteName.Airi:
			GetComponent<Image> ().sprite = sprites [0];
			break;
		case ConstantValues.RouteName.Mion:
			GetComponent<Image> ().sprite = sprites [1];
			break;
		case ConstantValues.RouteName.Umino:
			GetComponent<Image> ().sprite = sprites [2];
			break;
		default:
			GetComponent<Image> ().sprite = null;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
