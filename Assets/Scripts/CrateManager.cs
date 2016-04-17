using UnityEngine;
using System.Collections;

public class CrateManager : MonoBehaviour {

	public float moveTime;
	public float shiftDelay;
	public float timeSinceLastShift;
	public static CrateManager inst;
	private CrateShift[] crates;
	private SimplePlatformController player = null;

	void Awake () {
		inst = this;
	}

	void Update()
	{
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<SimplePlatformController>();
		}
		timeSinceLastShift += Time.deltaTime;
		if (timeSinceLastShift > shiftDelay)
		{
			DoShift();
		}
	}

	private void DoShift()
	{
		int h = (int)Input.GetAxisRaw("Horizontal");
		int v = (int)Input.GetAxisRaw("Vertical");
		if (h!=0)
		{
			v = 0; //Can't move both at the same time;
		}
		if (h==0 && v==0)
		{
			return;
		}
		crates = FindObjectsOfType<CrateShift>();
		bool shifted = false;
		for (int i = 0; i < crates.Length; i++)
		{

			if (v!=0 && Mathf.RoundToInt(player.transform.position.x) == crates[i].getRoundedX())
			{
				crates[i].Move(h, v);
				shifted = true;
			}
			if (h != 0 && Mathf.RoundToInt(player.transform.position.y) == crates[i].getRoundedY())
			{
				crates[i].Move(h, v);
				shifted = true;
			}

		}
		if (shifted)
		{
			timeSinceLastShift = 0;
			player.FreezeFor(moveTime);
		}

	}
	
}
