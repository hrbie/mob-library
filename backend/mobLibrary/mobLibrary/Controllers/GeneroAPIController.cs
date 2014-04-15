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
    public class GeneroAPIController : ApiController
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        // GET api/GeneroAPI
        public IEnumerable<GENERO> GetGENEROes()
        {
            return db.GENERO.AsEnumerable();
        }

        // GET api/GeneroAPI/5
        public GENERO GetGENERO(int id)
        {
            GENERO genero = db.GENERO.Find(id);
            if (genero == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return genero;
        }

        // PUT api/GeneroAPI/5
        public HttpResponseMessage PutGENERO(int id, GENERO genero)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != genero.ID_GENERO)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(genero).State = EntityState.Modified;

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

        // POST api/GeneroAPI
        public HttpResponseMessage PostGENERO(GENERO genero)
        {
            if (ModelState.IsValid)
            {
                db.GENERO.Add(genero);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, genero);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = genero.ID_GENERO }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/GeneroAPI/5
        public HttpResponseMessage DeleteGENERO(int id)
        {
            GENERO genero = db.GENERO.Find(id);
            if (genero == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GENERO.Remove(genero);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, genero);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}