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
            while (true)
            {
                try //server
                {
                    //IPEndPoint object will allow us to read datagrams sent from any source.
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                    // Blocks until a message returns on this socket from a remote host.
                    Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                    string returnData = Encoding.ASCII.GetString(receiveBytes);
                    Console.WriteLine("Message received " + returnData.ToString());
                    Console.WriteLine("This message was sent from " + RemoteIpEndPoint.Address.ToString() +
                                      " on their port number " + RemoteIpEndPoint.Port.ToString());
                    //udpClient.Connect();

                    // Sends a message to the host to which you have connected.
                    string inpt = Console.ReadLine();
                    if (string.IsNullOrEmpty(inpt))
                    {
                        Byte[] sendBytes = Encoding.ASCII.GetBytes("A message from visual studio");
                        udpClient.Send(sendBytes, sendBytes.Length, "127.0.0.1", 11001);
                    }

                    // Uses the IPEndPoint object to determine which of these two hosts responded.
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    udpClient.Close();
                    Console.ReadKey();
                }
            }
            
        }
    }
}
