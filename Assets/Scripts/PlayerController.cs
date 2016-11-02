using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

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

    //デバッグ用無敵モード
    private bool isInvincibleDebug;

    //無敵モードか
    private bool isInvincible = false;
    public bool IsInvincible
    {
        get { return isInvincible || isInvincibleDebug; }
        set
        {
            isInvincible = value;
            if (value == true)
            {
                GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, invincibleAlpha);
                StartCoroutine(this.DelayMethod(invincibleTime, () =>
                {
                    GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    isInvincible = false;
                }));
            }
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //加速、減速処理。AddForceが上手く行かないので無理矢理
        //speedが0以外のときは走っているアニメーションに切り替え
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false; //画像を反転しない
            GetComponent<Animator>().SetBool("isRunning", true);
            speed += diffSpeed;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true; //画像を反転
            GetComponent<Animator>().SetBool("isRunning", true);
            speed -= diffSpeed;
        }
        else
        {
            if (speed > 0)
            {
                speed -= diffSpeed;
                if (speed <= 0)
                {
                    GetComponent<Animator>().SetBool("isRunning", false);
                    speed = 0;
                }
            }
            else if (speed < 0)
            {
                speed += diffSpeed;
                if (speed >= 0)
                {
                    GetComponent<Animator>().SetBool("isRunning", false);
                    speed = 0;
                }
            }
        }

        //一定の速さでそれ以上加速しない
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        else if (speed < -maxSpeed)
        {
            speed = -maxSpeed;
        }


        if (Input.GetButtonDown("Jump") && !isJumping)
        {

            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            GetComponent<Animator>().enabled = false;
        }
        else if (Input.GetButtonDown("SmallJump") && !isJumping)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce * 0.8f, ForceMode2D.Impulse);

            // コストダウンのためにGetButtonDown判定の中に含むことが好ましいと思われるので、ここにおいてます。
            // C# の && は短絡評価です。
            if (Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.S))
            {
                isInvincibleDebug = !isInvincibleDebug;
				Debug.Log ("isInvincibleDebug=" + isInvincibleDebug);
            }

            isJumping = true;
            GetComponent<Animator>().enabled = false;
        }


        /*		
            //ジャンプ
            //跳んでいる間はアニメーションを停止
            if (Input.GetKey (KeyCode.Space) && !isJumping) {
                GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
                GetComponent<Animator> ().enabled = false;
            }
    */
        //y軸方向の速度が0かつ足がついているときにジャンプできるようにする
        //すりぬけ防止 Rigidbody2DのCollision DetectionをContinuousへ
		if (GetComponent<Rigidbody2D>().velocity.y == 0 && GetComponent<EdgeCollider2D>().IsTouchingLayers(1 << LayerMask.NameToLayer("GroundLayer")) == true)
        {
            isJumping = false;
            GetComponent<Animator>().enabled = true;
        }

        //横方向の速さを設定
        Vector2 vector = GetComponent<Rigidbody2D>().velocity;
        vector.x = speed;
        GetComponent<Rigidbody2D>().velocity = vector;

    }

}
