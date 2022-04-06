using Xunit;
using Meeting_manager.Models;
using Meeting_manager.Helpers;

namespace Meeting_manager.UnitTests
{
    public class MeetingTests
    {

        public Meetings CreateAMeetingForTest()
        {
            var database = new Database();
            Meetings newMeeting = new Meetings();
            newMeeting.people.Add("people1");
            newMeeting.ResponsiblePerson = "responsible";
            newMeeting.Description = "description";
            newMeeting.Category = "category";
            newMeeting.Type = "type";
            newMeeting.StartDate = "2022.01.01";
            newMeeting.EndDate = "2022.01.01";
            Database.meetings.Add(newMeeting);

            return newMeeting;
        }

        [Fact]
        public void RegisterAUser()
        {
            var database = new Database();
            Users newUser = new Users();
            newUser.name = "name";
            newUser.password = "password";
            Database.users.Add(newUser);

            var savedItem = Assert.Single(Database.users);
            Assert.NotNull(savedItem);
            Assert.Equal("name", savedItem.name);
        }

        [Fact]
        public void CreateMeeting()
        {
            CreateAMeetingForTest();

            var savedMeeting = Assert.Single(Database.meetings);
            Assert.NotNull(savedMeeting);
            Assert.Equal("description", savedMeeting.Description);
        }

        [Fact]
        public void AddExistingUserToMeeting()
        {
            var database = CreateAMeetingForTest();

            database.AddUserToMeeting(new("people1"));

            Assert.True(database.people.Count == 1);

        }

        [Fact]
        public void AddUserToAMeeting()
        {
            var database = CreateAMeetingForTest();

            database.AddUserToMeeting(new("people2"));

            Assert.True(database.people.Count == 2);
        }

        [Fact]
        public void DeletePersonFromMeeting()
        {
            var database = CreateAMeetingForTest();

            database.RemovePersonFromMeeting("people1");

            Assert.True(database.people.Count == 0);
        }


    }
}