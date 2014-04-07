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
    public class RiesgoController : Controller
    {
        private DisenioEntities db = new DisenioEntities();
        public ActionResult Dot(int riesgo)
        {
            Int32 idRiesgo = riesgo;
            //var resultado = db.CalificarRiesgo(idRiesgo);
            return RedirectToAction("Index");
        }

        //
        // GET: /Riesgo/

        public ViewResult Index()
        {
            var riesgo = db.Riesgo.Include(r => r.Estrategia).Include(r => r.Proyecto).Include(r => r.TipoRiesgo).Include(r => r.Usuario);
            return View(riesgo.ToList());
        }
        public ViewResult IndexRiesgos(int proyecto = 0)
        {
            var riesgo = from u in db.Riesgo.Include(r => r.Estrategia).Include(r => r.Proyecto).Include(r => r.TipoRiesgo).Include(r => r.Usuario)
                         where (u.idProyecto_fk == proyecto)
                         select u;
            ViewBag.mensajeRiesgo = "No existe ningún riesgo";
            TempData["idProyecto"] = proyecto;
            return View(riesgo.ToList());
        }
        //
        // GET: /Riesgo/Details/5

        public ViewResult Details(int id)
        {
            Riesgo riesgo = db.Riesgo.Find(id);
            return View(riesgo);
        }

        //
        // GET: /Riesgo/Create

        public ActionResult Create()
        {
            ViewBag.idEstrategia_fk = new SelectList(db.Estrategia, "idEstrategia", "nbrEstrategia");
            ViewBag.idProyecto_fk = new SelectList(db.Proyecto, "idProyecto", "nbrProyecto");
            ViewBag.idTipoRiesgo_fk = new SelectList(db.TipoRiesgo, "idTipoRiesgo", "nbrTipoRiesgo");
            ViewBag.idUsuario_fk = new SelectList(db.Usuario, "idUsuario", "nbrUsuario");
            return View();
        } 

        //
        // POST: /Riesgo/Create

        [HttpPost]
        public ActionResult Create(Riesgo riesgo)
        {
            if (ModelState.IsValid)
            {
                db.Riesgo.Add(riesgo);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idEstrategia_fk = new SelectList(db.Estrategia, "idEstrategia", "nbrEstrategia", riesgo.idEstrategia_fk);
            ViewBag.idProyecto_fk = new SelectList(db.Proyecto, "idProyecto", "nbrProyecto", riesgo.idProyecto_fk);
            ViewBag.idTipoRiesgo_fk = new SelectList(db.TipoRiesgo, "idTipoRiesgo", "nbrTipoRiesgo", riesgo.idTipoRiesgo_fk);
            ViewBag.idUsuario_fk = new SelectList(db.Usuario, "idUsuario", "nbrUsuario", riesgo.idUsuario_fk);
            return View(riesgo);
        }
        
        //
        // GET: /Riesgo/Edit/5
        public ActionResult CreateRiesgo(int proyecto)
        {
            ViewBag.idEstrategia_fk = new SelectList(db.Estrategia, "idEstrategia", "nbrEstrategia");
            ViewBag.idProyecto_fk = new SelectList(db.Proyecto.Where(p => p.idProyecto == proyecto), "idProyecto", "nbrProyecto");
            ViewBag.idTipoRiesgo_fk = new SelectList(db.TipoRiesgo, "idTipoRiesgo", "nbrTipoRiesgo");
            ViewBag.idUsuario_fk = new SelectList(db.Usuario, "idUsuario", "nbrUsuario");
            return View();
        }

        //
        // POST: /Riesgo/Create

        [HttpPost]
        public ActionResult CreateRiesgo(Riesgo riesgo, int proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Riesgo.Add(riesgo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstrategia_fk = new SelectList(db.Estrategia, "idEstrategia", "nbrEstrategia", riesgo.idEstrategia_fk);
            ViewBag.idProyecto_fk = new SelectList(db.Proyecto.Where(p => p.idProyecto == proyecto), "idProyecto", "nbrProyecto", riesgo.idProyecto_fk);
            ViewBag.idTipoRiesgo_fk = new SelectList(db.TipoRiesgo, "idTipoRiesgo", "nbrTipoRiesgo", riesgo.idTipoRiesgo_fk);
            ViewBag.idUsuario_fk = new SelectList(db.Usuario, "idUsuario", "nbrUsuario", riesgo.idUsuario_fk);
            return View(riesgo);
        }
 
        public ActionResult Edit(int id)
        {
            Riesgo riesgo = db.Riesgo.Find(id);
            ViewBag.idEstrategia_fk = new SelectList(db.Estrategia, "idEstrategia", "nbrEstrategia", riesgo.idEstrategia_fk);
            ViewBag.idProyecto_fk = new SelectList(db.Proyecto, "idProyecto", "nbrProyecto", riesgo.idProyecto_fk);
            ViewBag.idTipoRiesgo_fk = new SelectList(db.TipoRiesgo, "idTipoRiesgo", "nbrTipoRiesgo", riesgo.idTipoRiesgo_fk);
            ViewBag.idUsuario_fk = new SelectList(db.Usuario, "idUsuario", "nbrUsuario", riesgo.idUsuario_fk);
            return View(riesgo);
        }

        //
        // POST: /Riesgo/Edit/5

        [HttpPost]
        public ActionResult Edit(Riesgo riesgo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riesgo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstrategia_fk = new SelectList(db.Estrategia, "idEstrategia", "nbrEstrategia", riesgo.idEstrategia_fk);
            ViewBag.idProyecto_fk = new SelectList(db.Proyecto, "idProyecto", "nbrProyecto", riesgo.idProyecto_fk);
            ViewBag.idTipoRiesgo_fk = new SelectList(db.TipoRiesgo, "idTipoRiesgo", "nbrTipoRiesgo", riesgo.idTipoRiesgo_fk);
            ViewBag.idUsuario_fk = new SelectList(db.Usuario, "idUsuario", "nbrUsuario", riesgo.idUsuario_fk);
            return View(riesgo);
        }

        //
        // GET: /Riesgo/Delete/5
 
        public ActionResult Delete(int id)
        {
            Riesgo riesgo = db.Riesgo.Find(id);
            return View(riesgo);
        }

        //
        // POST: /Riesgo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Riesgo riesgo = db.Riesgo.Find(id);
            db.Riesgo.Remove(riesgo);
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