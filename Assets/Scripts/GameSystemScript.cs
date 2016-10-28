﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using Novel;

public class GameSystemScript : MonoBehaviour
{

    public bool IsGameOver { get; set; }

    public int[] pantsCounts;

    public Canvas uiCanvas;

    public Text[] texts;

    public UnityEngine.UI.Image[] zankiImages;

    public int zanki; //現在の残機

    public string sceneName; //このシーンの名前


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

        zanki--;
        int index = zanki;
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
        if (IsGameOver)
        {
			((PlayerController)(GameObject.FindGameObjectWithTag ("Player").GetComponent ("PlayerController"))).enabled = false;
            //Debug.Log ("GameOver");

            CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () =>
            {
                GameOverScript.CurrentSceneName = sceneName;
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
            // 正規表現によってStage番号を取得し分岐
            var initReg = new Regex(@"\d$");
            var getStageNum = initReg.Match(Application.loadedLevelName);
            string currentStageNum = null;
            if(getStageNum.Success)
            {
                currentStageNum = getStageNum.Value;
            }
            else
            {
                Debug.Log("Read Stage Name Error");
            }

			int maxCount = pantsCounts.Max();
            switch (maxCount)
            {
                case 0: //あいり
                    Debug.Log("Airi");
					ConstantValues.ROUTE = ConstantValues.RouteName.Airi;
                    // NovelSingleton.StatusManager.callJoker("wide/stage1_airi", "");
                    NovelSingleton.StatusManager.callJoker("wide/stage" + currentStageNum + "_airi", "");
                    break;
                case 1: //みおん
                    Debug.Log("Mion");
					ConstantValues.ROUTE = ConstantValues.RouteName.Mion;
                    // NovelSingleton.StatusManager.callJoker("wide/stage1_mion", "");
                    NovelSingleton.StatusManager.callJoker("wide/stage" + currentStageNum + "_mion", "");
                    break;
                case 2: //うみの
                    Debug.Log("Umino");
					ConstantValues.ROUTE = ConstantValues.RouteName.Umino;
                    // NovelSingleton.StatusManager.callJoker("wide/stage1_umino", "");
                    NovelSingleton.StatusManager.callJoker("wide/stage" + currentStageNum + "_umino", "");
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
