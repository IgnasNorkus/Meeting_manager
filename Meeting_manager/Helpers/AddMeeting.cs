using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meeting_manager.Models;

namespace Meeting_manager.Helpers
{
    public class AddMeeting
    {
        public static void AddaMeeting()
        {
            Meetings meeting = new Meetings();
            while (true)
            {
                Console.Clear();
                meeting.ResponsiblePerson = Login.User;
                Console.WriteLine("Meeting member: ");
                meeting.AddUserToMeeting(Console.ReadLine());
                Console.WriteLine("Meeting description: ");
                meeting.Description = Console.ReadLine();
                Console.WriteLine("Meeting category: \n"+
                    "1 - CodeMonkey \n"+
                    "2 - Hub \n"+
                    "3 - Short \n"+
                    "4 - TeamBuilding");
                int selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:

                        meeting.Category = "CodeMonkey";
                        Console.WriteLine(meeting.Category);
                        break;

                    case 2:

                        meeting.Category = "Hub";
                        Console.WriteLine(meeting.Category);
                        break;

                    case 3:

                        meeting.Category = "Short";
                        Console.WriteLine(meeting.Category);
                        break;

                    case 4:

                        meeting.Category = "TeamBuilding";
                        Console.WriteLine(meeting.Category);
                        break;
                    default:
                        Console.WriteLine("Invalid selection, try again!");
                        break;
                }

                Console.WriteLine("Choose meeting type: \n"+
                    "1 - Live \n"+
                    "2 - InPerson");
                int typeSelection = int.Parse(Console.ReadLine());
                switch (typeSelection)
                {
                    case 1:
                        meeting.Type = "Live";
                        Console.WriteLine(meeting.Type);
                        break;
                    case 2:
                        meeting.Type = "InPerson";
                        Console.WriteLine(meeting.Type);
                        break;
                }

                Console.WriteLine("Enter start date:");
                meeting.StartDate = Console.ReadLine();
                Console.WriteLine("Enter end date:");
                meeting.EndDate = Console.ReadLine();

                Database.meetings.Add(meeting);
                Database.SaveMeetings();

                Console.WriteLine("Meeting succesfully created");
                break;
            }
        }
    }
}
