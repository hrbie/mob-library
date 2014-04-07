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
    public class FactorController : Controller
    {
        private DisenioEntities db = new DisenioEntities();

        //
        // GET: /Factor/

        public ViewResult Index()
        {
            var factor = db.Factor.Include(f => f.Riesgo);
            return View(factor.ToList());
        }

        //
        // GET: /Factor/Details/5

        public ViewResult Details(int id)
        {
            Factor factor = db.Factor.Find(id);
            return View(factor);
        }

        //
        // GET: /Factor/Create

        public ActionResult Create()
        {
            ViewBag.idRiesgo_fk = new SelectList(db.Riesgo, "idRiesgo", "nbrRiesgo");
            return View();
        } 

        //
        // POST: /Factor/Create

        [HttpPost]
        public ActionResult Create(Factor factor)
        {
            if (ModelState.IsValid)
            {
                db.Factor.Add(factor);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idRiesgo_fk = new SelectList(db.Riesgo, "idRiesgo", "nbrRiesgo", factor.idRiesgo_fk);
            return View(factor);
        }
        
        //
        // GET: /Factor/Edit/5
 
        public ActionResult Edit(int id)
        {
            Factor factor = db.Factor.Find(id);
            ViewBag.idRiesgo_fk = new SelectList(db.Riesgo, "idRiesgo", "nbrRiesgo", factor.idRiesgo_fk);
            return View(factor);
        }

        //
        // POST: /Factor/Edit/5

        [HttpPost]
        public ActionResult Edit(Factor factor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRiesgo_fk = new SelectList(db.Riesgo, "idRiesgo", "nbrRiesgo", factor.idRiesgo_fk);
            return View(factor);
        }

        //
        // GET: /Factor/Delete/5
 
        public ActionResult Delete(int id)
        {
            Factor factor = db.Factor.Find(id);
            return View(factor);
        }

        //
        // POST: /Factor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Factor factor = db.Factor.Find(id);
            db.Factor.Remove(factor);
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