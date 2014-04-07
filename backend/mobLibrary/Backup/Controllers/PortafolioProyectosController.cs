using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalDisenio.Models;
using System.Web.UI;
using System.Web.Security;

namespace ProyectoFinalDisenio.Controllers
{ 
    public class PortafolioProyectosController : Controller
    {
        private DisenioEntities db = new DisenioEntities();

        //
        // GET: /PortafolioProyectos/

        public ViewResult Index()
        /*{
            int cantidadFilas = db.PortafolioProyectos.Count();
            if ((((page + 1) * 10) - cantidadFilas ) < 10)
            {
                ViewBag.siguientePortafolioproyecto = page + 1;
                var consulta = (from u in db.PortafolioProyectos
                                orderby u.idPortafolioProyecto ascending
                                select u).Skip((page - 1) * 10).Take(10);
                return View(consulta);
            }
            else
            {
                ViewBag.siguientePortafolioproyecto = -1;
                var consulta = (from u in db.PortafolioProyectos
                                orderby u.idPortafolioProyecto ascending
                                select u).Skip((page - 1) * 10).Take(10);
                return View(consulta);
            }
        }*/

        {
            ViewBag.mensaje = "No existe ningun poftafolio";
            return View(db.PortafolioProyectos.ToList());
        }

        //
        // GET: /PortafolioProyectos/Details/5

        public ActionResult Details(int id)
        {
            PortafolioProyectos portafolioproyectos = db.PortafolioProyectos.Find(id);
            return View(portafolioproyectos);
        }

        //
        // GET: /PortafolioProyectos/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PortafolioProyectos/Create

        [HttpPost]
        public ActionResult Create(PortafolioProyectos portafolioproyectos)
        {
            TempData["portafolioproyectos"] = portafolioproyectos.idPortafolioProyecto;
            if (ModelState.IsValid)
            {
                db.PortafolioProyectos.Add(portafolioproyectos);                
                db.SaveChanges();
                return RedirectToAction("CreateProyecto", "Proyecto", new { portafolio = portafolioproyectos.idPortafolioProyecto});  
            }

            return View(portafolioproyectos);
        }
        
        //
        // GET: /PortafolioProyectos/Edit/5
 
        public ActionResult Edit(int id)
        {
            PortafolioProyectos portafolioproyectos = db.PortafolioProyectos.Find(id);
            return View(portafolioproyectos);

        }

        //
        // POST: /PortafolioProyectos/Edit/5

        [HttpPost]
        public ActionResult Edit(PortafolioProyectos portafolioproyectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portafolioproyectos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portafolioproyectos);
        }

        //
        // GET: /PortafolioProyectos/Delete/5
 
        public ActionResult Delete(int id)
        {
            PortafolioProyectos portafolioproyectos = db.PortafolioProyectos.Find(id);
            return View(portafolioproyectos);
        }

        //
        // POST: /PortafolioProyectos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            PortafolioProyectos portafolioproyectos = db.PortafolioProyectos.Find(id);
            db.PortafolioProyectos.Remove(portafolioproyectos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult ValidarPortafolio(string nbrPortafolioProyecto)
        {
            var validPortafolio = (from u in db.PortafolioProyectos
                                 where (u.nbrPortafolioProyecto == nbrPortafolioProyecto)
                                 select u);
            if (validPortafolio.Count() == 1)
            {
                return Json("El nombre de portafolio ya está en uso, indique uno distinto.", JsonRequestBehavior.AllowGet);
            }
              return Json(true,JsonRequestBehavior.AllowGet);
            
        }
    }
}