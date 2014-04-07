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
    public class EscalaPuntajeController : Controller
    {
        private DisenioEntities db = new DisenioEntities();
        
        //
        // GET: /EscalaPuntaje/

        public ViewResult Index()
        {
            var escalapuntaje = db.EscalaPuntaje.Include(e => e.EscalaImpacto).Include(e => e.EscalaProbabilidad);
            return View(escalapuntaje.ToList());
            /*
            ViewBag.mensajeProyecto = "No existe ningún proyecto";
            return View(proyecto);*/
        }

        //
        // GET: /EscalaPuntaje/Details/5

        public ViewResult Details(int id)
        {
            EscalaPuntaje escalapuntaje = db.EscalaPuntaje.Find(id);
            return View(escalapuntaje);
        }

        //
        // GET: /EscalaPuntaje/Create

        public ActionResult Create()
        {
            ViewBag.idEscalaImpacto_fk = new SelectList(db.EscalaImpacto, "idEscalaImpacto", "nbrEscalaImpacto");
            ViewBag.idEscalaProbabilidad_fk = new SelectList(db.EscalaProbabilidad, "idEscalaProbabilidad", "nbrEscalaProbabilidad");
            return View();
        } 

        //
        // POST: /EscalaPuntaje/Create

        [HttpPost]
        public ActionResult Create(EscalaPuntaje escalapuntaje)
        {
            if (ModelState.IsValid)
            {
                db.EscalaPuntaje.Add(escalapuntaje);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idEscalaImpacto_fk = new SelectList(db.EscalaImpacto, "idEscalaImpacto", "nbrEscalaImpacto", escalapuntaje.idEscalaImpacto_fk);
            ViewBag.idEscalaProbabilidad_fk = new SelectList(db.EscalaProbabilidad, "idEscalaProbabilidad", "nbrEscalaProbabilidad", escalapuntaje.idEscalaProbabilidad_fk);
            return View(escalapuntaje);
        }
        
        //
        // GET: /EscalaPuntaje/Edit/5
 
        public ActionResult Edit(int id)
        {
            EscalaPuntaje escalapuntaje = db.EscalaPuntaje.Find(id);
            ViewBag.idEscalaImpacto_fk = new SelectList(db.EscalaImpacto, "idEscalaImpacto", "nbrEscalaImpacto", escalapuntaje.idEscalaImpacto_fk);
            ViewBag.idEscalaProbabilidad_fk = new SelectList(db.EscalaProbabilidad, "idEscalaProbabilidad", "nbrEscalaProbabilidad", escalapuntaje.idEscalaProbabilidad_fk);
            return View(escalapuntaje);
        }

        //
        // POST: /EscalaPuntaje/Edit/5

        [HttpPost]
        public ActionResult Edit(EscalaPuntaje escalapuntaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escalapuntaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEscalaImpacto_fk = new SelectList(db.EscalaImpacto, "idEscalaImpacto", "nbrEscalaImpacto", escalapuntaje.idEscalaImpacto_fk);
            ViewBag.idEscalaProbabilidad_fk = new SelectList(db.EscalaProbabilidad, "idEscalaProbabilidad", "nbrEscalaProbabilidad", escalapuntaje.idEscalaProbabilidad_fk);
            return View(escalapuntaje);
        }

        //
        // GET: /EscalaPuntaje/Delete/5
 
        public ActionResult Delete(int id)
        {
            EscalaPuntaje escalapuntaje = db.EscalaPuntaje.Find(id);
            return View(escalapuntaje);
        }

        //
        // POST: /EscalaPuntaje/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            EscalaPuntaje escalapuntaje = db.EscalaPuntaje.Find(id);
            db.EscalaPuntaje.Remove(escalapuntaje);
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