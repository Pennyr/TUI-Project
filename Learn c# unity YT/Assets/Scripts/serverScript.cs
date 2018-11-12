using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class serverScript : MonoBehaviour
{
    //-external GameObjects
    public FiducialController tangible; //-tangible
    public GameObject symKey; //-symmetric GameObject 

    //-components to GameObjects
    private ParticleSystem server_ps; //-server ParticleSystem 
    private Animator server_fadingOBJ;  //-server Animator
    private SpriteRenderer server_SpriteRenderer; //-server SpriteRenderer 
    
    private Color tmp;
    private bool triggerOnce = false; //-enable other animator only once

    // Use this for initialization
    void Start()
    {
        //-On Game Start
        //-init vars
        server_ps = this.GetComponent<ParticleSystem>();
        server_fadingOBJ = this.GetComponentInChildren<Animator>();
        server_SpriteRenderer = this.GetComponentInChildren<SpriteRenderer>();

        //-show gradient ring
        var colOL = server_ps.colorOverLifetime;
        var colbS = server_ps.colorBySpeed;

        colOL.enabled = true;   //-gradient ring
        colbS.enabled = false;  //-solid ring
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        //-on server fiducial trigger:
        //-1. turn symmetric sprite animation on and visible
        if (other.gameObject.tag == "serverFid")
        {
            // Debug.Log("Triggered");

            if (!triggerOnce)
            {
                symKey.gameObject.SetActive(true);
                triggerOnce = true;
            }
            
        }
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var colOL = server_ps.colorOverLifetime;
        var colbS = server_ps.colorBySpeed;
        
        //-on server fiducial stay:
        //-1. show solid ring
        //-2. turn server sprite animation off and fade out
        if (other.gameObject.tag == "serverFid")
        {
            //-show solid ring
            colOL.enabled = false;
            colbS.enabled = true;
            //-fade out animator sprite
            tmp = server_SpriteRenderer.color;
            tmp.a -= 0.07f;
            server_SpriteRenderer.color = tmp;
            //-stop animator
            server_fadingOBJ.enabled = false;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var colOL = server_ps.colorOverLifetime;
        var colbS = server_ps.colorBySpeed;

        //-on server fiducial stay:
        //-1. show gradient ring
        //-2. turn server sprite animation on and visible
        if (other.gameObject.tag == "serverFid")
        {
            //-show gradient ring
            colOL.enabled = true;
            colbS.enabled = false;
            //-start server animator
            server_fadingOBJ.enabled = true;

        }
    }


}
