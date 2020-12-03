using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer____Server_Script
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverIP = "";
            string serverPortNumber = "";
            Console.Write("Enter Server IP Address : ");
            serverIP = Console.ReadLine();
            Console.WriteLine("Enter Server Port Number : ");
            serverPortNumber = Console.ReadLine();
            Console.Write("\n Sending to : " + serverIP + serverPortNumber);

            Socket sendSocket;
            sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress destinationIP = IPAddress.Parse(serverIP);
            int destinationPortNumber = Int16.Parse(serverPortNumber);
            IPEndPoint destinationEndPoint = new IPEndPoint(destinationIP, destinationPortNumber);
            Console.WriteLine("\n Waiting to Connect ...");
            sendSocket.Connect(destinationEndPoint);
            Console.WriteLine("Connected...");
            string message = GetMessage();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            Console.WriteLine("\nSending Data...");
            sendSocket.Send(data, SocketFlags.None);
            Console.WriteLine("Sending Complete...");
            Console.ReadLine();




        }

        private static string GetMessage()
        {
            string message;
            Console.WriteLine("\n Enter message to send : ");
            message = Console.ReadLine();
            return message;
        }
    }
}
