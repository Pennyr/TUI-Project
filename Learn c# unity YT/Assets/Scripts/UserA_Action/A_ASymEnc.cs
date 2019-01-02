using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//UserA Action AsymEncDataUsrB
public class A_ASymEnc : MonoBehaviour {

    public GameObject A_chestObject; //to lock
    public GameObject B_chestObject; //to unlock
    public GameObject UserBPrKey;

    private GameObject ActionMenu;
    private GameObject EncChestStill;
    private GameObject AsymEncDataUserBStillText;
    public bool A_AsymEncInteractionDone { get; set; } // interaction done indicator

    //Use this for initialization
    void Start()
    {
        ActionMenu = this.transform.parent.parent.GetChild(4).gameObject;
        //Debug.Log("Message from A_RawData: " + userMenu.name + " " + keyMenu.name + " " + ActionMenu.name);
        EncChestStill = ActionMenu.transform.GetChild(8).gameObject; //show still closed chest while waiting
        AsymEncDataUserBStillText = ActionMenu.transform.GetChild(11).gameObject; //show still clear text while waiting
        this.gameObject.GetComponent<Animator>().SetBool("A_Unlock", false);
        this.gameObject.GetComponent<Animator>().SetBool("A_Lock", false);
        A_AsymEncInteractionDone = false;

        //enable chest for user to lock message
        A_chestObject.gameObject.SetActive(true);
        //enable text still while waiting for user
        AsymEncDataUserBStillText.SetActive(true);
    }

    //Update is called once per frame
    void Update () {
        if (A_chestObject.gameObject.GetComponent<chestAScript>().initialOnce) //when user A places chest on placeholder to lock
        {
            if (A_chestObject.gameObject.GetComponent<chestAScript>().A_KeyIn) // when key is inserted then message unlocked
            {
                this.gameObject.GetComponent<Animator>().SetBool("A_Lock", true);
            }
        }

        if (B_chestObject.gameObject.GetComponent<chestBScript>().initialOnce) //when user B places chest on placeholder to unlock
        {
            if (B_chestObject.gameObject.GetComponent<chestBScript>().B_KeyIn && // when key is inserted then message unlocked
                UserBPrKey.GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) //User B has his private key
            {
                this.gameObject.GetComponent<Animator>().SetBool("A_Unlock", true);
                EncChestStill.SetActive(false);
            }
        }
    }

    //turn off clear text still
    void StartofTextJumble()
    {
        AsymEncDataUserBStillText.SetActive(false);
    }

    //send closed chest to hacker after key lock
    void StartofSendEncAToB()
    {
        ActionMenu.transform.GetChild(12).gameObject.SetActive(true); // send enc to hacker as well
        A_chestObject.gameObject.SetActive(false); // A chest not needed any more
    }

    //wait key animation from user A to B, play still animation
    void EndofMoveAnimation()
    {
        EncChestStill.SetActive(true);
        B_chestObject.SetActive(true);
    }

    //wait for user to open chest with key, display chest placeholder
    void EndofKeyMoveAnimation()
    {
       
    }

    //key animation from still to behind chest, remove still animation
    void EndofKeyUnlockAnimation()
    {

    }

    void EndofDecryptAnimation()
    {
        B_chestObject.SetActive(false);
        this.gameObject.SetActive(false);
        A_AsymEncInteractionDone = true; //indicate animation done from user b.
    }
}
