using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSystemScript : MonoBehaviour {

	private bool gameOverFlag = false;

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
		if (zanki == 0)
			return;

		zanki--;
		int index = zanki;
		Destroy (zankiImages[index]);
		if (zanki == 0) {
			SerGameOverFlag (true);
			MoveNextPhase ();
		}
	}


	//パンツの数で分岐 //GameOverFlagが立っている場合ゲームオーバー
	public void MoveNextPhase(){
		if (gameOverFlag == true) {
			Debug.Log ("GameOver");
		} else {
			Debug.Log ("MoveNextPhase");
		}
		//if(pantsCounts[0] <= )
	}

	public void SerGameOverFlag(bool isGameOver){
		gameOverFlag = isGameOver;
	}

}
