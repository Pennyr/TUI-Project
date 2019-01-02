using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//UserB UserMenu send_encrypted
public class B_SendEnc_Menu : MonoBehaviour {

    public GameObject A_AsymEncAnimation;   //A Asymmetric enc to b animation
    public GameObject Hkr_AsymEncAnimation; //A Asymmetric enc to hacker animation

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (A_AsymEncAnimation.gameObject.GetComponent<B_ASymEnc>().B_AsymEncInteractionDone &&
            Hkr_AsymEncAnimation.gameObject.GetComponent<B_ASymEncHkr>().H_AsymEncInteractionDone)
        {
            this.transform.parent.GetChild(2).gameObject.SetActive(true); //turn disabled on
            this.gameObject.SetActive(false); ///turn icon off
        }// both user a and hacker finished interacting
    }
}
