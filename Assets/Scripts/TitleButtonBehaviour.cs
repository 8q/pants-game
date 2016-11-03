using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleButtonBehaviour : MonoBehaviour {

    public void TitleClick()
    {
        CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () => { SceneManager.LoadScene("Player"); });
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
