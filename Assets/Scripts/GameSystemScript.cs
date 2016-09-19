using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSystemScript : MonoBehaviour {
	
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
			MoveNextFades ();
		}
	}


	//パンツの数で分岐 //残機が0の場合ゲームオーバー
	public void MoveNextFades(){
		if (zanki <= 0) {

		}
		//if(pantsCounts[0] <= )
	}
}
