using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestScript : MonoBehaviour
{

    //-external GameObjects
    public FiducialController tangible; //-tangible
    public GameObject symKey;

    //-components to GameObjects
    private ParticleSystem chest_ps; //-chest ParticleSystem 

    private Animator chest_fadingOBJ;  //-chest Animator
    private SpriteRenderer chest_SpriteRenderer; //-chest SpriteRenderer 
    //private Collider2D chest_collider; //-chest Collider


    private Animator text_Jumble;  //-text encoding Animator
    private SpriteRenderer text_SpriteRenderer; //-chest SpriteRenderer 


    private Animator symKey_Motion;  //-symmetric Animator

    private Color tmp;

    private GameObject child0, child1;
        

    // Use this for initialization
    void Start()
    {
        //-On Game Start
        //-init vars
        chest_ps = this.GetComponent<ParticleSystem>();

        child0 = this.transform.GetChild(0).gameObject;
        chest_fadingOBJ = child0.GetComponent<Animator>();
        chest_SpriteRenderer = child1.GetComponent<SpriteRenderer>();
        
        child1 = this.transform.GetChild(1).gameObject;
        text_Jumble = child1.GetComponent<Animator>();
        text_SpriteRenderer = child0.GetComponent<SpriteRenderer>();
        

        ///chest_collider = this.GetComponentInChildren<Collider2D>();

        symKey_Motion = symKey.GetComponent<Animator>();

        //-set the & turn off gradient ring
        var colOL = chest_ps.colorOverLifetime;
        var colbS = chest_ps.colorBySpeed;
        ///var em_symKey_ps = chest_ps.emission;

        colOL.enabled = true;   //-gradient ring
        colbS.enabled = false;  //-solid ring
                                ///em_symKey_ps.enabled = false; //-ring emission

        ///chest_fadingOBJ.enabled = false; //-sprite animator off
        ///chest_textJumble.enabled = false; //-sprite animator off

        //-alpha off chest sprite
        ///tmp = chest_SpriteRenderer.color;
        ///tmp.a = 0f;
        ///chest_SpriteRenderer.color = tmp;

        //-disable collider
        ///chest_collider.enabled = false;


        this.gameObject.SetActive(false);

        Debug.Log("CF : " + chest_fadingOBJ.name);
        Debug.Log("CSR : " + chest_SpriteRenderer.name);



        Debug.Log("TJ : " + text_Jumble.name);
        Debug.Log("TSR : " + text_SpriteRenderer.name);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //-on chest fiducial trigger:
        if (other.gameObject.tag == "chestFid")
        {
            //Debug.Log("Triggered");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var colOL = chest_ps.colorOverLifetime;
        var colbS = chest_ps.colorBySpeed;

        //-on chest fiducial stay:
        //-1. show solid ring
        //-2. turn sym key sprite animation off and fade out
        if (other.gameObject.tag == "chestFid")
        {
            //-show solid ring
            colOL.enabled = false;
            colbS.enabled = true;
            //-fade out animator sprite
            tmp = chest_SpriteRenderer.color;
            tmp.a -= 0.07f;
            chest_SpriteRenderer.color = tmp;
            //-stop animator
            chest_fadingOBJ.enabled = false;
            //Debug.Log("Staying");

            symKey_Motion.enabled = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        var colOL = chest_ps.colorOverLifetime;
        var colbS = chest_ps.colorBySpeed;

        if (other.gameObject.tag == "chestFid")
        {
            //-show gradient ring
            colOL.enabled = true;
            colbS.enabled = false;
            //-start symKey animator
            chest_fadingOBJ.enabled = true;

            //Debug.Log("Exiting");
        }
    }
}