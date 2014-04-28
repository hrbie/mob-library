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
    public class ListaLibrosAPIController : ApiController
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        // GET api/ListaLibrosAPI
        public IEnumerable<LISTA_LIBROS> GetLISTA_LIBROS()
        {
            //var lista_libros = db.LISTA_LIBROS.Include(l => l.LIBRO).Include(l => l.USUARIO);
            
            return db.LISTA_LIBROS.Select(t => new
            {
                ID_USUARIO = t.ID_USUARIO,
                ISBN = t.ISBN,
                CALIFICACION = t.CALIFICACION,
                OPINION = t.OPINION,
                ESTADO = t.ESTADO
            }).ToList().Select(x => new LISTA_LIBROS
            {
                ID_USUARIO = x.ID_USUARIO,
                ISBN = x.ISBN,
                CALIFICACION = x.CALIFICACION,
                OPINION = x.OPINION,
                ESTADO = x.ESTADO
            });

            //return lista_libros.AsEnumerable();
        }

        public IEnumerable<LISTA_LIBROS> GetPendientesByUsuario(int id)
        {
            //var lista_libros = db.LISTA_LIBROS.Include(l => l.LIBRO).Include(l => l.USUARIO);

            return db.LISTA_LIBROS.Select(t => new
            {
                ID_USUARIO = t.ID_USUARIO,
                ISBN = t.ISBN,
                CALIFICACION = t.CALIFICACION,
                OPINION = t.OPINION,
                ESTADO = t.ESTADO
            }).ToList().Select(x => new LISTA_LIBROS
            {
                ID_USUARIO = x.ID_USUARIO,
                ISBN = x.ISBN,
                CALIFICACION = x.CALIFICACION,
                OPINION = x.OPINION,
                ESTADO = x.ESTADO
            }).Where(l => l.ID_USUARIO == id && l.ESTADO == "PENDIENTE");
        }

        public IEnumerable<LISTA_LIBROS> GetListaByUsuario(int id)
        {
            return db.LISTA_LIBROS.Select(t => new
            {
                ID_USUARIO = t.ID_USUARIO,
                ISBN = t.ISBN,
                CALIFICACION = t.CALIFICACION,
                OPINION = t.OPINION,
                ESTADO = t.ESTADO
            }).ToList().Select(x => new LISTA_LIBROS
            {
                ID_USUARIO = x.ID_USUARIO,
                ISBN = x.ISBN,
                CALIFICACION = x.CALIFICACION,
                OPINION = x.OPINION,
                ESTADO = x.ESTADO
            }).Where(l => l.ID_USUARIO == id);
        }

        public IEnumerable<LISTA_LIBROS> GetLISTA_LIBROSByLibro(int id)
        {
            //var lista_libros = db.LISTA_LIBROS.Include(l => l.LIBRO).Include(l => l.USUARIO);

            return db.LISTA_LIBROS.Select(t => new
            {
                ID_USUARIO = t.ID_USUARIO,
                ISBN = t.ISBN,
                CALIFICACION = t.CALIFICACION,
                OPINION = t.OPINION,
                ESTADO = t.ESTADO
            }).ToList().Select(x => new LISTA_LIBROS
            {
                ID_USUARIO = x.ID_USUARIO,
                ISBN = x.ISBN,
                CALIFICACION = x.CALIFICACION,
                OPINION = x.OPINION,
                ESTADO = x.ESTADO
            }).Where(l => l.ISBN == id && l.OPINION != null && l.OPINION != "");

            //return lista_libros.AsEnumerable();
        }

        public IEnumerable<LISTA_LIBROS> GetLISTA_LIBROSByLibroAndUsuario(int id_usuario, long isbn)
        {
            //var lista_libros = db.LISTA_LIBROS.Include(l => l.LIBRO).Include(l => l.USUARIO);

            return db.LISTA_LIBROS.Select(t => new
            {
                ID_USUARIO = t.ID_USUARIO,
                ISBN = t.ISBN,
                CALIFICACION = t.CALIFICACION,
                OPINION = t.OPINION,
                ESTADO = t.ESTADO
            }).ToList().Select(x => new LISTA_LIBROS
            {
                ID_USUARIO = x.ID_USUARIO,
                ISBN = x.ISBN,
                CALIFICACION = x.CALIFICACION,
                OPINION = x.OPINION,
                ESTADO = x.ESTADO
            }).Where(l => l.ISBN == isbn && l.ID_USUARIO == id_usuario );

            //return lista_libros.AsEnumerable();
        }

        public IEnumerable<LISTA_LIBROS_2> GetLISTA_LIBROSByLibro2(int id)
        {
            //var lista_libros = db.LISTA_LIBROS.Include(l => l.LIBRO).Include(l => l.USUARIO);

            return db.LISTA_LIBROS.Select(t => new
            {
                ID_USUARIO = t.ID_USUARIO,
                USUARIO = t.USUARIO,
                ISBN = t.ISBN,
                CALIFICACION = t.CALIFICACION,
                OPINION = t.OPINION,
                ESTADO = t.ESTADO
            }).ToList().Select(x => new LISTA_LIBROS_2
            {
                USUARIO = x.USUARIO.NOMBRE + " " + x.USUARIO.APELLIDO1 + " " + x.USUARIO.APELLIDO2,
                ISBN = x.ISBN,
                CALIFICACION = x.CALIFICACION,
                OPINION = x.OPINION,
                ESTADO = x.ESTADO
            }).Where(l => l.ISBN == id && l.OPINION != null && l.OPINION != "");

            //return lista_libros.AsEnumerable();
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

        public HttpResponseMessage PutLISTA_LIBROS(int id_usuario, int isbn, int? calificacion, string opinion, string estado)
        {
            LISTA_LIBROS lista_libros = db.LISTA_LIBROS.Where(x => x.ID_USUARIO == id_usuario && x.ISBN == isbn).FirstOrDefault();


            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if ( lista_libros == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            lista_libros.CALIFICACION = calificacion;
            lista_libros.OPINION = opinion;
            lista_libros.ESTADO = estado;
           

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

        // POST api/ListaLibrosAPI
        public HttpResponseMessage PostLISTA_LIBROS(int id_usuario, int isbn, int? calificacion, string opinion,string estado)
        {
            LISTA_LIBROS lista_libros = new LISTA_LIBROS();
            lista_libros.ID_USUARIO = id_usuario;
            lista_libros.ISBN = isbn;
            lista_libros.CALIFICACION = calificacion;
            lista_libros.OPINION = opinion;
            lista_libros.ESTADO = estado;


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