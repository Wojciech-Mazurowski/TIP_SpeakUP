using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIP_SpeakUP
{
    class Functions
    {

        private static List<string> VoiceChats = new List<string>();

        /// <summary>
        ///  function realizing client requests
        /// </summary>
        /// <param name="OP">Operation requested by client</param>
        /// <returns></returns>
        public static string DecodeOperation(string OP)
        {
            string anwser;
            string[] Split_OP = OP.Split("$$");
            string login;
            string pass;
            switch (Split_OP[0])
            {
                case "LOG":
                    login = Split_OP[1];
                    pass = Split_OP[2];
                    //todo sprawdzenie loginu z bazy danych i zalogowanie ewentualne 
                    anwser = "OK";
                    break;
                case "REG":
                    login = Split_OP[1];
                    pass = Split_OP[2];
                    //todo rejestracja do bazy danych i zalogowanie
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
