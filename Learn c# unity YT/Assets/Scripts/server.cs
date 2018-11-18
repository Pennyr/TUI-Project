using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class server : MonoBehaviour
{
    private int connectionID;
    private int maxConnections = 10;
    private int reliableChannelID;
    private int hostID;
    private int socketPort;
    private byte error;

    // Use this for initialization
    void Start()
    {
        NetworkTransport.Init(); // every time a new connection.
        ConnectionConfig config = new ConnectionConfig(); // for channels between clients and server
        reliableChannelID = config.AddChannel(QosType.ReliableSequenced); // message delivered in sequence and in order
        HostTopology topology = new HostTopology(config, maxConnections);// how the host interacts with everyone else
        hostID = NetworkTransport.AddHost(topology, socketPort, null); // open a socket
        Debug.Log("socket open, host id is " + hostID);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
