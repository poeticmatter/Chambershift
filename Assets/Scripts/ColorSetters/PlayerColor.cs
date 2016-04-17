using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer.color = Colors.inst.Player();
	}
}
