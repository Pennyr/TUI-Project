using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UserA UserMenu send_key
public class A_SendKey_Menu : MonoBehaviour {

    public GameObject A_keyAnimation;   //A raw to b animation
    public GameObject Hkr_keyAnimation; //A raw to hacker animation
    public GameObject A_PrivkeyAnimation; //A raw to hacker animation
    public GameObject KeyServer;    //check if server sent public key before making send encrypt available

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if ((A_keyAnimation.gameObject.GetComponent<A_SymKey>().A_KeyInteractionDone && 
            Hkr_keyAnimation.gameObject.GetComponent<A_Hkr_SymKey>().Hkr_KeyInteractionDone) || //used during symmetric
	         (KeyServer.transform.GetChild(3).GetChild(0).gameObject.GetComponent<S_KeyRight>().rightKeyTransmitted &&
	         A_PrivkeyAnimation.gameObject.GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone)) //used during asymmetric. checks if this user has the other's public key
        {
            this.transform.parent.GetChild(2).gameObject.SetActive(true); // turn send key disabled on
            this.gameObject.SetActive(false); //turn send key option off

            this.transform.parent.GetChild(4).gameObject.SetActive(false); // turn send encrypted disabled off
            this.transform.parent.GetChild(5).gameObject.SetActive(true); // turn send encrypted  on
        }// both user a and hacker finished interacting

	    if (A_PrivkeyAnimation.gameObject.GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) //used during asymmetric. checks if this user has his private key.
	    {
	        this.transform.GetComponent<Animator>().enabled = false; //disable animation
	    }// private key animation to user A
    }
}
