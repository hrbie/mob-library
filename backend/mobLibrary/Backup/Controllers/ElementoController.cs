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
    public class ElementoController : Controller
    {
        private DisenioEntities db = new DisenioEntities();

        //
        // GET: /Elemento/

        public ViewResult Index()
        {
            var elemento = db.Elemento.Include(e => e.Factor);
            return View(elemento.ToList());
        }

        //
        // GET: /Elemento/Details/5

        public ViewResult Details(int id)
        {
            Elemento elemento = db.Elemento.Find(id);
            return View(elemento);
        }

        //
        // GET: /Elemento/Create

        public ActionResult Create()
        {
            ViewBag.idFactor_fk = new SelectList(db.Factor, "idFactor", "nbrFactor");
            return View();
        } 

        //
        // POST: /Elemento/Create

        [HttpPost]
        public ActionResult Create(Elemento elemento)
        {
            if (ModelState.IsValid)
            {
                db.Elemento.Add(elemento);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idFactor_fk = new SelectList(db.Factor, "idFactor", "nbrFactor", elemento.idFactor_fk);
            return View(elemento);
        }
        
        //
        // GET: /Elemento/Edit/5
 
        public ActionResult Edit(int id)
        {
            Elemento elemento = db.Elemento.Find(id);
            ViewBag.idFactor_fk = new SelectList(db.Factor, "idFactor", "nbrFactor", elemento.idFactor_fk);
            return View(elemento);
        }

        //
        // POST: /Elemento/Edit/5

        [HttpPost]
        public ActionResult Edit(Elemento elemento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elemento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFactor_fk = new SelectList(db.Factor, "idFactor", "nbrFactor", elemento.idFactor_fk);
            return View(elemento);
        }

        //
        // GET: /Elemento/Delete/5
 
        public ActionResult Delete(int id)
        {
            Elemento elemento = db.Elemento.Find(id);
            return View(elemento);
        }

        //
        // POST: /Elemento/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Elemento elemento = db.Elemento.Find(id);
            db.Elemento.Remove(elemento);
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