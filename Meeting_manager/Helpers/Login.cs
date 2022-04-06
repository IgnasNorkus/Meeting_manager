using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meeting_manager.Models;

namespace Meeting_manager.Helpers
{
    public class Login
    {
        public static string User;
        public static bool IsLoggedIn = false;

        public static void LoginUser()
        {
            Console.Clear();
            Console.WriteLine("Name: ");
            string UserName = Console.ReadLine();
            Console.WriteLine("Password: ");
            string UserPass = Console.ReadLine();

            LoggingIn(UserName, UserPass);
        }

        public static void LoggingIn(string name, string password)
        {
            List<Users> info = Database.users;

            var data = info.FirstOrDefault(o => o.name == name && o.password == password).ToString();
            if (data != null)
            {
                Console.Clear();
                Console.WriteLine("Logged in as " + name + "\n");

                IsLoggedIn = true;
                User = name;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong name or password \n");
            }
        }
    }
}
