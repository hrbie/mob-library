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
    public class GeneroController : Controller
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        //
        // GET: /Genero/

        public ActionResult Index()
        {
            return View(db.GENERO.ToList());
        }

        public ActionResult IndexGenerosLibro(int libro)
        { 
            LIBRO l = db.LIBRO.Find(libro);
            
            return View(l.GENERO);
        }

        public ActionResult IndexAgregarGeneroALibro(int libro)
        {
            LIBRO l = db.LIBRO.Find(libro);
            ViewBag.libro = l.ISBN;
            List<int> idsGen = new List<int>();

            foreach (GENERO i in l.GENERO) {
                idsGen.Add(i.ID_GENERO);
            }

            return View(db.GENERO.Where(x => idsGen.Contains(x.ID_GENERO) == false ));
        }

        public ActionResult AgregarGenero(int libro, int genero)
        {
            db.LIBRO.Find(libro).GENERO.Add(db.GENERO.Find(genero));
            //db.GENERO.Find(genero).LIBRO.Add(db.LIBRO.Find(libro));
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("IndexGenerosLibro", new { libro = libro });
                
            }

            //Cambiarlo a mostrar libros de la cadena
            return RedirectToAction("IndexGenerosLibro", libro); 
        }

        //
        // GET: /Genero/Details/5

        public ActionResult Details(int id = 0)
        {
            GENERO genero = db.GENERO.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        //
        // GET: /Genero/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Genero/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GENERO genero)
        {
            if (ModelState.IsValid)
            {
                db.GENERO.Add(genero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genero);
        }

        //
        // GET: /Genero/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GENERO genero = db.GENERO.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        //
        // POST: /Genero/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GENERO genero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genero);
        }

        //
        // GET: /Genero/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GENERO genero = db.GENERO.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        //
        // POST: /Genero/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GENERO genero = db.GENERO.Find(id);
            db.GENERO.Remove(genero);
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