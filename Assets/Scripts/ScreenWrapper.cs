using UnityEngine;
using System.Collections;

public class ScreenWrapper : MonoBehaviour {
	public Vector2 aspectRatio;
	public SpriteRenderer spriteRenderer;
	private SpriteRenderer[] wrapClones = new SpriteRenderer[8];
	
	void Start () {
		int i = 0;
		for (int x = -1; x <= 1; x++)
		{
			for (int y = -1; y <= 1; y++)
			{
				if (y==0 && x==0) {
					continue;
				}
				Vector3 offset = new Vector3(x * aspectRatio.x, y * aspectRatio.y, 0);
                SpriteRenderer clone = (SpriteRenderer)Instantiate(spriteRenderer, transform.position + offset, Quaternion.identity);
				clone.transform.parent = this.transform;
				wrapClones[i++] = clone;
			}
		}	
	}
	
	
	void Update () {
			int xSign = (int)Mathf.Sign(transform.position.x);
			int ySign = (int)Mathf.Sign(transform.position.y);
			Vector3 teleport = Vector3.zero;
            if (Mathf.Abs(transform.position.x) > aspectRatio.x / 2)
			{
				teleport.x = aspectRatio.x * xSign;
			}
			if (Mathf.Abs(transform.position.y) > aspectRatio.y / 2)
			{
				teleport.y = aspectRatio.y * ySign;
			}
			transform.position = transform.position + teleport*-1;
	}
}
