using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoseOnContact : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			UIManager.inst.GameOver();
			GetComponent<SimplePlatformController>().enabled = false;
			GetComponent<AudioSource>().Play();
		}
	}
}
