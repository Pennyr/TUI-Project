using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPClient : IDisposable { 

    Thread receiveThread;
    UdpClient client;

    public int port;
    public string lastReceivedUDPPacket = "";

    public void Begin()
    {
        port = 11001;
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }
   
    // receive thread
    private void ReceiveData()
    {
        while (true)
        {
            client = new UdpClient(port);
            IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = client.Receive(ref anyIP);
            string text = Encoding.UTF8.GetString(data);
            lastReceivedUDPPacket = text;
        }
    }

    public ThreadState threadStat()
    {
        return receiveThread.ThreadState;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}