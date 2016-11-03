using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private GameObject player;
	private float worldWidth;

	public GameObject door; //ドアより向こう側には移動できないようにするため

	public bool isReverse;

	private Vector3 ScreenTopLeft {
		get { 
			if (isReverse == false)
				return GetComponent<Camera> ().ScreenToWorldPoint (Vector3.zero);
			else 
				return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
		}
	}

	private Vector3 ScreenBottomRight {
		get { 
			if (isReverse == false)
				return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
			else 
				return GetComponent<Camera> ().ScreenToWorldPoint (Vector3.zero);
		}
	}

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		worldWidth = Mathf.Abs(ScreenTopLeft.x - ScreenBottomRight.x);
	}

	void LateUpdate () {
		Vector3 topLeft = ScreenTopLeft;
		//後ろに戻れないようにする
		if (player.transform.position.x < topLeft.x) {
			Vector3 newPosition = player.transform.position;
			newPosition.x = topLeft.x;
			player.transform.position = newPosition;
		}
		//ドアより向こう側には行けないようにする
		if (door.transform.position.x < player.transform.position.x) {
			Vector3 newPosition = player.transform.position;
			newPosition.x = door.transform.position.x;
			player.transform.position = newPosition;
		}
		//中央過ぎると画面追従
		if (Mathf.Abs(player.transform.position.x - topLeft.x) > worldWidth / 2) {
			Vector3 newPosition = transform.position;
			newPosition.x = player.transform.position.x;
			transform.position = newPosition;
		}
	}
}
