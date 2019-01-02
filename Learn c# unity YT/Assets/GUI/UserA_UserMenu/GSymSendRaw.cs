using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UserA-UserMenu:send_raw
public class GSymSendRaw : MonoBehaviour {

    private GameObject Action;

    // Use this for initialization
    void Start () {
	    Action = this.transform.parent.parent.GetChild(3).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Action.transform.GetChild(0).gameObject.SetActive(true); // play send raw to user B animation
        Action.transform.GetChild(1).gameObject.SetActive(true); // play send raw to hacker animation
    }

    //animate send raw menu icon on hover
    void OnMouseOver()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Mouse", true);
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Mouse", false);
    }
}
