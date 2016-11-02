using UnityEngine;
using System.Collections;

//反転用
public class CameraControllerReverse : MonoBehaviour {

	private GameObject player;
	private float worldWidth;

	public GameObject door; //ドアより向こう側には移動できないようにするため

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		Vector3 topLeft = GetScreenTopLeft();
		Vector3 bottomRight = GetScreenBottomRight();
		worldWidth = Mathf.Abs(topLeft.x - bottomRight.x);
	}

	void LateUpdate () {
		Vector3 topLeft = GetScreenTopLeft();
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

	//ワールド座標
	private Vector3 GetScreenTopLeft() {
		//反転
		//画面の右下を取得
		return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
	}

	private Vector3 GetScreenBottomRight() {
		//反転
		//画面の左上を取得
		return GetComponent<Camera>().ScreenToWorldPoint(Vector3.zero);
	}
}
