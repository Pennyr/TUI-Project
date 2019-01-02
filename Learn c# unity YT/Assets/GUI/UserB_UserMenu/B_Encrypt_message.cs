using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UserA-UserMenu:Encrypt_message
public class B_Encrypt_message : MonoBehaviour
{
    private string spriteTagPu = "KeyLockBPu";
    private GameObject Action;
    private GameObject UserMenu;

    // Use this for initialization
    void Start()
    {
        Action = this.transform.parent.parent.GetChild(2).gameObject;
        UserMenu = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // when key is placed on chest, begin key encryption animation
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == spriteTagPu)
        {
            Action.transform.GetChild(4).gameObject.SetActive(true);   // play send asym enc to user B animation
            Action.transform.GetChild(5).gameObject.SetActive(false);   //hide text still
            this.gameObject.SetActive(false);                          // hide key
            UserMenu.transform.GetChild(7).gameObject.SetActive(false);// hide public key
        }
    }
}
