using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting_manager.Models
{
    public class Meetings
    {
        public List<string> people = new List<string>();

        public string ResponsiblePerson { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public void AddUserToMeeting(string name)
        {
            if (people.Contains(name))
            {
                return;
            }
            people.Add(name);
        }

        public string printPeopleList()
        {
            var builder = new StringBuilder();
            people.ForEach(x => builder.AppendLine(x + ","));
            return builder.ToString();
        }

        public void RemovePersonFromMeeting(string name)
        {
            people.Remove(name);
        }
    }
}
