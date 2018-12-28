using UnityEngine;
using System.Collections;

using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Linq;

public class test200 : MonoBehaviour
{
    static int port = 11000;
    IPEndPoint RecieveEndPoint = new IPEndPoint(IPAddress.Any, port);

    UdpClient client;
    Thread receiveThread;

    void Start()
    {
        client = new UdpClient(port);

        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void ReceiveData()
    {
        while (true)
        {
            try
            {
                Byte[] receiveBytes = client.Receive(ref RecieveEndPoint);

                string returnData = Encoding.ASCII.GetString(receiveBytes);
                GlobalVariables.RecievedFromArduino.Add(new string[] { RecieveEndPoint.Address.ToString(), returnData });

                Debug.Log("Receive");
                Debug.Log("Message received: " + returnData.ToString());
                Debug.Log("This message was sent from " + RecieveEndPoint.Address.ToString() +
                                    " on their port number " + RecieveEndPoint.Port.ToString());
            }
            catch (Exception e)
            {

            }
        }
    }

    public void sendData(byte[] dataToSend, string IP)
    {
        client.Send(dataToSend, dataToSend.Length, new IPEndPoint(IPAddress.Parse(IP), port));
        Debug.Log("Sent data: (" + dataToSend.ToString() + ") to the IP: " + IP);
    }

    public void OnApplicationQuit()
    {
        receiveThread.Abort();
        if (client != null)
            client.Close();
    
        Debug.Log("Stop");
    }


    // -------------------------------------------------------------------------


    public void onButtonClick()
    {
        sendData(new byte[]{ 0x53 }, "192.168.0.14");
    }

    IEnumerator computingButtonClick()
    {
        // Waiting for button click from 192.168.0.14

        Debug.Log("Waiting for button click");

        yield return new WaitUntil(() => GlobalVariables.RecievedFromArduino.Select(s => s[0] == "192.168.0.14" && s[1] == "Button 1 Clicked").ToList().Count >= 1);
        GlobalVariables.RecievedFromArduino.RemoveAll(s => s[0] == "192.168.0.14" && s[1] == "Button 1 Clicked");

        Debug.Log("Button was clicked");
    }
    // -------------------------------------------------------------------------
}