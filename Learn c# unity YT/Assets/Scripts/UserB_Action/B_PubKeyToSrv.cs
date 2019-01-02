using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_PubKeyToSrv : MonoBehaviour
{
    public bool B_PubKeyInteractionDone { get; set; } // interaction done indicator

    //Use this for initialization
    void Start ()
	{
	    B_PubKeyInteractionDone = false;
	}
	
	//wait for user input and turn on chest b placeholder
    void EndofMoveAnimation()
    {
        B_PubKeyInteractionDone = true; //indicate animation done from user b.
    }
}
