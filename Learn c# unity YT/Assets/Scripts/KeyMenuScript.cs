using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class KeyMenuScript : MonoBehaviour
{
    private float pointerRotation;
    private UserMenuScript UserMenu;
    
    // Use this for initialization
    void Start()
    {
        UserMenu = this.transform.parent.GetChild(3).gameObject.GetComponent<UserMenuScript>();
    }
    
    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter Key Menu");

        pointerRotation = this.transform.parent.GetChild(1).transform.localRotation.eulerAngles.z;

        if (pointerRotation > 60 && pointerRotation < 85)
        {
            Debug.Log("User Chose Symmetric");
            //Symmetric 
            UserMenu.userMenu = true;
        }
        else if (pointerRotation > 109 && pointerRotation < 121)
        {
            Debug.Log("User Chose Asymmetric");
            //Asymmetric 
            UserMenu.userMenu = false;
        }

        this.transform.parent.GetChild(2).gameObject.SetActive(false);
        this.transform.parent.GetChild(3).gameObject.SetActive(true);
        this.transform.parent.GetChild(4).gameObject.SetActive(true);
    }

   
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit Key Menu");
        
    }

    

}
