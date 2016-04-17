using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorSchemeChooser : MonoBehaviour {

	public Dropdown setup;
	public const string COLOR_SCHEME = "ColorScheme";
	
	void Start () {
		setup.value = PlayerPrefs.GetInt(COLOR_SCHEME);
	}
	
	
	public void SelectedScheme(int index)
	{
		PlayerPrefs.SetInt(COLOR_SCHEME, index);
	}
}
