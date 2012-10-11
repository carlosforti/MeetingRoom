using Ffsti.MeetingRoom.Domain;
using Ffsti.MeetingRoom.Service;
using Ffsti.MeetingRoom.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ffsti.MeetingRoom.WebUI.Controllers
{
    public class ContactController : BaseController<Contact, ContactService>
    {
        public override ActionResult Create()
        {
            ContactTypeService ct = new ContactTypeService();
            ViewBag.ContactTypeId = new SelectList(ct.ListAll().OrderBy(c => c.Name), "Id", "Name");
            return View();
        }

        public override ActionResult Edit(int id = 0)
        {
            var contact = Service.Find(id);
            if (contact != null)
                return View(contact);

            return HttpNotFound();
        }

        public override ActionResult Details(int id = 0)
        {
            var contact = Service.Find(id);
            if (contact != null)
                return View(contact);

            return HttpNotFound();
        }

        public override ActionResult Delete(int id = 0)
        {
            var contact = Service.Find(id);
            if (contact != null)
                return View(contact);

            return HttpNotFound();
        }
    }
}
