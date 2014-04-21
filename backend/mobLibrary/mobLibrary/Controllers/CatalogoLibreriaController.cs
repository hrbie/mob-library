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
    public class CatalogoLibreriaController : Controller
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        //
        // GET: /CatalogoLibreria/

        public ActionResult Index()
        {
            var catalogo_libreria = db.CATALOGO_LIBRERIA.Include(c => c.CADENA_LIBRERIAS).Include(c => c.LIBRO);
            return View(catalogo_libreria.ToList());
        }

        //
        // GET: /CatalogoLibreria/Details/5

        public ActionResult Details(int id = 0)
        {
            CATALOGO_LIBRERIA catalogo_libreria = db.CATALOGO_LIBRERIA.Find(id);
            if (catalogo_libreria == null)
            {
                return HttpNotFound();
            }
            return View(catalogo_libreria);
        }

        //
        // GET: /CatalogoLibreria/Create

        public ActionResult Create()
        {
            ViewBag.ID_LIBRERIA = new SelectList(db.CADENA_LIBRERIAS, "ID_LIBRERIA", "NOMBRE");
            ViewBag.ISBN = new SelectList(db.LIBRO, "ISBN", "NOMBRE");
            return View();
        }

        //
        // POST: /CatalogoLibreria/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CATALOGO_LIBRERIA catalogo_libreria)
        {
            if (db.CATALOGO_LIBRERIA.Find(catalogo_libreria.ID_LIBRERIA, catalogo_libreria.ISBN) == null)
            {

                if (ModelState.IsValid)
                {
                    db.CATALOGO_LIBRERIA.Add(catalogo_libreria);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ID_LIBRERIA = new SelectList(db.CADENA_LIBRERIAS, "ID_LIBRERIA", "NOMBRE", catalogo_libreria.ID_LIBRERIA);
                ViewBag.ISBN = new SelectList(db.LIBRO, "ISBN", "NOMBRE", catalogo_libreria.ISBN);
                return View(catalogo_libreria);
            }
            else {
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /CatalogoLibreria/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CATALOGO_LIBRERIA catalogo_libreria = db.CATALOGO_LIBRERIA.Find(id);
            if (catalogo_libreria == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LIBRERIA = new SelectList(db.CADENA_LIBRERIAS, "ID_LIBRERIA", "NOMBRE", catalogo_libreria.ID_LIBRERIA);
            ViewBag.ISBN = new SelectList(db.LIBRO, "ISBN", "NOMBRE", catalogo_libreria.ISBN);
            return View(catalogo_libreria);
        }

        //
        // POST: /CatalogoLibreria/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CATALOGO_LIBRERIA catalogo_libreria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogo_libreria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LIBRERIA = new SelectList(db.CADENA_LIBRERIAS, "ID_LIBRERIA", "NOMBRE", catalogo_libreria.ID_LIBRERIA);
            ViewBag.ISBN = new SelectList(db.LIBRO, "ISBN", "NOMBRE", catalogo_libreria.ISBN);
            return View(catalogo_libreria);
        }

        //
        // GET: /CatalogoLibreria/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CATALOGO_LIBRERIA catalogo_libreria = db.CATALOGO_LIBRERIA.Find(id);
            if (catalogo_libreria == null)
            {
                return HttpNotFound();
            }
            return View(catalogo_libreria);
        }

        //
        // POST: /CatalogoLibreria/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATALOGO_LIBRERIA catalogo_libreria = db.CATALOGO_LIBRERIA.Find(id);
            db.CATALOGO_LIBRERIA.Remove(catalogo_libreria);
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