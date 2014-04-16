﻿using System;
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
    public class ListaLibrosAPIController : ApiController
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        // GET api/ListaLibrosAPI
        public IEnumerable<LISTA_LIBROS> GetLISTA_LIBROS()
        {
            var lista_libros = db.LISTA_LIBROS.Include(l => l.LIBRO).Include(l => l.USUARIO);
            return lista_libros.AsEnumerable();
        }

        // GET api/ListaLibrosAPI/5
        public LISTA_LIBROS GetLISTA_LIBROS(int id)
        {
            LISTA_LIBROS lista_libros = db.LISTA_LIBROS.Find(id);
            if (lista_libros == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return lista_libros;
        }

        // PUT api/ListaLibrosAPI/5
        public HttpResponseMessage PutLISTA_LIBROS(int id, LISTA_LIBROS lista_libros)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != lista_libros.ID_USUARIO)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(lista_libros).State = EntityState.Modified;

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

        // POST api/ListaLibrosAPI
        public HttpResponseMessage PostLISTA_LIBROS(LISTA_LIBROS lista_libros)
        {
            if (ModelState.IsValid)
            {
                db.LISTA_LIBROS.Add(lista_libros);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, lista_libros);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = lista_libros.ID_USUARIO }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ListaLibrosAPI/5
        public HttpResponseMessage DeleteLISTA_LIBROS(int id)
        {
            LISTA_LIBROS lista_libros = db.LISTA_LIBROS.Find(id);
            if (lista_libros == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.LISTA_LIBROS.Remove(lista_libros);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, lista_libros);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}