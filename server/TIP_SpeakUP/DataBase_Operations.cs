using System;
using System.Collections.Generic;
using System.Data.SQLite;
namespace TIP_SpeakUP
{
    public class DataBase_Operations
    {

        SQLiteConnection database;
        public DataBase_Operations(string cs)
        {
            database = new SQLiteConnection(cs);

            SQLiteCommand com = new SQLiteCommand(database);
            database.Open();
            com.CommandText = "CREATE TABLE IF NOT EXISTS USERS (ID INTEGER PRIMARY KEY AUTOINCREMENT,username varchar(255),password varchar(255))";
            com.ExecuteNonQuery();
            database.Close();
        }


        public List<string> get_accounts()
        {
            database.Open();
            SQLiteCommand com = database.CreateCommand();
            SQLiteDataReader sqlite_datareader;
            List<string> accounts = new List<string>();
            com.CommandText = "SELECT * FROM USERS";

            sqlite_datareader = com.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                accounts.Add($"{sqlite_datareader.GetString(1)}");
            }
            database.Close();
            //zwraca wszystkie konta
            return accounts;
        }

        public string add_account(string username, string password)
        {

            database.Open();
            SQLiteCommand com = new SQLiteCommand(database);
            com.CommandText = "INSERT INTO USERS(username, password) VALUES(@username, @password)";
            com.Parameters.AddWithValue("@username", username);
            com.Parameters.AddWithValue("@password", password);
            com.Prepare();
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            database.Close();
            //dodawanie konta
            return "OK";
        }



        public string[] get_account(string username)
        {
            database.Open();
            SQLiteCommand com = database.CreateCommand();
            SQLiteDataReader sqlite_datareader;
            string[] account = new string[2];
            com.CommandText = "SELECT * FROM USERS WHERE username = @username";
            com.Parameters.AddWithValue("@username", username);

            try
            {
                sqlite_datareader = com.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    account[0] = sqlite_datareader.GetString(1);
                    account[1] = sqlite_datareader.GetString(2);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
            database.Close();
            //zwraca konto / jezeli pusty array to nie istnieje

            return account;
        }

    }
}
