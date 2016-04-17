using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public static UIManager inst;
	public GameObject gameOver;

	
	void Awake () {
		inst = this;
	}

	public void GameOver()
	{
		gameOver.SetActive(true);
	}
}
