using UnityEngine;
using System.Collections;

public class SoundTrackMusicButtonBehabior : MonoBehaviour {

	private SoundTrackSystemScript soundTrackSystemScript;

	public SoundTrack soundTrack;

	public int musicindex;

	void Start(){
		soundTrackSystemScript = (SoundTrackSystemScript)(GameObject.Find("SoundTrackSystem").GetComponent("SoundTrackSystemScript"));
		if(!AllPlayerPrefs.LoadSoundTrack().HasTrackFlag(soundTrack)){
			this.GetComponent<UnityEngine.UI.Button> ().interactable = false;
		}
	}

	public void play(){
		soundTrackSystemScript.MusicIndex = musicindex;
		soundTrackSystemScript.Play();
	}

}
