using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalDisenio.Models;

namespace ProyectoFinalDisenio.Controllers
{ 
    public class PermisoController : Controller
    {
        private DisenioEntities db = new DisenioEntities();

        //
        // GET: /Permiso/

        public ViewResult Index()
        {
            return View(db.Permiso.ToList());
        }

        //
        // GET: /Permiso/Details/5

        public ViewResult Details(int id)
        {
            Permiso permiso = db.Permiso.Find(id);
            return View(permiso);
        }

        //
        // GET: /Permiso/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Permiso/Create

        [HttpPost]
        public ActionResult Create(Permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.Permiso.Add(permiso);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(permiso);
        }
        
        //
        // GET: /Permiso/Edit/5
 
        public ActionResult Edit(int id)
        {
            Permiso permiso = db.Permiso.Find(id);
            return View(permiso);
        }

        //
        // POST: /Permiso/Edit/5

        [HttpPost]
        public ActionResult Edit(Permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permiso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(permiso);
        }

        //
        // GET: /Permiso/Delete/5
 
        public ActionResult Delete(int id)
        {
            Permiso permiso = db.Permiso.Find(id);
            return View(permiso);
        }

        //
        // POST: /Permiso/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Permiso permiso = db.Permiso.Find(id);
            db.Permiso.Remove(permiso);
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