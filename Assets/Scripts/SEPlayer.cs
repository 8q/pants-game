using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SEPlayer : MonoBehaviour{

	public enum SE {
		Bomb,
		Hasami,
		Pants,
		Taifu,
		Otoshiana,
		Tatsumaki
	}

	private static Dictionary<SE, string> passDic = new Dictionary<SE, string> (){
		{SE.Bomb, "SE/bomb"},
		{SE.Hasami, "SE/bite1"},
		{SE.Pants, "SE/coin02"},
		{SE.Taifu, "SE/boomerang"},
		{SE.Otoshiana, "SE/falling1a"},
		{SE.Tatsumaki, "SE/attack3"},
	};


	private static Dictionary<SE, AudioClip> audioDic = new Dictionary<SE, AudioClip> (){
		{SE.Bomb, Resources.Load(passDic[SE.Bomb]) as AudioClip},
		{SE.Hasami, Resources.Load(passDic[SE.Hasami]) as AudioClip},
		{SE.Pants, Resources.Load(passDic[SE.Pants]) as AudioClip},
		{SE.Taifu, Resources.Load(passDic[SE.Taifu]) as AudioClip},
		{SE.Otoshiana, Resources.Load(passDic[SE.Otoshiana]) as AudioClip},
		{SE.Tatsumaki, Resources.Load(passDic[SE.Tatsumaki]) as AudioClip},
	};

	private static GameObject gameObject;

	static SEPlayer(){
		gameObject = new GameObject ("Sound");
		gameObject.AddComponent<AudioSource>();
		DontDestroyOnLoad (gameObject);
	}


	public static void Play(SE se){
		gameObject.GetComponent<AudioSource> ().PlayOneShot(audioDic[se]);
	}

}
