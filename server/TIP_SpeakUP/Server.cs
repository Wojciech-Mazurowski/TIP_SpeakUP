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
        private bool _isRunning;
        private IPAddress ip = IPAddress.Parse("127.0.0.1");
        private int port = 6969;


        public Server()
        {
            Console.WriteLine("Server is running...");
            _server = new TcpListener(ip, port);
            _server.Start();
            _isRunning = true;
            Console.WriteLine("server ip: " + ip);
            Console.WriteLine("__________________________________________________________\n");
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
            // retrieve client 
            TcpClient client = (TcpClient)obj;

            // set writer/reader stream
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            Boolean bClientConnected = true;
            String Data = null;

            while (bClientConnected)
            {

                Data = sReader.ReadLine();
          
                if (Data == "EXT")//todo usunąć to gówno i wkleic to w Functions zeby latwiej usuwać z ActiveUsers
                {
                    sWriter.WriteLine("EXT");
                    sWriter.Flush();
                    bClientConnected = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(client.Client.RemoteEndPoint + ": " + "disconnected");
                    Console.ResetColor();
                }
                else
                {
                    string ans = Functions.DecodeOperation(Data);
                    sWriter.WriteLine(ans);
                    sWriter.Flush();

                }

            }
        }
    }
}
