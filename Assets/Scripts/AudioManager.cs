using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager inst;

	public AudioSource win;

	public AudioSource[] shifts;

	public AudioSource kill;

	public AudioSource loss;

	public AudioSource music;

	void Awake ()
	{
		inst = this;
	}

	void Start()
	{
		LoadMusicVolume();
	}

	public void PlayWin()
	{
		win.volume = OptionsControl.GetFXVolume();
		win.Play();
	}

	public void PlayLoss()
	{
		loss.volume = OptionsControl.GetFXVolume();
		loss.Play();
	}

	public void PlayKill()
	{
		kill.volume = OptionsControl.GetFXVolume();
		kill.Play();
	}

	public void PlayShift()
	{
		AudioSource shift = GetRandom(shifts);
		shift.volume = OptionsControl.GetFXVolume();
		shift.Play();
	}

	private AudioSource GetRandom(AudioSource [] audioSources)
	{
		return audioSources[Random.Range(0, audioSources.Length)];
	}

	public void LoadMusicVolume()
	{
		music.volume = OptionsControl.GetMusicVolume();
	}
}
