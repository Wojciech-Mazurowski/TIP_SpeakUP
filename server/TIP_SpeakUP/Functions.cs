using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TIP_SpeakUP
{
    class Functions
    {
        public static Dictionary<string, List<string>> Voicechats = new Dictionary<string, List<string>>();

        public static event EventHandler Disconnect;

        /// <summary>
        ///  function realizing client requests
        /// </summary>
        /// <param name="OP">Operation requested by client</param>
        /// <returns></returns>
        public static string DecodeOperation(string OP, TcpClient client = null)
        {
            string anwser = "";
            string[] Split_OP = OP.Split("$$");
            string login;
            string pass;
            string server_name;

            switch (Split_OP[0])
            {
                case "LOG":
                    (login, pass) = (Split_OP[1], Split_OP[2]);
                    anwser = LoginService.Login(login, pass, client);
                    break;
                case "REG":
                    (login, pass) = (Split_OP[1], Split_OP[2]);
                    anwser = LoginService.Register(login, pass, client);
                    break;
                case "REF":
                    anwser = "REF";
                    foreach (var e in Voicechats)
                    {
                        anwser += "$$" + e.Key;
                    }
                    break;
                case "ADD":
                    server_name = Split_OP[1];
                    Voicechats.Add(server_name, new List<string>());
                    anwser = "ADD";
                    foreach (var e in Voicechats)
                    {
                        anwser += "$$" + e.Key;
                    }
                    Send_server_names_to_others();
                    break;
                case "SHW":
                    anwser = "SHW";
                    foreach (var e in Voicechats[Split_OP[1]])
                    {
                        anwser += "$$" + e;
                    }
                    break;
                case "JON":
                    server_name = Split_OP[1];
                    login = Split_OP[2];
                    if (!Voicechats[server_name].Contains(login))
                    {
                        foreach (var e in Voicechats.Values)
                        {
                            if (e.Contains(login))
                            {
                                e.Remove(login);
                                break;
                            }
                        }
                        Voicechats[server_name].Add(login);

                        anwser = "JON" + Get_IP_addresses(server_name, login);
                        Send_IP_address_to_others(client, server_name, login);
                        Send_active_users_to_others(server_name);
                    }
                    else
                    {
                        anwser = "ERR$$User Already In Chat";
                    }

                    break;
                case "DSC":
                    server_name = Split_OP[1];
                    login = Split_OP[2];
                    foreach (var e in Voicechats.Values)
                    {
                        if (e.Contains(login))
                        {
                            e.Remove(login);
                            break;
                        }
                    }
                    anwser = "DSC";
                    Send_IP_address_to_others(client, server_name, login);
                    Send_active_users_to_others(server_name);
                    break;
                case "EXT":
                    anwser = "EXT";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User: " + "127.0.0.1:53536" + " disconnected");
                    Console.ResetColor();
                    Disconnect.Invoke(null, null);
                    break;
                default:

                    anwser = "OK man kinda cringe";
                    break;
            }


            return anwser;
        }


        public static string Get_IP_addresses(string servername, string login)
        {

            string ans = "";


            foreach (string user in Voicechats[servername])
            {
                if (user != login)
                {
                    Console.WriteLine("user: " + user + "jego IP: " + LoginService.ActiveUsers[user].Client.RemoteEndPoint.ToString().Split(':')[0]);
                    ans += "$$" + LoginService.ActiveUsers[user].Client.RemoteEndPoint.ToString().Split(':')[0];
                }
            }
            return ans;
            //w odpowiedzi na join

        }


        public static void Send_IP_address_to_others(TcpClient client, string servername, string login)
        {
            string ans = "CAL$$";

            foreach (string user in Voicechats[servername])
            {
                if (user != login)
                {

                    StreamWriter sWriter2 = new StreamWriter(LoginService.ActiveUsers[user].GetStream(), Encoding.ASCII);
                    Console.WriteLine("wyslalem " + ans + client.Client.RemoteEndPoint.ToString().Split(':')[0] + " do " + LoginService.ActiveUsers[user].Client.RemoteEndPoint.ToString());
                    sWriter2.WriteLine(ans + client.Client.RemoteEndPoint.ToString().Split(':')[0]);
                    sWriter2.Flush();

                }
            }
        }

        public static void Send_server_names_to_others()
        {
            string ans = "REF";
            foreach (var e in Voicechats)
            {
                ans += "$$" + e.Key;
            }

            foreach (string user in LoginService.ActiveUsers.Keys)
            {
                StreamWriter sWriter2 = new StreamWriter(LoginService.ActiveUsers[user].GetStream(), Encoding.ASCII);
                Console.WriteLine("wyslalem: " + ans);
                sWriter2.WriteLine(ans);
                sWriter2.Flush();
            }
        }


        public static void Send_active_users_to_others(string servername)
        {
            string ans = "SHW";
            foreach (var e in Voicechats[servername])
            {
                ans += "$$" + e;
            }

            foreach (string user in Voicechats[servername])
            {
                {
                    StreamWriter sWriter2 = new StreamWriter(LoginService.ActiveUsers[user].GetStream(), Encoding.ASCII);
                    Console.WriteLine("wyslalem:  " + ans);
                    sWriter2.WriteLine(ans);
                    sWriter2.Flush();
                }
            }


        }
    }
}
