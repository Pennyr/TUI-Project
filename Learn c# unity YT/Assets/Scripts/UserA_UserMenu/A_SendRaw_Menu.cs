using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_SendRaw_Menu : MonoBehaviour {

    public GameObject A_rawAnimation;   //A raw to b animation
    public GameObject Hkr_rawAnimation; //A raw to hacker animation

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (A_rawAnimation.gameObject.GetComponent<A_RawData>().A_RawInteractionDone && 
            Hkr_rawAnimation.gameObject.GetComponent<A_Hkr_RawData>().Hkr_RawInteractionDone)
        {
            this.transform.parent.GetChild(0).gameObject.SetActive(true); // turn send raw disabled on
            this.gameObject.SetActive(false); //turn send raw option off

            this.transform.parent.GetChild(2).gameObject.SetActive(false); // turn send key disabled off
            this.transform.parent.GetChild(3).gameObject.SetActive(true); // turn send key  on
        }// both user a and hacker finished interacting
	}
}
