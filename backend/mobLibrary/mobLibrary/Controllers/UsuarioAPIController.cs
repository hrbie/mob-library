using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using mobLibrary.Models;

namespace mobLibrary.Controllers
{
    public class UsuarioAPIController : ApiController
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        // GET api/UsuarioAPI
        public IEnumerable<USUARIO> GetUSUARIOs()
        {
            //return db.USUARIO.AsEnumerable();
            return db.USUARIO.Select(l => new
            {
                ID_USUARIO = l.ID_USUARIO,
                NOMBRE = l.NOMBRE,
                APELLIDO1 = l.APELLIDO1,
                APELLIDO2 = l.APELLIDO2,
                FECHA_NACIMIENTO = l.FECHA_NACIMIENTO,
                DIRECCION = l.DIRECCION,
                EMAIL = l.EMAIL,
                USERNAME = l.USERNAME
            }).ToList().Select(x => new USUARIO
            {
                ID_USUARIO = x.ID_USUARIO,
                NOMBRE = x.NOMBRE,
                APELLIDO1 = x.APELLIDO1,
                APELLIDO2 = x.APELLIDO2,
                FECHA_NACIMIENTO = x.FECHA_NACIMIENTO,
                DIRECCION = x.DIRECCION,
                EMAIL = x.EMAIL,
                USERNAME = x.USERNAME
            });
        }

        public IEnumerable<USUARIO> GetUSUARIOByUSERNAME(string id)
        {
            //return db.USUARIO.AsEnumerable();
            return db.USUARIO.Select(l => new
            {
                ID_USUARIO = l.ID_USUARIO,
                NOMBRE = l.NOMBRE,
                APELLIDO1 = l.APELLIDO1,
                APELLIDO2 = l.APELLIDO2,
                FECHA_NACIMIENTO = l.FECHA_NACIMIENTO,
                DIRECCION = l.DIRECCION,
                EMAIL = l.EMAIL,
                USERNAME = l.USERNAME
            }).ToList().Select(x => new USUARIO
            {
                ID_USUARIO = x.ID_USUARIO,
                NOMBRE = x.NOMBRE,
                APELLIDO1 = x.APELLIDO1,
                APELLIDO2 = x.APELLIDO2,
                FECHA_NACIMIENTO = x.FECHA_NACIMIENTO,
                DIRECCION = x.DIRECCION,
                EMAIL = x.EMAIL,
                USERNAME = x.USERNAME
            }).Where(t => t.USERNAME==id);
        }

        // GET api/UsuarioAPI/5
        public USUARIO GetUSUARIO(int id)
        {
            //USUARIO usuario = db.USUARIO.Find(id);

            USUARIO usuario = db.USUARIO.Select(l => new
            {
                ID_USUARIO = l.ID_USUARIO,
                NOMBRE = l.NOMBRE,
                APELLIDO1 = l.APELLIDO1,
                APELLIDO2 = l.APELLIDO2,
                FECHA_NACIMIENTO = l.FECHA_NACIMIENTO,
                DIRECCION = l.DIRECCION,
                EMAIL = l.EMAIL,
                USERNAME = l.USERNAME
            }).ToList().Select(x => new USUARIO
            {
                ID_USUARIO = x.ID_USUARIO,
                NOMBRE = x.NOMBRE,
                APELLIDO1 = x.APELLIDO1,
                APELLIDO2 = x.APELLIDO2,
                FECHA_NACIMIENTO = x.FECHA_NACIMIENTO,
                DIRECCION = x.DIRECCION,
                EMAIL = x.EMAIL,
                USERNAME = x.USERNAME
            }).Where(t => t.ID_USUARIO == id).FirstOrDefault();

            if (usuario == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            
                return usuario;
            
        }

        // PUT api/UsuarioAPI/5
        public HttpResponseMessage PutUSUARIO(int id, USUARIO usuario)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != usuario.ID_USUARIO)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/UsuarioAPI
        public HttpResponseMessage PostUSUARIO(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO.Add(usuario);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, usuario);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = usuario.ID_USUARIO }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // POST api/UsuarioAPI
        public HttpResponseMessage PostUSUARIO(string nombre,string apellido1, string apellido2, string fecha, string direccion, string email,string username )
        {
            USUARIO usuario = new USUARIO();
            usuario.ID_USUARIO = 0;
            usuario.NOMBRE = nombre;
            usuario.APELLIDO1 = apellido1;
            usuario.APELLIDO2 = apellido2;

            int anio = Int32.Parse(fecha.Split('/').ElementAt(2));
            int mes = Int32.Parse(fecha.Split('/').ElementAt(1));
            int dia = Int32.Parse(fecha.Split('/').ElementAt(0));

            usuario.FECHA_NACIMIENTO = new DateTime(anio, mes, dia);
            usuario.DIRECCION = direccion;
            usuario.EMAIL = email;
            usuario.USERNAME = username;

            if (ModelState.IsValid)
            {
                db.USUARIO.Add(usuario);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, usuario);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = usuario.ID_USUARIO }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

       

        // DELETE api/UsuarioAPI/5
        public HttpResponseMessage DeleteUSUARIO(int id)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            if (usuario == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.USUARIO.Remove(usuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}