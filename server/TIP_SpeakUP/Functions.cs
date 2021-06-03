using System.Collections.Generic;
using System.Net.Sockets;

namespace TIP_SpeakUP
{
    class Functions
    {
        
        public static Dictionary<string, List<string>> Voicechats = new Dictionary<string, List<string>>();

        public static void SendMessages()
        {

        }

        /// <summary>
        ///  function realizing client requests
        /// </summary>
        /// <param name="OP">Operation requested by client</param>
        /// <returns></returns>
        public static string DecodeOperation(string OP,TcpClient client = null)
        {
            string anwser="";
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
                    anwser = LoginService.Register(login,pass, client);
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
                        anwser +="$$"+e.Key;
                    }
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
                    if(!Voicechats[server_name].Contains(login))
                    {
                        foreach (var e in Voicechats.Values)
                        {
                            if(e.Contains(login))
                            {
                                e.Remove(login);
                                break;
                            }
                        }
                        Voicechats[server_name].Add(login);
                    }
                    anwser = "JON";
                    
                    break;
                case "DSC":
                    login = Split_OP[2];
                    System.Console.WriteLine(login);
                    foreach (var e in Voicechats.Values)
                    {
                        if (e.Contains(login))
                        {
                            System.Console.WriteLine(e);
                            e.Remove(login);
                            break;
                        }
                    }
                    anwser = "DSC";
                    break;
                default:
                    anwser = "OK";
                    break;
            }


            return anwser;
        }
    }
}
