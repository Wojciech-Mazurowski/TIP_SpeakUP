using System.Collections.Generic;
using System;


namespace TIP_SpeakUP
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Dictionary<string, List<string>> xd = new Dictionary<string, List<string>>();
             xd.Add("aaa", new List<string>());
             xd.Add("bbb", new List<string>());
             xd["aaa"].Add("helou");
             xd["aaa"].Add("helou2");
             xd["aaa"].Add("helou3");
             xd["bbb"].Add("xd123");
             xd["bbb"].Add("xd124");

             string ans = "LST$$";
             foreach(var e in xd)
             {
                 ans += e.Key;
                 ans += "$$";
                 e.Value.ForEach(x=>ans+=x+"$$");
             }
             Console.WriteLine(ans);*/

                //starting server
              Server serwer = new Server();
              Console.WriteLine("witam");







            //db.add_account("witam", "nara");
            //db.add_account("witam3", "nara");
            //db.add_account("witam4", "nara");
            //db.add_account("witam5", "nara");
            //db.get_accounts().ForEach(Console.WriteLine);


            //Console.WriteLine(Functions.db.get_account("witam")[2]);



          
            
        }
    }
}
