using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;


namespace Backend_Client_SpeakUP
{
    class Client
    {
        private static TcpClient _client;
        private static StreamReader _streamReader;
        private static StreamWriter _streamWriter;
        private static Boolean _isConnected;
        public static string data;
        public static string server_ip = "127.0.0.1";
        public static int port = 6969;
        public static String streamDataIncomming;

        public Client() { }
        public static Boolean runclient()
        {
            try
            {
                IPAddress ip = IPAddress.Parse(server_ip);
                _client = new TcpClient();
                _client.Connect(ip, port);
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
            _streamReader = new StreamReader(_client.GetStream(), Encoding.ASCII);
            _streamWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);

            _isConnected = true;

        }

        public static string send(string text)
        {
            _streamReader = new StreamReader(_client.GetStream(), Encoding.ASCII);
            _streamWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);

            if (_isConnected)
            {
                // write data and make sure to flush, or the buffer will continue to 
                // grow, and your data might not be sent when you want it, and will
                // only be sent once the buffer is filled.
                _streamWriter.WriteLine(text);
                _streamWriter.Flush();

                streamDataIncomming = _streamReader.ReadLine();
                return streamDataIncomming;
            }

            return "false";
        }

        public static void close()
        {
            send("bye");
            _streamReader.Close();
            _streamWriter.Close();
            _client.Client.Close();
            _client.Close();
        }
    }
}
