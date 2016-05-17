using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovingObject))]
public class FallingObject : MonoBehaviour {

	public Transform groundCheck;
	private MovingObject movingObject;

	public MovingObject MovingObject
	{
		get { return movingObject; }
	}

	void Awake()
	{
		movingObject = GetComponent<MovingObject>();
	}

	public bool IsGrounded()
	{
		return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
	}
}
