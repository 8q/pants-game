using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{

    public Text[] pantsCountText;

    // Use this for initialization
    void Start()
    {
        var gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
        for (int i = 0; i < 3; i++)
        {
            pantsCountText[i].text = gameSystemScript.pantsCounts[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
