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
    public class LibroController : Controller
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        //
        // GET: /Libro/

        public ActionResult Index()
        {
            return View(db.LIBRO.ToList());
        }

        //
        // GET: /Libro/Details/5

        public ActionResult Details(long id = 0)
        {
            LIBRO libro = db.LIBRO.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        //
        // GET: /Libro/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Libro/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LIBRO libro)
        {
            if (ModelState.IsValid)
            {
                db.LIBRO.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libro);
        }

        //
        // GET: /Libro/Edit/5

        public ActionResult Edit(long id = 0)
        {
            LIBRO libro = db.LIBRO.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        //
        // POST: /Libro/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LIBRO libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libro);
        }

        //
        // GET: /Libro/Delete/5

        public ActionResult Delete(long id = 0)
        {
            LIBRO libro = db.LIBRO.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        //
        // POST: /Libro/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            LIBRO libro = db.LIBRO.Find(id);
            db.LIBRO.Remove(libro);
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