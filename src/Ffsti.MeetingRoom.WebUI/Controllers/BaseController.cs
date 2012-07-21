using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ffsti.MeetingRoom.Service.Interfaces;

namespace Ffsti.MeetingRoom.WebUI.Controllers
{
    public abstract class BaseController<T, S> : Controller
        where T : class
        where S : IBaseService<T>, new()
    {
        private S service;

        public S Service
        {
            get { return service; }
            set { service = value; }
        }

        public BaseController()
        {
            service = new S();
        }

        public virtual ActionResult Index()
        {
            IEnumerable<T> list = service.ListAll().AsEnumerable<T>();
            return View(list);
        }

        [HttpPost()]
        public virtual ActionResult Create(T entity)
        {
            Service.Add(entity);
            if (ModelState.IsValid)
                return RedirectToAction("Index");
            return View(entity);
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public virtual ActionResult Edit(T entity)
        {
            if (ModelState.IsValid && Service.Edit(entity))
                return RedirectToAction("Index");

            return View(entity);
        }

        [ActionName("Delete")]
        [HttpPost()]
        public virtual ActionResult DeleteConfirmed(T entity)
        {
            if (Service.Delete(entity))
            {
                return RedirectToAction("Index");
            }

            ViewBag.ErrorMessage = "Não foi possível excluir este registro. Por favor, verifique.";
            return View(entity);
        }

        public abstract ActionResult Edit(int id = 0);

        public abstract ActionResult Details(int id = 0);

        public abstract ActionResult Delete(int id = 0);

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
        }

    }
}