using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoseOnContact : MonoBehaviour {

	private GameObject gameOver;

	void Start()
	{
		gameOver = GameObject.FindGameObjectWithTag("GameOver");
		gameOver.SetActive(false);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			gameOver.SetActive(true);
			GetComponent<SimplePlatformController>().enabled = false;

		}


	}
}
