using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class Arduino : MonoBehaviour
{

    // Use this for initialization
    public string ipAddress;
    public int port;

    IPEndPoint remoteEndPoint;
    UdpClient client;

    private bool received = false;



    protected void Start()
    {
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
        client = new UdpClient();
        try
        {
            client.BeginReceive(new AsyncCallback(recv), null);
        }
        catch (Exception e)
        {

        }
    }

    //CallBack
    private void recv(IAsyncResult res)
    {
        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, port);
        byte[] receivedBuffer = client.EndReceive(res, ref RemoteIpEndPoint);

        //Process codes

        //MessageBox.Show(Encoding.UTF8.GetString(received));
        client.BeginReceive(new AsyncCallback(recv), null);
        for (int i = 0; i < receivedBuffer.Length; i++)
        {
            if (receivedBuffer[i] == '!')
            {
                received = true;
            }
        }
    }

    public bool getReceived()
    {
        return received;
    }
    public void setReceived(bool rec)
    {
        received = rec;
    }
    void Update()
    {

    }

    public void sendMessage(byte[] data)
    {
        client.Send(data, data.Length, remoteEndPoint);
    }
    public void ledColor(byte index, byte red, byte green, byte blue)
    {
        byte[] data = { 0x02, index, red, green, blue };
        client.Send(data, data.Length, remoteEndPoint);
    }
    public void vibrateMotor(byte intensity, byte period)//period in ms x10
    {
        byte[] data = { 0x01, intensity, period };
        client.Send(data, data.Length, remoteEndPoint);
    }
    public void auxOut(byte intensity, byte period)//period in ms x10
    {
        byte[] data = { 0x03, intensity, period };
        client.Send(data, data.Length, remoteEndPoint);
    }
}
