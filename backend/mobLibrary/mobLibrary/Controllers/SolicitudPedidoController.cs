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
    public class SolicitudPedidoController : Controller
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        //
        // GET: /SolicitudPedido/

        public ActionResult Index()
        {
            var solicitud_pedido = db.SOLICITUD_PEDIDO.Include(s => s.INVENTARIO_PDV).Include(s => s.USUARIO);
            return View(solicitud_pedido.ToList());
        }

        //
        // GET: /SolicitudPedido/Details/5

        public ActionResult Details(int id = 0)
        {
            SOLICITUD_PEDIDO solicitud_pedido = db.SOLICITUD_PEDIDO.Find(id);
            if (solicitud_pedido == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_pedido);
        }

        //
        // GET: /SolicitudPedido/Create

        public ActionResult Create()
        {
            ViewBag.ID_LIBRERIA = new SelectList(db.INVENTARIO_PDV, "ID_LIBRERIA", "ID_LIBRERIA");
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE");
            return View();
        }

        //
        // POST: /SolicitudPedido/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SOLICITUD_PEDIDO solicitud_pedido)
        {
            if (ModelState.IsValid)
            {
                db.SOLICITUD_PEDIDO.Add(solicitud_pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LIBRERIA = new SelectList(db.INVENTARIO_PDV, "ID_LIBRERIA", "ID_LIBRERIA", solicitud_pedido.ID_LIBRERIA);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", solicitud_pedido.ID_USUARIO);
            return View(solicitud_pedido);
        }

        //
        // GET: /SolicitudPedido/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SOLICITUD_PEDIDO solicitud_pedido = db.SOLICITUD_PEDIDO.Find(id);
            if (solicitud_pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LIBRERIA = new SelectList(db.INVENTARIO_PDV, "ID_LIBRERIA", "ID_LIBRERIA", solicitud_pedido.ID_LIBRERIA);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", solicitud_pedido.ID_USUARIO);
            return View(solicitud_pedido);
        }

        //
        // POST: /SolicitudPedido/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SOLICITUD_PEDIDO solicitud_pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud_pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LIBRERIA = new SelectList(db.INVENTARIO_PDV, "ID_LIBRERIA", "ID_LIBRERIA", solicitud_pedido.ID_LIBRERIA);
            ViewBag.ID_USUARIO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", solicitud_pedido.ID_USUARIO);
            return View(solicitud_pedido);
        }

        //
        // GET: /SolicitudPedido/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SOLICITUD_PEDIDO solicitud_pedido = db.SOLICITUD_PEDIDO.Find(id);
            if (solicitud_pedido == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_pedido);
        }

        //
        // POST: /SolicitudPedido/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOLICITUD_PEDIDO solicitud_pedido = db.SOLICITUD_PEDIDO.Find(id);
            db.SOLICITUD_PEDIDO.Remove(solicitud_pedido);
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