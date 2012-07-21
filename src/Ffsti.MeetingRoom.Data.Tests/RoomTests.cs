using System;
using System.Linq;
using Ffsti.MeetingRoom.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ffsti.MeetingRoom.Data.Tests
{
    [TestClass]
    public class RoomTests
    {
        private RoomRepository repository = new RoomRepository();

        [TestMethod]
        public void Room01AddTest()
        {
            var Room = new Room
            {
                Capacity = 100,
                Color = "#ff00ff",
                HasProjector = true,
                Name = "Room 01"
            };
            repository.Add(Room);
            Assert.IsTrue(repository.Save());
        }

        [TestMethod]
        public void Room02ListAllTest()
        {
            Assert.IsInstanceOfType(repository.ListAll(), typeof(IQueryable<Room>));
        }

        [TestMethod]
        public void Room03FindTest()
        {
            Assert.IsInstanceOfType(repository.Find(1), typeof(Room));
        }

        [TestMethod]
        public void Room04EditTest()
        {
            var Room = repository.Find(1);
            Room.Name = "Teste Editado";
            repository.Edit(Room);
            Assert.IsTrue(repository.Save());
        }

        [TestMethod]
        public void Room05DeleteTest()
        {
            repository.Delete(1);
            Assert.IsTrue(repository.Save());
        }
    }
}
