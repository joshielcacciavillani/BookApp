using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AccentureAcademy.BookApp.Models;

namespace AccentureAcademy.BookApp.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        private AccentureAcademyBookDbEntities db;
        public BookController()
        {
            this.db = new AccentureAcademyBookDbEntities();
        }
        public ActionResult Listar()
        {
            List<Book> books = this.db.Book.ToList();
            return View(books);
        }

        public ActionResult Editar(int id)
        {
            this.ViewBag.Titulo = "Editar Libro";
            Book m = this.db.Book.Find(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Editar(Book book)
        {
            if (ModelState.IsValid)
            {
                this.db.Book.Attach(book);
                this.db.Entry(book).State = System.Data.Entity.EntityState.Modified;
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
            this.ViewBag.Titulo = "Agregar Libro";
            Book m = new Book();
            return View("Editar", m);
        }

        [HttpPost]
        public ActionResult Agregar(Book book)
        {
            if (ModelState.IsValid)
            {
                this.db.Book.Add(book);
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
            Book book = db.Book.Find(id);
            this.db.Book.Remove(book);
            this.db.SaveChanges();
            return RedirectToAction("Listar");

        }

    }
}