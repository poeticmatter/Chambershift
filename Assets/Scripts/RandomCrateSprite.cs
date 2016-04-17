using UnityEngine;
using System.Collections;

public class RandomCrateSprite : MonoBehaviour {
	public Sprite[] sprites;
	public SpriteRenderer spriteRenderer;
	
	void Awake () {
		spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
	}	
}
