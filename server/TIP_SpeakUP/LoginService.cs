using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace TIP_SpeakUP
{
    class LoginService
    {
        public static DataBase_Operations db = new DataBase_Operations("URI=FILE:Users.db");
        public static Dictionary<string,TcpClient> ActiveUsers = new Dictionary<string, TcpClient>();


        private static bool Check_avability(string username)
        {
            string[] user = db.get_account(username);

            if (user[0] == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private static bool Check_user(string username, string password)
        {
            string[] user = db.get_account(username);

            if (user[0] == username && user[1] == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static string Register(string username, string password,TcpClient client)
        {
            if (Check_avability(username) == false)
            {
                return "ERR$$User already exists";
            }
            else
            {
                db.add_account(username, password);
                ActiveUsers.Add(username, client);
                foreach (KeyValuePair<string, TcpClient> kvp in LoginService.ActiveUsers)
                {
                    Console.WriteLine("Uzytkownik: {0}, jego IP: = {1}", kvp.Key, kvp.Value.Client.RemoteEndPoint);
                }
                return "REG";
            }

        }

        public static string Login(string username, string password,TcpClient client)
        {
            if (Check_avability(username) == true)
            {
                return "ERR$$Wrong username or password";
            }
            else
            {
                if (Check_user(username, password))
                {
                    string anwser = "LOG";
                    foreach (var e in Functions.Voicechats)
                    {
                        anwser += "$$" + e.Key;
                    }

                    ActiveUsers.Add(username,client);
                    foreach (KeyValuePair<string, TcpClient> kvp in LoginService.ActiveUsers)
                    {
                        Console.WriteLine("Uzytkownik: {0}, jego IP: = {1}", kvp.Key, kvp.Value.Client.RemoteEndPoint);
                    }
                    return anwser;
                }
                else
                {
                    return "ERR$$Wrong username or password";
                }

            }
        }
    }
}

