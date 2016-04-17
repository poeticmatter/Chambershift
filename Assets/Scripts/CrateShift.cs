using UnityEngine;
using System.Collections;

public class CrateShift : MonoBehaviour {

	public float moveTime = 0.1f;

	private Rigidbody2D rb2D;
	private float inverseMoveTime;


	protected virtual void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		inverseMoveTime = 1f / moveTime;
	}


	void Update () {
	
	}

	public int getRoundedX()
	{
		return Mathf.RoundToInt(transform.position.x);
	}

	public int getRoundedY()
	{
		return Mathf.RoundToInt(transform.position.y);
	}

	protected IEnumerator SmoothMovement(Vector3 end)
	{
		GetComponent<ScreenWrapper>().enabled = false;
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

		while (sqrRemainingDistance > float.Epsilon)
		{
			Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
			rb2D.MovePosition(newPostion);
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}
		GetComponent<ScreenWrapper>().enabled = true;
	}

	public void Move(int x, int y)
	{
		StartCoroutine(SmoothMovement(transform.position + new Vector3(x,y,0)));
	}
}
