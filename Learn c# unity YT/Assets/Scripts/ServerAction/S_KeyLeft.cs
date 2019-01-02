using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_KeyLeft : MonoBehaviour {

    public bool leftKeyTransmitted { get; set; }

	void Start ()
	{
	    leftKeyTransmitted = false;
	}

    void KeytoUser()
    {
        leftKeyTransmitted = true;
    }
}
