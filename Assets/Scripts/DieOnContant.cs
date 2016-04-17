using UnityEngine;
using System.Collections;

public class DieOnContant : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			Spawn.inst.spawnPoints.Remove(this.transform);
			if (Spawn.inst.spawnPoints.Count <= 0)
			{
				UIManager.inst.Win();
			}
			else
			{
				AudioSource audio = GameObject.FindGameObjectWithTag("KillSound").GetComponent<AudioSource>();
				audio.Play();
			}
			Destroy(this.gameObject);
		}
			

	}
}
