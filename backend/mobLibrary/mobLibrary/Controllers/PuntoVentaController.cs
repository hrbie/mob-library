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
    public class PuntoVentaController : Controller
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        //
        // GET: /PuntoVenta/

        public ActionResult Index()
        {
            var punto_venta = db.PUNTO_VENTA.Include(p => p.CADENA_LIBRERIAS);
            return View(punto_venta.ToList());
        }

        //
        // GET: /PuntoVenta/Details/5

        public ActionResult Details(int id = 0)
        {
            PUNTO_VENTA punto_venta = db.PUNTO_VENTA.Find(id);
            if (punto_venta == null)
            {
                return HttpNotFound();
            }
            return View(punto_venta);
        }

        //
        // GET: /PuntoVenta/Create

        public ActionResult Create()
        {
            ViewBag.ID_LIBRERIA = new SelectList(db.CADENA_LIBRERIAS, "ID_LIBRERIA", "NOMBRE");
            return View();
        }

        //
        // POST: /PuntoVenta/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PUNTO_VENTA punto_venta)
        {
            
            if (ModelState.IsValid)
            {
                db.PUNTO_VENTA.Add(punto_venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LIBRERIA = new SelectList(db.CADENA_LIBRERIAS, "ID_LIBRERIA", "NOMBRE", punto_venta.ID_LIBRERIA);
            return View(punto_venta);
        }

        //
        // GET: /PuntoVenta/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PUNTO_VENTA punto_venta = db.PUNTO_VENTA.Find(id);
            if (punto_venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LIBRERIA = new SelectList(db.CADENA_LIBRERIAS, "ID_LIBRERIA", "NOMBRE", punto_venta.ID_LIBRERIA);
            return View(punto_venta);
        }

        //
        // POST: /PuntoVenta/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PUNTO_VENTA punto_venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(punto_venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LIBRERIA = new SelectList(db.CADENA_LIBRERIAS, "ID_LIBRERIA", "NOMBRE", punto_venta.ID_LIBRERIA);
            return View(punto_venta);
        }

        //
        // GET: /PuntoVenta/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PUNTO_VENTA punto_venta = db.PUNTO_VENTA.Find(id);
            if (punto_venta == null)
            {
                return HttpNotFound();
            }
            return View(punto_venta);
        }

        //
        // POST: /PuntoVenta/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PUNTO_VENTA punto_venta = db.PUNTO_VENTA.Find(id);
            db.PUNTO_VENTA.Remove(punto_venta);
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