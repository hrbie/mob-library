using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalDisenio.Models;
using System.Web.Security;

namespace ProyectoFinalDisenio.Controllers
{ 
    public class UsuarioController : Controller
    {
        private DisenioEntities db = new DisenioEntities();
        static Rol rolTemporal;

        //
        // GET: /Usuario/

        public ViewResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Rol);
            return View(usuario.ToList());
        }

        //
        // GET: /Usuario/Details/5

        public ViewResult Details(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            ViewBag.idRol_fk = new SelectList(db.Rol, "idRol", "nbrRol");
            return View();
        } 

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idRol_fk = new SelectList(db.Rol, "idRol", "nbrRol", usuario.idRol_fk);
            return View(usuario);
        }
        
        //
        // GET: /Usuario/Edit/5
 
        public ActionResult Edit(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            ViewBag.idRol_fk = new SelectList(db.Rol, "idRol", "nbrRol", usuario.idRol_fk);
            Rol rol = db.Rol.Find(usuario.idRol_fk);
            rolTemporal = rol;
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.contraseña = usuario.StringToBytes("");
                db.Entry(usuario).State = EntityState.Modified;
                Roles.RemoveUserFromRole(usuario.nbrUsuario, rolTemporal.nbrRol);
                Rol rolActual = db.Rol.Find(usuario.idRol_fk);
                Roles.AddUserToRole(usuario.nbrUsuario, rolActual.nbrRol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRol_fk = new SelectList(db.Rol, "idRol", "nbrRol", usuario.idRol_fk);
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5
 
        public ActionResult Delete(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Usuario usuario = db.Usuario.Find(id);
            Membership.DeleteUser(usuario.nbrUsuario);
            db.Usuario.Remove(usuario);
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