using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AccentureAcademy.BookApp.Models;

namespace AccentureAcademy.BookApp.Controllers
{
    public class GenreController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JsonListar()
        {
            IEnumerable<Object> Genre = this.db.Genre.ToList().Select(p => new
            {
                Id = p.Id,
                GenreName = p.GenreName,
            });
            return Json(Genre, JsonRequestBehavior.AllowGet);
        }
        private AccentureAcademyBookDbEntities db;
        public GenreController()
        {
            this.db = new AccentureAcademyBookDbEntities();
        }

        public ActionResult Listar()
        {
            List<Genre> genres = this.db.Genre.ToList();
            return View(genres);
        }

        public ActionResult Editar(int id)
        {
            this.ViewBag.Titulo = "Editar Autor";
            Genre m = this.db.Genre.Find(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Editar(Genre genre)
        {
            if (ModelState.IsValid)
            {
                this.db.Genre.Attach(genre);
                this.db.Entry(genre).State = System.Data.Entity.EntityState.Modified;
                this.db.SaveChanges();
                return RedirectToAction("Listar");
            }
            else
            {
                return Content("No puede dejar el campo vacio");
            }
        }

        public ActionResult Agregar()
        {
            this.ViewBag.Titulo = "Agregar Autor";
            Genre m = new Genre();
            return View("Editar", m);
        }

        [HttpPost]
        public ActionResult Agregar(Genre genre)
        {
            if (ModelState.IsValid)
            {
                this.db.Genre.Add(genre);
                this.db.SaveChanges();
                return RedirectToAction("Listar");
            }
            else
            {
                return Content("No puede dejar el campo vacio");
            }
        }


        public ActionResult Eliminar(int id)
        {
            Genre genre = db.Genre.Find(id);
            this.db.Genre.Remove(genre);
            this.db.SaveChanges();
            return RedirectToAction("Listar");

        }

    }
}