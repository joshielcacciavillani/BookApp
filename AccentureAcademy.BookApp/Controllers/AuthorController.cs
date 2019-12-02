using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AccentureAcademy.BookApp.Models;

namespace AccentureAcademy.BookApp.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JsonListar()
        {
            IEnumerable<Object> Author = this.db.Author.ToList().Select(p => new
            {
                Id = p.Id,
                AuthorName = p.AuthorName,
                Country = p.Country
            });
            return Json(Author, JsonRequestBehavior.AllowGet);
        }
        private AccentureAcademyBookDbEntities db;
        public AuthorController()
        {
            this.db = new AccentureAcademyBookDbEntities();
        }
        public ActionResult ListarAsync()
        {
            return View();
        }
        public ActionResult Listar()
        {
            List<Author> authors = this.db.Author.ToList();
            return View(authors);
        }

        public ActionResult Editar(int id)
        {
            this.ViewBag.Titulo = "Editar Autor";
            Author m = this.db.Author.Find(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Editar(Author author)
        {
            this.db.Author.Attach(author);
            this.db.Entry(author).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Agregar()
        {
            this.ViewBag.Titulo = "Agregar Autor";
            Author m = new Author();
            return View("Editar", m);
        }

        [HttpPost]
        public ActionResult Agregar(Author author)
        {
            this.db.Author.Add(author);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Eliminar(int id)
        {
            Author author = db.Author.Find(id);
            this.db.Author.Remove(author);
            this.db.SaveChanges();
            return RedirectToAction("Listar");

        }

    }
}