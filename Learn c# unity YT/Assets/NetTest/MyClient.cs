using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyClient : MonoBehaviour
{
    private const int MAX_CONNECTION = 10;

    private int socketPort = 11000;

    private int hostID;

    private int connectionID;

    private int reliableChannelID;
    private byte error;
    private bool isConnected = false;
    private string playerName;

    // Use this for initialization
    void Start () {
		Connect();
	}
	
	// Update is called once per frame
	void Update () {
	    if (isConnected)
	    {
	        int recHostID;
	        int recConnectionID;
	        int recChannelID;
	        byte[] recBuffer = new byte[1024];
	        int bufferSize = 1024;
	        int datasize;
	        NetworkEventType recNetworkEvent = NetworkTransport.Receive(out recHostID, out recConnectionID, out recChannelID, recBuffer, bufferSize, out datasize, out error);

	        switch (recNetworkEvent)
	        {

	            case NetworkEventType.DataEvent:
	                string msg = Encoding.ASCII.GetString(recBuffer, 0, datasize);
                    Debug.Log("Receiving :" + msg);
	                break;
	        }
        }

	}

    public void Connect()
    {
        //string pName = GameObject.Find("NameInput").GetComponent<InputField>().text;
        //if (pName == "")
        //{
        //    Debug.Log("You must enter a name!");
        //    return;
        //}
        string pName = "CHUMBA WAMBA";
        playerName = pName; // send name back to the server

        NetworkTransport.Init(); // every time a new connection.
        ConnectionConfig config = new ConnectionConfig(); // for channels between clients and server

        reliableChannelID = config.AddChannel(QosType.ReliableSequenced); // message delivered in sequence and in order

        HostTopology topology = new HostTopology(config, MAX_CONNECTION);// how the host interacts with everyone else

        hostID = NetworkTransport.AddHost(topology, 0); // open a socket
        Debug.Log("From Client. socket open, host id is " + hostID);

        connectionID = NetworkTransport.Connect(hostID, "127.0.0.1", socketPort, 0, out error);

        byte[] buffer = Encoding.ASCII.GetBytes(pName); // can only send byte arrays. convert string to individual bytes to byte array
        NetworkTransport.Send(hostID, connectionID, reliableChannelID, buffer, pName.Length * sizeof(char), out error); // send message
        isConnected = true;
    }

    public void Disconnect()
    {
        NetworkTransport.Disconnect(hostID, connectionID, out error);
    }

    public void SendDatagram()
    {
        string message = GameObject.Find("NameInput").GetComponent<InputField>().text;
        byte[] buffer = Encoding.ASCII.GetBytes(message); // can only send byte arrays. convert string to individual bytes to byte array
        NetworkTransport.Send(hostID, connectionID, reliableChannelID, buffer, message.Length * sizeof(char), out error); // send message
    }
}
