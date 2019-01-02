using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UserB UserMenu send_key
public class B_SendKey_Menu : MonoBehaviour {

    public GameObject B_PrivkeyAnimation; //A raw to hacker animation
    public GameObject KeyServer;    //check if server sent public key before making send encrypt available

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (KeyServer.transform.GetChild(3).GetChild(1).gameObject.GetComponent<S_KeyLeft>().leftKeyTransmitted &&
	        B_PrivkeyAnimation.gameObject.GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) //used during asymmetric. checks if this user has the other's public key and this user has his key
        {
            this.transform.parent.GetChild(0).gameObject.SetActive(true); // turn send key disabled on
            this.gameObject.SetActive(false); //turn send key option off

            this.transform.parent.GetChild(2).gameObject.SetActive(false); // turn send encrypted disabled off
            this.transform.parent.GetChild(3).gameObject.SetActive(true); // turn send encrypted  on
        }// both user a and hacker finished interacting

	    if (B_PrivkeyAnimation.gameObject.GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) //used during asymmetric. checks if this user has his private key.
	    {
	        this.transform.GetComponent<Animator>().enabled = false; //disable animation
	    }// private key animation to user A
    }
}
