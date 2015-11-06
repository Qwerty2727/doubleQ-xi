using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	Rigidbody2D rb;
	public float speed;
	float velocityY = 0f;
	public float jumpPower;
	public bool isGrounded = false; //this can be seen working in the Unity inspector
	public Transform groundedEndLeft;//declares the empty game object in Unity acting as a collider set to the position of the player
	public Transform groundedEndMid;
	public Transform groundedEndRight;

	// Use this for initialization
	void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		if (Physics2D.Linecast (this.transform.position, groundedEndLeft.position, 1 << LayerMask.NameToLayer ("Ground")))
		{
			isGrounded = true;
		}
		else 
		{
			if(Physics2D.Linecast (this.transform.position, groundedEndMid.position, 1 << LayerMask.NameToLayer ("Ground")))
			{
				isGrounded = true;
			}
			else 
			{
				if(Physics2D.Linecast (this.transform.position, groundedEndRight.position, 1 << LayerMask.NameToLayer ("Ground")))
				{
					isGrounded = true;
				}
				else
				{
					isGrounded = false;
				}
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		float velocityX = 0f;

		if (Input.GetKey (KeyCode.LeftArrow))
		{
			velocityX = speed * -1f;
		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
			velocityX = speed * 1f;
			if (Input.GetKey (KeyCode.LeftArrow))
			{
				velocityX = 0f;
			}
		}
		if (Input.GetKeyDown (KeyCode.Z)) 
		{		
			if (isGrounded)
			{
				rb.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
				isGrounded = false;
			}
		}
		if (Input.GetKey (KeyCode.Z))
		{
			if (rb.velocity.y >= jumpPower)
			{
				velocityY = jumpPower;
			}
			else
			{
				velocityY = rb.velocity.y;
			}
		}
		else
		{
			if (rb.velocity.y <= 0f)
			{
				velocityY = rb.velocity.y;
			}
			else
			{
				velocityY = 0f;
			}
		}
		rb.velocity = new Vector2(velocityX,velocityY);
	}
	
}
