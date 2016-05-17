using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSetter : MonoBehaviour {

	public void SetScene(int scene)
	{
		SceneManager.LoadScene(scene);
	}
}
