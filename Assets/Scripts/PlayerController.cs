using UnityEngine;
using System.Collections;

//https://github.com/unity3d-jp-tutorials/2d-shooting-game/wiki/%E7%AC%AC02%E5%9B%9E-%E3%83%97%E3%83%AC%E3%82%A4%E3%83%A4%E3%83%BC%E3%81%AE%E7%A7%BB%E5%8B%95
//http://www.go-next.co.jp/blog/web/10988/

public class PlayerController : MonoBehaviour {
	
	// 移動スピード
	private float speed = 0.0f;

	//飛んでいるか
	private bool isJumping = false;

	//飛ぶ力
	public float jumpforce;

	//速さ変化量
	public float diffspeed;

	//速さ最大
	public float maxspeed;

	//画像
	public Sprite[] sprites;

	//止まっているときのインデックス
	private const int STOPPING = 0;
	//走っている時のインデックス
	private const int RUNNING = 1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Debug.Log (speed);
		//加速、減速処理。AddForceが上手く行かないので無理矢理
		if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<SpriteRenderer> ().sprite = sprites [RUNNING]; //走っている画像に差し替え
			GetComponent<SpriteRenderer> ().flipX = false; //画像を反転しない
			speed += diffspeed;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<SpriteRenderer> ().sprite = sprites [RUNNING];
			GetComponent<SpriteRenderer> ().flipX = true; //画像を反転
			speed -= diffspeed;
		} else {
			GetComponent<SpriteRenderer> ().sprite = sprites [STOPPING];
			if (speed > 0) {
				speed -= diffspeed;
				if (speed < 0) {
					speed = 0;
				}
			} else if (speed < 0) {
				speed += diffspeed;
				if (speed > 0) {
					speed = 0;
				}
			}
		}

		//一定の速さでそれ以上加速しない
		if (speed > maxspeed) {
			speed = maxspeed;
		} else if (speed < -maxspeed) {
			speed = -maxspeed;
		}
			
		//ジャンプ
		if (Input.GetKey (KeyCode.Space) && !isJumping) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpforce, ForceMode2D.Impulse);
			isJumping = true;
		}

		//縦方向の速度が0なら着地した判定（ガバガバだから修正必要
		if (GetComponent<Rigidbody2D> ().velocity.y == 0) {
			isJumping = false;
		}

		//横方向の速さを設定
		Vector2 vector = GetComponent<Rigidbody2D> ().velocity;
		vector.x = speed;
		GetComponent<Rigidbody2D> ().velocity = vector;

	}

}
