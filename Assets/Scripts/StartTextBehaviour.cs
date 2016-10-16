using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartTextBehaviour : MonoBehaviour {

    public Text StartText;


    // ゲームスタート
    private IEnumerator GameStart()
    {

        //        yield return new WaitForSeconds(1f);
        StartText.text = "START!";
        yield return new WaitForSeconds(0.4f);

        int i = 0;
        for (int fontsize = 200; fontsize < 800; fontsize+=10)
        {
            StartText.fontSize = fontsize;
            StartText.color = new Color(1,1,1,1-((fontsize-200)/500f));
            yield return new WaitForSeconds(0.01f);
        }

        StartText.enabled = false;

        yield break;
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GameStart());
    }

#if false
    // Update is called once per frame
    void Update()
    {

    }
#endif
}
