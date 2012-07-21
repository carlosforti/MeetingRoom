using System;
using System.Linq;
using Ffsti.MeetingRoom.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ffsti.MeetingRoom.Data.Tests
{
    [TestClass]
    public class ContactTypeTests
    {
        private ContactTypeRepository repository = new ContactTypeRepository();

        [TestMethod]
        public void ContactType01AddTest()
        {
            var contactType = new ContactType("Teste");
            repository.Add(contactType);
            repository.Add(new ContactType("Teste 2"));
            Assert.IsTrue(repository.Save());
        }

        [TestMethod]
        public void ContactType02ListAllTest()
        {
            Assert.IsInstanceOfType(repository.ListAll(), typeof(IQueryable<ContactType>));
        }

        [TestMethod]
        public void ContactType03FindTest()
        {
            Assert.IsInstanceOfType(repository.Find(1), typeof(ContactType));
        }

        [TestMethod]
        public void ContactType04EditTest()
        {
            var contactType = repository.Find(1);
            contactType.Name = "Teste Editado";
            repository.Edit(contactType);
            Assert.IsTrue(repository.Save());
        }

        [TestMethod]
        public void ContactType05DeleteTest()
        {
            repository.Delete(2);
            Assert.IsTrue(repository.Save());
        }
    }
}
