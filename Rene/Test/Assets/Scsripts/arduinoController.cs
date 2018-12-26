using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class arduinoController : MonoBehaviour {

    
    byte[] mes1 = { 0x42 };
    byte[] mes2 = { 0x52 };
    byte[] mes3 = { 0x47 };
    byte[] state = { 0x53 };

    // Use this for initialization
    void Start () {
        Debug.Log(5);
	}

    bool ledState;

    Socket sok = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    //IPAddress servIp = IPAddress.Parse("192.168.0.14");
    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
    
    public void test()
    {
        Debug.Log("test");
        byte[] mes1 = { 0x42 };
        byte[] mes2 = { 0x52 };
        byte[] mes3 = { 0x47 };
        
        try
        {
            //UdpClient udpClient = new UdpClient(11000);
            sok.SendTo(mes1, RemoteIpEndPoint);
            //udpClient.Send(mes2, mes2.Length, "192.168.0.14", 11000);
            Debug.Log("Send mes1");
        }
        catch (Exception e)
        {
            Debug.Log("error");
        }
        
    }

    public IEnumerator recieve()
    {
        WebSocket w = new WebSocket(new Uri("ws://192.168.0.14:11000"));
        yield return StartCoroutine(w.Connect());

        while (true)
        {
            try
            {

                //Socket Methode
                Debug.Log("Send turn off state from recieve()");
                sok.SendTo(state, RemoteIpEndPoint);


                string reply = w.RecvString();

                if (reply != null)
                {
                    Debug.Log("inside if reply");
                    Debug.Log(reply);

                }

                //byte[] receiveBytes = new byte[1024];
                //int bytesec = sok.Receive(receiveBytes);
                //Debug.Log(Encoding.ASCII.GetString(receiveBytes));

                //UDP
                /*Debug.Log("recieve");
                UdpClient udpClient = new UdpClient(11000);
                udpClient.Send(state, state.Length, "192.168.0.14", 11000);
                Debug.Log("Send state from recieve");
                UdpClient udpClient2 = new UdpClient(11000);
                Byte[] receiveBytes = udpClient2.Receive(ref RemoteIpEndPoint);
                Debug.Log("Receive");
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                Debug.Log("Message received: " + returnData.ToString());
                Debug.Log("This message was sent from " + RemoteIpEndPoint.Address.ToString() +
                                    " on their port number " + RemoteIpEndPoint.Port.ToString());
                  */
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
                break;
            }
        }

    }

}
