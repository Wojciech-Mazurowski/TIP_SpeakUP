namespace TIP_SpeakUP
{
    class LoginService
    {
        public static DataBase_Operations db = new DataBase_Operations("URI=FILE:Users.db");
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


        public static string Register(string username, string password)
        {
            if (Check_avability(username) == false)
            {
                return "ERR$$User already exists";
            }
            else
            {
                db.add_account(username, password);
                return "OK";
            }

        }

        public static string Login(string username, string password)
        {
            if (Check_avability(username) == true)
            {
                return "ERR$$Wrong username or password";
            }
            else
            {
                if (Check_user(username, password))
                {
                    string anwser = "OK";
                    foreach (var e in Functions.Voicechats)
                    {
                        anwser += "$$" + e.Key;
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

