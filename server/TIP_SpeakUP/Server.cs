using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace TIP_SpeakUP
{
    class Server
    {
        private TcpListener _server;
        private Boolean _isRunning;
        private IPAddress ip = IPAddress.Parse("127.0.0.1");
        private int port = 6969;


        public Server()
        {
            Console.WriteLine("Server is running...");
            _server = new TcpListener(ip, port);
            _server.Start();
            _isRunning = true;
            Console.WriteLine("ip server: " + ip);
            Console.WriteLine("-----------------------------------------------------------------\n");
            ServerLoop();
        }


        public void ServerLoop()
        {
            while (_isRunning)
            {
                // wait for client connection
                TcpClient newClient = _server.AcceptTcpClient();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(newClient.Client.RemoteEndPoint + ": " + "connected");
                Console.ResetColor();
                // client found.
                // create a thread to handle communication
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }

        public void HandleClient(object obj)
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;

            // sets two streams
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested

            Boolean bClientConnected = true;
            String sData = null;

            while (bClientConnected)
            {
                // reads from stream
                sData = sReader.ReadLine();
                sWriter.WriteLine(sData);
                sWriter.Flush();
                if(sData == "exit")
                {
                    bClientConnected = false;
                }

            }
        }
    }
}
