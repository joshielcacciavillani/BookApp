using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccentureAcademy.BookApp.Models;

namespace AccentureAcademy.BookApp.Controllers
{
    public class PublisherController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JsonListar()
        {
            IEnumerable<Object> Publisher = this.db.Publisher.ToList().Select(p => new
            {
                Id = p.Id,
                PublisherName = p.PublisherName,
            });
            return Json(Publisher, JsonRequestBehavior.AllowGet);
        }
        private AccentureAcademyBookDbEntities db;
        public PublisherController()
        {
            this.db = new AccentureAcademyBookDbEntities();
        }
        public ActionResult ListarAsync()
        {
            return View();
        }
        public ActionResult Listar()
        {
            List<Publisher> publishers = this.db.Publisher.ToList();
            return View(publishers);
        }

        public ActionResult Editar(int id)
        {
            this.ViewBag.Titulo = "Editar Editorial";
            Publisher m = this.db.Publisher.Find(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Editar(Publisher publisher)
        {
            this.db.Publisher.Attach(publisher);
            this.db.Entry(publisher).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Agregar()
        {
            this.ViewBag.Titulo = "Agregar Editorial";
            Publisher m = new Publisher();
            return View("Editar", m);
        }

        [HttpPost]
        public ActionResult Agregar(Publisher publisher)
        {
            this.db.Publisher.Add(publisher);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Eliminar(int id)
        {
            Publisher publisher = db.Publisher.Find(id);
            this.db.Publisher.Remove(publisher);
            this.db.SaveChanges();
            return RedirectToAction("Listar");

        }
    }
}