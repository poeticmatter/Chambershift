using UnityEngine;
using System.Collections;

public class EnemyMovement : MovingObject {

	public Transform leftCheck;
	public Transform rightCheck;

	public bool facingRight = false;
	public bool bumpLeft = false;
	public bool bumpRight = false;

	public SpriteRenderer spriteRenderer;


	public void Advance(float inverseMoveTime)
	{
		UpdateFacing();
        Debug.Log("bumpRight " + bumpRight + " bumpLeft " + bumpLeft);
		if (facingRight && !bumpRight)
		{
			Move(1, 0, inverseMoveTime);
		}
		else if (!facingRight && !bumpLeft)
		{
			Move(-1, 0, inverseMoveTime);
		}
	}

	private void UpdateFacing()
	{
		bumpLeft = CheckBump(leftCheck.position);
		bumpRight = CheckBump(rightCheck.position);
		if (bumpLeft || bumpRight)
		{
			SetFacingRight(bumpLeft);
		}
		
	}

	private bool CheckBump(Vector2 to)
	{
		return Physics2D.Linecast(transform.position, to, 1 << LayerMask.NameToLayer("Ground"));
	}

	private void SetFacingRight(bool facingRight)
	{
		if (this.facingRight != facingRight)
		{
			this.facingRight = facingRight;
			spriteRenderer.flipX = facingRight;
		}
	}
}

