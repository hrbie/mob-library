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
    public class EscalaProbabilidadController : Controller
    {
        private DisenioEntities db = new DisenioEntities();
        
        //
        // GET: /EscalaProbabilidad/

        public ViewResult Index(int id = 0)
        {
            try
            {
                var escalaProbabilidad = db.EscalaProbabilidad;
                if (id != 0)
                {
                    var EscalaProbabilidadActual = escalaProbabilidad.Where(s => s.idEscalaProbabilidad == id);
                    return View(EscalaProbabilidadActual);
                    //Viewbag.Message
                }
                else
                {
                    //ViewBag.Message
                    return View(db.EscalaProbabilidad.ToList());
                }
            }
            catch (Exception e)
            {
                IList<EscalaProbabilidad> lista = new List<EscalaProbabilidad>();
                ViewBag.Message = e.Message;
                return View(lista);
            }
        }

        //
        // GET: /EscalaProbabilidad/Details/5

        public ViewResult Details(int id)
        {
            EscalaProbabilidad escalaprobabilidad = db.EscalaProbabilidad.Find(id);
            return View(escalaprobabilidad);
        }

        //
        // GET: /EscalaProbabilidad/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /EscalaProbabilidad/Create

        [HttpPost]
        public ActionResult Create(EscalaProbabilidad escalaprobabilidad)
        {
            if (ModelState.IsValid)
            {
                db.EscalaProbabilidad.Add(escalaprobabilidad);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(escalaprobabilidad);
        }
        
        //
        // GET: /EscalaProbabilidad/Edit/5
 
        public ActionResult Edit(int id)
        {
            EscalaProbabilidad escalaprobabilidad = db.EscalaProbabilidad.Find(id);
            return View(escalaprobabilidad);
        }

        //
        // POST: /EscalaProbabilidad/Edit/5

        [HttpPost]
        public ActionResult Edit(EscalaProbabilidad escalaprobabilidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escalaprobabilidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escalaprobabilidad);
        }

        //
        // GET: /EscalaProbabilidad/Delete/5
 
        public ActionResult Delete(int id)
        {
            EscalaProbabilidad escalaprobabilidad = db.EscalaProbabilidad.Find(id);
            return View(escalaprobabilidad);
        }

        //
        // POST: /EscalaProbabilidad/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            EscalaProbabilidad escalaprobabilidad = db.EscalaProbabilidad.Find(id);
            db.EscalaProbabilidad.Remove(escalaprobabilidad);
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