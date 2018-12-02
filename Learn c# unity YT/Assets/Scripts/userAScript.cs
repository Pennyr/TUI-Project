using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class userAScript : MonoBehaviour {

    public FiducialController tangible; // fiducial for this user

    private ParticleSystem user_ps; // UserA ParticleSystem 
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();
    
    private string fiducialTag = "userA";
    private bool initialOnce = false; //-enable other animator only once

    private float prev = 60;
    private float now;
    private float initial;
    private float offset;
    private float pointerStart = 60;
    private float pointerEnd = 120;

    private Vector3 collBounds;

    UdpClient udpClient = new UdpClient(); // new UdpClient() // with tangable try fixing a port
    IPEndPoint userATangible = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 51000);  // target endpoint
    IPEndPoint userBTangible = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 21000);  // target endpoint
    IPEndPoint hackerTangible = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 31000);  // target endpoint
    IPEndPoint chestTangible = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 41000);  // target endpoint

    Byte[] sendBytes;

    // Use this for initialization
    void Start() // On Game Start
    {

        collBounds = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
 
        // Get reference to children objects
        childGameObjects.Add("userImg", this.transform.GetChild(0).gameObject);         // user icon
        childGameObjects.Add("menuSelector", this.transform.GetChild(1).gameObject);    // menu child object
        childGameObjects.Add("menu", this.transform.GetChild(2).gameObject);            // menu child object

        // initialise variables
        user_ps = this.GetComponent<ParticleSystem>();

        // show gradient ring
        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        colOL.enabled = true;   //-gradient ring
        colbS.enabled = false;  //-solid ring

        // Sends a message to the tangible
        sendBytes = Encoding.ASCII.GetBytes("Unity: Place tangibles in place, blink led");

        udpClient.BeginSend(sendBytes, sendBytes.Length, userATangible, null, null);
        udpClient.BeginSend(sendBytes, sendBytes.Length, userBTangible, null, null);
        udpClient.BeginSend(sendBytes, sendBytes.Length, hackerTangible, null, null);
        udpClient.BeginSend(sendBytes, sendBytes.Length, chestTangible, null, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        //-on server fiducial stay:
        //-1. show solid ring
        //-2. turn server sprite animation off and fade out
        if (other.gameObject.tag == fiducialTag && other.bounds.Contains(collBounds))
        {

            // get initial tangible angle
            if (!initialOnce)
            {
                childGameObjects["menu"].SetActive(true); // enable menu on fiducial in
                childGameObjects["menuSelector"].SetActive(true); // enable menuSelector on fiducial in
                childGameObjects["userImg"].SetActive(false); // disable image
                // show solid ring
                colOL.enabled = false;
                colbS.enabled = true;

                initial = tangible.AngleDegrees;
                offset = 60 - initial;

                initialOnce = true;

                // Sends a message to the tangible
                sendBytes = Encoding.ASCII.GetBytes("Unity: Tangible in place, led off");

                udpClient.BeginSend(sendBytes, sendBytes.Length, userATangible, null, null);
            }

            now = tangible.AngleDegrees;
            now += offset;

            if (now > pointerStart && now < pointerEnd) // if tangible angle is within range & clip tangible rotation to pointer limits
            {
                childGameObjects["menuSelector"].transform.rotation = Quaternion.Euler(180,0,now);
            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var colOL = user_ps.colorOverLifetime;
        var colbS = user_ps.colorBySpeed;

        //-on server fiducial stay:
        //-1. show gradient ring
        //-2. turn server sprite animation on and visible
        if (other.gameObject.tag == fiducialTag)
        {
            childGameObjects["menu"].SetActive(false); // disable menu on fiducial out
            childGameObjects["menuSelector"].SetActive(false); // disable menuSelector on fiducial out
            childGameObjects["userImg"].SetActive(true); // enable image
            // show gradient ring
            colOL.enabled = true;
            colbS.enabled = false;

            initialOnce = false;
        }
    }


}
