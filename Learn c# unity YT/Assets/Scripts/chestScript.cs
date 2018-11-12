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

    private GameObject child0, child1;
    private Animator chest_fadingOBJ;  //-chest Animator
    private SpriteRenderer chest_SpriteRenderer; //-chest SpriteRenderer 

    private Animator text_Jumble;  //-text encoding Animator
    private SpriteRenderer text_SpriteRenderer; //-chest SpriteRenderer 


    private Animator symKey_Motion;  //-symmetric Animator

    private Color tmp;

    // Use this for initialization
    void Start()
    {
               
        //-On Game Start
        //-init vars
        chest_ps = this.GetComponent<ParticleSystem>();

        child0 = this.transform.GetChild(0).gameObject;
        text_Jumble = child0.GetComponent<Animator>();
        text_SpriteRenderer = child0.GetComponent<SpriteRenderer>();


        child1 = this.transform.GetChild(1).gameObject;
        chest_fadingOBJ = child1.GetComponent<Animator>();
        chest_SpriteRenderer = child1.GetComponent<SpriteRenderer>();

        symKey_Motion = symKey.GetComponent<Animator>();

        //-set the & turn off gradient ring
        var colOL = chest_ps.colorOverLifetime;
        var colbS = chest_ps.colorBySpeed;


        colOL.enabled = true;   //-gradient ring
        colbS.enabled = false;  //-solid ring

        this.gameObject.SetActive(false); //-start off
        text_Jumble.gameObject.SetActive(false);//-keep text off

    }

    // Update is called once per frame
    void Update()
    {

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
        }
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Hello From Collision");
    //    if (collision.gameObject.tag == "symKeyFid")
    //    {
    //        Debug.Log("Encrypted");
    //    }
    //}
}