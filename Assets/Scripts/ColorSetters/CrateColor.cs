using UnityEngine;
using System.Collections;

public class CrateColor : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer.color = Colors.inst.Crates();
	}
}
