using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ScreenWrapper))]
[RequireComponent(typeof(Rigidbody2D))]
public class MovingObject: MonoBehaviour {

	private Rigidbody2D rb2D;
	private ScreenWrapper screenWrapper;
	public bool moving = false;

	void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
		screenWrapper = GetComponent<ScreenWrapper>();
	}

	public int getRoundedX()
	{
		return Mathf.RoundToInt(transform.position.x);
	}

	public int getRoundedY()
	{
		return Mathf.RoundToInt(transform.position.y);
	}
	
	public bool SamePosition(MovingObject other)
	{
		return getRoundedX() == other.getRoundedX() && getRoundedY() == other.getRoundedY();
    }

	protected IEnumerator SmoothMovement(Vector3 direction, float inverseMoveTime)
	{
		OnMoveStart();
		float sqrRemainingDistance = (transform.position - direction).sqrMagnitude;
		while (sqrRemainingDistance > float.Epsilon)
		{
			Vector3 newPostion = Vector3.MoveTowards(rb2D.position, direction, inverseMoveTime * Time.fixedDeltaTime);
			rb2D.MovePosition(newPostion);
			sqrRemainingDistance = (transform.position - direction).sqrMagnitude;
			yield return new WaitForFixedUpdate();
		}
		OnMoveComplete();
	}

	protected virtual void OnMoveComplete()
	{
		screenWrapper.enabled = true;
		moving = false;
	}

	protected virtual void OnMoveStart()
	{
		screenWrapper.enabled = false;
		moving = true;
	}

	public void Move(int x, int y, float inverseMoveTime)
	{
		StartCoroutine(SmoothMovement(transform.position + new Vector3(x,y,0), inverseMoveTime));
	}
}
