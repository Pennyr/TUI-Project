using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UserB UserMenu send_public
public class B_SendPubKey_Menu : MonoBehaviour {

    public GameObject B_pubKeyAnimation;   //A public key to server animation
    public GameObject KeyServer;    //make send public key to user b available

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (B_pubKeyAnimation.gameObject.GetComponent<B_PubKeyToSrv>().B_PubKeyInteractionDone)
        {   //turn public key off
            this.transform.parent.GetChild(4).gameObject.SetActive(true); // turn send public disabled on
            this.gameObject.SetActive(false); //turn send raw option off
            //turn private key on
            this.transform.parent.GetChild(0).gameObject.SetActive(false); // turn send key disabled off
            this.transform.parent.GetChild(1).gameObject.SetActive(true); // turn send key  on
            //turn server key on
            KeyServer.transform.GetChild(2).GetChild(2).gameObject.SetActive(false); //turn off send public key disabled
            KeyServer.transform.GetChild(2).GetChild(3).gameObject.SetActive(true); //turn on send public key 
        }// both user a and hacker finished interacting
	}
}
