using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;
using System.Net;


public class LowPassFilter
{
    private float _smoothingFactor;
    public float SmoothedValue;

    public LowPassFilter(float smoothingFactor)
    {
        _smoothingFactor = smoothingFactor;
    }

    public void Step(float sensorValue)
    {
        SmoothedValue = _smoothingFactor * sensorValue + (1 - _smoothingFactor) * SmoothedValue;
    }

}
public class InputController
{
    public float CurrentValue;

    // The range of inputs we expect. In this case we're saying it'll be between 0 and 30cm
    float _minInputY = 0f;
    float _maxInputY = 30;

    // The Y range that the plane can move within
    float _minFinalY = -4f;
    float _maxFinalY = 4;

    public void Begin(string ipAddress, int port)
    {/*
        Debug.Log("Step 2");
        // Give the network stuff its own special thread
        //var thread = new Thread(() =>
        //{
            // We'll use `LowPassFilter` to filter out some incorrect readings coming from the sensor
            var filter = new LowPassFilter(0.95f);

            // This class makes it super easy to do network stuff
            var client = new TcpClient();

            // Change this to your devices real address
            client.Connect(ipAddress, port);
            Debug.Log("Step 3");
            var stream = new StreamReader(client.GetStream());

            // We'll read values and buffer them up in here
            var buffer = new List<byte>();
            while (client.Connected)
            {
            client.Close();
                // Read the next byte
                var read = stream.Read();

                // We split readings with a carriage return, so check for it 
                if (read == 13)
                {
                    // Once we have a reading, convert our buffer to a string, since the values are coming as strings
                    var str = Encoding.ASCII.GetString(buffer.ToArray());

                    // We assume that they're floats
                    var dist = float.Parse(str);

                    // Ignore any value outside of our expected input range
                    dist = Mathf.Clamp(dist, _minInputY, _maxInputY);

                    // Use the `LowPassFilter` to smooth out values
                    filter.Step(dist);

                    // Remap the value from our input range to our planes movement range
                    CurrentValue = filter.SmoothedValue;//.Remap(_minInputY, _maxInputY, _minFinalY, _maxFinalY);

                    // Clear the buffer ready for another reading
                    buffer.Clear();
                }
                else
                    // If this wasn't the end of a reading, then just add this new byte to our buffer
                    buffer.Add((byte)read);
            }
       // });

        //thread.Start();*/
        // This constructor arbitrarily assigns the local port number.
        UdpClient udpClient = new UdpClient(11001);
        try //client
        {
            //udpClient.Connect();

            // Sends a message to the host to which you have connected.
            Byte[] sendBytes = Encoding.ASCII.GetBytes("This is the message you from unity");

            udpClient.Send(sendBytes, sendBytes.Length, "192.168.0.14", 11000);

            //IPEndPoint object will allow us to read datagrams sent from any source.
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            // Blocks until a message returns on this socket from a remote host.
            Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
            string returnData = Encoding.ASCII.GetString(receiveBytes);

            // Uses the IPEndPoint object to determine which of these two hosts responded.
            Debug.Log("This is the message you received " +
                              returnData.ToString());
            Debug.Log("This message was sent from " +
                              RemoteIpEndPoint.Address.ToString() +
                              " on their port number " +
                              RemoteIpEndPoint.Port.ToString());

            udpClient.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

}