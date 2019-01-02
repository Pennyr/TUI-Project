using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UserA-UserMenu:Encrypt_message
public class Encrypt_message : MonoBehaviour
{
    private string spriteTagPr = "KeyLockPr";
    private string spriteTagPu = "KeyLockPu";
    private GameObject Action;
    private GameObject UserMenu;
    private Vector3 originalKeyPos;

    // Use this for initialization
    void Start()
    {
        Action = this.transform.parent.parent.GetChild(3).gameObject;
        UserMenu = this.transform.parent.gameObject;
        originalKeyPos = UserMenu.transform.GetChild(8).position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // when key is placed on chest, begin key encryption animation
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == spriteTagPr)
        {
            if (UserMenu.transform.GetChild(3).gameObject.activeSelf) // when send key
            {
                UserMenu.transform.GetChild(8).position = originalKeyPos;
                Action.transform.GetChild(4).gameObject.SetActive(true);   // play send key enc to user B animation
                Action.transform.GetChild(11).gameObject.SetActive(false);   //hide text still
                this.gameObject.SetActive(false);                          // hide key
                UserMenu.transform.GetChild(8).gameObject.SetActive(false);// hide private key
            }
            
            else if (UserMenu.transform.GetChild(5).gameObject.activeSelf) // when send enc
            {
                UserMenu.transform.GetChild(8).position = originalKeyPos;
                Action.transform.GetChild(2).gameObject.SetActive(true);   // play send enc to user B animation
                Action.transform.GetChild(11).gameObject.SetActive(false);   //hide text still
                this.gameObject.SetActive(false);                          // hide key
                UserMenu.transform.GetChild(8).gameObject.SetActive(false);// hide private key
            }
        }
        else if (other.gameObject.tag == spriteTagPu)
        {
            Action.transform.GetChild(10).gameObject.SetActive(true);   // play send asym enc to user B animation
            Action.transform.GetChild(11).gameObject.SetActive(false);   //hide text still
            this.gameObject.SetActive(false);                          // hide key
            UserMenu.transform.GetChild(10).gameObject.SetActive(false);// hide public key
        }
    }
}
