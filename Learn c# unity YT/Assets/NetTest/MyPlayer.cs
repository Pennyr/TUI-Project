using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    private Rigidbody rb;
    public MyClient client;

	// Use this for initialization
	void Start ()
	{
	    rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{

	    float xMove = Input.GetAxis("Horizontal");
	    float yMove = Input.GetAxis("Vertical");
        transform.Translate(xMove, 0, yMove);

	    if (xMove != 0 || yMove != 0)
	    {
            string msg = "Move| " + xMove.ToString() + "|" + yMove.ToString();
	        client.SendMessage(msg);
        }
	    
		
	}
}
