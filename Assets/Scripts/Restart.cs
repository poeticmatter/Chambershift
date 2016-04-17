using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour {

	public void RestartLevel()
	{
		SceneManager.LoadScene(0);
	}
}
