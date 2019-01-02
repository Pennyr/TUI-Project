using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UserB-UserMenu:send_key
public class GB_ASymSendEncKey : MonoBehaviour {

    private GameObject Action;

    // Use this for initialization
    void Start () {
        Action = this.transform.parent.parent.GetChild(2).gameObject;
    }
	
	// Update is called once per frame
	void Update () {}

    void OnMouseDown() 
    {
        Action.transform.GetChild(0).gameObject.SetActive(true); //show send private key A to A
    }

    //animate send key menu icon on hover
    void OnMouseOver()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Mouse", true);
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Mouse", false);
    }
}
