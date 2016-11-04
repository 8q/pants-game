using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    private struct CreditItem
    {
        public CreditItem(string text, float waitSecond = 2.5f)
        {
            Text = text;
            WaitSecond = waitSecond;
        }
        public float WaitSecond { get; set; }
        public string Text { get; set; }
    }

    public Text CreditText;

    public Image BackgroundImage;
    public Image MaskImage;

    public List<Sprite> SpriteList;


    private IEnumerator CreditStart(List<CreditItem> creditList, int fadeCount = 30)
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


    private IEnumerator BackgroundStart(int fadeCount = 100)
    {

        float waitSecond = 28f / SpriteList.Count;

        yield return new WaitForSeconds(10);

        BackgroundImage.enabled = true;
        foreach (var s in SpriteList)
        {
            BackgroundImage.sprite = s;
            for (int i = 0; i < fadeCount; i++)
            {
                MaskImage.color = new Color(0, 0, 0, 1 - (i * 0.25f / fadeCount));
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(waitSecond);

            for (int i = 0; i < fadeCount; i++)
            {
                MaskImage.color = new Color(0, 0, 0, 0.75f + (i * 0.25f / fadeCount));
                yield return new WaitForSeconds(0.01f);
            }
            MaskImage.color = new Color(0, 0, 0, 1);
        }
        yield break;
    }


    // Use this for initialization
    void Start()
    {
        var creditList = new List<CreditItem>
        {
            new CreditItem("",2),
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
わかな"),

new CreditItem(@"《チームPANTS》

グラフィック

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

new CreditItem(@"",0.5f),

new CreditItem(@"おしまい",4),
        };

        StartCoroutine(CreditStart(creditList));

        StartCoroutine(BackgroundStart());
    }


    // Update is called once per frame
    void Update()
    {

    }
}
