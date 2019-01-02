using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_PubKeyToSrv : MonoBehaviour
{
    public bool A_PubKeyInteractionDone { get; set; } // interaction done indicator

    //Use this for initialization
    void Start ()
	{
	    A_PubKeyInteractionDone = false;
	}
	
	//wait for user input and turn on chest b placeholder
    void EndofMoveAnimation()
    {
        A_PubKeyInteractionDone = true; //indicate animation done from user b.
    }
}
