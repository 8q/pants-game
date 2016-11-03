using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    private struct CreditItem
    {
        public CreditItem(string text, float waitSecond = 2f)
        {
            Text = text;
            WaitSecond = waitSecond;
        }
        public float WaitSecond { get; set; }
        public string Text { get; set; }
    }

    public Text CreditText;

    private List<CreditItem> creditList;

    private IEnumerator CreditStart(int fadeCount = 30)
    {
        CreditText.enabled = true;

        foreach (var c in creditList)
        {
            CreditText.text = c.Text;
            for (int i = 0; i < fadeCount; i++)
            {
                CreditText.color = new Color(1, 1, 1, (float)i / fadeCount);
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(c.WaitSecond);

            for (int i = 0; i < fadeCount; i++)
            {
                CreditText.color = new Color(1, 1, 1, 1 - (float)i / fadeCount);
                yield return new WaitForSeconds(0.01f);
            }
            CreditText.color = new Color(1, 1, 1, 0);
        }

        CreditText.enabled = false;

        // おしまい
        CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () => { SceneManager.LoadScene("Player"); });



        yield break;
    }

    // Use this for initialization
    void Start()
    {
        creditList = new List<CreditItem>
        {
            new CreditItem(@"かくして、彼女たちの努力によって

ひとまず世界は救われたのであった――",4),
            new CreditItem("――たぶん。",3),


            new CreditItem(@"参加スタッフ"),
            new CreditItem(@"《チームPANTS》"),

new CreditItem(@"《チームPANTS》

シナリオ

zuzu"),

new CreditItem(@"《チームPANTS》

プログラム

しらす
むさしん
G2"),

new CreditItem(@"《チームPANTS》

グラフィック

きつめ
しゃんぬ
わかな
UN-CHO
ほわいと納豆"),

new CreditItem(@"《チームPANTS》

音楽

あんず
D
ねずみ"),

new CreditItem(@"《協力》"),

new CreditItem(@"《協力》

テストプレイ

Poi
クランク"),

new CreditItem(@"《協力》

アドバイスをくださった方
早稲田大学経営情報学会 MIS.W の皆さま
"),

new CreditItem(@"そして、プレイをしてくれたあなたへ"),

new CreditItem(@"心からの感謝を込めて"),

new CreditItem(@"パンツ！"),

new CreditItem(@"おしまい",4),
        };

        StartCoroutine(CreditStart());
    }


    // Update is called once per frame
    void Update()
    {

    }
}
