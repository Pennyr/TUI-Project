using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UserA-UserMenu:send_key
public class GSymSendEncKey : MonoBehaviour {

    private GameObject UserMenu;
    private GameObject Action;

    public GameObject KeyServer; 


    // Use this for initialization
    void Start () {
        UserMenu = this.transform.parent.gameObject;
        Action = this.transform.parent.parent.GetChild(3).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown() 
    {
        if (KeyServer.activeSelf)
        {
            Action.transform.GetChild(6).gameObject.SetActive(true); //show send private key A to A
        }
        else
        {
            UserMenu.transform.GetChild(8).gameObject.SetActive(true); //show key to lock open chest
            UserMenu.transform.GetChild(9).gameObject.SetActive(true); //show chest to lock
            Action.transform.GetChild(11).gameObject.SetActive(true); //show chest to lock
        }

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
