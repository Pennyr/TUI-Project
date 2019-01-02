using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UserA-Action: RawDataUsrB
public class GA_RawData : MonoBehaviour
{
    public GameObject B_chestObject; //chest B fiducial script from user B
    public bool A_RawInteractionDone { get; set; } // interaction done indicator

    //Use this for initialization
    void Start ()
	{
        this.gameObject.GetComponent<Animator>().SetBool("goStill", false); //animation for when waiting user interaction with chest
	    this.gameObject.GetComponent<Animator>().SetBool("reveal", false);  //animation for after user interacts with chest
	    A_RawInteractionDone = false;
	}
	
	//Update is called once per frame
	void Update ()
	{
	    if (B_chestObject.gameObject.GetComponent<GchestBScript>().pressed) //when user places chest on placeholder
	    {
	        this.gameObject.GetComponent<Animator>().SetBool("reveal", true);
        }
    }

    //wait for user input and turn on chest b placeholder
    void EndofMoveAnimation()
    {
        this.gameObject.GetComponent<Animator>().SetBool("goStill", true);
        B_chestObject.SetActive(true);
    }

    //job complete, turn off chest placeholder, turn off send raw menu option off, turn on send encrypted.
    void EndofTextAnimation()
    {
        B_chestObject.SetActive(false);
        this.gameObject.SetActive(false);
        A_RawInteractionDone = true; //indicate animation done from user b.
    }
}
