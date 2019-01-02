using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GA_ASymEnc : MonoBehaviour {

    public GameObject B_chestObject;
    public GameObject UserBPrKey;

    private GameObject ActionMenu;
    private GameObject EncChestStill;
    private GameObject AsymEncDataUserBStillText;
    public bool A_AsymEncInteractionDone { get; set; } // interaction done indicator

    //Use this for initialization
    void Start()
    {
        ActionMenu = this.transform.parent.parent.GetChild(3).gameObject;
        //Debug.Log("Message from A_RawData: " + userMenu.name + " " + keyMenu.name + " " + ActionMenu.name);
        EncChestStill = ActionMenu.transform.GetChild(8).gameObject; //show still closed chest while waiting
        AsymEncDataUserBStillText = ActionMenu.transform.GetChild(11).gameObject; //show still clear text while waiting
        this.gameObject.GetComponent<Animator>().SetBool("A_Unlock", false);
        this.gameObject.GetComponent<Animator>().SetBool("A_Lock", true);
        A_AsymEncInteractionDone = false;

        //enable text still while waiting for user
        AsymEncDataUserBStillText.SetActive(true);
    }

    //Update is called once per frame
    void Update () {
        if (B_chestObject.gameObject.GetComponent<GchestBScript>().pressed &&
            UserBPrKey.GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) // when key is inserted then message unlocked
        {
            this.gameObject.GetComponent<Animator>().SetBool("A_Unlock", true);
            EncChestStill.SetActive(false);
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
