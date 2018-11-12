using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    // any object in the screen that can have a position, rotation and scale
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private bool isTouchingGround;

	// Use this for initialization
	void Start ()
	{
	    rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
	    movement = Input.GetAxis("Horizontal");
	    if (movement > 0f)
	    {
	        rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else if (movement < 0f)
	    {
	        rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
	    }
	    else {
	        rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
	    }

        // extra keys
        // if(Input.GetButtonDown("Jump") && isTouchingGround){
        //  rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
    }
}
