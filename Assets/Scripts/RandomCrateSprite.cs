using UnityEngine;
using System.Collections;

public class RandomCrateSprite : MonoBehaviour {
	public Sprite[] sprites;
	
	void Start () {
		GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
	}
	
	
}
