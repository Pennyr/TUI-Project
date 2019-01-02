using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UserMenuScript : MonoBehaviour
{
    public GameObject KeyServer;
    private float pointerRotation;
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>(); //list dictionary of children
    private GameObject Action;
    public bool userMenu { get; set; }

    //Use this for initialization
    void Start()
    {
        childGameObjects.Add("sendRaw", this.transform.GetChild(1).gameObject);    //send encrypted data to user B
        childGameObjects.Add("sendKey", this.transform.GetChild(3).gameObject);    //send raw data to user B
        childGameObjects.Add("sendEnc", this.transform.GetChild(5).gameObject);    //send raw data to hacker
        childGameObjects.Add("sendPub", this.transform.GetChild(7).gameObject);    //send public key to server

        if (!userMenu)
        {
            childGameObjects["sendPub"].SetActive(true); //replace send raw with send public
            childGameObjects["sendRaw"].SetActive(false);
            KeyServer.SetActive(true); //key server waiting for keys
        }//Asymmetric

        Action = this.transform.parent.GetChild(4).gameObject;
        childGameObjects.Add("rawDataUserB", Action.transform.GetChild(0).gameObject);  //data encryption animation
        childGameObjects.Add("rawDataHkr", Action.transform.GetChild(1).gameObject);    //data decryption animation
        childGameObjects.Add("encDataUserB", Action.transform.GetChild(2).gameObject);  //data encryption animation
        childGameObjects.Add("encDataHkr", Action.transform.GetChild(3).gameObject);    //send encrypted data to user B
        childGameObjects.Add("keyUserB", Action.transform.GetChild(4).gameObject);      //send encrypted data to hacker
        childGameObjects.Add("keyHkr", Action.transform.GetChild(5).gameObject);        //send encrypted data to user B
        childGameObjects.Add("private_key", Action.transform.GetChild(6).gameObject);   //send private key to hacker
        childGameObjects.Add("public_key", Action.transform.GetChild(7).gameObject);    //send public key to server
        childGameObjects.Add("asym_enc", Action.transform.GetChild(10).gameObject);     //send asymmetric encryption
        childGameObjects.Add("asym_text", Action.transform.GetChild(11).gameObject);    //send asymmetric encryption still text
    }
    
    //Update is called once per frame
    void Update()
    {
        pointerRotation = this.transform.parent.GetChild(1).transform.localRotation.eulerAngles.z; //get rotation angle from pointer
        
        //update animation rotation variable
        if(childGameObjects["sendRaw"].activeSelf)
            childGameObjects["sendRaw"].GetComponent<Animator>().SetFloat("rotation", pointerRotation);

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

        if (childGameObjects["sendRaw"].activeSelf && (pointerRotation > 60 && pointerRotation < 85)) //activate send raw data animation - symmetric
        {
            childGameObjects["rawDataUserB"].SetActive(true);
            childGameObjects["rawDataHkr"].SetActive(true);
        }
        else if(childGameObjects["sendPub"].activeSelf && (pointerRotation > 60 && pointerRotation < 85) && KeyServer.gameObject.GetComponent<ServScript>().initialOnce) //activate send public key animation - asymmetric
        {// if send public menu option is on, rotation is between values and server is placed
            childGameObjects["public_key"].SetActive(true);
        }
        else if (childGameObjects["sendKey"].activeSelf && (pointerRotation > 84 && pointerRotation < 110)) //activate send key data animation
        {
            if (userMenu) //symmetric
            {
                childGameObjects["keyUserB"].SetActive(true);
            }
            else
            {
                childGameObjects["private_key"].SetActive(true);
            }
        }
        else if (childGameObjects["sendEnc"].activeSelf && (pointerRotation > 109 && pointerRotation < 121)) //activate send encrypted data animation
        {
            if (userMenu)//symmetric
            {
                childGameObjects["encDataUserB"].SetActive(true);
            }
            else
            {
                childGameObjects["asym_enc"].SetActive(true);
            }
        }
    }

   
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Trigger Exit User Menu");
        
    }

}
