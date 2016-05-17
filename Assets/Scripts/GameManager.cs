using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager inst;
	private enum GameState {SETUP, RUNNING, PAUSED, LOSS, WIN};
	private GameState state = GameState.SETUP;

	void Awake () {
		inst = this;
	}
	
	public bool IsGameRunning()
	{
		return state == GameState.RUNNING;
	}

	public void SetupComplete()
	{
		state = GameState.RUNNING;
	}
}
