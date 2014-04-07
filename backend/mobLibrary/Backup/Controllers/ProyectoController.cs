using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalDisenio.Models;
using System.Web.UI;

namespace ProyectoFinalDisenio.Controllers
{ 
    public class ProyectoController : Controller
    {
        private DisenioEntities db = new DisenioEntities();

        //
        // GET: /Proyecto/

        public ViewResult Index()
        {
            var proyecto = db.Proyecto.Include(p => p.EscalaPuntaje).Include(p => p.PortafolioProyectos);
            ViewBag.mensajeProyecto = "No existe ningún proyecto";
            return View(proyecto);
        }

        //
        // GET: /ProyectobyPortafolioProyecyo

        public ActionResult IndexProyectos(int portafolio)
        {
           var consulta = from u in db.Proyecto.Include(e => e.EscalaPuntaje).Include(e => e.PortafolioProyectos)
                            orderby u.idProyecto descending
                            where (u.idPortafolioProyecto_fk == portafolio)
                            select u;
           TempData["idPortafolio"] = portafolio;
           ViewBag.mensajeProyecto = "No existe ningún proyecto";
            return View(consulta);
        }

        //
        // GET: /Proyecto/Details/5

        /*public ViewResult Details(int id, int? portafolio)
        {
            Proyecto proyecto = db.Proyecto.Find(id);
            if (portafolio == null)
            {                
                return View(proyecto);
            }
            else
            {
                return View("DetailsProyecto", proyecto);
            }
        }*/

       
        //
        // GET: /Proyecto/Create

        public ActionResult Create()
        {
            ViewBag.idEscalaPuntaje = new SelectList(db.EscalaPuntaje, "idEscala", "nbrEscala");
            ViewBag.idPortafolioProyecto_fk = new SelectList(db.PortafolioProyectos, "idPortafolioProyecto", "nbrPortafolioProyecto");
            return View();
        } 

        //
        // POST: /Proyecto/Create

        [HttpPost]
        public ActionResult Create(Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idEscalaPuntaje = new SelectList(db.EscalaPuntaje, "idEscala", "nbrEscala", proyecto.idEscalaPuntaje);
            ViewBag.idPortafolioProyecto_fk = new SelectList(db.PortafolioProyectos, "idPortafolioProyecto", "nbrPortafolioProyecto", proyecto.idPortafolioProyecto_fk);
            return View(proyecto);
        }

        // GET: /Proyecto/CreatebyPortafolioProyecto

        public ActionResult CreateProyecto(int portafolio)
        {
            ViewBag.idEscalaPuntaje = new SelectList(db.EscalaPuntaje, "idEscala", "nbrEscala");
            ViewBag.idPortafolioProyecto_fk = new SelectList(db.PortafolioProyectos.Where(p => p.idPortafolioProyecto == portafolio), "idPortafolioProyecto", "nbrPortafolioProyecto");
            ViewBag.portafolio = portafolio;
            return View("CreateProyecto");
        }

        //
        // POST: /Proyecto/CreatebyPortafolioProyecto

        [HttpPost]
        public ActionResult CreateProyecto(Proyecto proyecto, int? portafolio)
        {
            if (ModelState.IsValid)
            {
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("IndexProyectos",  new {portafolio = portafolio});
            }

            ViewBag.idEscalaPuntaje = new SelectList(db.EscalaPuntaje, "idEscala", "nbrEscala", proyecto.idEscalaPuntaje);
            ViewBag.idPortafolioProyecto_fk = new SelectList(db.PortafolioProyectos, "idPortafolioProyecto", "nbrPortafolioProyecto", proyecto.idPortafolioProyecto_fk);
            return View(proyecto);
        }

        //
        // GET: /Proyecto/Edit/5
 
        public ActionResult Edit(int id, int? portafolio)
        {
            Proyecto proyecto = db.Proyecto.Find(id);
            ViewBag.idEscalaPuntaje = new SelectList(db.EscalaPuntaje, "idEscala", "nbrEscala", proyecto.idEscalaPuntaje);
            if (portafolio == null)
            {
                ViewBag.idPortafolioProyecto_fk = new SelectList(db.PortafolioProyectos, "idPortafolioProyecto", "nbrPortafolioProyecto", proyecto.idPortafolioProyecto_fk);
                return View(proyecto);
            }
            else
            {
                ViewBag.idPortafolioProyecto_fk = new SelectList(db.PortafolioProyectos.Where(p => p.idPortafolioProyecto == portafolio), "idPortafolioProyecto", "nbrPortafolioProyecto", proyecto.idPortafolioProyecto_fk);
                                                      
                return View("EditProyecto", proyecto);
            }
        }

        //
        // POST: /Proyecto/Edit/5

        [HttpPost]
        public ActionResult Edit(Proyecto proyecto, int? portafolio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                if (portafolio == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("IndexProyectos", new { portafolio = portafolio });
                }
            }
            ViewBag.idEscalaPuntaje = new SelectList(db.EscalaPuntaje, "idEscala", "nbrEscala", proyecto.idEscalaPuntaje);
            ViewBag.idPortafolioProyecto_fk = new SelectList(db.PortafolioProyectos.Where(p => p.idPortafolioProyecto == proyecto.idPortafolioProyecto_fk), "idPortafolioProyecto", "nbrPortafolioProyecto", proyecto.idPortafolioProyecto_fk);
            return View(proyecto);

        }



        //
        // GET: /Proyecto/Delete/5
 
        public ActionResult Delete(int id, int? portafolio)
        {
            Proyecto proyecto = db.Proyecto.Find(id);
            if (portafolio == null)
            {
                return View(proyecto);
            }
            else
            {
                return View("DeleteProyecto", proyecto);
            }
        }

        //
        // POST: /Proyecto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, int? portafolio)
        {            
            Proyecto proyecto = db.Proyecto.Find(id);
            db.Proyecto.Remove(proyecto);
            db.SaveChanges();
            if (portafolio == null)
                return RedirectToAction("Index");
            else
                return RedirectToAction("IndexProyectos", new { portafolio = portafolio });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult ValidarProyecto(string nbrProyecto)
        {
            var validProyecto = (from u in db.Proyecto
                                 where (u.nbrProyecto == nbrProyecto)
                                 select u);
            if (validProyecto.Count() == 1)
            {
                return Json("El nombre de proyecto ya está en uso, indique uno distinto.", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}