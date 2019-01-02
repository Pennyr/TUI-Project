using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_EncData : MonoBehaviour
{
    public GameObject A_chestObject; //chest A fiducial script from user A
    public GameObject B_chestObject; //chest B fiducial script from user B
    private GameObject ActionMenu;
    private GameObject EncChestStill;
    public bool A_EncInteractionDone { get; set; } // interaction done indicator

    //Use this for initialization
    void Start ()
	{
	    ActionMenu = this.transform.parent.parent.GetChild(4).gameObject;
        EncChestStill = ActionMenu.transform.GetChild(8).gameObject; //show still closed chest while waiting
        this.gameObject.GetComponent<Animator>().SetBool("A_Unlock", false); //for when user inserts key
	    this.gameObject.GetComponent<Animator>().SetBool("A_Lock", false); //for when user inserts key
        A_EncInteractionDone = false;

	    //enable chest for user to lock message
	    A_chestObject.gameObject.SetActive(true);
    }
	
	//Update is called once per frame
	void Update ()
	{
	    if (A_chestObject.gameObject.GetComponent<chestAScript>().initialOnce) //when user A places chest on placeholder to lock
	    {
	        if (A_chestObject.gameObject.GetComponent<chestAScript>().A_KeyIn) // when key is inserted then message unlocked
	        {
	            this.gameObject.GetComponent<Animator>().SetBool("A_Lock", true);
	            A_chestObject.gameObject.SetActive(false); //turn off chest placeholder after lock
	        }
	    }

        if (B_chestObject.gameObject.GetComponent<chestBScript>().initialOnce) //when user places chest on placeholder
	    {
	        if (B_chestObject.gameObject.GetComponent<chestBScript>().B_KeyIn) // when key is inserted then message unlocked
	        {
	            EncChestStill.SetActive(false); //user has inserted key
                this.gameObject.GetComponent<Animator>().SetBool("A_Unlock", true);
	        }
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
        A_chestObject.gameObject.SetActive(false); // A chest not needed any more
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
