using UnityEngine;
using UnityEngine.UI;

public class PortalsNumber : MonoBehaviour {

	public Slider setup;
	public const string PORTALS = "Portals";

	void Start()
	{
		int loadValue = PlayerPrefs.GetInt(PORTALS);
		if(loadValue == 0)
		{
			loadValue = 3;
			PlayerPrefs.SetInt(PORTALS, loadValue);
		}
		setup.value = loadValue;
	}


	public void SelectedPortals()
	{
		PlayerPrefs.SetInt(PORTALS, Mathf.RoundToInt(setup.value));
	}
}
