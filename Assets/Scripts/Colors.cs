using UnityEngine;
using System.Collections;

public class Colors : MonoBehaviour {

	public Color[] enemies;
	public Color[] player;
	public Color[] bg;
	public Color[] crates;
	private int scheme;

	public static Colors inst;


	void Awake () {
		inst = this;
		scheme = PlayerPrefs.GetInt(ColorSchemeChooser.COLOR_SCHEME);
	}

	public Color Bg()
	{
		return bg[scheme];
	}

	public Color Enemies()
	{
		return enemies[scheme];
	}

	public Color Player()
	{
		return player[scheme];
	}

	public Color Crates()
	{
		return crates[scheme];
	}

}
