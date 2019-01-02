using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
//UserA-Reveal_B
public class GchestBScript : MonoBehaviour {

    public GameObject UserAAsymSend;
    public GameObject UserBPrKey;


    public bool pressed { get; set; } //when chest is placed. for use by other objects

    void OnMouseDown()
    {
        pressed = true;
    }

    void OnMouseUp()
    {
        pressed = false;

        if (UserAAsymSend.activeSelf && !UserBPrKey.GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) //asym from user a to b is true but user b private is false, return
            return;
        this.gameObject.SetActive(false);
    }
   
}
