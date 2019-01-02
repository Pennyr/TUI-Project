﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UserA:UserMenu-send-public
public class GA_SendPubKey_Menu : MonoBehaviour {

    private GameObject Action;

    // Use this for initialization
    void Start()
    {
        Action = this.transform.parent.parent.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Action.transform.GetChild(7).gameObject.SetActive(true); //show chest to lock
    }

    //animate send key menu icon on hover
    void OnMouseOver()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Mouse", true);
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Mouse", false);
    }
}
