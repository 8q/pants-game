using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// 移動スピード
	private float speed = 0.0f;

	//飛んでいるか
	private bool isJumping = false;

	//飛ぶ力
	public float jumpForce;

	//速さ変化量
	public float diffSpeed;

	//速さ最大
	public float maxSpeed;

	//無敵時間（秒）
	public float invincibleTime;

	//無敵モードのときの透過率
	public float invincibleAlpha;

	//無敵モードか
	private bool isInvincible = false;
	public bool IsInvincible 
	{
		get { return isInvincible; }
		set {
			isInvincible = value;
			if(value == true)
			{
				GetComponent<SpriteRenderer> ().color = new Color(1.0f,1.0f,1.0f, invincibleAlpha);
				StartCoroutine (this.DelayMethod(invincibleTime, () => {
					GetComponent<SpriteRenderer> ().color = new Color(1.0f,1.0f,1.0f, 1.0f);
					isInvincible = false;
				}));
			}
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//加速、減速処理。AddForceが上手く行かないので無理矢理
		//speedが0以外のときは走っているアニメーションに切り替え
		if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<SpriteRenderer> ().flipX = false; //画像を反転しない
			GetComponent<Animator>().SetBool("isRunning", true);
			speed += diffSpeed;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<SpriteRenderer> ().flipX = true; //画像を反転
			GetComponent<Animator>().SetBool("isRunning", true);
			speed -= diffSpeed;
		} else {
			if (speed > 0) {
				speed -= diffSpeed;
				if (speed <= 0) {
					GetComponent<Animator>().SetBool("isRunning", false);
					speed = 0;
				}
			} else if (speed < 0) {
				speed += diffSpeed;
				if (speed >= 0) {
					GetComponent<Animator>().SetBool("isRunning", false);
					speed = 0;
				}
			}
		}

		//一定の速さでそれ以上加速しない
		if (speed > maxSpeed) {
			speed = maxSpeed;
		} else if (speed < -maxSpeed) {
			speed = -maxSpeed;
		}
			
		//ジャンプ
		//跳んでいる間はアニメーションを停止
		if (Input.GetKey (KeyCode.Space) && !isJumping) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
			isJumping = true;
			GetComponent<Animator> ().enabled = false;
		}
			
		//y軸方向の速度が0かつ足がついているときにジャンプできるようにする
		//すりぬけ防止 Rigidbody2DのCollision DetectionをContinuousへ
		if (GetComponent<Rigidbody2D> ().velocity.y == 0 && GetComponent<CircleCollider2D> ().IsTouchingLayers() == true) {
			isJumping = false;
			GetComponent<Animator> ().enabled = true;
		}

		//横方向の速さを設定
		Vector2 vector = GetComponent<Rigidbody2D> ().velocity;
		vector.x = speed;
		GetComponent<Rigidbody2D> ().velocity = vector;

	}
		
}
