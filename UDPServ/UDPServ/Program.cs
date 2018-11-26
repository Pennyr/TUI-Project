using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPServ
{
    class Program
    {
        static void Main(string[] args)
        {
            // This constructor arbitrarily assigns the local port number.
            UdpClient udpClient = new UdpClient(11000);
            try //server
            {
                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);


                //udpClient.Connect();

                // Sends a message to the host to which you have connected.
                Byte[] sendBytes = Encoding.ASCII.GetBytes("A message from vis stud");


                udpClient.Send(sendBytes, sendBytes.Length, "127.0.0.1", 11001);

                

                // Uses the IPEndPoint object to determine which of these two hosts responded.
                Console.WriteLine("This is the message you received " +
                                  returnData.ToString());
                Console.WriteLine("This message was sent from " +
                                  RemoteIpEndPoint.Address.ToString() +
                                  " on their port number " +
                                  RemoteIpEndPoint.Port.ToString());

                udpClient.Close();
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
