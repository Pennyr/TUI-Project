using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//UserB Action AsymEncDataHkr
public class B_ASymEncHkr : MonoBehaviour {

    public GameObject Hkr_chestObject;
    private GameObject ActionMenu;
    private GameObject EncChestStill;
    private GameObject AsymEncDataHkrStillText;
    public bool H_AsymEncInteractionDone { get; set; } // interaction done indicator

    //Use this for initialization
    void Start()
    {
        ActionMenu = this.transform.parent.parent.GetChild(3).gameObject; //action group
        //Debug.Log("Message from A_RawData: " + userMenu.name + " " + keyMenu.name + " " + ActionMenu.name);
        EncChestStill = ActionMenu.transform.GetChild(3).gameObject; //show still closed chest while waiting
        AsymEncDataHkrStillText = ActionMenu.transform.GetChild(7).gameObject; //show still clear text while waiting
        this.gameObject.GetComponent<Animator>().SetBool("H_Unlock", false);
        this.gameObject.GetComponent<Animator>().SetBool("H_Lock", false);
        H_AsymEncInteractionDone = false;
    }

    //Update is called once per frame
    void Update () {
        if (Hkr_chestObject.gameObject.GetComponent<chestHScript>().initialOnce) //when user places chest on placeholder
        {
            if (Hkr_chestObject.gameObject.GetComponent<chestHScript>().Hkr_KeyIn && !Hkr_chestObject.gameObject.activeSelf) // when key is inserted then message unlocked
            {
                this.gameObject.GetComponent<Animator>().SetBool("H_Lock", true);
            }

            if (Hkr_chestObject.gameObject.GetComponent<chestHScript>().Hkr_KeyIn && Hkr_chestObject.gameObject.activeSelf) // when key is inserted then message unlocked
            {
                this.gameObject.GetComponent<Animator>().SetBool("H_Unlock", true);
            }
        }
    }

    //turn off clear text still
    void StartofTextJumble()
    {
        AsymEncDataHkrStillText.SetActive(false);
    }

    //wait key animation from user A to B, play still animation
    void EndofMoveAnimation()
    {
        EncChestStill.SetActive(true);
        Hkr_chestObject.SetActive(true);
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
        Hkr_chestObject.SetActive(false);
        this.gameObject.SetActive(false);
        H_AsymEncInteractionDone = true; //indicate animation done from user b.
    }
}
