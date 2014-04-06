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
    public class CadenaLibreriasAPIController : ApiController
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        // GET api/CadenaLibreriasAPI
        [HttpGet]
        public IEnumerable<CADENA_LIBRERIAS> GetCADENA_LIBRERIAS()
        {
            return db.CADENA_LIBRERIAS.AsEnumerable();
        }

        // GET api/CadenaLibreriasAPI/5
        [HttpGet]
        public CADENA_LIBRERIAS GetCADENA_LIBRERIAS(int id)
        {
            CADENA_LIBRERIAS cadena_librerias = db.CADENA_LIBRERIAS.Find(id);
            if (cadena_librerias == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return cadena_librerias;
        }

        // PUT api/CadenaLibreriasAPI/5
        [HttpPut]
        public HttpResponseMessage PutCADENA_LIBRERIAS(int id, CADENA_LIBRERIAS cadena_librerias)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != cadena_librerias.ID_LIBRERIA)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(cadena_librerias).State = EntityState.Modified;

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

        // POST api/CadenaLibreriasAPI
        [HttpPost]
        public HttpResponseMessage PostCADENA_LIBRERIAS(CADENA_LIBRERIAS cadena_librerias)
        {
            if (ModelState.IsValid)
            {
                db.CADENA_LIBRERIAS.Add(cadena_librerias);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cadena_librerias);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = cadena_librerias.ID_LIBRERIA }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/CadenaLibreriasAPI/5
        [HttpDelete]
        public HttpResponseMessage DeleteCADENA_LIBRERIAS(int id)
        {
            CADENA_LIBRERIAS cadena_librerias = db.CADENA_LIBRERIAS.Find(id);
            if (cadena_librerias == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.CADENA_LIBRERIAS.Remove(cadena_librerias);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, cadena_librerias);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}