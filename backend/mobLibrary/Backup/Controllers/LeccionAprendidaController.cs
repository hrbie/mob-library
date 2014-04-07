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
    public class LeccionAprendidaController : Controller
    {
        private DisenioEntities db = new DisenioEntities();

        //
        // GET: /LeccionAprendida/

        public ViewResult Index()
        {
            var leccionaprendida = db.LeccionAprendida.Include(l => l.Proyecto);
            return View(leccionaprendida.ToList());
        }

        //
        // GET: /LeccionAprendida/Details/5

        public ViewResult Details(int id)
        {
            LeccionAprendida leccionaprendida = db.LeccionAprendida.Find(id);
            return View(leccionaprendida);
        }

        //
        // GET: /LeccionAprendida/Create

        public ActionResult Create()
        {
            ViewBag.idProyecto_fk = new SelectList(db.Proyecto, "idProyecto", "nbrProyecto");
            return View();
        } 

        //
        // POST: /LeccionAprendida/Create

        [HttpPost]
        public ActionResult Create(LeccionAprendida leccionaprendida)
        {
            if (ModelState.IsValid)
            {
                db.LeccionAprendida.Add(leccionaprendida);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idProyecto_fk = new SelectList(db.Proyecto, "idProyecto", "nbrProyecto", leccionaprendida.idProyecto_fk);
            return View(leccionaprendida);
        }
        
        //
        // GET: /LeccionAprendida/Edit/5
 
        public ActionResult Edit(int id)
        {
            LeccionAprendida leccionaprendida = db.LeccionAprendida.Find(id);
            ViewBag.idProyecto_fk = new SelectList(db.Proyecto, "idProyecto", "nbrProyecto", leccionaprendida.idProyecto_fk);
            return View(leccionaprendida);
        }

        //
        // POST: /LeccionAprendida/Edit/5

        [HttpPost]
        public ActionResult Edit(LeccionAprendida leccionaprendida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leccionaprendida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProyecto_fk = new SelectList(db.Proyecto, "idProyecto", "nbrProyecto", leccionaprendida.idProyecto_fk);
            return View(leccionaprendida);
        }

        //
        // GET: /LeccionAprendida/Delete/5
 
        public ActionResult Delete(int id)
        {
            LeccionAprendida leccionaprendida = db.LeccionAprendida.Find(id);
            return View(leccionaprendida);
        }

        //
        // POST: /LeccionAprendida/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            LeccionAprendida leccionaprendida = db.LeccionAprendida.Find(id);
            db.LeccionAprendida.Remove(leccionaprendida);
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