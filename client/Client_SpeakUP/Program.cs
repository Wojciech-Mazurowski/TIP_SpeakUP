using System;
namespace Backend_Client_SpeakUP
{
    class Program
    {
        static void Main(string[] args)
        {

            Client.runclient();
            string dane;

            while (true)
            {
                Console.WriteLine("Podaj dane do wysłania:");
                dane = Console.ReadLine();
                dane = Client.send(dane);
                Console.WriteLine(dane);

            }
        }
    }
}
