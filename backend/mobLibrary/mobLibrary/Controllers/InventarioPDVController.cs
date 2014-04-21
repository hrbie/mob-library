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
    public class InventarioPDVController : Controller
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        //
        // GET: /InventarioPDV/

        public ActionResult Index()
        {
            var inventario_pdv = db.INVENTARIO_PDV.Include(i => i.CATALOGO_LIBRERIA).Include(i => i.PUNTO_VENTA);
            return View(inventario_pdv.ToList());
        }

        //
        // GET: /InventarioPDV/Details/5

        public ActionResult Details(int id = 0)
        {
            INVENTARIO_PDV inventario_pdv = db.INVENTARIO_PDV.Find(id);
            if (inventario_pdv == null)
            {
                return HttpNotFound();
            }
            return View(inventario_pdv);
        }

        //
        // GET: /InventarioPDV/Create

        public ActionResult Create()
        {
            ViewBag.ID_LIBRERIA = new SelectList(db.CADENA_LIBRERIAS, "ID_LIBRERIA", "NOMBRE");
            ViewBag.ID_PDV = new SelectList(db.PUNTO_VENTA, "ID_PDV", "NOMBRE");
            ViewBag.ISBN = new SelectList(db.LIBRO, "ISBN", "NOMBRE");



            return View();
        }

        //
        // POST: /InventarioPDV/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(INVENTARIO_PDV inventario_pdv)
        {
            if (ModelState.IsValid)
            {
                db.INVENTARIO_PDV.Add(inventario_pdv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LIBRERIA = new SelectList(db.CATALOGO_LIBRERIA, "ID_LIBRERIA", "ID_LIBRERIA", inventario_pdv.ID_LIBRERIA);
            ViewBag.ID_PDV = new SelectList(db.PUNTO_VENTA, "ID_PDV", "NOMBRE", inventario_pdv.ID_PDV);
            return View(inventario_pdv);
        }

        //
        // GET: /InventarioPDV/Edit/5

        public ActionResult Edit(int id = 0, int id2 =0 , int id3 =0)
        {
            INVENTARIO_PDV inventario_pdv = db.INVENTARIO_PDV.Find(id,id2,id3);
            if (inventario_pdv == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LIBRERIA = new SelectList(db.CATALOGO_LIBRERIA, "ID_LIBRERIA", "ID_LIBRERIA", inventario_pdv.ID_LIBRERIA);
            ViewBag.ID_PDV = new SelectList(db.PUNTO_VENTA, "ID_PDV", "NOMBRE", inventario_pdv.ID_PDV);
            return View(inventario_pdv);
        }

        //
        // POST: /InventarioPDV/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(INVENTARIO_PDV inventario_pdv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventario_pdv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LIBRERIA = new SelectList(db.CATALOGO_LIBRERIA, "ID_LIBRERIA", "ID_LIBRERIA", inventario_pdv.ID_LIBRERIA);
            ViewBag.ID_PDV = new SelectList(db.PUNTO_VENTA, "ID_PDV", "NOMBRE", inventario_pdv.ID_PDV);
            return View(inventario_pdv);
        }

        //
        // GET: /InventarioPDV/Delete/5

        public ActionResult Delete(int id = 0)
        {
            INVENTARIO_PDV inventario_pdv = db.INVENTARIO_PDV.Find(id);
            if (inventario_pdv == null)
            {
                return HttpNotFound();
            }
            return View(inventario_pdv);
        }

        //
        // POST: /InventarioPDV/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INVENTARIO_PDV inventario_pdv = db.INVENTARIO_PDV.Find(id);
            db.INVENTARIO_PDV.Remove(inventario_pdv);
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