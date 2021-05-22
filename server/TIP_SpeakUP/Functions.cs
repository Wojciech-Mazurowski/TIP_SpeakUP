using System.Collections.Generic;

namespace TIP_SpeakUP
{
    class Functions
    {

        public static Dictionary<string, List<string>> Voicechats = new Dictionary<string, List<string>>();
        

        /// <summary>
        ///  function realizing client requests
        /// </summary>
        /// <param name="OP">Operation requested by client</param>
        /// <returns></returns>
        public static string DecodeOperation(string OP)
        {
            string anwser="";
            string[] Split_OP = OP.Split("$$");
            string login;
            string pass;
            string new_pass;
            string server_name;

            switch (Split_OP[0])
            {
                case "LOG":
                    (login, pass) = (Split_OP[1], Split_OP[2]);
                    anwser = LoginService.Login(login, pass);
                    break;
                case "REG":
                    (login, pass) = (Split_OP[1], Split_OP[2]);
                    anwser = LoginService.Register(login,pass);
                    break;
                case "CHP":
                    (login, pass) = (Split_OP[1], Split_OP[2]);
                    //todo zmiana hasła
                    anwser = "OK";
                    break;
                case "REF":
                    anwser = "OK";
                    foreach (var e in Voicechats)
                    {
                        anwser += "$$" + e.Key;
                    }
                    break;
                case "ADD":
                    server_name = Split_OP[1];
                    Voicechats.Add(server_name, new List<string>());
                    anwser = "OK";
                    foreach (var e in Voicechats)
                    {
                        anwser +="$$"+e.Key;
                    }
                    break;
                case "SHW":
                    anwser = "OK";
                    foreach (var e in Voicechats)
                    {
                        if (e.Key == Split_OP[1])
                        {
                            e.Value.ForEach(x => anwser += "$$" + x);
                        }
                    }
                    break;
                case "JON":
                    string server_name = Split_OP[1];

                    anwser = "OK";
                    
                    break;
                default:
                    anwser = "OK";
                    break;
            }


            return anwser;
        }
    }
}
