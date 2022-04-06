using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meeting_manager.Models;

namespace Meeting_manager.Helpers
{
    public class Register
    {
        public static void UserRegistration()
        {
            Console.Clear();
            Console.WriteLine("Enter login name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            Users newUser = new Users();
            newUser.name = name;
            newUser.password = password;
            Database.users.Add(newUser);
            Database.SaveData();
        }
    }
}
