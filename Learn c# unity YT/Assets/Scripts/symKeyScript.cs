using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class symKeyScript : MonoBehaviour {

    //-external GameObjects
    public FiducialController tangible; //-tangible
    public GameObject chest; //-chest GameObject 

    //-components to GameObjects
    private ParticleSystem symKey_ps; //-symKey ParticleSystem 
    private Animator symKey_fadingOBJ;  //-symKey Animator
    private Animator symKey_MergeMove;  //-symKey Animator
    private SpriteRenderer symKey_SpriteRenderer; //-symKey SpriteRenderer 
    ///private Collider2D symKey_collider; //-symmetric Collider

    ///private ParticleSystem chest_ps; //-symmetric ParticleSystem 
    ///private Animator chest_fadingOBJ;  //-symmetric Animator
    ///private Collider2D chest_collider; //-symmetric Collider

    private Color tmp;
    private bool triggerOnce = false; //-enable other animator only once

    // Use this for initialization
    void Start()
    {
        //-On Game Start
        //-init vars
        symKey_ps = this.GetComponent<ParticleSystem>();

        symKey_MergeMove = this.GetComponent<Animator>();
        
        symKey_fadingOBJ = this.transform.GetChild(0).GetComponent<Animator>();
        
        symKey_SpriteRenderer = this.GetComponentInChildren<SpriteRenderer>();

        ///symKey_collider = this.GetComponentInChildren<Collider2D>();


        ///chest_ps = chest.GetComponent<ParticleSystem>();

        ///chest_fadingOBJ = chest.GetComponentInChildren<Animator>();

        ///chest_collider = chest.GetComponentInChildren<Collider2D>();

        //-set the & turn off gradient ring
        var colOL = symKey_ps.colorOverLifetime;
        var colbS = symKey_ps.colorBySpeed;
        ///var em_symKey_ps = symKey_ps.emission;
        

        colOL.enabled = true;   //-gradient ring
        colbS.enabled = false;  //-solid ring

        this.gameObject.SetActive(false);
        symKey_MergeMove.enabled = false; //-motion animator off

        ///em_symKey_ps.enabled = false; //-ring emission

        ///symKey_fadingOBJ.enabled = false; //-sprite animator off
        

        //-alpha off sym Key sprite
        ///tmp = symKey_SpriteRenderer.color;
        ///tmp.a = 0f;
        ///symKey_SpriteRenderer.color = tmp;

        //-disable collider
        ///symKey_collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(symKey_MergeMove.GetCurrentAnimatorStateInfo(0).IsName("moveSymKeyOne"));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //-on symKey fiducial trigger:
        //-1. turn chest sprite animation on and visible
        if (other.gameObject.tag == "symKeyFid")
        {
            // Debug.Log("Triggered");
            ///var em_chest = chest_ps.emission;
            ///em_chest.enabled = true;

            if (!triggerOnce)
            {
                ///chest_fadingOBJ.enabled = true; //-chest sprite animator on
                ///chest_collider.enabled = true; //-chest collider on
                chest.gameObject.SetActive(true);
                triggerOnce = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var colOL = symKey_ps.colorOverLifetime;
        var colbS = symKey_ps.colorBySpeed;

        //-on sym key fiducial stay:
        //-1. show solid ring
        //-2. turn sym key sprite animation off and fade out
        if (other.gameObject.tag == "symKeyFid")
        {
            //-show solid ring
            colOL.enabled = false;
            colbS.enabled = true;
            //-fade out animator sprite
            tmp = symKey_SpriteRenderer.color;
            tmp.a -= 0.07f;
            symKey_SpriteRenderer.color = tmp;
            //-stop animator
            symKey_fadingOBJ.enabled = false;
            //Debug.Log("Staying");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var colOL = symKey_ps.colorOverLifetime;
        var colbS = symKey_ps.colorBySpeed;

        if (other.gameObject.tag == "symKeyFid")
        {
            //-show gradient ring
            colOL.enabled = true;
            colbS.enabled = false;
            //-start symKey animator
            symKey_fadingOBJ.enabled = true;

            //Debug.Log("Exiting");
        }
    }

    void OnStateExit()
    {
        Debug.Log("Animation Finished");
    }

}
