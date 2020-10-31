using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerAndStreamWork
{
    class Server
    {
        Socket serverSocket;
        Socket client;
        IPEndPoint endPoint;
        StringBuilder stringBuilder = new StringBuilder();
        byte[] data = default;
        string stringRequest = default;
        bool isRunning = false;

        public Server()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(IPAddress.Parse("192.168.0.103"), 8080);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(10);
        }
        public void Start()
        {
            Thread startThread = new Thread(ServerRun);
            startThread.Start();
            isRunning = true;
        }

        private void ServerRun()
        {
            while (isRunning)
            {
                client = serverSocket.Accept();
                while (client.Available > 0)
                {
                    data = new byte[255];
                    client.Receive(data);
                    stringRequest = stringBuilder.Append(System.Text.Encoding.UTF8.GetString(data)).ToString();
                    Request request = Request.Parse(stringRequest);
                    Thread.Sleep(1000);
                }



                client.Send(data);
                client.Shutdown(SocketShutdown.Both);
                client.Close();

            }
        }
    }
}
