﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keyServScript : MonoBehaviour {

    public FiducialController tangible; // fiducial for this user

    private ParticleSystem user_ps; // UserA ParticleSystem 
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();
    
    private string fiducialTag = "serverFid";
    private bool initialOnce = false; //-enable other animator only once
    private bool keySelection = false;

    private float now, offset, initial;
    private float pointerStart_Key = 90;
    private float pointerEnd_Key = 270;

    private Vector3 collBounds;

    // Use this for initialization
    void Start() // On Game Start
    {

        collBounds = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
 
        // Get reference to children objects
        childGameObjects.Add("userImg", this.transform.GetChild(0).gameObject);         // user icon
        childGameObjects.Add("menuSelector", this.transform.GetChild(1).gameObject);    // menu selector child object
        childGameObjects.Add("userMenu", this.transform.GetChild(2).gameObject);        // user menu child object
        childGameObjects.Add("action", this.transform.GetChild(3).gameObject);          // user action child object

        // initialise variables
        user_ps = this.GetComponent<ParticleSystem>();

        // show gradient ring
        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        colOL.enabled = true;   //-gradient ring
        colbS.enabled = false;  //-solid ring

        
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
            Debug.Log("Trigger Stay Key Server Script");

            // get initial tangible angle
            if (!initialOnce)
            {
                childGameObjects["userImg"].SetActive(false); // disable image
                childGameObjects["menuSelector"].SetActive(true); // enable menuSelector on fiducial in
                childGameObjects["userMenu"].SetActive(true); // enable user menu on fiducial in

                // show solid ring
                colOL.enabled = false;
                colbS.enabled = true;

                initialOnce = true;

            }


            if (childGameObjects["userMenu"].activeSelf)
            {
                now = tangible.AngleDegrees + 90;

                if (now < 0)
                    now = tangible.AngleDegrees;

                if (now > pointerStart_Key && now < pointerEnd_Key) // if tangible angle is within range & clip tangible rotation to pointer limits
                {
                    childGameObjects["menuSelector"].transform.rotation = Quaternion.Euler(180,0,now);
                }
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit Key Server Script");

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

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Reloaded!!");
        }

    }


}
