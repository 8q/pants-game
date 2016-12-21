using UnityEngine;
using System.Collections;
using Novel;

public class ForceReturn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(this.DelayMethod(4.5f, () =>
        {
			NovelSingleton.StatusManager.callJoker("wide/libs/save","*loadstart");
        }));
	}

	// Update is called once per frame
	void Update () {

	}
}
