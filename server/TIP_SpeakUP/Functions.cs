using System.Collections.Generic;

namespace TIP_SpeakUP
{
    class Functions
    {

        private static Dictionary<string, List<string>> Voicechats = new Dictionary<string, List<string>>();

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
            switch (Split_OP[0])
            {
                case "LOG":
                    login = Split_OP[1];
                    pass = Split_OP[2];
                    //todo sprawdzenie loginu z bazy danych i zalogowanie ewentualne 
                    anwser = "OK";
                    foreach (var e in Voicechats)
                    {
                        anwser += "$$" + e.Key;
                    }
                    break;
                case "REG":
                    login = Split_OP[1];
                    pass = Split_OP[2];
                    //todo rejestracja do bazy danych i zalogowanie
                    anwser = "OK";
                    break;
                case "CHP":
                    login = Split_OP[1];
                    new_pass = Split_OP[2];
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
                    string server_name = Split_OP[1];
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
                default:
                    anwser = "OK";
                    break;
            }


            return anwser;
        }
    }
}
