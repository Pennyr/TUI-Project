using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
//UserA-SymAsymMenu:Key-icon
public class GSymMenuScript : MonoBehaviour
{
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>(); //list dictionary of children
    private GameObject KeyMenu;
    private GameObject UserMenu;
    //Use this for initialization
    void Start()
    {
        UserMenu = this.transform.parent.parent.GetChild(2).gameObject;
        KeyMenu = this.transform.parent.parent.GetChild(1).gameObject;

        childGameObjects.Add("sendRaw", UserMenu.transform.GetChild(1).gameObject);    //send encrypted data to user B
        childGameObjects.Add("sendKey_dis", UserMenu.transform.GetChild(2).gameObject);    //send raw data to user B
        childGameObjects.Add("sendEnc_dis", UserMenu.transform.GetChild(4).gameObject);    //send raw data to hacker
        
    }
    
    void OnMouseDown()
    {
        childGameObjects["sendRaw"].SetActive(true);
        childGameObjects["sendKey_dis"].SetActive(true);
        childGameObjects["sendEnc_dis"].SetActive(true);
        KeyMenu.SetActive(false);
    }
}
