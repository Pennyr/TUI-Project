using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class userAScript : MonoBehaviour {

    public FiducialController tangible; // fiducial for this user

    private ParticleSystem user_ps; // UserA ParticleSystem 
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();
    
    private string fiducialTag = "userA";
    private bool initialOnce = false; //-enable other animator only once

    private float now;
    private float initial;
    private float pointerStart = 60;
    private float pointerEnd = 120;

    private Vector3 collBounds;

    // Use this for initialization
    void Start() // On Game Start
    {

        collBounds = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
 
        // Get reference to children objects
        childGameObjects.Add("userImg", this.transform.GetChild(0).gameObject);         // user icon
        childGameObjects.Add("menuSelector", this.transform.GetChild(1).gameObject);    // menu selector child object
        childGameObjects.Add("keyMenu", this.transform.GetChild(2).gameObject);         // sym/asym menu child object
        childGameObjects.Add("userMenu", this.transform.GetChild(3).gameObject);        // user menu child object
        childGameObjects.Add("action", this.transform.GetChild(4).gameObject);          // user menu child object

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
            Debug.Log("Trigger Stay User A Script");

            // get initial tangible angle
            if (!initialOnce)
            {
                childGameObjects["userImg"].SetActive(false); // disable image
                childGameObjects["menuSelector"].SetActive(true); // enable menuSelector on fiducial in
                childGameObjects["keyMenu"].SetActive(true); // enable menu on fiducial in

                // show solid ring
                colOL.enabled = false;
                colbS.enabled = true;

                initial = tangible.AngleDegrees;
                //offset = 60 - initial;

                initialOnce = true;

            }

            now = tangible.AngleDegrees;
            //now += offset;

            if (now > pointerStart && now < pointerEnd) // if tangible angle is within range & clip tangible rotation to pointer limits
            {
                childGameObjects["menuSelector"].transform.rotation = Quaternion.Euler(180,0,now);

                if (childGameObjects["keyMenu"].activeSelf)
                    childGameObjects["keyMenu"].GetComponent<Animator>().SetFloat("rotation", now);
            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit User A Script");

        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        //-on server fiducial stay:
        //-1. show gradient ring
        //-2. turn server sprite animation on and visible
        if (other.gameObject.tag == fiducialTag)
        {
            childGameObjects["userImg"].SetActive(true); // enable image
            childGameObjects["menuSelector"].SetActive(false); // disable menuSelector on fiducial out
            childGameObjects["keyMenu"].SetActive(false); // disable menu on fiducial out
            childGameObjects["userMenu"].SetActive(false); // disable menu on fiducial out
            childGameObjects["action"].SetActive(false); // disable actions on fiducial out

            // show gradient ring
            colOL.enabled = true;
            colbS.enabled = false;

            initialOnce = false;
        }

        // Reset any ongoing animations
    }


}
