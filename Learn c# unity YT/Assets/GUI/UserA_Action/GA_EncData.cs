using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UserA-Action:EncDataUsrB
public class GA_EncData : MonoBehaviour
{
    public GameObject B_chestObject; //chest B fiducial script from user B
    private GameObject ActionMenu;
    private GameObject EncChestStill;
    public bool A_EncInteractionDone { get; set; } // interaction done indicator

    //Use this for initialization
    void Start ()
	{
	    ActionMenu = this.transform.parent.parent.GetChild(3).gameObject;
        EncChestStill = ActionMenu.transform.GetChild(8).gameObject; //show still closed chest while waiting
        this.gameObject.GetComponent<Animator>().SetBool("A_Unlock", false); //for when user inserts key
	    this.gameObject.GetComponent<Animator>().SetBool("A_Lock", true); //for when user inserts key
        A_EncInteractionDone = false;
    }
	
	//Update is called once per frame
	void Update ()
	{
	    if (B_chestObject.gameObject.GetComponent<GchestBScript>().pressed) //when user places chest on placeholder
	    {
	        EncChestStill.SetActive(false); //user has inserted key
            this.gameObject.GetComponent<Animator>().SetBool("A_Unlock", true);
	    }
    }

    //no use for this
    void StartofTextJumble()
    {
    }

    //send closed chest to hacker after key lock
    void StartofSendEncAToB()
    {
        ActionMenu.transform.GetChild(3).gameObject.SetActive(true); // send enc to hacker as well
    }

    void EndofMoveAnimation()
    {
        B_chestObject.SetActive(true);
        EncChestStill.SetActive(true);
        //communicate with chest - blink key hole led to wait for key, lid should be closed
    }

    //job complete, turn off chest placeholder, turn off send encrypt menu option off.
    void EndofDecryptAnimation()
    {
        B_chestObject.SetActive(false);
        this.gameObject.SetActive(false);
        A_EncInteractionDone = true; //indicate animation done from user b.
    }
}
