using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundControl : MonoBehaviour {
	public AudioListener listener;
	public Toggle setup;
	public const string SOUND = "Sound";

	void Start()
	{
		setup.isOn = PlayerPrefs.GetInt(SOUND) == 0;
	}


	public void ChangedSound(bool enab)
	{
		PlayerPrefs.SetInt(SOUND, enab ? 0 : -1);
		listener.enabled = enab;
		
	}
}
