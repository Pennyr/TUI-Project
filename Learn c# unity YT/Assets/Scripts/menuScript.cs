using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    private float pointerRotation;
    private Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();

    UdpClient udpClient = new UdpClient(); // new UdpClient() // with tangable try fixing a port
    IPEndPoint userATangible = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 51000);  // target endpoint
    IPEndPoint userBTangible = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 21000);  // target endpoint
    IPEndPoint hackerTangible = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 31000);  // target endpoint
    IPEndPoint chestTangible = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 41000);  // target endpoint

    Byte[] sendBytes;

    // Use this for initialization
    void Start()
    {

        childGameObjects.Add("sendRaw", this.transform.GetChild(0).gameObject);    // send encrypted data to user B
        childGameObjects.Add("sendKey", this.transform.GetChild(1).gameObject);    // send raw data to user B
        childGameObjects.Add("sendEnc", this.transform.GetChild(2).gameObject);      // send raw data to hacker
        childGameObjects.Add("rawDataUserB", this.transform.GetChild(3).gameObject);    // send encrypted data to user B
        childGameObjects.Add("rawDataHkr", this.transform.GetChild(4).gameObject);      // send encrypted data to hacker
        childGameObjects.Add("encDataUserB", this.transform.GetChild(5).gameObject);    // send encrypted data to user B
        childGameObjects.Add("encDataHkr", this.transform.GetChild(6).gameObject);      // send encrypted data to hacker
        childGameObjects.Add("keyUserB", this.transform.GetChild(7).gameObject);        // send key to user B
        childGameObjects.Add("keyHkr", this.transform.GetChild(8).gameObject);          // send key to hacker
        childGameObjects.Add("encData", this.transform.GetChild(9).gameObject);         // data encryption animation
        childGameObjects.Add("decryData", this.transform.GetChild(10).gameObject);       // data decryption animation

        // schedule the first receive operation:
        udpClient.BeginReceive(new AsyncCallback(OnUdpData), udpClient);

    }
    
    // Update is called once per frame
    void Update()
    {

        pointerRotation = this.transform.parent.GetChild(1).transform.localRotation.eulerAngles.z;

        if (pointerRotation > 60 && pointerRotation < 85)
        {
            EnableSelectorAnimator(true, false, false);
        }
        else if (pointerRotation > 84 && pointerRotation < 110)
        {
            EnableSelectorAnimator(false, true, false);
        }
        else if (pointerRotation > 109 && pointerRotation < 121)
        {
            EnableSelectorAnimator(false, false, true);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter");

        if (pointerRotation > 60 && pointerRotation < 85) // active raw data 
        {
            // to make anim repeatable, remove EndOfAnimation function and make enable & disable
            childGameObjects["rawDataUserB"].SetActive(true);
            childGameObjects["rawDataHkr"].SetActive(true);

            // Sends a message to the tangible
            sendBytes = Encoding.ASCII.GetBytes("Unity: User sent raw data, blink led");
            udpClient.BeginSend(sendBytes, sendBytes.Length, userBTangible, null, null);
            udpClient.BeginSend(sendBytes, sendBytes.Length, hackerTangible, null, null);
        }
        else if (pointerRotation > 84 && pointerRotation < 110) // active key
        {
            childGameObjects["keyUserB"].SetActive(true);
            childGameObjects["keyHkr"].SetActive(true);

            // Sends a message to the tangible
            sendBytes = Encoding.ASCII.GetBytes("Unity: User sent key, blink led");
            udpClient.BeginSend(sendBytes, sendBytes.Length, userBTangible, null, null);
            udpClient.BeginSend(sendBytes, sendBytes.Length, hackerTangible, null, null);

        }
        else if (pointerRotation > 109 && pointerRotation < 121) // active enc data 
        {
            childGameObjects["encDataUserB"].SetActive(true);
            childGameObjects["encDataHkr"].SetActive(true);

            // Sends a message to the tangible
            sendBytes = Encoding.ASCII.GetBytes("Unity: User sent encrypted, blink led");
            udpClient.BeginSend(sendBytes, sendBytes.Length, userBTangible, null, null);
            udpClient.BeginSend(sendBytes, sendBytes.Length, hackerTangible, null, null);

        }

    }

   
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit");
        
    }

    void EnableSelectorAnimator(bool b1, bool b2, bool b3)
    {
        childGameObjects["sendRaw"].GetComponent<Animator>().enabled = b1;
        childGameObjects["sendKey"].GetComponent<Animator>().enabled = b2;
        childGameObjects["sendEnc"].GetComponent<Animator>().enabled = b3;
    }

    static void OnUdpData(IAsyncResult result)
    {
        // this is what had been passed into BeginReceive as the second parameter:
        UdpClient socket = result.AsyncState as UdpClient;
        // points towards whoever had sent the message:
        IPEndPoint source = new IPEndPoint(0, 0);
        // get the actual message and fill out the source:
        byte[] message = socket.EndReceive(result, ref source);
        // do what you'd like with `message` here:
        Debug.Log("Got " + message.Length + " bytes from " + source);
        // schedule the next receive operation once reading is done:
        socket.BeginReceive(new AsyncCallback(OnUdpData), socket);
    }

}
