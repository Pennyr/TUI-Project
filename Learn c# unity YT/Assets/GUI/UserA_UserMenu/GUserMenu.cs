using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//UserA-UserMenu
public class GUserMenu : MonoBehaviour
{

    public GameObject KeyServer;
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>(); //list dictionary of children

    private GameObject UserMenu;
    private GameObject Action;

    void Start()
    {
        UserMenu = this.transform.gameObject;
        Action = this.transform.parent.GetChild(3).gameObject;

        childGameObjects.Add("sendRaw", UserMenu.transform.GetChild(1).gameObject);    //send raw data
        childGameObjects.Add("sendKey", UserMenu.transform.GetChild(3).gameObject);    //send key and enc data
        childGameObjects.Add("sendEnc", UserMenu.transform.GetChild(5).gameObject);    //send enc data
        childGameObjects.Add("sendPub", UserMenu.transform.GetChild(7).gameObject);    //send public key to server
        childGameObjects.Add("sendRaw_dis", UserMenu.transform.GetChild(0).gameObject);    //send raw data disable
        childGameObjects.Add("sendKey_dis", UserMenu.transform.GetChild(2).gameObject);    //send key and enc data disable
        childGameObjects.Add("sendEnc_dis", UserMenu.transform.GetChild(4).gameObject);    //send enc data disable
        childGameObjects.Add("sendPub_dis", UserMenu.transform.GetChild(6).gameObject);    //send public key to server disable

        childGameObjects.Add("rawDataUserB", Action.transform.GetChild(0).gameObject);  //data encryption animation
        childGameObjects.Add("rawDataHkr", Action.transform.GetChild(1).gameObject);    //data decryption animation
        childGameObjects.Add("encDataUserB", Action.transform.GetChild(2).gameObject);  //data encryption animation
        childGameObjects.Add("encDataHkr", Action.transform.GetChild(3).gameObject);    //send encrypted data to user B
        childGameObjects.Add("keyUserB", Action.transform.GetChild(4).gameObject);      //send encrypted data to hacker
        childGameObjects.Add("keyHkr", Action.transform.GetChild(5).gameObject);        //send encrypted data to user B
        childGameObjects.Add("private_key", Action.transform.GetChild(6).gameObject);   //send private key to user a
        childGameObjects.Add("public_key", Action.transform.GetChild(7).gameObject);    //send public key to server
        childGameObjects.Add("asym_enc", Action.transform.GetChild(10).gameObject);     //send asymmetric encryption
        childGameObjects.Add("asym_enc_hkr", Action.transform.GetChild(12).gameObject);    //send asymmetric encryption still text
    }


    //Update is called once per frame
    void Update()
    {
        // when send raw animation is over, show send key
        if (childGameObjects["rawDataUserB"].GetComponent<GA_RawData>().A_RawInteractionDone &&
            childGameObjects["rawDataHkr"].GetComponent<GA_Hkr_RawData>().Hkr_RawInteractionDone)
        {
            childGameObjects["sendRaw_dis"].SetActive(true); // turn send raw disabled on
            childGameObjects["sendRaw"].SetActive(false); //turn send raw option off

            childGameObjects["sendKey_dis"].SetActive(false); // turn send key disabled off
            childGameObjects["sendKey"].SetActive(true); // turn send key  on
        }// both user a and hacker finished interacting

       // when send key animation is over, show send encrypted
        if ((childGameObjects["keyUserB"].GetComponent<GA_SymKey>().A_KeyInteractionDone &&
            childGameObjects["keyHkr"].GetComponent<GA_Hkr_SymKey>().Hkr_KeyInteractionDone) || //used during symmetric
	        KeyServer.transform.GetChild(2).GetChild(0).gameObject.GetComponent<S_KeyRight>().rightKeyTransmitted &&
            childGameObjects["private_key"].GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) //used during asymmetric. checks if this user has the other's public key and his private key
        {
            childGameObjects["sendKey_dis"].SetActive(true); // turn send key disabled off
            childGameObjects["sendKey"].SetActive(false); // turn send key  on

            childGameObjects["sendEnc_dis"].SetActive(false); // turn send enc disabled off
            childGameObjects["sendEnc"].SetActive(true); // turn send enc  on
        }// both user a and hacker finished interacting

	    if (childGameObjects["private_key"].GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) //used during asymmetric. checks if this user has his private key.
	    {
	        childGameObjects["sendKey"].GetComponent<Animator>().enabled = false; //disable animation
	    }// private key animation to user A

        // when send enc animation is over, show key icons
        if (childGameObjects["encDataUserB"].GetComponent<GA_EncData>().A_EncInteractionDone &&
            childGameObjects["encDataHkr"].GetComponent<GA_Hkr_EncData>().Hkr_EncInteractionDone)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Reloaded!!");
        }// both user a and hacker finished interacting
        
        if (childGameObjects["public_key"].GetComponent<GA_PubKeyToSrv>().A_PubKeyInteractionDone &&
            !childGameObjects["sendEnc"].activeSelf) //condition is only true for send ing public key. otherwise private key will stay on.
        {
            childGameObjects["sendPub_dis"].SetActive(true);// turn send public disabled on
            childGameObjects["sendPub"].SetActive(false); //turn send raw option off

            childGameObjects["sendKey_dis"].SetActive(false); // turn send key disabled off
            childGameObjects["sendKey"].SetActive(true); // turn send key  on
            KeyServer.transform.GetChild(1).GetChild(0).gameObject.SetActive(false); //turn off send public key disabled
            KeyServer.transform.GetChild(1).GetChild(1).gameObject.SetActive(true); //turn on send public key 
        }// both user a and hacker finished interacting

        // when send asym enc animation is over, disable all options
        if (childGameObjects["asym_enc"].GetComponent<GA_ASymEnc>().A_AsymEncInteractionDone &&
            childGameObjects["asym_enc_hkr"].GetComponent<GA_ASymEncHkr>().H_AsymEncInteractionDone)
        {
            childGameObjects["sendEnc_dis"].SetActive(true); // turn send enc disabled on
            childGameObjects["sendEnc"].SetActive(false); // turn send enc  off
        }// both user a and hacker finished interacting

    }
}
