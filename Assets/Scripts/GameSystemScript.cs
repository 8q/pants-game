using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class GameSystemScript : MonoBehaviour {

	public bool IsGameOver { get; set; }

	public int[] pantsCounts;

	public Canvas uiCanvas;

	public Text[] texts;

	public Image[] zankiImages;

	public int zanki; //現在の残機


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
			Application.LoadLevel("stage1");
			return;
		} 

		var maxCount = pantsCounts.Select((val, index) => new { V = val, I = index })
			.Aggregate((max, working) => (max.V > working.V) ? max : working);
		switch(maxCount.I){
		case 0: //あいり
			Debug.Log ("Airi");
			break;
		case 1: //みおん
			Debug.Log ("Mion");
			break;
		case 2: //うみの
			Debug.Log ("Umino");
			break;
		default:
			break;
		}
	}
		

}
