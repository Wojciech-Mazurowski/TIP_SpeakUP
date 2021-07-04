using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;


namespace SpeakUP
{
    class Client
    {
        private static TcpClient _TCPclient;
        private static StreamReader _streamReader;
        private static StreamWriter _streamWriter;
        private static bool _isConnected;
        public static string data;
        public static string server_ip = "127.0.0.1";
        public static int port = 6969;
        public static String streamDataIncomming;

        public Client() { }
        public static bool runTCPclient()
        {
            try
            { 
                IPAddress ip = IPAddress.Parse(server_ip);
                _TCPclient = new TcpClient();
                _TCPclient.Connect(ip, port);
                HandleCommunication();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static void HandleCommunication()
        {
          

            _isConnected = true;

        }

        public static void send(string text)
        {
            _streamReader = new StreamReader(_TCPclient.GetStream(), Encoding.ASCII);
            _streamWriter = new StreamWriter(_TCPclient.GetStream(), Encoding.ASCII);

            if (_isConnected)
            {
                // write data and make sure to flush, or the buffer will continue to 
                // grow, and your data might not be sent when you want it, and will
                // only be sent once the buffer is filled.
                _streamWriter.WriteLine(text);
                _streamWriter.Flush();
            }

        }


        public static string listen()
        {
            if (_isConnected)
            {
                try
                {
                    streamDataIncomming = _streamReader.ReadLine();
                    return streamDataIncomming;
                }
                catch { }
            }
            return "false";
        }

        public static void close(string name)
        {
            send("EXT$$" + name);
            listen();
            _streamReader.Close();
            _streamWriter.Close();
            _TCPclient.Client.Close();
            _TCPclient.Close();
        }
    }
}
