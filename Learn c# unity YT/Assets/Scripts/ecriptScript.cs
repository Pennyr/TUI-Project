using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ecriptScript : MonoBehaviour {

    private ParticleSystem encript_ps; //-symmetric ParticleSystem 
    private Animator encript_textOBJ;  //-symmetric Animator
    private SpriteRenderer encript_SpriteRenderer; //-symmetric SpriteRenderer 
    private Collider2D encript_collider; //-symmetric Collider

    private Color tmp;
    // Use this for initialization
    void Start () {
        //-On Game Start
        //-init vars
        encript_ps = this.GetComponent<ParticleSystem>();
        encript_textOBJ = this.GetComponentInChildren<Animator>();
        encript_SpriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
        encript_collider = this.GetComponentInChildren<Collider2D>();

        var em_ecript = encript_ps.emission;//-ring emission
        em_ecript.enabled = false;

        encript_textOBJ.enabled = false; //-script animator

        //-alpha off text script sprite
        tmp = encript_SpriteRenderer.color;
        tmp.a = 0f;
        encript_SpriteRenderer.color = tmp;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
