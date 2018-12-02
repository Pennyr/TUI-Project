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

    private Vector3 collBounds;

    // Use this for initialization
    void Start() // On Game Start
    {

        collBounds = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
 
        // Get reference to children objects
        childGameObjects.Add("userImg", this.transform.GetChild(0).gameObject);         // user icon
        childGameObjects.Add("menuSelector", this.transform.GetChild(1).gameObject);    // menu child object
        childGameObjects.Add("menu", this.transform.GetChild(2).gameObject);            // menu child object

        // initialise variables
        user_ps = this.GetComponent<ParticleSystem>();
        user_fadingOBJ = childGameObjects["userImg"].GetComponent<Animator>();
        user_SpriteRenderer = childGameObjects["userImg"].GetComponent<SpriteRenderer>();

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
            //Delete//
            /*
            if (other.bounds.Contains(collBounds))
            {
                //Delete//
                Debug.Log("Fully inside");
            }
            */

            // get initial tangible angle
            if (!initialOnce)
            {
                childGameObjects["menu"].SetActive(true); // enable menu on fiducial in
                childGameObjects["menuSelector"].SetActive(true); // enable menuSelector on fiducial in
                childGameObjects["userImg"].SetActive(false); // disable image
                // show solid ring
                colOL.enabled = false;
                colbS.enabled = true;

                initial = tangible.AngleDegrees;
                offset = 60 - initial;

                initialOnce = true;
                //Delete// childGameObjects["menu"].transform.GetChild(0).gameObject.GetComponent<Animator>().SetFloat("offset", offset);
                //Delete//Debug.Log("Hello 1");
            }

            //Delete// fade out animator sprite
            /*
            while (tmp.a != 0f)
            {
                tmp = user_SpriteRenderer.color;
                tmp.a -= 0.07f;
                user_SpriteRenderer.color = tmp;
                Debug.Log("tmp.a != 0f");
            }
            
            // stop animator
            user_fadingOBJ.enabled = false;
            */
            now = tangible.AngleDegrees;
            now += offset;
            //Delete//Debug.Log("Hello 2");
            if (now > pointerStart && now < pointerEnd) // if tangible angle is within range & clip tangible rotation to pointer limits
            {
                childGameObjects["menuSelector"].transform.rotation = Quaternion.Euler(180,0,now);

                //Delete//childGameObjects["menu"].transform.GetChild(0).gameObject.GetComponent<Animator>().SetFloat("rotation", now);
                //Delete//childGameObjects["menu"].transform.GetChild(0).gameObject.GetComponent<Animator>().SetFloat("rotationoriginal", tangible.AngleDegrees);
                //Delete//Debug.Log("Hello 3");

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
            childGameObjects["userImg"].SetActive(true); // enable image
            // show gradient ring
            colOL.enabled = true;
            colbS.enabled = false;
            // start server animator
            user_fadingOBJ.enabled = true;

            initialOnce = false;
            //Delete//Debug.Log("Hello 4");

        }
    }


}
