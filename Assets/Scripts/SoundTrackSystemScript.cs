﻿using UnityEngine;
using System.Collections;
using Novel;

public class SoundTrackSystemScript : MonoBehaviour {

	public int MusicIndex{ get; set; }

	public AudioClip[] audios;

	public AudioSource audiosource;

	public UnityEngine.UI.Button[] buttons;

	public GameObject mark;

	public GameObject playButton;

	public Sprite playSprite;

	public Sprite stopSprite;

	private const int MUSIC_COUNT = 7;

	// Use this for initialization
	void Start () {
		MusicIndex = 0;
		//Openingだけは最初からフラグを立てておく
		if (!AllPlayerPrefs.LoadSoundTrack ().HasTrackFlag (SoundTrack.Opening)) {
			AllPlayerPrefs.SaveSoundTrack (SoundTrack.Opening);
		}
	}

	public void OnPlayButton(){
		if (audiosource.isPlaying) {
			Stop ();
		} else {
			Play ();
		}
	}

	public void OnProgressPlayButton(){
		ProgressPlay ();
	}

	public void OnBackPlayButton(){
		BackPlay ();
	}

	public void ProgressPlay(){
		do {
			MusicIndex = (MusicIndex + 1) % MUSIC_COUNT;
		} while (!buttons [MusicIndex].interactable);
		_Play (MusicIndex);
	}

	public void Play(){
		_Play (MusicIndex);
	}

	//眠いよ
	public void BackPlay(){
		do {
			MusicIndex = (MusicIndex - 1 + MUSIC_COUNT) % MUSIC_COUNT;
		} while(!buttons [MusicIndex].interactable);
		_Play (MusicIndex);
	}

	public void Stop(){
		mark.SetActive (false);
		playButton.GetComponent<UnityEngine.UI.Image> ().sprite = playSprite;
		audiosource.Stop ();
	}

	private void _Play(int index){
		if (audiosource.isPlaying) {
			audiosource.Stop ();
		}
		audiosource.PlayOneShot (audios[index]);
		playButton.GetComponent<UnityEngine.UI.Image> ().sprite = stopSprite;
		RectTransform rec = buttons [index].GetComponent<RectTransform> ();
		mark.SetActive (true);
		mark.GetComponent<RectTransform> ().anchoredPosition = new Vector3(rec.anchoredPosition.x - rec.sizeDelta.x/2 + 5, rec.anchoredPosition.y, 1);
	}

	public void  OnTitileButton(){
		if (audiosource.isPlaying) {
			Stop ();
		}
		CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () => { NovelSingleton.StatusManager.callJoker("wide/title",""); });
	}
}
