using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//UserA-Action:KeyHkr
public class GA_Hkr_SymKey : MonoBehaviour {

    public GameObject H_chestObject;
    private GameObject ActionMenu;
    private GameObject EncChestStill;
    public bool Hkr_KeyInteractionDone { get; set; } // interaction done indicator

    // Use this for initialization
    void Start()
    {
        ActionMenu = this.transform.parent.gameObject; //get action menu
        //Debug.Log("Message from A_RawData: " + userMenu.name + " " + keyMenu.name + " " + ActionMenu.name);
        EncChestStill = ActionMenu.transform.GetChild(9).gameObject; //show still closed chest while waiting
        this.gameObject.GetComponent<Animator>().SetBool("Hkr_Unlock_Chest", false);
        Hkr_KeyInteractionDone = false;
    }

    // Update is called once per frame
    void Update () {
        if (H_chestObject.gameObject.GetComponent<GchestHScript>().pressed) // when key is inserted then message unlocked
        {
            this.gameObject.GetComponent<Animator>().SetBool("Hkr_Unlock_Chest", true);
            
        }
    }

    //no use for this
    void StartofTextJumble()
    {
    }

    //wait key animation from user A to B, play still animation
    void EndofMoveAnimation()
    {
        EncChestStill.SetActive(true);
    }

    //wait for user to open chest with key, display chest placeholder
    void EndofKeyMoveAnimation()
    {
        H_chestObject.SetActive(true);
    }

    //key animation from still to behind chest, remove still animation
    void EndofKeyUnlockAnimation()
    {
        EncChestStill.SetActive(false);
    }

    void EndofDecryptAnimation()
    {
        H_chestObject.SetActive(false);
        this.gameObject.SetActive(false);
        Hkr_KeyInteractionDone = true; //indicate animation done from user b.
    }
}
