using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GA_Hkr_EncData : MonoBehaviour
{
    public GameObject H_chestObject;
    public bool Hkr_EncInteractionDone { get; set; } // interaction done indicator
    private GameObject Action;

    // Use this for initialization
    void Start ()
	{
	    this.gameObject.GetComponent<Animator>().SetBool("Hkr_Unlock", false);
	    Hkr_EncInteractionDone = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (H_chestObject.gameObject.GetComponent<GchestHScript>().pressed)
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
    }

    void EndofDecryptAnimation()
    {
        H_chestObject.SetActive(false);
        this.gameObject.SetActive(false);
        Hkr_EncInteractionDone = true; //indicate animation done from hacker.
    }
}
