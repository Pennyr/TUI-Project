using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
//UserA-Reveal_H
public class GchestAScript : MonoBehaviour {

    public GameObject UserBAsymSend;
    public GameObject UserAPrKey;

    public bool pressed { get; set; } //when chest is placed. for use by other objects

    void OnMouseDown()
    {
        pressed = true;
        
    }

    void OnMouseUp()
    {
        pressed = false;

        if (UserBAsymSend.activeSelf && !UserAPrKey.GetComponent<A_PrivKeyToA>().A_PrivKeyAnimationDone) //asym from user a to b is true but user b private is false, return
            return;
        this.gameObject.SetActive(false);
    }
    
}
