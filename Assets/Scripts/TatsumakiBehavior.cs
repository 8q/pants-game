using UnityEngine;
using System.Collections;

public class TatsumakiBehavior : MonoBehaviour {

	// http://www.raywenderlich.com/70344/unity-2d-tutorial-physics-and-screen-sizes

	public PolygonCollider2D[] colliders;

	private int currentColliderIndex = 0;
	private GameSystemScript gameSystemScript;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		gameSystemScript = (GameSystemScript)(GameObject.Find("GameSystem").GetComponent("GameSystemScript"));
		playerController = (PlayerController)(GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerController"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetColliderForSprite(int spriteNum)
	{
		if (spriteNum < 0) 
		{
			colliders[currentColliderIndex].enabled = false;
			return;
		}

		colliders[currentColliderIndex].enabled = false;
		currentColliderIndex = spriteNum;
		colliders[currentColliderIndex].enabled = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && playerController.IsInvincible == false) {
			playerController.IsInvincible = true;
			gameSystemScript.DecreaseZanki ();
		}
	}
}
