using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userAScript : MonoBehaviour {

    public FiducialController tangible; // fiducial for this user

    private GameObject MenuAnimator; //-menu Animator
    private ParticleSystem user_ps; //-user ParticleSystem 
    private Animator user_fadingOBJ;  //-user Animator
    private SpriteRenderer user_SpriteRenderer; //-user SpriteRenderer 
    private Color tmp;
    private string fiducialTag = "userA";

    // Use this for initialization
    void Start()
    {
        //-On Game Start
        //-init vars
        MenuAnimator = this.transform.GetChild(9).gameObject;

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
        MenuAnimator.SetActive(true); // enable menu

        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        //-on server fiducial stay:
        //-1. show solid ring
        //-2. turn server sprite animation off and fade out
        if (other.gameObject.tag == fiducialTag)
        {
            //-show solid ring
            colOL.enabled = false;
            colbS.enabled = true;
            //-fade out animator sprite
            tmp = user_SpriteRenderer.color;
            tmp.a -= 0.07f;
            user_SpriteRenderer.color = tmp;
            //-stop animator
            user_fadingOBJ.enabled = false;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        MenuAnimator.SetActive(false); // disable menu

        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        //-on server fiducial stay:
        //-1. show gradient ring
        //-2. turn server sprite animation on and visible
        if (other.gameObject.tag == fiducialTag)
        {
            //-show gradient ring
            colOL.enabled = true;
            colbS.enabled = false;
            //-start server animator
            user_fadingOBJ.enabled = true;

        }
    }


}
