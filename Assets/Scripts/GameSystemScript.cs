using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using Novel;

public class GameSystemScript : MonoBehaviour
{

    public bool IsGameOver { get; set; }

	public int stageNumber; //ステージ番号

    public int[] pantsCounts;

	public int borderOfPantsCount; //最大の個数がこれ以下のときゲームオーバーとなる

    public Text[] texts;

    public UnityEngine.UI.Image[] zankiImages;

    public int zanki; //現在の残機

	public bool isRouteDiverged; //このステージはルート分岐後のものか

    // Use this for initialization
    void Start()
    {
        ///TODO: DEBUG用10秒で強制クリア
        /*
        StartCoroutine(this.DelayMethod(10f, () =>
        {
            MoveNextPhase();
        }));
        */
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPantsCount(int index)
    {
        pantsCounts[index]++;
        texts[index].text = pantsCounts[index].ToString();
    }

    public void DecreaseZanki()
    {
        //ひとまずデバッグ用
        //		if (zanki == 0)
        //			return;

        int index = --zanki;
        Destroy(zankiImages[index]);
        if (zanki == 0)
        {
            IsGameOver = true;
            MoveNextPhase();
        }
    }


    //パンツの数で分岐 //GameOverFlagが立っている場合ゲームオーバー
    public void MoveNextPhase()
    {
		//プレーヤーをコントロールできなくする
		((PlayerController)(GameObject.FindGameObjectWithTag ("Player").GetComponent ("PlayerController"))).enabled = false;

		//パンツの最大個数とそのインデックス
		int maxCountIndex = -1;
		int maxCount = -1;
		for (int i = 0; i < pantsCounts.Length; i++) {
			if(maxCount < pantsCounts[i]){
				maxCountIndex = i;
				maxCount = pantsCounts[i];
			} 
		}

		//獲得数の最大個数が設定以下だったときゲームオーバー
		if (!IsGameOver && maxCount < borderOfPantsCount) 
		{
            CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () =>
            {
                GameOverScript.CurrentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("gameover_pantsless");
            });
            return;
        }

        if (IsGameOver)
        {
            //Debug.Log ("GameOver");

            CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () =>
            {
				GameOverScript.CurrentSceneName = SceneManager.GetActiveScene ().name;
                SceneManager.LoadScene("gameover");
            });
            return;
        }
			
        // GOALシーンをかぶせる
        CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () =>
        {
            SceneManager.LoadScene("goal", LoadSceneMode.Additive);
        });

        //4.5秒後に実行
        StartCoroutine(this.DelayMethod(4.5f, () =>
        {
				//ルート分岐前
				if(isRouteDiverged == false)
				{
					switch (maxCountIndex)
		            {
		                case 0: //あいり
							ConstantValues.ROUTE = ConstantValues.RouteName.Airi;
		                    break;
		                case 1: //みおん
							ConstantValues.ROUTE = ConstantValues.RouteName.Mion;						
		                    break;
		                case 2: //うみの
							ConstantValues.ROUTE = ConstantValues.RouteName.Umino;
		                    break;
		                default:
		                    Debug.Log("Move Next Phase Error");
		                    break;
		            }
				}
				
				switch(ConstantValues.ROUTE)
				{
					case ConstantValues.RouteName.Airi:
						NovelSingleton.StatusManager.callJoker("wide/stage" + stageNumber + "_airi", "");
						break;
					case ConstantValues.RouteName.Mion:
						NovelSingleton.StatusManager.callJoker("wide/stage" + stageNumber + "_mion", "");
						break;
					case ConstantValues.RouteName.Umino:
						NovelSingleton.StatusManager.callJoker("wide/stage" + stageNumber + "_umino", "");
						break;
					default:
						Debug.Log("Move Next Phase Error");
						break;
				}

	            // 次の画面をロードしてからGOALシーンを削除
	            CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () =>
	            {
	                SceneManager.UnloadScene("goal");
	            });
				
        }));

    }


}
