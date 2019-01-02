using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class KeyMenuScript : MonoBehaviour
{
    public GameObject userB;
    private float pointerRotation;
    private UserMenuScript UserMenu;
    private userBScript UserBScript;

    // Use this for initialization
    void Start()
    {
        UserMenu = this.transform.parent.GetChild(3).gameObject.GetComponent<UserMenuScript>(); // user A
        UserBScript = userB.GetComponent<userBScript>(); // user B
        //Debug.Log(UserBScript.name);
    }
    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.parent.GetChild(1).transform.localRotation.eulerAngles.z);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Trigger Enter Key Menu");

        pointerRotation = this.transform.parent.GetChild(1).transform.localRotation.eulerAngles.z;

        if (pointerRotation > 270 && pointerRotation < 290)
        {
            Debug.Log("User Chose Symmetric");
            //Symmetric 
            UserMenu.userMenu = true;
            UserBScript.userMenu = false;
            FirstMenuChoice();
        }
        else if (pointerRotation > 250 && pointerRotation < 265)
        {
            Debug.Log("User Chose Asymmetric");
            //Asymmetric 
            UserMenu.userMenu = false;
            UserBScript.userMenu = true;
            FirstMenuChoice();
        }


    }

   
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Trigger Exit Key Menu");
        
    }

    void FirstMenuChoice()
    {
        this.transform.parent.GetChild(2).gameObject.SetActive(false);  // sym-asym menu
        this.transform.parent.GetChild(3).gameObject.SetActive(true);   // user menu
        this.transform.parent.GetChild(4).gameObject.SetActive(true);   //action
    }

    

}
