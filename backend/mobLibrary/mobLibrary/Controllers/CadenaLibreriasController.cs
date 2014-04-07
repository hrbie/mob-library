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
    public class CadenaLibreriasController : Controller
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        //
        // GET: /CadenaLibrerias/

        public ActionResult Index()
        {
            return View(db.CADENA_LIBRERIAS.ToList());
        }

        //
        // GET: /CadenaLibrerias/Details/5

        public ActionResult Details(int id = 0)
        {
            CADENA_LIBRERIAS cadena_librerias = db.CADENA_LIBRERIAS.Find(id);
            if (cadena_librerias == null)
            {
                return HttpNotFound();
            }
            return View(cadena_librerias);
        }

        //
        // GET: /CadenaLibrerias/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CadenaLibrerias/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CADENA_LIBRERIAS cadena_librerias)
        {
            if (ModelState.IsValid)
            {
                db.CADENA_LIBRERIAS.Add(cadena_librerias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadena_librerias);
        }

        //
        // GET: /CadenaLibrerias/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CADENA_LIBRERIAS cadena_librerias = db.CADENA_LIBRERIAS.Find(id);
            if (cadena_librerias == null)
            {
                return HttpNotFound();
            }
            return View(cadena_librerias);
        }

        //
        // POST: /CadenaLibrerias/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CADENA_LIBRERIAS cadena_librerias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadena_librerias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadena_librerias);
        }

        //
        // GET: /CadenaLibrerias/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CADENA_LIBRERIAS cadena_librerias = db.CADENA_LIBRERIAS.Find(id);
            if (cadena_librerias == null)
            {
                return HttpNotFound();
            }
            return View(cadena_librerias);
        }

        //
        // POST: /CadenaLibrerias/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CADENA_LIBRERIAS cadena_librerias = db.CADENA_LIBRERIAS.Find(id);
            db.CADENA_LIBRERIAS.Remove(cadena_librerias);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddBook(int id)
        {
            ViewBag.cadena = id;
            return RedirectToAction("IndexCadenaAgregarLibro","LibroController",new {cadena = id});
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}