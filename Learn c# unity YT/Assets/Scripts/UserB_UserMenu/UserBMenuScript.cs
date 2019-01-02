using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UserBMenuScript : MonoBehaviour
{
    public GameObject KeyServer;
    private float pointerRotation;
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>(); //list dictionary of children
    private GameObject Action;


    //Use this for initialization
    void Start()
    {
        childGameObjects.Add("sendKey", this.transform.GetChild(1).gameObject);    //send raw data to user B
        childGameObjects.Add("sendEnc", this.transform.GetChild(3).gameObject);    //send raw data to hacker
        childGameObjects.Add("sendPub", this.transform.GetChild(5).gameObject);    //send public key to server

        KeyServer.SetActive(true); //key server waiting for keys

        Action = this.transform.parent.GetChild(3).gameObject;
        childGameObjects.Add("private_key", Action.transform.GetChild(0).gameObject);  //send private key to hacker
        childGameObjects.Add("public_key", Action.transform.GetChild(1).gameObject);   //send public key to server
        childGameObjects.Add("asym_enc", Action.transform.GetChild(4).gameObject);     //send asymmetric encryption user A
        childGameObjects.Add("asym_text", Action.transform.GetChild(5).gameObject);    //send asymmetric encryption still text
        childGameObjects.Add("asym_enc_h", Action.transform.GetChild(6).gameObject);     //send asymmetric encryption hacker
        childGameObjects.Add("asym_text_h", Action.transform.GetChild(7).gameObject);    //send asymmetric encryption still text
    }
    
    //Update is called once per frame
    void Update()
    {
        pointerRotation = this.transform.parent.GetChild(1).transform.localRotation.eulerAngles.z; //get rotation angle from pointer
        
        //update animation rotation variable

        if (childGameObjects["sendKey"].activeSelf)
            childGameObjects["sendKey"].GetComponent<Animator>().SetFloat("rotation", pointerRotation);

        if (childGameObjects["sendEnc"].activeSelf)
            childGameObjects["sendEnc"].GetComponent<Animator>().SetFloat("rotation", pointerRotation);

        if (childGameObjects["sendPub"].activeSelf)
            childGameObjects["sendPub"].GetComponent<Animator>().SetFloat("rotation", pointerRotation);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Trigger Enter User Menu");

        if(childGameObjects["sendPub"].activeSelf && (pointerRotation > 290 && pointerRotation < 310) && KeyServer.gameObject.GetComponent<ServScript>().initialOnce) //activate send public key animation - asymmetric
        {
            childGameObjects["public_key"].SetActive(true);
        }
        else if (childGameObjects["sendKey"].activeSelf && (pointerRotation > 250 && pointerRotation < 289)) //activate send key data animation
        {
            childGameObjects["private_key"].SetActive(true);
        }
        else if (childGameObjects["sendEnc"].activeSelf && (pointerRotation > 230 && pointerRotation < 249)) //activate send encrypted data animation
        {
            childGameObjects["asym_enc"].SetActive(true);
            childGameObjects["asym_text"].SetActive(true);
        }
    }

   
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Trigger Exit User Menu");
        
    }

}
