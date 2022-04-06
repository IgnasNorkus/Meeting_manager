using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meeting_manager.Models;

namespace Meeting_manager.Helpers
{
    internal class MainMenu
    {
        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine(
                    "1 - Meeting management \n"+
                    "2 - Login \n"+
                    "3 - Register");

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        if (Login.IsLoggedIn)
                        {
                            MeetingMenu.Menu();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You need to be logged in!\n");
                        }
                        break;
                    case "2":
                        Login.LoginUser();
                        break;
                    case "3":
                        Register.UserRegistration();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice, try again!");
                        break;

                }
            }
        }
    }
}
