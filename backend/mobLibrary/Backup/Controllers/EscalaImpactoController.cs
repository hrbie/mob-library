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
    public class EscalaImpactoController : Controller
    {
        private DisenioEntities db = new DisenioEntities();
        //
        // GET: /EscalaImpacto/

        public ViewResult Index(int id = 0)
        {
            try
            {
                var escalaImpacto = db.EscalaImpacto;
                if (id != 0)
                {
                    var EscalaImpactoActual = escalaImpacto.Where(s => s.idEscalaImpacto == id);
                    return View(EscalaImpactoActual);
                    //Viewbag.Message
                }
                else
                {
                    //ViewBag.Message
                    return View(db.EscalaImpacto.ToList());
                }
            }
            catch (Exception e)
            {
                IList<EscalaImpacto> lista = new List<EscalaImpacto>();
                ViewBag.Message = e.Message;
                return View(lista);
            }
        }

        //
        // GET: /EscalaImpacto/Details/5

        public ViewResult Details(int id)
        {
            EscalaImpacto escalaimpacto = db.EscalaImpacto.Find(id);
            return View(escalaimpacto);
        }

        //
        // GET: /EscalaImpacto/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /EscalaImpacto/Create

        [HttpPost]
        public ActionResult Create(EscalaImpacto escalaimpacto)
        {
            if (ModelState.IsValid)
            {
                db.EscalaImpacto.Add(escalaimpacto);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(escalaimpacto);
        }
        
        //
        // GET: /EscalaImpacto/Edit/5
 
        public ActionResult Edit(int id)
        {
            EscalaImpacto escalaimpacto = db.EscalaImpacto.Find(id);
            return View(escalaimpacto);
        }

        //
        // POST: /EscalaImpacto/Edit/5

        [HttpPost]
        public ActionResult Edit(EscalaImpacto escalaimpacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escalaimpacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escalaimpacto);
        }

        //
        // GET: /EscalaImpacto/Delete/5
 
        public ActionResult Delete(int id)
        {
            EscalaImpacto escalaimpacto = db.EscalaImpacto.Find(id);
            return View(escalaimpacto);
        }

        //
        // POST: /EscalaImpacto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            EscalaImpacto escalaimpacto = db.EscalaImpacto.Find(id);
            db.EscalaImpacto.Remove(escalaimpacto);
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