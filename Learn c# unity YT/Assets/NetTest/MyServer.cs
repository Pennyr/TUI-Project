using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ServerClient
{
    public int connectionID;
    public string PlayerName;
}

public class MyServer : MonoBehaviour
{
    private const int MAX_CONNECTION = 10;

    private int socketPort = 5701;

    private int hostID;

    private int connectionID;
    
    private int reliableChannelID;
    private byte error;
    private bool isStarted = true;


    public GameObject PlayerObject;

    private List<GameObject> players;
    private List<ServerClient> clients = new List<ServerClient>();

    // Use this for initialization
    void Start()
    {
        NetworkTransport.Init(); // every time a new connection.
        ConnectionConfig config = new ConnectionConfig(); // for channels between clients and server
        reliableChannelID = config.AddChannel(QosType.ReliableSequenced); // message delivered in sequence and in order
        HostTopology topology = new HostTopology(config, MAX_CONNECTION);// how the host interacts with everyone else
        hostID = NetworkTransport.AddHost(topology, socketPort, null); // open a socket
        Debug.Log("From Server. socket open, host id is " + hostID);
        isStarted = true;

    }

    // Update is called once per frame
    void Update ()
    {
        if (isStarted)
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
                case NetworkEventType.ConnectEvent:
                    //GameObject temp = Instantiate(PlayerObject, transform.position, transform.rotation);
                    //players.Add(temp);
                    Debug.Log("Player " + connectionID + " has connected");
                    OnConnection(connectionID);
                    break;
                case NetworkEventType.DataEvent:
                    string msg = Encoding.Unicode.GetString(recBuffer, 0, datasize);
                    Debug.Log("Receiving:: " + msg);
                    //string[] splitData = msg.Split('|');
                    //switch (splitData[0])
                    //{
                    //    case "MOVE":
                    //        Move(splitData[1], splitData[2], players[recConnectionID]);
                    //        break;
                    //}
                    break;
                case NetworkEventType.DisconnectEvent:
                    Debug.Log("Player " + connectionID + " has disconnected");
                    break;
            }
        }
    }

    void Move(string x, string y, GameObject obj)
    {
        float xMove = float.Parse(x);
        float yMove = float.Parse(y);
        obj.transform.Translate(xMove, 0, yMove);
    }

    private void OnConnection(int cnnID)
    {
        // add him to a list
        ServerClient c = new ServerClient();
        c.connectionID = cnnID;
        c.PlayerName = "TEMP";
        clients.Add(c);

        // when the player joins the server, tell him his ID
        // request his name and send the name of all the other players

        string msg = "ASKNAME|" + cnnID + "|";
        foreach (ServerClient sc in clients)
        {
            msg += sc.PlayerName + '%' + sc.connectionID + '|';
        }

        msg = msg.Trim('|');

        // ASKNAME|3|DAVE%1|MICH%2
        Send(msg, reliableChannelID, cnnID);
        
    }

    private void Send(string message, int channelId, int cnnId)
    {
        List<ServerClient> c = new List<ServerClient>();
        c.Add(clients.Find(x => x.connectionID == cnnId));
        Send(message, channelId, c);
    }

    private void Send(string message, int channelId, List<ServerClient> c)
    {
        Debug.Log("Sending : " + message);
        byte[] msg = Encoding.Unicode.GetBytes(message);
        foreach(ServerClient sc in clients)
        {
            NetworkTransport.Send(hostID, sc.connectionID, channelId, msg, message.Length * sizeof(char), out error);
        }
    }
}
