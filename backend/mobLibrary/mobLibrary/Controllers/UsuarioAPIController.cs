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
            return db.USUARIO.AsEnumerable();
        }

        // GET api/UsuarioAPI/5
        public USUARIO GetUSUARIO(int id)
        {
            USUARIO usuario = db.USUARIO.Find(id);
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