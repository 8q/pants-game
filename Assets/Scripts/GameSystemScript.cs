using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;
using Novel;

public class GameSystemScript : MonoBehaviour {

	public bool IsGameOver { get; set; }

	public int[] pantsCounts;

	public Canvas uiCanvas;

	public Text[] texts;

	public UnityEngine.UI.Image[] zankiImages;

	public int zanki; //現在の残機

	public string sceneName; //このシーンの名前


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void AddPantsCount(int index){
		pantsCounts [index]++;
		texts [index].text = pantsCounts [index].ToString ();
	}

	public void DecreaseZanki(){
		//ひとまずデバッグ用
//		if (zanki == 0)
//			return;

		zanki--;
		int index = zanki;
		Destroy (zankiImages[index]);
		if (zanki == 0) {
			IsGameOver = true;
			MoveNextPhase ();
		}
	}


	//パンツの数で分岐 //GameOverFlagが立っている場合ゲームオーバー
	public void MoveNextPhase(){
		if (IsGameOver) {

            //Debug.Log ("GameOver");

            CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () => { 
				GameOverScript.CurrentSceneName = sceneName;
				SceneManager.LoadScene("gameover"); 
			});
            return;
		} 

		var maxCount = pantsCounts.Select((val, index) => new { V = val, I = index })
			.Aggregate((max, working) => (max.V > working.V) ? max : working);
		switch(maxCount.I){
		case 0: //あいり
			Debug.Log ("Airi");
			NovelSingleton.StatusManager.callJoker("wide/stage1_aft","");
			break;
		case 1: //みおん
			Debug.Log ("Mion");
			NovelSingleton.StatusManager.callJoker("wide/stage1_aft","");
			break;
		case 2: //うみの
			Debug.Log ("Umino");
			NovelSingleton.StatusManager.callJoker("wide/stage1_aft","");
			break;
		default:
			Debug.Log ("Move Next Phase Error");
			break;
		}
	}
		

}
