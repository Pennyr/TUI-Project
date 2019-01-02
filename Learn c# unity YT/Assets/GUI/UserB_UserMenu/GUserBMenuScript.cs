using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class GUserBMenuScript : MonoBehaviour
{
    public GameObject KeyServer;
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>(); //list dictionary of children

    private GameObject UserMenu;
    private GameObject Action;

    private bool activeOnce = true;

    void Start()
    {
        UserMenu = this.transform.gameObject;
        Action = this.transform.parent.GetChild(2).gameObject;

        childGameObjects.Add("sendKey", this.transform.GetChild(1).gameObject);    //send raw data to user B
        childGameObjects.Add("sendEnc", this.transform.GetChild(3).gameObject);    //send raw data to hacker
        childGameObjects.Add("sendPub", this.transform.GetChild(5).gameObject);    //send public key to server
        childGameObjects.Add("sendKey_dis", UserMenu.transform.GetChild(0).gameObject);    //send key and enc data disable
        childGameObjects.Add("sendEnc_dis", UserMenu.transform.GetChild(2).gameObject);    //send enc data disable
        childGameObjects.Add("sendPub_dis", UserMenu.transform.GetChild(4).gameObject);    //send public key to server disable

        childGameObjects.Add("private_key", Action.transform.GetChild(0).gameObject);  //send private key to hacker
        childGameObjects.Add("public_key", Action.transform.GetChild(1).gameObject);   //send public key to server
        childGameObjects.Add("asym_enc", Action.transform.GetChild(4).gameObject);     //send asymmetric encryption user A
        childGameObjects.Add("asym_text", Action.transform.GetChild(5).gameObject);    //send asymmetric encryption still text
        childGameObjects.Add("asym_enc_h", Action.transform.GetChild(6).gameObject);   //send asymmetric encryption hacker
        childGameObjects.Add("asym_text_h", Action.transform.GetChild(7).gameObject);  //send asymmetric encryption still text
    }
    
    //Update is called once per frame
    void Update()
    {
        if (KeyServer.activeSelf && activeOnce)
        {
            childGameObjects["sendPub"].SetActive(true); // turn send public key on
            childGameObjects["sendKey_dis"].SetActive(true); // turn send key disabled on
            childGameObjects["sendEnc_dis"].SetActive(true); // turn send enc disabled on
            activeOnce = false;
        }

        if (childGameObjects["public_key"].GetComponent<GB_PubKeyToSrv>().B_PubKeyInteractionDone)
        {
            childGameObjects["sendPub_dis"].SetActive(true);// turn send public disabled on
            childGameObjects["sendPub"].SetActive(false); //turn send raw option off

            childGameObjects["sendKey_dis"].SetActive(false); // turn send key disabled off
            childGameObjects["sendKey"].SetActive(true); // turn send key  on
            KeyServer.transform.GetChild(1).GetChild(2).gameObject.SetActive(false); //turn off send public key disabled
            KeyServer.transform.GetChild(1).GetChild(3).gameObject.SetActive(true); //turn on send public key 
        }// both user a and hacker finished interacting

        // when send key animation is over, show send encrypted
        if (KeyServer.transform.GetChild(2).GetChild(1).gameObject.GetComponent<S_KeyLeft>().leftKeyTransmitted && // when user b has user a public key
            childGameObjects["private_key"].GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) //used during asymmetric. checks if this user has the other's public key and his private key
        {
            childGameObjects["sendKey_dis"].SetActive(true); // turn send key disabled off
            childGameObjects["sendKey"].SetActive(false); // turn send key  on

            childGameObjects["sendEnc_dis"].SetActive(false); // turn send enc disabled off
            childGameObjects["sendEnc"].SetActive(true); // turn send enc  on
        }// both user a and hacker finished interacting

        if (childGameObjects["private_key"].GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) //used during asymmetric. checks if this user has his private key.
        {   //leave icon on but disable animation
            childGameObjects["sendKey"].GetComponent<Animator>().enabled = false; //disable animation
        }// private key animation to user A


        // when send asym enc animation is over, turn all options off
        if (childGameObjects["asym_enc"].GetComponent<GB_ASymEnc>().B_AsymEncInteractionDone &&
            childGameObjects["asym_enc_h"].GetComponent<GB_ASymEncHkr>().H_AsymEncInteractionDone)
        {
            childGameObjects["sendEnc_dis"].SetActive(true); // turn send enc disabled on
            childGameObjects["sendEnc"].SetActive(false); // turn send enc  off
        }// both user a and hacker finished interacting
    }
}
