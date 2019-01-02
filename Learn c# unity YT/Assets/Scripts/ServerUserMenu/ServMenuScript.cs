using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class ServMenuScript: MonoBehaviour
{
    private float pointerRotation;
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();
    private GameObject Action;


    //Use this for initialization
    void Start()
    {

        childGameObjects.Add("sendKeyADis", this.transform.GetChild(0).gameObject); //send key to user A Disabled
        childGameObjects.Add("sendKeyA", this.transform.GetChild(1).gameObject);    //send key to user A
        childGameObjects.Add("sendKeyBDis", this.transform.GetChild(2).gameObject); //send key to user B Disabled
        childGameObjects.Add("sendKeyB", this.transform.GetChild(3).gameObject);    //send key to user B


        Action = this.transform.parent.GetChild(3).gameObject;

        childGameObjects.Add("keyRight", Action.transform.GetChild(0).gameObject); //key to B
        childGameObjects.Add("keyLeft", Action.transform.GetChild(1).gameObject);  //key to A
        childGameObjects.Add("centerA", Action.transform.GetChild(2).gameObject);  //key A to Hkr
        childGameObjects.Add("centerB", Action.transform.GetChild(3).gameObject);  //key B to Hkr

    }
    
    //Update is called once per frame
    void Update()
    {
        pointerRotation = this.transform.parent.GetChild(1).transform.localRotation.eulerAngles.z;
    
        childGameObjects["sendKeyA"].GetComponent<Animator>().SetFloat("rotation", pointerRotation);
        childGameObjects["sendKeyB"].GetComponent<Animator>().SetFloat("rotation", pointerRotation);

    }


    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (pointerRotation > 315 && pointerRotation < 330) //active raw data 
        {
            childGameObjects["keyRight"].SetActive(true);
            childGameObjects["centerB"].SetActive(true);
        }
        else if (pointerRotation > 30 && pointerRotation < 50) //active key
        {
            childGameObjects["keyLeft"].SetActive(true);
            childGameObjects["centerA"].SetActive(true);
        }
    }

   
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Trigger Exit Server User Menu");
        
    }

}
