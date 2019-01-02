using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//UserB Action AsymEncDataUsrA
public class B_ASymEnc : MonoBehaviour {

    public GameObject A_chestObject; //to unlock
    public GameObject B_chestObject; //to lock
    public GameObject UserAPrKey;

    private GameObject ActionMenu;
    private GameObject EncChestStill;
    private GameObject AsymEncDataUserAStillText;
    public bool B_AsymEncInteractionDone { get; set; } // interaction done indicator

    //Use this for initialization
    void Start()
    {
        ActionMenu = this.transform.parent.parent.GetChild(3).gameObject; //action group
        //Debug.Log("Message from A_RawData: " + userMenu.name + " " + keyMenu.name + " " + ActionMenu.name);
        EncChestStill = ActionMenu.transform.GetChild(2).gameObject; //show still closed chest while waiting
        AsymEncDataUserAStillText = ActionMenu.transform.GetChild(5).gameObject; //show still clear text while waiting
        this.gameObject.GetComponent<Animator>().SetBool("B_Unlock", false);
        this.gameObject.GetComponent<Animator>().SetBool("B_Lock", false);
        B_AsymEncInteractionDone = false;

        //enable chest for user to lock message
        B_chestObject.gameObject.SetActive(true);
        //enable text still while waiting for user
        AsymEncDataUserAStillText.SetActive(true);
    }

    //Update is called once per frame
    void Update () {
        //UserB has to lock Chest
        if (B_chestObject.gameObject.GetComponent<chestBScript>().initialOnce) //when user B places chest on placeholder to unlock
        {
            if (B_chestObject.gameObject.GetComponent<chestBScript>().B_KeyIn)  // when key is inserted then message unlocked
                
            {
                this.gameObject.GetComponent<Animator>().SetBool("B_Lock", true);
            }
        }

        if (A_chestObject.gameObject.GetComponent<chestAScript>().initialOnce) //when user A places chest on placeholder to lock
        {
            if (A_chestObject.gameObject.GetComponent<chestAScript>().A_KeyIn && // when key is inserted then message unlocked
                UserAPrKey.GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) //User A has his private key
            {
                this.gameObject.GetComponent<Animator>().SetBool("B_Unlock", true);
            }
        }
    }

    //turn off clear text still
    void StartofTextJumble()
    {
        AsymEncDataUserAStillText.SetActive(false);
    }

    //send closed chest to hacker after key lock
    void StartofSendEncAToB()
    {
        ActionMenu.transform.GetChild(6).gameObject.SetActive(true); // send enc to hacker as well
        B_chestObject.gameObject.SetActive(false); // A chest not needed any more
    }

    //wait key animation from user A to B, play still animation
    void EndofMoveAnimation()
    {
        EncChestStill.SetActive(true);
        A_chestObject.SetActive(true);
    }

    //wait for user to open chest with key, display chest placeholder
    void EndofKeyMoveAnimation()
    {
        
    }

    //key animation from still to behind chest, remove still animation
    void EndofKeyUnlockAnimation()
    {
        EncChestStill.SetActive(false);
    }

    void EndofDecryptAnimation()
    {
        A_chestObject.SetActive(false);
        this.gameObject.SetActive(false);
        B_AsymEncInteractionDone = true; //indicate animation done from user b.
    }
}
