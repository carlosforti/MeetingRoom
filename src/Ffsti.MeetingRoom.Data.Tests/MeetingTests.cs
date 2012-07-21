using System;
using System.Linq;
using Ffsti.MeetingRoom.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ffsti.MeetingRoom.Data.Tests
{
    [TestClass]
    public class MeetingTests
    {
        private MeetingRepository repository = new MeetingRepository();

        [TestMethod]
        public void Meeting01AddTest()
        {
            var Meeting = new Meeting
            {
                Contact = new Contact
                 {
                     ContactType = new ContactType("Teste"),
                     Email = "a@a.com",
                     Empresa = "Ffsti",
                     Extension = "01",
                     FirstName = "Carlos",
                     InformacoesExtras = "none",
                     LastName = "Forti",
                     Phone = "34936209",
                     Site = "http://fortieforti.com.br"
                 },
                Finish = DateTime.Now.AddHours(4),
                Participants = 100,
                Room = new Room
                {
                    Capacity = 100,
                    Color = "#ff00ff",
                    HasProjector = true,
                    Name = "Room 01"
                },
                Start = DateTime.Now.AddHours(2),
                Subject = "Teste"
            };
            repository.Add(Meeting);
            Assert.IsTrue(repository.Save());
        }

        [TestMethod]
        public void Meeting02ListAllTest()
        {
            Assert.IsInstanceOfType(repository.ListAll(), typeof(IQueryable<Meeting>));
        }

        [TestMethod]
        public void Meeting03FindTest()
        {
            Assert.IsInstanceOfType(repository.Find(1), typeof(Meeting));
        }

        [TestMethod]
        public void Meeting04EditTest()
        {
            var meeting = repository.Find(1);
            meeting.Subject = "Teste Editado";
            repository.Edit(meeting);
            Assert.IsTrue(repository.Save());
        }

        [TestMethod]
        public void Meeting05DeleteTest()
        {
            repository.Delete(1);
            Assert.IsTrue(repository.Save());
        }
    }
}
