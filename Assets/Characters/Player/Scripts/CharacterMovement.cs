using System;
using Boo.Lang;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	private bool facingRight = true;
	private bool jump = false;

	public float moveForce = 50f;
	public float jumpForce = 200f;
	public float brakeForce = 10f;
	public Transform groundCheck1;
	public Transform groundCheck2;
	public float turningSpeed = 15;
	
	public bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;

	public float horizontalMovement;
	
	public bool Jump()
	{
		if (IsGrounded()) {
			jump = true;
			return true;
		}
		return false;
	}

	public void Brake()
	{
	
		//if (IsGrounded())
		{
			if (Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon)
			{
				float brakeAmount = Mathf.Sign(rb2d.velocity.x) * brakeForce * Time.deltaTime;

				float velX;

				if (Mathf.Abs(rb2d.velocity.x) < Mathf.Abs(brakeAmount))
				{
					velX = 0f;
				}
				else
				{
					velX = rb2d.velocity.x - brakeAmount;
				}
				
				rb2d.velocity = new Vector2(velX, rb2d.velocity.y);
			}
		}
	}
	
	void Awake ()
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate()
	{
		if (currentAngle < targetAngle)
		{
			currentAngle += turningSpeed;
		}
		if (currentAngle > targetAngle)
		{
			currentAngle -= turningSpeed;
			
		}

		RotateToAngle(currentAngle);
		
		rb2d.AddForce(new Vector2(horizontalMovement * moveForce, 0f));
		
		if (IsGrounded())
		{
			rb2d.AddForce(new Vector2(0f, 80f));

		}

		if (horizontalMovement > 0 && !facingRight)
		{
			Flip();
		}

		else if (horizontalMovement < 0 && facingRight)
		{
			Flip();
		}

		if (jump)
		{
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}

	private bool flippingRight;
	
	void Flip()
	{
		facingRight = !facingRight;
		targetAngle = facingRight ? 0 : 180;
	}

	bool IsGrounded()
	{
		return Physics2D.Linecast(transform.position, groundCheck1.position, 1 << LayerMask.NameToLayer("Ground"))
			|| Physics2D.Linecast(transform.position, groundCheck2.position, 1 << LayerMask.NameToLayer("Ground"));

	}

	private float currentAngle = 0;
	private float targetAngle = 0;

	private void RotateToAngle(float degrees)
	{
		rb2d.transform.rotation = Quaternion.Euler(0f, degrees, 0f);
	}
}
