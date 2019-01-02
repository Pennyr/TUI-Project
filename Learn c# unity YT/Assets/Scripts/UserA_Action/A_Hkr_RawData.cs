using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Hkr_RawData : MonoBehaviour
{
    public GameObject H_chestObject;
    public bool Hkr_RawInteractionDone { get; set; } // interaction done indicator

	// Use this for initialization
	void Start ()
	{
	    this.gameObject.GetComponent<Animator>().SetBool("goStill", false);
	    this.gameObject.GetComponent<Animator>().SetBool("reveal", false);
	    Hkr_RawInteractionDone = false;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (H_chestObject.gameObject.GetComponent<chestHScript>().initialOnce)
	    {
	        this.gameObject.GetComponent<Animator>().SetBool("reveal", true);
        }
    }

    void EndofMoveAnimation()
    {
        //Debug.Log("Message from A_RawData: EndofMoveAnimation");
        this.gameObject.GetComponent<Animator>().SetBool("goStill", true);
        H_chestObject.SetActive(true);
    }

    void EndofTextAnimation()
    {
        //Debug.Log("Message from A_RawData: EndofTextAnimation");
        H_chestObject.SetActive(false);
        this.gameObject.SetActive(false);
        Hkr_RawInteractionDone = true; //indicate animation done from hacker.
    }
}
