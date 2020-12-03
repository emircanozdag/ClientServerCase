using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ClientServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //string localAddress = LocalIPAdress();
            //Console.WriteLine(localAddress);
            //Console.ReadKey();
            Socket listenSocket;
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int portNumber = 2085;
            IPEndPoint localIPEndPoint = new IPEndPoint(IPAddress.Any, portNumber);
            listenSocket.Bind(localIPEndPoint);
            Console.WriteLine(" Server IP Address : " + LocalIPAdress());
            Console.WriteLine(" Listenin on Port : " + portNumber);
            listenSocket.Listen(4);
            Socket acceptedSocket = listenSocket.Accept();
            byte[] receiveBuffer = new byte[1024];
            int receiveByteCount;
            receiveByteCount = acceptedSocket.Receive(receiveBuffer, SocketFlags.None);
            if (receiveByteCount > 0)
            {
                string message = Encoding.ASCII.GetString(receiveBuffer, 0, receiveByteCount);
                Console.WriteLine(message);
            }
            acceptedSocket.Shutdown(SocketShutdown.Both);
            acceptedSocket.Close();
            Console.ReadLine();
        }
        public static string LocalIPAdress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
        
    }
}
