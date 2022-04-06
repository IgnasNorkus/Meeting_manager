using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Meeting_manager.Models
{
    public class Database
    {
        public static List<Users> users = new();
        public static List<Meetings> meetings = new();

        public static void SaveData()
        {
            var saveChanges = JsonConvert.SerializeObject(users);
            File.WriteAllText("users.json", saveChanges);
        }

        public static void LoadData()
        {
            var loadChanges = File.ReadAllText("users.json");
            users = JsonConvert.DeserializeObject<List<Users>>(loadChanges);
        }

        public static void SaveMeetings()
        {
            var save = JsonConvert.SerializeObject(meetings);

            File.WriteAllText("meetings.json", save);
        }

        public static void LoadMeetings()
        {
            var data = File.ReadAllText("meetings.json");
        }
    }
}
