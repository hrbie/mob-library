using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mobLibrary.Models;

namespace mobLibrary.Controllers
{
    public class ListaLibrosController : Controller
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        //
        // GET: /ListaLibros/

        public ActionResult Index()
        {
            var lista_libros = db.LISTA_LIBROS.Include(l => l.LIBRO).Include(l => l.USUARIO);
            return View(lista_libros.ToList());
        }

        //
        // GET: /ListaLibros/Details/5

        public ActionResult Details(int id = 0)
        {
            LISTA_LIBROS lista_libros = db.LISTA_LIBROS.Find(id);
            if (lista_libros == null)
            {
                return HttpNotFound();
            }
            return View(lista_libros);
        }

        //
        // GET: /ListaLibros/Create

        public ActionResult Create()
        {
            ViewBag.ISBN = new SelectList(db.LIBRO, "ISBN", "NOMBRE");
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE");
            return View();
        }

        //
        // POST: /ListaLibros/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LISTA_LIBROS lista_libros)
        {
            if (ModelState.IsValid)
            {
                db.LISTA_LIBROS.Add(lista_libros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ISBN = new SelectList(db.LIBRO, "ISBN", "NOMBRE", lista_libros.ISBN);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", lista_libros.ID_USUARIO);
            return View(lista_libros);
        }

        //
        // GET: /ListaLibros/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LISTA_LIBROS lista_libros = db.LISTA_LIBROS.Find(id);
            if (lista_libros == null)
            {
                return HttpNotFound();
            }
            ViewBag.ISBN = new SelectList(db.LIBRO, "ISBN", "NOMBRE", lista_libros.ISBN);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", lista_libros.ID_USUARIO);
            return View(lista_libros);
        }

        //
        // POST: /ListaLibros/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LISTA_LIBROS lista_libros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista_libros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ISBN = new SelectList(db.LIBRO, "ISBN", "NOMBRE", lista_libros.ISBN);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", lista_libros.ID_USUARIO);
            return View(lista_libros);
        }

        //
        // GET: /ListaLibros/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LISTA_LIBROS lista_libros = db.LISTA_LIBROS.Find(id);
            if (lista_libros == null)
            {
                return HttpNotFound();
            }
            return View(lista_libros);
        }

        //
        // POST: /ListaLibros/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LISTA_LIBROS lista_libros = db.LISTA_LIBROS.Find(id);
            db.LISTA_LIBROS.Remove(lista_libros);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}