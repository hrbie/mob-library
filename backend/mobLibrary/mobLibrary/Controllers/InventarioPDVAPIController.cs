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
    public class InventarioPDVAPIController : ApiController
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        // GET api/InventarioPDVAPI
        public IEnumerable<INVENTARIO_PDV> GetINVENTARIO_PDV()
        {
            //var inventario_pdv = db.INVENTARIO_PDV.Include(i => i.CATALOGO_LIBRERIA).Include(i => i.PUNTO_VENTA);
            //return inventario_pdv.AsEnumerable();
            return db.INVENTARIO_PDV.Select(x=> new 
            {
                CANTIDAD_DISPONIBLE = x.CANTIDAD_DISPONIBLE,
                ID_LIBRERIA = x.ID_LIBRERIA,
                ID_PDV = x.ID_PDV,
                ISBN = x.ISBN
            }).ToList().Select(t=> new INVENTARIO_PDV
            {
                CANTIDAD_DISPONIBLE = t.CANTIDAD_DISPONIBLE,
                ID_LIBRERIA = t.ID_LIBRERIA,
                ID_PDV = t.ID_PDV,
                ISBN = t.ISBN
            });
        }

        public IEnumerable<INVENTARIO_PDV> GetINVENTARIO_PDV(int id_libreria, int id_pdv,int isbn)
        {
            //var inventario_pdv = db.INVENTARIO_PDV.Include(i => i.CATALOGO_LIBRERIA).Include(i => i.PUNTO_VENTA);
            //return inventario_pdv.AsEnumerable();
            return db.INVENTARIO_PDV.Select(x => new
            {
                CANTIDAD_DISPONIBLE = x.CANTIDAD_DISPONIBLE,
                ID_LIBRERIA = x.ID_LIBRERIA,
                ID_PDV = x.ID_PDV,
                ISBN = x.ISBN
            }).ToList().Select(t => new INVENTARIO_PDV
            {
                CANTIDAD_DISPONIBLE = t.CANTIDAD_DISPONIBLE,
                ID_LIBRERIA = t.ID_LIBRERIA,
                ID_PDV = t.ID_PDV,
                ISBN = t.ISBN
            }).Where( l => l.ISBN ==isbn && l.ID_PDV == id_pdv && l.ID_LIBRERIA == id_libreria);

        }

        // PUT api/InventarioPDVAPI/5
        public HttpResponseMessage PutINVENTARIO_PDV(int id, INVENTARIO_PDV inventario_pdv)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != inventario_pdv.ID_LIBRERIA)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(inventario_pdv).State = EntityState.Modified;

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

        // POST api/InventarioPDVAPI
        public HttpResponseMessage PostINVENTARIO_PDV(int id_libreria, int id_pdv, int isbn, int cantidad_disponible)
        {
            INVENTARIO_PDV inventario_pdv = new INVENTARIO_PDV();
            inventario_pdv.ID_LIBRERIA = id_libreria;
            inventario_pdv.ID_PDV = id_pdv;
            inventario_pdv.ISBN = isbn;
            inventario_pdv.CANTIDAD_DISPONIBLE = cantidad_disponible;

            if (ModelState.IsValid)
            {
                db.INVENTARIO_PDV.Add(inventario_pdv);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, inventario_pdv);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = inventario_pdv.ID_LIBRERIA }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // POST api/InventarioPDVAPI
        public HttpResponseMessage PostINVENTARIO_PDV(INVENTARIO_PDV inventario_pdv)
        {
            if (ModelState.IsValid)
            {
                db.INVENTARIO_PDV.Add(inventario_pdv);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, inventario_pdv);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = inventario_pdv.ID_LIBRERIA }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }


        // DELETE api/InventarioPDVAPI/5
        public HttpResponseMessage DeleteINVENTARIO_PDV(int id)
        {
            INVENTARIO_PDV inventario_pdv = db.INVENTARIO_PDV.Find(id);
            if (inventario_pdv == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.INVENTARIO_PDV.Remove(inventario_pdv);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, inventario_pdv);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}