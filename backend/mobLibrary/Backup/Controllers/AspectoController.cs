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
    public class AspectoController : Controller
    {
        private DisenioEntities db = new DisenioEntities();

        //
        // GET: /Aspecto/

        public ViewResult Index()
        {
            var aspecto = db.Aspecto.Include(a => a.Elemento);
            return View(aspecto.ToList());
        }

        //
        // GET: /Aspecto/Details/5

        public ViewResult Details(int id)
        {
            Aspecto aspecto = db.Aspecto.Find(id);
            return View(aspecto);
        }

        //
        // GET: /Aspecto/Create

        public ActionResult Create()
        {
            ViewBag.idElemento_fk = new SelectList(db.Elemento, "idElemento", "nbrElemento");
            return View();
        } 

        //
        // POST: /Aspecto/Create

        [HttpPost]
        public ActionResult Create(Aspecto aspecto)
        {
            if (ModelState.IsValid)
            {
                db.Aspecto.Add(aspecto);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idElemento_fk = new SelectList(db.Elemento, "idElemento", "nbrElemento", aspecto.idElemento_fk);
            return View(aspecto);
        }
        
        //
        // GET: /Aspecto/Edit/5
 
        public ActionResult Edit(int id)
        {
            Aspecto aspecto = db.Aspecto.Find(id);
            ViewBag.idElemento_fk = new SelectList(db.Elemento, "idElemento", "nbrElemento", aspecto.idElemento_fk);
            return View(aspecto);
        }

        //
        // POST: /Aspecto/Edit/5

        [HttpPost]
        public ActionResult Edit(Aspecto aspecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idElemento_fk = new SelectList(db.Elemento, "idElemento", "nbrElemento", aspecto.idElemento_fk);
            return View(aspecto);
        }

        //
        // GET: /Aspecto/Delete/5
 
        public ActionResult Delete(int id)
        {
            Aspecto aspecto = db.Aspecto.Find(id);
            return View(aspecto);
        }

        //
        // POST: /Aspecto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Aspecto aspecto = db.Aspecto.Find(id);
            db.Aspecto.Remove(aspecto);
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