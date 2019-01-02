using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Hkr_EncData : MonoBehaviour
{
    public GameObject H_chestObject;
    public bool Hkr_EncInteractionDone { get; set; } // interaction done indicator

    // Use this for initialization
    void Start ()
	{
	    this.gameObject.GetComponent<Animator>().SetBool("Hkr_Unlock", false);
	    Hkr_EncInteractionDone = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (H_chestObject.gameObject.GetComponent<chestHScript>().Hkr_KeyIn)
	    {
	        this.gameObject.GetComponent<Animator>().SetBool("Hkr_Unlock", true);
        }
    }

    //no use for this
    void StartofTextJumble()
    {
    }

    void EndofMoveAnimation()
    {
        H_chestObject.SetActive(true);
        // René communicate with chest - blink key hole led, lid should be closed
    }

    void EndofDecryptAnimation()
    {
        H_chestObject.SetActive(false);
        this.gameObject.SetActive(false);
        Hkr_EncInteractionDone = true; //indicate animation done from hacker.
    }
}
