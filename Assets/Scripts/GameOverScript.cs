using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

	public static string CurrentSceneName{ get; set;}

    public void ContinueClick()
    {
		CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () => { SceneManager.LoadScene(CurrentSceneName); });
    }

    public void TitleClick()
    {
		CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () => { SceneManager.LoadScene("Player"); });
    }

    // Use this for initialization
    void Start()
    {
        GameObject.Find("/Canvas/Panel/ContinueButton").GetComponent<Button>().Select();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
