using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_PrivKeyToA : MonoBehaviour
{
    public bool A_PrivKeyAnimationDone { get; set; } // Animation done indicator

    //Use this for initialization
    void Start ()
	{
	    A_PrivKeyAnimationDone = false;
	}
	
	//wait for user input and turn on chest b placeholder
    void EndofMoveAnimation()
    {
        A_PrivKeyAnimationDone = true; //indicate animation done from user b.
    }
}
