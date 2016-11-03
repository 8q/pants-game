using UnityEngine;
using System.Collections;
using Novel;

public class ScenarioTestScript : MonoBehaviour {

	public string scenarioFileName;

	// Use this for initialization
	void Start () {
		NovelSingleton.StatusManager.callJoker("wide/" + scenarioFileName, "");
	}

	// Update is called once per frame
	void Update () {

	}
}
