using UnityEngine;
using System.Collections;

public class DisabledAudioListener : MonoBehaviour {

	void Start () {
		if(PlayerPrefs.GetInt(SoundControl.SOUND) !=0)
		{
			GetComponent<AudioListener>().enabled = false;
		}
	}
	
	
}
