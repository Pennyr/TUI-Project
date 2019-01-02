using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class A_SymKey : MonoBehaviour {

    public GameObject A_chestObject;
    public GameObject B_chestObject;
    private GameObject ActionMenu;
    private GameObject EncChestStill;
    public bool A_KeyInteractionDone { get; set; } // interaction done indicator

    //Use this for initialization
    void Start()
    {
        ActionMenu = this.transform.parent.parent.GetChild(4).gameObject;
        //Debug.Log("Message from A_RawData: " + userMenu.name + " " + keyMenu.name + " " + ActionMenu.name);
        EncChestStill = ActionMenu.transform.GetChild(8).gameObject; //show still closed chest while waiting
        this.gameObject.GetComponent<Animator>().SetBool("A_Unlock_Chest", false);
        this.gameObject.GetComponent<Animator>().SetBool("A_Lock_Chest", false);
        A_KeyInteractionDone = false;

        //enable chest for user to lock message
        A_chestObject.gameObject.SetActive(true);
    }

    //Update is called once per frame
    void Update () {
        if (A_chestObject.gameObject.GetComponent<chestAScript>().initialOnce) //when user A places chest on placeholder to lock
        {
            if (A_chestObject.gameObject.GetComponent<chestAScript>().A_KeyIn) // when key is inserted then message unlocked
            {
                this.gameObject.GetComponent<Animator>().SetBool("A_Lock_Chest", true);
                A_chestObject.gameObject.SetActive(false); //turn off chest placeholder after lock
            }
        }

        if (B_chestObject.gameObject.GetComponent<chestBScript>().initialOnce) //when user B places chest on placeholder to unlock
        {
            if (B_chestObject.gameObject.GetComponent<chestBScript>().B_KeyIn) // when key is inserted then message unlocked
            {
                this.gameObject.GetComponent<Animator>().SetBool("A_Unlock_Chest", true);
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
        ActionMenu.transform.GetChild(5).gameObject.SetActive(true); // send enc to hacker as well
        A_chestObject.gameObject.SetActive(false); // A chest not needed any more
    }

    //wait key animation from user A to B, play still animation
    void EndofMoveAnimation()
    {
        EncChestStill.SetActive(true);
    }

    //wait for user to open chest with key, display chest placeholder
    void EndofKeyMoveAnimation()
    {
        B_chestObject.SetActive(true);
    }

    //key animation from still to behind chest, remove still animation
    void EndofKeyUnlockAnimation()
    {
        EncChestStill.SetActive(false);
    }

    void EndofDecryptAnimation()
    {
        B_chestObject.SetActive(false);
        this.gameObject.SetActive(false);
        A_KeyInteractionDone = true; //indicate animation done from user b.
    }
}
