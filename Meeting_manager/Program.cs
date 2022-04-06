using System;
using Newtonsoft.Json;
using Meeting_manager.Models;
using Meeting_manager.Helpers;

namespace Meeting_manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.LoadData();
            Database.LoadMeetings();
            MainMenu.Menu();
        }
    }
} 