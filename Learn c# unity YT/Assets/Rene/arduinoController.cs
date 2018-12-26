using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;


public class arduinoController : MonoBehaviour {

    
    byte[] sendBytes = { 0x42 };
    byte[] sendBytes2 = { 0x52 };
    byte[] sendBytes3 = { 0x47 };

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void controlLED()
    {

        UdpClient udpClient = new UdpClient(11000);
        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 11000);

        try
        {
            udpClient.Send(sendBytes, sendBytes.Length, "192.168.0.14", 11000);
        }
        catch (Exception e)
        {

            Console.WriteLine(e.ToString); ;
        }
    }
}
