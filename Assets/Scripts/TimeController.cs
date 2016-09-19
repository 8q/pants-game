using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeController: MonoBehaviour {

	private Text timeText;

	public int remainTime;

	public float waitingTime;

	private GameSystemScript gameSystemScript;

	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text> ();
		gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
		StartCoroutine(Timer());
	}

	IEnumerator Timer(){
		while(true){
			yield return new WaitForSeconds(waitingTime);
			remainTime--;
			timeText.text = remainTime.ToString ();
			if (remainTime == 0)
				break;
		}
		gameSystemScript.SerGameOverFlag (true);
		gameSystemScript.MoveNextFades();
	}
}
