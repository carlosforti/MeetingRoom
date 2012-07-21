using System;
using System.Linq;
using Ffsti.MeetingRoom.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ffsti.MeetingRoom.Service.Tests
{
    [TestClass]
    public class ContactTypeServiceTest
    {
        private ContactTypeService service = new ContactTypeService();

        [TestMethod]
        public void ContactTypeService01Add()
        {
            var contactType = new ContactType("Teste Service");
            Assert.IsTrue(service.Add(contactType));

            Assert.IsTrue(service.Add(new ContactType("Teste Service 2")));
        }

        [TestMethod]
        public void ContactTypeService02ListAll()
        {
            Assert.IsInstanceOfType(service.ListAll(), typeof(IQueryable<ContactType>));
        }

        [TestMethod]
        public void ContactTypeService03Find()
        {
            Assert.IsInstanceOfType(service.Find(1), typeof(ContactType));
        }

        [TestMethod]
        public void ContactTypeService04Edit()
        {
            var contactType = service.Find(1);
            Assert.IsTrue(service.Edit(contactType));
        }

        [TestMethod]
        public void ContactTypeService05Delete()
        {
            Assert.IsTrue(service.Delete(4));
        }
    }
}
