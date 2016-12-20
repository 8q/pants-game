using UnityEngine;
using System.Collections;

public class SoundTrackMusicButtonBehabior : MonoBehaviour {

	private SoundTrackSystemScript soundTrackSystemScript;

	public int musicindex;

	void Start(){
		soundTrackSystemScript = (SoundTrackSystemScript)(GameObject.Find("SoundTrackSystem").GetComponent("SoundTrackSystemScript"));
	}

	public void play(){
		soundTrackSystemScript.MusicIndex = musicindex;
		soundTrackSystemScript.Play();
	}

}
