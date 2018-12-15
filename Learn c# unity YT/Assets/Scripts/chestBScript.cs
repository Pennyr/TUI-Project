using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class chestBScript : MonoBehaviour {

    public FiducialController tangible; // fiducial for this user

    private ParticleSystem user_ps; // UserA ParticleSystem 
   
    private string fiducialTag = "chestFid";
    //private bool initialOnce = false; //-enable other animator only once
    public bool initialOnce { get; set; }
    public bool B_KeyIn { get; set; }

    
    private Vector3 collBounds;

    // Use this for initialization
    void Start() // On Game Start
    {

        collBounds = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        // initialise variables
        user_ps = this.GetComponent<ParticleSystem>();

        // show gradient ring
        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        colOL.enabled = true;   //-gradient ring
        colbS.enabled = false;  //-solid ring

        initialOnce = false;
        B_KeyIn = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        

        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        //-on server fiducial stay:
        //-1. show solid ring
        //-2. turn server sprite animation off and fade out
        if (other.gameObject.tag == fiducialTag && other.bounds.Contains(collBounds))
        {
            Debug.Log("Trigger Stay Chest B Script");

            // get initial tangible angle
            if (!initialOnce)
            {
                // show solid ring
                colOL.enabled = false;
                colbS.enabled = true;

                initialOnce = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit Chest B Script");

        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        //-on server fiducial stay:
        //-1. show gradient ring
        //-2. turn server sprite animation on and visible
        if (other.gameObject.tag == fiducialTag)
        {
            // show gradient ring
            colOL.enabled = true;
            colbS.enabled = false;

            initialOnce = false;
            B_KeyIn = false;
        }

        // Reset any ongoing animations
    }

    // René function for detecting key in and toggle boolean B_KeyIn
}
