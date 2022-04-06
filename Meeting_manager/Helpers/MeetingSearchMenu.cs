using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meeting_manager.Models;

namespace Meeting_manager.Helpers
{
    public class MeetingSearchMenu
    {
        public static void MeetingSearch()
        {
            Console.Clear();
            Console.WriteLine("Meeting search menu \n");
            while (true)
            {
                Console.WriteLine("1 - Show all meetings \n"+
                    "2 - Filter by type \n"+
                    "3 - Filter by category \n"+
                    "4 - Filter by number of people \n"+
                    "5 - Filter by responsible preson \n"+
                    "6 - Filter by description \n"+
                    "7 - Filter by date \n"+
                    "8 - Main menu");

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("List of all meetings: \n");
                        List<Meetings> meeting = Database.meetings;
                        PrintMeeting(meeting);
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Choose a type (Live / InPerson):");
                        string type = Console.ReadLine();
                        List<Meetings> tMeeting = Database.meetings;
                        var returnType = tMeeting.Where(x => x.Type == type).ToList();
                        if (returnType != null)
                        {
                            PrintMeeting(returnType);
                        }
                        else
                        {
                            Console.WriteLine("Not found!");
                        }
                        break;
                    case"3":
                        Console.Clear();
                        Console.WriteLine("Choose a category (CodeMonkey / Hub / Short / TeamBuilding):");
                        string category = Console.ReadLine();
                        List<Meetings> cMeeting = Database.meetings;
                        var returnCategory = cMeeting.Where(x => x.Category == category).ToList();
                        if (returnCategory != null)
                        {

                            PrintMeeting(returnCategory);

                        }
                        else
                        {
                            Console.WriteLine("Category not found!");
                        }
                        break;
                    case"4":
                        Console.Clear();
                        Console.WriteLine("Enter number of meeting members");
                        int numPeople = int.Parse(Console.ReadLine());
                        List<Meetings> noMeeting = Database.meetings;
                        var returnNum = noMeeting.Where(x => x.people.Count() == numPeople).ToList();
                        if (returnNum != null)
                        {

                            PrintMeeting(returnNum);

                        }
                        else
                        {
                            Console.WriteLine("Members not found!");
                        }
                        break;
                    case"5":
                        Console.Clear();
                        Console.WriteLine("Enter responsible person:");
                        string reponsiblePerson = Console.ReadLine();
                        List<Meetings> mainPerson = Database.meetings;
                        var returnMainP = mainPerson.Where(x => x.ResponsiblePerson == reponsiblePerson).ToList();
                        if (returnMainP != null)
                        {

                            PrintMeeting(returnMainP);

                        }
                        else
                        {
                            Console.WriteLine("Responsible person not found!");
                        }
                        break;
                    case"6":
                        Console.Clear();
                        Console.WriteLine("Enter meeting description:\n");
                        string desc = Console.ReadLine();
                        List<Meetings> description = Database.meetings;
                        var returnDesc = description.Where(x => x.Description == desc).ToList();
                        if (returnDesc != null)
                        {
                            PrintMeeting(returnDesc);

                        }
                        else
                        {
                            Console.WriteLine("Description not found!");
                        }
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Enter start date");
                        string enterStart = Console.ReadLine();
                        Console.WriteLine("Enter end date");
                        string enterEnd = Console.ReadLine();
                        List<Meetings> fDate = Database.meetings;
                        var returnDate = fDate.Where(x => x.StartDate == enterStart && x.EndDate == enterEnd).ToList();
                        if (returnDate != null)
                        {

                            PrintMeeting(returnDate);

                        }
                        else
                        {
                            Console.WriteLine("Meetings with such date not found");
                        }
                        break;
                    case "8":
                        Console.Clear();
                        MeetingMenu.Menu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice, try again!");
                        break;
                }
            }
        }

        public static void PrintMeeting(List<Meetings> meeting)
        {
            meeting.ForEach(m => Console.WriteLine(
                                "Responsible person: {0}\n" +
                                "Members: {1}\n" +
                                "Description: {2}\n" +
                                "Category: {3}\n" +
                                "Meeting type: {4}\n" +
                                "Start of meeting: {5}\n" +
                                "End of meeting: {6}\n\n",
                                 m.ResponsiblePerson, m.printPeopleList(), m.Description, m.Category, m.Type, m.StartDate, m.EndDate));
        }
    }
}
