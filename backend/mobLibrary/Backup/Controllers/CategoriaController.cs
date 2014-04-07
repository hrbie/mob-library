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
    public class CategoriaController : Controller
    {
        private DisenioEntities db = new DisenioEntities();

        //
        // GET: /Categoria/

        public ViewResult Index()
        {
            var categoria = db.Categoria.Include(c => c.EscalaPuntaje);
            return View(categoria.ToList());
        }

        //
        // GET: /Categoria/Details/5

        public ViewResult Details(int id)
        {
            Categoria categoria = db.Categoria.Find(id);
            return View(categoria);
        }

        //
        // GET: /Categoria/Create

        public ActionResult Create()
        {
            ViewBag.idEscala_fk = new SelectList(db.EscalaPuntaje, "idEscala", "nbrEscala");
            return View();
        } 

        //
        // POST: /Categoria/Create

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Categoria.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idEscala_fk = new SelectList(db.EscalaPuntaje, "idEscala", "nbrEscala", categoria.idEscala_fk);
            return View(categoria);
        }
        
        //
        // GET: /Categoria/Edit/5
 
        public ActionResult Edit(int id)
        {
            Categoria categoria = db.Categoria.Find(id);
            ViewBag.idEscala_fk = new SelectList(db.EscalaPuntaje, "idEscala", "nbrEscala", categoria.idEscala_fk);
            return View(categoria);
        }

        //
        // POST: /Categoria/Edit/5

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEscala_fk = new SelectList(db.EscalaPuntaje, "idEscala", "nbrEscala", categoria.idEscala_fk);
            return View(categoria);
        }

        //
        // GET: /Categoria/Delete/5
 
        public ActionResult Delete(int id)
        {
            Categoria categoria = db.Categoria.Find(id);
            return View(categoria);
        }

        //
        // POST: /Categoria/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Categoria categoria = db.Categoria.Find(id);
            db.Categoria.Remove(categoria);
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