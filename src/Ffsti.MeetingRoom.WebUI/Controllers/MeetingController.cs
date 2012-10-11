using Ffsti.MeetingRoom.Domain;
using Ffsti.MeetingRoom.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ffsti.MeetingRoom.WebUI.Controllers
{
    public class MeetingController : BaseController<Meeting, MeetingService>
    {
        public override ActionResult Create()
        {
            ContactService cs = new ContactService();
            RoomService rs = new RoomService();

            ViewBag.ContactId = new SelectList(cs.ListAll().OrderBy(c => new { c.FirstName, c.LastName}), "Id", "FullName");
            ViewBag.RoomId = new SelectList(rs.ListAll().OrderBy(c => c.Name), "Id", "Name");
            return base.Create();
        }
        public override ActionResult Edit(int id = 0)
        {
            var meeting = Service.Find(id);
            if (meeting != null)
                return View(meeting);

            return HttpNotFound();
        }

        public override ActionResult Details(int id = 0)
        {
            var meeting = Service.Find(id);
            if (meeting != null)
                return View(meeting);

            return HttpNotFound();
        }

        public override ActionResult Delete(int id = 0)
        {
            var meeting = Service.Find(id);
            if (meeting != null)
                return View(meeting);

            return HttpNotFound();
        }
    }
}
