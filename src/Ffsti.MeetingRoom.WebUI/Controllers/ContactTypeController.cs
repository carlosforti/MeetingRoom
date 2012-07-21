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
    public class ContactTypeController : Controller
    {
        private IContactTypeService service;

        public ContactTypeController()
        {
            service = new ContactTypeService(this.ModelState);
        }

        public ActionResult Index()
        {
            return View(service.ListAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult
    }
}
