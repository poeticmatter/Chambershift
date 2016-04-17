using UnityEngine;
using System.Collections;

public class EnemyColor : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	
	void Start() {
		spriteRenderer.color = Colors.inst.Enemies();	
	}
}
