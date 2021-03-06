﻿using System;
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

        public ActionResult IndexCadenaCatalogoLibro(int cadena) {
            //mostrar los libros del catálogo
            ViewBag.cadena = cadena;

            LibroAPIController api = new LibroAPIController();
            IEnumerable<LIBRO> libros = api.GetLIBROByLibreria(cadena);
            return View(libros);
        }

        public ActionResult IndexCadenaAgregarLibro(int cadena) {
            //agregar acá el filtro para no agregar libros que  ya están.
            ViewBag.cadena = cadena;

            IEnumerable<CATALOGO_LIBRERIA> catalogo = db.CATALOGO_LIBRERIA.Where(c => c.ID_LIBRERIA == cadena);

            List<long> ISBNs = new List<long>();
            foreach (CATALOGO_LIBRERIA c in catalogo)
            {
                ISBNs.Add(c.ISBN);
            }
            //solo los que no estén en el catálogo se muestran
            IEnumerable<LIBRO> libro = db.LIBRO.Where(l => ISBNs.Contains(l.ISBN) == false);

            return View(libro);
        }

        

        public ActionResult verGeneros(int id)
        {
            ViewBag.libro = id;
            return RedirectToAction("IndexGenerosLibro", "Genero", new { libro = id });
        }

        public ActionResult asignarGenero(int id)
        {
            ViewBag.libro = id;
            return RedirectToAction("IndexAgregarGeneroALibro", "Genero", new { libro = id });
        }


        public ActionResult AgregarLibroACadena(int cadena, int libro)
        {
            CATALOGO_LIBRERIA c = new CATALOGO_LIBRERIA();
            c.ID_LIBRERIA = cadena;
            c.ISBN = libro;

            if (ModelState.IsValid)
            {
                db.CATALOGO_LIBRERIA.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Cambiarlo a mostrar libros de la cadena
            return RedirectToAction("IndexCadenaCatalogoLibro", cadena);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}