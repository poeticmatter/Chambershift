using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuEscape : MonoBehaviour {



	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene(0);
		}
	}
}
