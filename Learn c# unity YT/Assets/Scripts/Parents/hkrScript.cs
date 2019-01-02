﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hkrScript : MonoBehaviour {

    public FiducialController tangible; // fiducial for this user

    private ParticleSystem user_ps; // UserA ParticleSystem 
    private GameObject userImg;

    private string fiducialTag = "hackerFid";
    private bool initialOnce = false; //-enable other animator only once
    
    private Vector3 collBounds;

    // Use this for initialization
    void Start() // On Game Start
    {

        collBounds = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        userImg = this.transform.GetChild(0).gameObject;

        // initialise variables
        user_ps = this.GetComponent<ParticleSystem>();

        // show gradient ring
        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        colOL.enabled = true;   //-gradient ring
        colbS.enabled = false;  //-solid ring

        
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
            //Debug.Log("Trigger Stay hackerFid Script");
            //get initial tangible angle
            if (!initialOnce)
            {
                // show solid ring
                colOL.enabled = false;
                colbS.enabled = true;
                userImg.SetActive(false);

                initialOnce = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Trigger Exit hackerFid Script");

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
            userImg.SetActive(true);

            initialOnce = false;
        }
    }
}
