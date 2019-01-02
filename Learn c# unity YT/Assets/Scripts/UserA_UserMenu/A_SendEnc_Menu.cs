using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//User A UserMenu send_encrypted
public class A_SendEnc_Menu : MonoBehaviour {

    public GameObject A_encAnimation;   //A symmetric enc to b animation
    public GameObject Hkr_encAnimation; //A symmetric enc to hacker animation

    public GameObject A_AsymEncAnimation;   //A Asymmetric enc to b animation
    public GameObject Hkr_AsymEncAnimation; //A Asymmetric enc to hacker animation

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (A_encAnimation.gameObject.GetComponent<A_EncData>().A_EncInteractionDone &&
            Hkr_encAnimation.gameObject.GetComponent<A_Hkr_EncData>().Hkr_EncInteractionDone) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Reloaded!!");
        }// both user a and hacker finished interacting

        if (A_AsymEncAnimation.gameObject.GetComponent<A_ASymEnc>().A_AsymEncInteractionDone &&
            Hkr_AsymEncAnimation.gameObject.GetComponent<A_ASymEncHkr>().H_AsymEncInteractionDone)
        {
            this.transform.parent.GetChild(4).gameObject.SetActive(true); //turn disabled on
            this.gameObject.SetActive(false); ///turn icon off
        }// both user a and hacker finished interacting
    }
}
