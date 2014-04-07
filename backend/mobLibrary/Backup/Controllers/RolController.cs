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
    public class RolController : Controller
    {
        private DisenioEntities db = new DisenioEntities();

        //
        // GET: /Rol/

        public ViewResult Index()
        {
            return View(db.Rol.ToList());
        }

        //
        // GET: /Rol/Details/5

        public ViewResult Details(int id)
        {
            Rol rol = db.Rol.Find(id);
            return View(rol);
        }

        //
        // GET: /Rol/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Rol/Create

        [HttpPost]
        public ActionResult Create(Rol rol)
        {
            if (ModelState.IsValid)
            {
                db.Rol.Add(rol);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(rol);
        }
        
        //
        // GET: /Rol/Edit/5
 
        public ActionResult Edit(int id)
        {
            Rol rol = db.Rol.Find(id);
            return View(rol);
        }

        //
        // POST: /Rol/Edit/5

        [HttpPost]
        public ActionResult Edit(Rol rol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        //
        // GET: /Rol/Delete/5
 
        public ActionResult Delete(int id)
        {
            Rol rol = db.Rol.Find(id);
            return View(rol);
        }

        //
        // POST: /Rol/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Rol rol = db.Rol.Find(id);
            db.Rol.Remove(rol);
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