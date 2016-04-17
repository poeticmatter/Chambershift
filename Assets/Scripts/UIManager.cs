using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public static UIManager inst;
	public GameObject gameOver;
	public Button button;
	public Text label;

	
	void Awake () {
		inst = this;
	}
	void Start()
	{
		inst = this;
	}

	public void GameOver()
	{
		EnabledButton("Game Over");

	}

	public void Win()
	{
		EnabledButton("Victory!");
		PlayerPrefs.SetInt(PortalsNumber.PORTALS, PlayerPrefs.GetInt(PortalsNumber.PORTALS) + 1);
	}

	private void EnabledButton(string text) 
	{
		gameOver.SetActive(true);
		label.text = text;
		button.Select();
	}
}
