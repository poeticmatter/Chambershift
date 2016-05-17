using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovingObject))]
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
				BoxCollider2D box2d = GetComponent<BoxCollider2D>();
				if (box2d)
				{
					clone.gameObject.AddComponent<BoxCollider2D>();
					clone.gameObject.GetComponent<BoxCollider2D>().size = box2d.size;
					clone.gameObject.GetComponent<BoxCollider2D>().offset = box2d.offset;
					clone.gameObject.layer = LayerMask.NameToLayer("Ground");
                }
				wrapClones[i++] = clone;
			}
		}	
	}
	
	void Update () {
		Vector3 teleport = Vector3.zero;
		teleport.x = GetTeleport(transform.position.x, aspectRatio.x);
		teleport.y = GetTeleport(transform.position.y, aspectRatio.y);
		if(teleport.x != 0 || teleport.y != 0) 
		transform.position = transform.position + teleport;
	}

	private float GetTeleport(float postion, float aspectRatio)
	{
		if (postion < 0)
		{
			return aspectRatio;
		}
		if (postion > aspectRatio)
		{
			return -aspectRatio;
		}
		return 0;
	}
}
