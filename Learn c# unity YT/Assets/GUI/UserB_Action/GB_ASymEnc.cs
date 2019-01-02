using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GB_ASymEnc : MonoBehaviour {

    public GameObject A_chestObject;
    public GameObject UserAPrKey;

    private GameObject ActionMenu;
    private GameObject EncChestStill;
    private GameObject AsymEncDataUserAStillText;
    public bool B_AsymEncInteractionDone { get; set; } // interaction done indicator

    //Use this for initialization
    void Start()
    {
        ActionMenu = this.transform.parent.parent.GetChild(2).gameObject;
        //Debug.Log("Message from A_RawData: " + userMenu.name + " " + keyMenu.name + " " + ActionMenu.name);
        EncChestStill = ActionMenu.transform.GetChild(2).gameObject; //show still closed chest while waiting
        AsymEncDataUserAStillText = ActionMenu.transform.GetChild(5).gameObject; //show still clear text while waiting
        this.gameObject.GetComponent<Animator>().SetBool("B_Unlock", false);
        this.gameObject.GetComponent<Animator>().SetBool("B_Lock", true);
        B_AsymEncInteractionDone = false;

        //enable text still while waiting for user
        AsymEncDataUserAStillText.SetActive(true);
    }

    //Update is called once per frame
    void Update () {
        if (A_chestObject.gameObject.GetComponent<GchestAScript>().pressed &&
            UserAPrKey.GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) // when key is inserted then message unlocked
        {
            this.gameObject.GetComponent<Animator>().SetBool("B_Unlock", true);
            EncChestStill.SetActive(false);
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

    }

    void EndofDecryptAnimation()
    {
        A_chestObject.SetActive(false);
        this.gameObject.SetActive(false);
        B_AsymEncInteractionDone = true; //indicate animation done from user b.
    }
}
