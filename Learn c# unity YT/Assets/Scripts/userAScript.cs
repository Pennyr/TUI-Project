using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userAScript : MonoBehaviour {

    public FiducialController tangible; // fiducial for this user

    private ParticleSystem user_ps; // UserA ParticleSystem 
    private Animator user_fadingOBJ;  // UserA Animator
    private SpriteRenderer user_SpriteRenderer; // UserA SpriteRenderer 
    private Color tmp; // UserA Sprite Color
    
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();
    
    private string fiducialTag = "userA";
    private bool initialOnce = false; //-enable other animator only once

    private float prev = 60;
    private float now;
    private float initial;
    private float offset;
    private float pointerStart = 60;
    private float pointerEnd = 120;

    // Use this for initialization
    void Start() // On Game Start
    {
        
        // Get reference to children objects
        childGameObjects.Add("userImg", this.transform.GetChild(0).gameObject);         // user icon
        childGameObjects.Add("rawDataUserB", this.transform.GetChild(1).gameObject);    // send raw data to user B
        childGameObjects.Add("rawDataHkr", this.transform.GetChild(2).gameObject);      // send raw data to hacker
        childGameObjects.Add("encDataUserB", this.transform.GetChild(3).gameObject);    // send encrypted data to user B
        childGameObjects.Add("encDataHkr", this.transform.GetChild(4).gameObject);      // send encrypted data to hacker
        childGameObjects.Add("keyUserB", this.transform.GetChild(5).gameObject);        // send key to user B
        childGameObjects.Add("keyHkr", this.transform.GetChild(6).gameObject);          // send key to hacker
        childGameObjects.Add("encData", this.transform.GetChild(7).gameObject);         // data encryption animation
        childGameObjects.Add("decryData", this.transform.GetChild(8).gameObject);       // data decryption animation
        childGameObjects.Add("menuSelector", this.transform.GetChild(9).gameObject);    // menu child object
        childGameObjects.Add("menu", this.transform.GetChild(10).gameObject);            // menu child object

        //-init vars
        user_ps = this.GetComponent<ParticleSystem>();
        user_fadingOBJ = this.GetComponentInChildren<Animator>();
        user_SpriteRenderer = this.GetComponentInChildren<SpriteRenderer>();

        //-show gradient ring
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
        if (other.gameObject.tag == fiducialTag)
        {
            // get initial tangible angle
            if (!initialOnce)
            {
                childGameObjects["menu"].SetActive(true); // enable menu on fiducial in
                childGameObjects["menuSelector"].SetActive(true); // enable menuSelector on fiducial in

                // show solid ring
                colOL.enabled = false;
                colbS.enabled = true;
                // fade out animator sprite
                tmp = user_SpriteRenderer.color;
                tmp.a -= 0.07f;
                user_SpriteRenderer.color = tmp;
                // stop animator
                user_fadingOBJ.enabled = false;

                initial = tangible.AngleDegrees;
                offset = 60 - initial;

                initialOnce = true;
            }
            
            now = tangible.AngleDegrees;
            now += offset;

            if (now > pointerStart && now < pointerEnd) // if tangible angle is within range & clip tangible rotation to pointer limits
            {
                childGameObjects["menuSelector"].transform.rotation = Quaternion.Euler(180,0,now);

                childGameObjects["menu"].transform.GetChild(0).gameObject.GetComponent<Animator>().SetFloat("rotation", now);


            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        //-on server fiducial stay:
        //-1. show gradient ring
        //-2. turn server sprite animation on and visible
        if (other.gameObject.tag == fiducialTag)
        {
            childGameObjects["menu"].SetActive(false); // disable menu on fiducial out
            childGameObjects["menuSelector"].SetActive(false); // disable menuSelector on fiducial out

            //-show gradient ring
            colOL.enabled = true;
            colbS.enabled = false;
            //-start server animator
            user_fadingOBJ.enabled = true;

            initialOnce = false;

        }
    }


}
