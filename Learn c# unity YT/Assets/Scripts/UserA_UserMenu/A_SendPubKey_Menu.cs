using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_SendPubKey_Menu : MonoBehaviour {

    public GameObject A_pubKeyAnimation;   //A public key to server animation
    public GameObject KeyServer;    //make send public key to user b available

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (A_pubKeyAnimation.gameObject.GetComponent<A_PubKeyToSrv>().A_PubKeyInteractionDone)
        {
            this.transform.parent.GetChild(6).gameObject.SetActive(true); // turn send public disabled on
            this.gameObject.SetActive(false); //turn send raw option off

            this.transform.parent.GetChild(2).gameObject.SetActive(false); // turn send key disabled off
            this.transform.parent.GetChild(3).gameObject.SetActive(true); // turn send key  on
            KeyServer.transform.GetChild(2).GetChild(0).gameObject.SetActive(false); //turn off send public key disabled
            KeyServer.transform.GetChild(2).GetChild(1).gameObject.SetActive(true); //turn on send public key 
        }// both user a and hacker finished interacting
	}
}
