using System;
using System.Linq;
using Ffsti.MeetingRoom.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ffsti.MeetingRoom.Data.Tests
{
    [TestClass]
    public class ContactTests
    {
        private ContactRepository repository = new ContactRepository();

        [TestMethod]
        public void Contact01AddTest()
        {
            var contact = new Contact
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
            };
            repository.Add(contact);
            Assert.IsTrue(repository.Save());
        }

        [TestMethod]
        public void Contact02ListAllTest()
        {
            Assert.IsInstanceOfType(repository.ListAll(), typeof(IQueryable<Contact>));
        }

        [TestMethod]
        public void Contact03FindTest()
        {
            Assert.IsInstanceOfType(repository.Find(1), typeof(Contact));
        }

        [TestMethod]
        public void Contact04EditTest()
        {
            var Contact = repository.Find(1);
            Contact.FirstName = "Carlos";
            repository.Edit(Contact);
            Assert.IsTrue(repository.Save());
        }

        [TestMethod]
        public void Contact05DeleteTest()
        {
            repository.Delete(1);
            Assert.IsTrue(repository.Save());
        }
    }
}
