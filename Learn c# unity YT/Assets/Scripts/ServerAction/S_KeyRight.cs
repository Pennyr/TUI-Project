using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_KeyRight : MonoBehaviour {

    public bool rightKeyTransmitted { get; set; }

	void Start ()
	{
	    rightKeyTransmitted = false;
	}

    void KeytoUser()
    {
        rightKeyTransmitted = true;
    }
}
