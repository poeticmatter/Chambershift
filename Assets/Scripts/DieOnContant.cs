using UnityEngine;
using System.Collections;

public class DieOnContant : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			Spawn.inst.spawnPoints.Remove(this.transform);
			Destroy(this.gameObject);
		}
			

	}
}
