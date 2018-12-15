using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UserMenuScript : MonoBehaviour
{
    private float pointerRotation;
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();
    private GameObject Action;
    public bool userMenu { get; set; }
    



    // Use this for initialization
    void Start()
    {

        childGameObjects.Add("sendRaw", this.transform.GetChild(1).gameObject);    // send encrypted data to user B
        childGameObjects.Add("sendKey", this.transform.GetChild(3).gameObject);    // send raw data to user B
        childGameObjects.Add("sendEnc", this.transform.GetChild(5).gameObject);    // send raw data to hacker

        Action = this.transform.parent.GetChild(4).gameObject;

        childGameObjects.Add("rawDataUserB", Action.transform.GetChild(0).gameObject);  // data encryption animation
        childGameObjects.Add("rawDataHkr", Action.transform.GetChild(1).gameObject);    // data decryption animation
        childGameObjects.Add("encDataUserB", Action.transform.GetChild(2).gameObject);  // data encryption animation
        childGameObjects.Add("encDataHkr", Action.transform.GetChild(3).gameObject);    // send encrypted data to user B
        childGameObjects.Add("keyUserB", Action.transform.GetChild(4).gameObject);      // send encrypted data to hacker
        childGameObjects.Add("keyHkr", Action.transform.GetChild(5).gameObject);        // send encrypted data to user B
        childGameObjects.Add("private_key", Action.transform.GetChild(6).gameObject);   // send key to hacker
    }
    
    // Update is called once per frame
    void Update()
    {
        pointerRotation = this.transform.parent.GetChild(1).transform.localRotation.eulerAngles.z;
        
        if(childGameObjects["sendRaw"].activeSelf)
            childGameObjects["sendRaw"].GetComponent<Animator>().SetFloat("rotation", pointerRotation);

        if (childGameObjects["sendKey"].activeSelf)
            childGameObjects["sendKey"].GetComponent<Animator>().SetFloat("rotation", pointerRotation);

        if (childGameObjects["sendEnc"].activeSelf)
            childGameObjects["sendEnc"].GetComponent<Animator>().SetFloat("rotation", pointerRotation);

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter User Menu");

        if (pointerRotation > 60 && pointerRotation < 85) // active raw data 
        {
            
            childGameObjects["rawDataUserB"].SetActive(true);
            childGameObjects["rawDataHkr"].SetActive(true);


        }
        else if (pointerRotation > 84 && pointerRotation < 110) // active key
        {
            if (userMenu)
            {
                
                childGameObjects["keyUserB"].SetActive(true);
                childGameObjects["keyHkr"].SetActive(true);
            }
            else
            {
                childGameObjects["private_key"].SetActive(true);
            }


        }
        else if (pointerRotation > 109 && pointerRotation < 121) // active enc data 
        {

            childGameObjects["encData"].SetActive(true);
            childGameObjects["encDataUserB"].SetActive(true);
            childGameObjects["encDataHkr"].SetActive(true);

        }

    }

   
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit User Menu");
        
    }

}
