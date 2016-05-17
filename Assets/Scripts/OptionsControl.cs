using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsControl : MonoBehaviour {
	public Slider musicSlider;
	public Slider fxSlider;
	public Dropdown colorSchemeDropdown;

	public const string MUSIC = "music";
	public const string FX = "fx";
	public const string COLOR_SCHEME = "colorScheme";


	void Start()
	{
		SetupSlider(musicSlider, PlayerPrefs.GetFloat(MUSIC));
		SetupSlider(fxSlider, PlayerPrefs.GetFloat(FX));
	}

	private void SetupSlider(Slider slider, float initValue)
	{
		slider.value = InvertVolumeValue(initValue);
	}

	private void SetupDropDown(Dropdown dropdown, int initValue)
	{
		dropdown.value = initValue;
	}

	public void ChangedMusic(float value)
	{
		PlayerPrefs.SetFloat(MUSIC, InvertVolumeValue(value));
	}

	public void ChangedFX(float value)
	{
		PlayerPrefs.SetFloat(FX, InvertVolumeValue(value));
	}

	public void ChangedScheme(int index)
	{
		PlayerPrefs.SetInt(COLOR_SCHEME, index);
	}

	public static float GetFXVolume()
	{
		return InvertVolumeValue(PlayerPrefs.GetFloat(FX));
	}

	public static float GetMusicVolume()
	{
		return InvertVolumeValue(PlayerPrefs.GetFloat(MUSIC));
	}

	//Required so the default, 0, would be full volume.
	private static float InvertVolumeValue(float value)
	{
		return 1 - value;
	}


}
