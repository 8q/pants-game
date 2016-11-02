using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{

	public GameObject pantsPanel1;

	public GameObject pantsPanel2;

    public Text[] pantsCountTexts1;

	public Text pantsCountText2;

	public Image pantsImage2;

	public Sprite[] sprites;

    // Use this for initialization
    void Start()
    {
        var gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
		if (gameSystemScript.isRouteDiverged == false) 
		{
			pantsPanel1.SetActive (true);
			pantsPanel2.SetActive (false);
			for (int i = 0; i < 3; i++) 
			{
				pantsCountTexts1 [i].text = gameSystemScript.pantsCounts [i].ToString ();
			}
		} 
		else 
		{
			pantsPanel1.SetActive (false);
			pantsPanel2.SetActive (true);
			switch(ConstantValues.ROUTE)
			{
				case ConstantValues.RouteName.Airi:
					pantsImage2.sprite = sprites [0];
					break;
				case ConstantValues.RouteName.Mion:
					pantsImage2.sprite = sprites [1];
					break;
				case ConstantValues.RouteName.Umino:
					pantsImage2.sprite = sprites [2];
					break;
				default:
					break;
			}
			pantsCountText2.text = gameSystemScript.pantsCounts [0].ToString ();
		}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
