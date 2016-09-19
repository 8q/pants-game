using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSystemScript : MonoBehaviour {
	
	public int[] pantsCounts;

	public Text[] texts;

	public Canvas uiCanvas;

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
}
