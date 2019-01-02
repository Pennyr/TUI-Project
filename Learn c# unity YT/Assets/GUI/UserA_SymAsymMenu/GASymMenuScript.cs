using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class GASymMenuScript : MonoBehaviour
{
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>(); //list dictionary of children
    private GameObject KeyMenu;
    private GameObject UserMenu;
    public GameObject KeyServer;

    //Use this for initialization
    void Start()
    {
        UserMenu = this.transform.parent.parent.GetChild(2).gameObject;
        KeyMenu = this.transform.parent.parent.GetChild(1).gameObject;

        childGameObjects.Add("sendPub", UserMenu.transform.GetChild(7).gameObject);    //send encrypted data to user B
        childGameObjects.Add("sendKey_dis", UserMenu.transform.GetChild(2).gameObject);    //send raw data to user B
        childGameObjects.Add("sendEnc_dis", UserMenu.transform.GetChild(4).gameObject);    //send raw data to hacker

    }

    void OnMouseDown()
    {
        childGameObjects["sendPub"].SetActive(true);
        childGameObjects["sendKey_dis"].SetActive(true);
        childGameObjects["sendEnc_dis"].SetActive(true);
        KeyServer.transform.gameObject.SetActive(true);
        KeyMenu.SetActive(false);
    }
}
