using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meeting_manager.Models;

namespace Meeting_manager.Helpers
{
    public class MeetingMenu
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Meetings Menu \n");

            while (true)
            {
                Console.WriteLine("1 - List of meetings \n" +
                    "2 - Create new meeting \n" +
                    "3 - Delete a meeting \n" +
                    "4 - Add a person to a meeting \n" +
                    "5 - Remove a person from a meeting \n" +
                    "6 - Main menu");

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        MeetingSearchMenu.MeetingSearch();
                        break;
                    case "2":
                        AddMeeting.AddaMeeting();
                        break;
                    case "3":
                        DeleteMeeting();
                        break;
                    case "4":
                        AddPersonToMeeting();
                        break;
                    case "5":
                        RemovePersonFromMeeting();
                        break;
                    case "6":
                        Console.Clear();
                        MainMenu.Menu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again!");
                        break;

                }
            }
        }

        public static void AddPersonToMeeting()
        {
            Console.Clear();
            Console.WriteLine("Add person to a meeting");
            Console.WriteLine("Enter meeting description");
            string input = Console.ReadLine();
            List<Meetings> description = Database.meetings;
            var selection = description.SingleOrDefault(m => m.Description == input);

            if (selection != null)
            {
                Console.WriteLine("Responsible person: {0}\n" +
                                "Members: {1}\n" +
                                "Description: {2}\n" +
                                "Category: {3}\n" +
                                "Meeting type: {4}\n" +
                                "Start of meeting: {5}\n" +
                                "End of meeting: {6}\n\n",
                                 selection.ResponsiblePerson, selection.printPeopleList(), selection.Description, selection.Category, selection.Type, selection.StartDate, selection.EndDate);

                Console.WriteLine("Add a person to this meeting? \n" +
                                   "1 - Yes \n" +
                                   "2 - No \n");
                var select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Console.WriteLine("Enter persons name: ");
                        string personsName = Console.ReadLine();
                        selection.AddUserToMeeting(personsName);
                        Database.SaveMeetings();
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Invalid selection, try again!");
                        break;
                }

            }
        }

        public static void DeleteMeeting()
        {
            Console.Clear();
            Console.WriteLine("Delete meeting");
            Console.WriteLine("Enter meeting description:");
            string input = Console.ReadLine();
            List<Meetings> description = Database.meetings;

            var selected = description.SingleOrDefault(x => x.Description == input);

            if (selected != null)
            {
                Console.WriteLine("Responsible person: {0}\n" +
                                "Members: {1}\n" +
                                "Description: {2}\n" +
                                "Category: {3}\n" +
                                "Meeting type: {4}\n" +
                                "Start of meeting: {5}\n" +
                                "End of meeting: {6}\n\n",
                                 selected.ResponsiblePerson, selected.printPeopleList(), selected.Description, selected.Category, selected.Type, selected.StartDate, selected.EndDate);

                Console.WriteLine("Delete this meeting? \n" +
                                   "1 - Yes \n" +
                                   "2 - No \n");

                var select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        if (Login.User == selected.ResponsiblePerson)
                        {
                            description.Remove(selected);
                            Database.SaveMeetings();
                            Console.WriteLine("Meeting has been deleted!");
                        }
                        else
                        {
                            Console.WriteLine("Only the responsible person of the meeting can delete it!");
                        }
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Invalid selection, try again!");
                        break;
                }
            }
        }
        public static void RemovePersonFromMeeting()
        {
            Console.Clear();
            Console.WriteLine("Remove person from meeting");
            Console.WriteLine("Enter meeting description:");
            string input = Console.ReadLine();
            List<Meetings> description = Database.meetings;

            var selected = description.SingleOrDefault(x => x.Description == input);

            if (selected != null)
            {
                Console.WriteLine("Responsible person: {0}\n" +
                                "Members: {1}\n" +
                                "Description: {2}\n" +
                                "Category: {3}\n" +
                                "Meeting type: {4}\n" +
                                "Start of meeting: {5}\n" +
                                "End of meeting: {6}\n\n",
                                 selected.ResponsiblePerson, selected.printPeopleList(), selected.Description, selected.Category, selected.Type, selected.StartDate, selected.EndDate);

                Console.WriteLine("Remove a person from this meeting? \n" +
                                   "1 - Yes \n" +
                                   "2 - No \n");

                var select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Console.WriteLine("Enter persons name to remove");
                        string inputName = Console.ReadLine();
                        selected.RemovePersonFromMeeting(inputName);
                        Database.SaveMeetings();
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Invalid selection, try again!");
                        break;
                }
            }
        }
    }
}
