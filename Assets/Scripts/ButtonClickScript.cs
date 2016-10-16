using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClickScript : MonoBehaviour
{



    public void ContinueClick()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

    public void TitleClick()
    {
        CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () => { SceneManager.LoadScene("stage1"); });
    }

    /*    public void StopClick()
        {
            throw new System.NotImplementedException();
        }
    */
    // Use this for initialization

    //　このゲームオブジェクトがアクティブになった時
    void OnEnable()
    {
        GetComponent<Button>().interactable = true;
        //        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
        //        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(transform.parent.gameObject);
    }

    void Start()
    {
        GameObject.Find("/Canvas/Panel/ContinueButton").GetComponent<Button>().Select();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
