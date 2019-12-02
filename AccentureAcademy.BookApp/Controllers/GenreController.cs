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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JsonListar()
        {
            IEnumerable<Object> Author = this.db.Author.ToList().Select(p => new
            {
                Id = p.Id,
                Title = p.AuthorName,
            });
            return Json(Author, JsonRequestBehavior.AllowGet);
        }
        private AccentureAcademyBookDbEntities db;
        public GenreController()
        {
            this.db = new AccentureAcademyBookDbEntities();
        }
        public ActionResult ListarAsync()
        {
            return View();
        }
        public ActionResult Listar()
        {
            List<Genre> genres = this.db.Genre.ToList();
            return View(genres);
        }

        public ActionResult Editar(int id)
        {
            this.ViewBag.Titulo = "Editar Generos";
            Genre m = this.db.Genre.Find(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Editar(Genre genre)
        {
            this.db.Genre.Attach(genre);
            this.db.Entry(genre).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Agregar()
        {
            this.ViewBag.Titulo = "Agregar Genero";
            Genre m = new Genre();
            return View("Editar", m);
        }

        [HttpPost]
        public ActionResult Agregar(Genre genre)
        {
            this.db.Genre.Add(genre);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
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