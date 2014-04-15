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
    public class SolicitudTrasladoController : Controller
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        //
        // GET: /SolicitudTraslado/

        public ActionResult Index()
        {
            var solicitud_traslado = db.SOLICITUD_TRASLADO.Include(s => s.INVENTARIO_PDV).Include(s => s.PUNTO_VENTA).Include(s => s.USUARIO);
            return View(solicitud_traslado.ToList());
        }

        //
        // GET: /SolicitudTraslado/Details/5

        public ActionResult Details(int id = 0)
        {
            SOLICITUD_TRASLADO solicitud_traslado = db.SOLICITUD_TRASLADO.Find(id);
            if (solicitud_traslado == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_traslado);
        }

        //
        // GET: /SolicitudTraslado/Create

        public ActionResult Create()
        {
            ViewBag.ID_LIBRERIA = new SelectList(db.INVENTARIO_PDV, "ID_LIBRERIA", "ID_LIBRERIA");
            ViewBag.ID_PDV_ORIGEN = new SelectList(db.PUNTO_VENTA, "ID_PDV", "NOMBRE");
            ViewBag.ID_PDV_DESTINO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE");
            return View();
        }

        //
        // POST: /SolicitudTraslado/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SOLICITUD_TRASLADO solicitud_traslado)
        {
            if (ModelState.IsValid)
            {
                db.SOLICITUD_TRASLADO.Add(solicitud_traslado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LIBRERIA = new SelectList(db.INVENTARIO_PDV, "ID_LIBRERIA", "ID_LIBRERIA", solicitud_traslado.ID_LIBRERIA);
            ViewBag.ID_PDV_ORIGEN = new SelectList(db.PUNTO_VENTA, "ID_PDV", "NOMBRE", solicitud_traslado.ID_PDV_ORIGEN);
            ViewBag.ID_PDV_DESTINO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", solicitud_traslado.ID_PDV_DESTINO);
            return View(solicitud_traslado);
        }

        //
        // GET: /SolicitudTraslado/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SOLICITUD_TRASLADO solicitud_traslado = db.SOLICITUD_TRASLADO.Find(id);
            if (solicitud_traslado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LIBRERIA = new SelectList(db.INVENTARIO_PDV, "ID_LIBRERIA", "ID_LIBRERIA", solicitud_traslado.ID_LIBRERIA);
            ViewBag.ID_PDV_ORIGEN = new SelectList(db.PUNTO_VENTA, "ID_PDV", "NOMBRE", solicitud_traslado.ID_PDV_ORIGEN);
            ViewBag.ID_PDV_DESTINO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", solicitud_traslado.ID_PDV_DESTINO);
            return View(solicitud_traslado);
        }

        //
        // POST: /SolicitudTraslado/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SOLICITUD_TRASLADO solicitud_traslado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud_traslado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LIBRERIA = new SelectList(db.INVENTARIO_PDV, "ID_LIBRERIA", "ID_LIBRERIA", solicitud_traslado.ID_LIBRERIA);
            ViewBag.ID_PDV_ORIGEN = new SelectList(db.PUNTO_VENTA, "ID_PDV", "NOMBRE", solicitud_traslado.ID_PDV_ORIGEN);
            ViewBag.ID_PDV_DESTINO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", solicitud_traslado.ID_PDV_DESTINO);
            return View(solicitud_traslado);
        }

        //
        // GET: /SolicitudTraslado/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SOLICITUD_TRASLADO solicitud_traslado = db.SOLICITUD_TRASLADO.Find(id);
            if (solicitud_traslado == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_traslado);
        }

        //
        // POST: /SolicitudTraslado/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOLICITUD_TRASLADO solicitud_traslado = db.SOLICITUD_TRASLADO.Find(id);
            db.SOLICITUD_TRASLADO.Remove(solicitud_traslado);
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