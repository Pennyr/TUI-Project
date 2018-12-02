using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void EndOfAnimation()
    {
        // Turns object off @ end of animation
        this.gameObject.SetActive(false);

    }
}
