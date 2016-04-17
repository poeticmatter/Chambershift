using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour
{

	[HideInInspector]
	public bool facingRight = true;
	public float moveForce = 365f;
	public float maxSpeedHorizontal = 1f;
	public float maxSpeedVertical = 1f;

	public Transform groundCheck;

	public float freezeTime = 0;

	private Vector3 velocity = Vector3.zero;


	private bool grounded = false;
	public Animator anim;
	private Rigidbody2D rb2d;


	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
	}

	void FixedUpdate()
	{
		if (freezeTime > 0)
		{
			freezeTime-= Time.fixedDeltaTime;
			if (freezeTime<=0)
			{
				rb2d.velocity = velocity;
				velocity = Vector3.zero;
			} else
			{
				rb2d.velocity = Vector3.zero;
			}
		}
		else
		{
			HandleInput();
			CapSpeed();
		}
	}

	private void HandleInput()
	{
		float h = Input.GetAxis("Horizontal");
		if(grounded)
		{
			anim.SetFloat("Speed", Mathf.Abs(h)*2);
		}
		else
		{
			anim.SetFloat("Speed", 0);
		}

		if (h * rb2d.velocity.x < maxSpeedHorizontal)
		{
			rb2d.AddForce(Vector2.right * h * moveForce);
		}
		if (h > 0 && !facingRight)
		{
			Flip();
		}
		else if (h < 0 && facingRight)
		{
			Flip();
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


	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void FreezeFor(float time)
	{
		velocity = rb2d.velocity;
		rb2d.velocity = Vector3.zero;
		freezeTime = time;


	}
}
