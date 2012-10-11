using Ffsti.MeetingRoom.Domain;
using Ffsti.MeetingRoom.Service;
using System.Web.Mvc;

namespace Ffsti.MeetingRoom.WebUI.Controllers
{
    public class RoomController : BaseController<Room, RoomService>
    {
        public override ActionResult Edit(int id = 0)
        {
            var room = Service.Find(id);
            if (room != null)
                return View(room);

            return HttpNotFound();
        }

        public override ActionResult Details(int id = 0)
        {
            var room = Service.Find(id);
            if (room != null)
                return View(room);

            return HttpNotFound();
        }

        public override ActionResult Delete(int id = 0)
        {
            var room = Service.Find(id);
            if (room != null)
                return View(room);

            return HttpNotFound();
        }
    }
}
