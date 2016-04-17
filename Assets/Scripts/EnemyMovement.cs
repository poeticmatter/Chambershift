using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Transform leftCheck;
	public Transform rightCheck;
	public Transform groundCheck;

	public bool facingRight = false;
	public bool bumpLeft = false;
	public bool bumpRight = false;
	public float moveForce = 365f;
	public float maxSpeedHorizontal = 1f;
	public float maxSpeedVertical = 1f;

	private Vector3 velocity = Vector3.zero;


	private bool grounded = false;
	public Animator anim;
	public SpriteRenderer spriteRenderer;
	private Rigidbody2D rb2d;


	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if (Physics2D.Linecast(transform.position, leftCheck.position, 1 << LayerMask.NameToLayer("Ground")))
		{
			bumpLeft = true;
		}
		else if ( Physics2D.Linecast(transform.position, rightCheck.position, 1 << LayerMask.NameToLayer("Ground")))
		{
			bumpRight = true;
		}
	}

	void FixedUpdate()
	{
		HandleInput();
		CapSpeed();
		if (bumpLeft)
		{
			SetFacingRight(true);
			bumpLeft = false;
		}
		else if (bumpRight)
		{
			SetFacingRight(false);
			bumpRight = false;
		}
	}

	private void HandleInput()
	{
		float direction = facingRight ? 0.1f : -0.1f;
		if (grounded)
		{
			anim.SetFloat("Speed", Mathf.Abs(direction) * 2);
			
		}
		else
		{
			anim.SetFloat("Speed", 0);
			direction *= 0.1f;
		}

		if (direction * rb2d.velocity.x < maxSpeedHorizontal)
		{
			rb2d.AddForce(Vector2.right * direction * moveForce);
		}

	}

	private void CapSpeed()
	{
		if (Mathf.Abs(rb2d.velocity.x) > maxSpeedHorizontal)
		{
			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeedHorizontal, rb2d.velocity.y);
		}
		if (Mathf.Abs(rb2d.velocity.y) > maxSpeedVertical)
		{
			rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Sign(rb2d.velocity.y) * maxSpeedVertical);
		}
	}

	private void SetFacingRight(bool facingRight)
	{
		if(this.facingRight != facingRight)
		{
			this.facingRight = facingRight;
			spriteRenderer.flipX = facingRight;
		}
	}
}

