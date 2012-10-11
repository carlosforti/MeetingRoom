using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ffsti.MeetingRoom.Domain;
using Ffsti.MeetingRoom.Service;
using Ffsti.MeetingRoom.Service.Interfaces;
using Ffsti.MeetingRoom.Service.Wrappers;

namespace Ffsti.MeetingRoom.WebUI.Controllers
{
    public class ContactTypeController : BaseController<ContactType, ContactTypeService>
    {
        public override ActionResult Edit(int id = 0)
        {
            var contactType = Service.Find(id);
            if (contactType != null)
                return View(contactType);

            return HttpNotFound();
        }

        public override ActionResult Details(int id = 0)
        {
            var contactType = Service.Find(id);
            if (contactType != null)
                return View(contactType);

            return HttpNotFound();
        }

        public override ActionResult Delete(int id = 0)
        {
            var contactType = Service.Find(id);
            if (contactType != null)
                return View(contactType);

            return HttpNotFound();
        }
    }
}
