using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class tcpServer : MonoBehaviour
{
    //#region private members 	
    ///// <summary> 	
    ///// TCPListener to listen for incomming TCP connection 	
    ///// requests. 	
    ///// </summary> 	
    //private TcpListener tcpListener;
    ///// <summary> 
    ///// Background thread for TcpServer workload. 	
    ///// </summary> 	
    //private Thread tcpListenerThread;
    ///// <summary> 	
    ///// Create handle to connected tcp client. 	
    ///// </summary> 	
    //private TcpClient connectedTcpClient;

    //private Boolean _isRunning;
    //#endregion

    //// Use this for initialization
    //void Start()
    //{
    //    // Start TcpServer background thread 		
    //    tcpListenerThread = new Thread(new ThreadStart(ListenForIncommingRequests));
    //    tcpListenerThread.IsBackground = true;
    //    tcpListenerThread.Start();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        SendMessage();
    //    }

    //    while (_isRunning)
    //    {
    //        // wait for client connection
    //        TcpClient newClient = tcpListener.AcceptTcpClient();

    //        // client found.
    //        // create a thread to handle communication
    //        Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
    //        t.Start(newClient);
    //    }
    //}


    //public void HandleClient(object obj)
    //{
    //    // retrieve client from parameter passed to thread
    //    TcpClient client = (TcpClient)obj;

        

    //}

    ///// <summary> 	
    ///// Runs in background TcpServerThread; Handles incomming TcpClient requests 	
    ///// </summary> 	
    //private void ListenForIncommingRequests()
    //{
    //    try
    //    {
    //        // Create listener on localhost port 8052. 			
    //        tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 13000);
    //        tcpListener.Start();
    //        _isRunning = true;
    //        Debug.Log("Server is listening");
    //        //Byte[] bytes = new Byte[1024];
    //        //while (true)
    //        //{
    //        //    using (connectedTcpClient = tcpListener.AcceptTcpClient())
    //        //    {
    //        //        // Get a stream object for reading 					
    //        //        using (NetworkStream stream = connectedTcpClient.GetStream())
    //        //        {
    //        //            int length;
    //        //            // Read incomming stream into byte arrary. 						
    //        //            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
    //        //            {
    //        //                var incommingData = new byte[length];
    //        //                Array.Copy(bytes, 0, incommingData, 0, length);
    //        //                // Convert byte array to string message. 							
    //        //                string clientMessage = Encoding.ASCII.GetString(incommingData);
    //        //                Debug.Log("client message received as: " + clientMessage);
    //        //            }
    //        //        }
    //        //    }
    //        //}
    //    }
    //    catch (SocketException socketException)
    //    {
    //        Debug.Log("SocketException " + socketException.ToString());
    //    }
    //}
    ///// <summary> 	
    ///// Send message to client using socket connection. 	
    ///// </summary> 	
    //private void SendMessage()
    //{
    //    if (connectedTcpClient == null)
    //    {
    //        return;
    //    }

    //    try
    //    {
    //        // Get a stream object for writing. 			
    //        NetworkStream stream = connectedTcpClient.GetStream();
    //        if (stream.CanWrite)
    //        {
    //            string serverMessage = "This is a message from your server.";
    //            // Convert string message to byte array.                 
    //            byte[] serverMessageAsByteArray = Encoding.ASCII.GetBytes(serverMessage);
    //            // Write byte array to socketConnection stream.               
    //            stream.Write(serverMessageAsByteArray, 0, serverMessageAsByteArray.Length);
    //            Debug.Log("Server sent his message - should be received by client");
    //        }
    //    }
    //    catch (SocketException socketException)
    //    {
    //        Debug.Log("Socket exception: " + socketException);
    //    }
    //}
}