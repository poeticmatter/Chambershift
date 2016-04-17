using UnityEngine;
using System.Collections;

public class CrateManager : MonoBehaviour {

	public float moveTime;
	public float shiftDelay;
	public float timeSinceLastShift;
	public static CrateManager inst;
	private CrateShift[] crates;
	public SimplePlatformController player;

	void Awake () {
		inst = this;
		crates = FindObjectsOfType<CrateShift>();
	}

	void Update()
	{
		timeSinceLastShift += Time.deltaTime;
		if (timeSinceLastShift > shiftDelay)
		{
			DoShift();
		}
	}

	private void DoShift()
	{
		int h = (int)Input.GetAxisRaw("HorizontalShift");
		int v = (int)Input.GetAxisRaw("VerticalShift");
		if (h!=0)
		{
			v = 0; //Can't move both at the same time;
		}
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
