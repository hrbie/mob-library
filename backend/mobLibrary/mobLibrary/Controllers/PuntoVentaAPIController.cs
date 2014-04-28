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
    public class PuntoVentaAPIController : ApiController
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        // GET api/PuntoVentaAPI
        public IEnumerable<PUNTO_VENTA> GetPUNTO_VENTA()
        {
            //var punto_venta = db.PUNTO_VENTA.Include(p => p.CADENA_LIBRERIAS);
            //return punto_venta.AsEnumerable();

            return db.PUNTO_VENTA.Select(l => new { ID_PDV = l.ID_PDV, ID_LIBRERIA = l.ID_LIBRERIA, NOMBRE = l.NOMBRE, DIRECCIÓN = l.DIRECCIÓN, TELEFONO = l.TELEFONO, 
                LATITUD = l.LATITUD, LONGITUD = l.LONGITUD}).ToList().Select(x => new PUNTO_VENTA {ID_PDV = x.ID_PDV, ID_LIBRERIA = x.ID_LIBRERIA, NOMBRE = x.NOMBRE, 
                    DIRECCIÓN = x.DIRECCIÓN, TELEFONO = x.TELEFONO, LATITUD = x.LATITUD, LONGITUD = x.LONGITUD});
        
        }

        // GET api/PuntoVentaAPI/5
        public PUNTO_VENTA GetPUNTO_VENTA(int id)
        {
            //PUNTO_VENTA punto_venta = db.PUNTO_VENTA.Find(id);

            PUNTO_VENTA punto_venta = db.PUNTO_VENTA.Select(l => new
            {
                ID_PDV = l.ID_PDV,
                ID_LIBRERIA = l.ID_LIBRERIA,
                NOMBRE = l.NOMBRE,
                DIRECCIÓN = l.DIRECCIÓN,
                TELEFONO = l.TELEFONO,
                LATITUD = l.LATITUD,
                LONGITUD = l.LONGITUD
            }).ToList().Select(x => new PUNTO_VENTA
            {
                ID_PDV = x.ID_PDV,
                ID_LIBRERIA = x.ID_LIBRERIA,
                NOMBRE = x.NOMBRE,
                DIRECCIÓN = x.DIRECCIÓN,
                TELEFONO = x.TELEFONO,
                LATITUD = x.LATITUD,
                LONGITUD = x.LONGITUD
            }).Where(t => t.ID_PDV == id).First();

            if (punto_venta == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return punto_venta;
        }

        // GET api/PuntoVentaAPI/GetPUNTO_VENTA_ByLIBRERIA/id
        public IEnumerable<PUNTO_VENTA> GetPUNTO_VENTA_ByLIBRERIA(int id)
        {
            //PUNTO_VENTA punto_venta = db.PUNTO_VENTA.Find(id);

            return db.PUNTO_VENTA.Select(l => new
            {
                ID_PDV = l.ID_PDV,
                ID_LIBRERIA = l.ID_LIBRERIA,
                NOMBRE = l.NOMBRE,
                DIRECCIÓN = l.DIRECCIÓN,
                TELEFONO = l.TELEFONO,
                LATITUD = l.LATITUD,
                LONGITUD = l.LONGITUD
            }).ToList().Select(x => new PUNTO_VENTA
            {
                ID_PDV = x.ID_PDV,
                ID_LIBRERIA = x.ID_LIBRERIA,
                NOMBRE = x.NOMBRE,
                DIRECCIÓN = x.DIRECCIÓN,
                TELEFONO = x.TELEFONO,
                LATITUD = x.LATITUD,
                LONGITUD = x.LONGITUD
            }).Where(t => t.ID_LIBRERIA == id);
        }

        // PUT api/PuntoVentaAPI/5
        public HttpResponseMessage PutPUNTO_VENTA(int id, PUNTO_VENTA punto_venta)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != punto_venta.ID_PDV)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(punto_venta).State = EntityState.Modified;

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

        // POST api/PuntoVentaAPI
        public HttpResponseMessage PostPUNTO_VENTA(PUNTO_VENTA punto_venta)
        {
            if (ModelState.IsValid)
            {
                db.PUNTO_VENTA.Add(punto_venta);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, punto_venta);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = punto_venta.ID_PDV }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/PuntoVentaAPI/5
        public HttpResponseMessage DeletePUNTO_VENTA(int id)
        {
            PUNTO_VENTA punto_venta = db.PUNTO_VENTA.Find(id);
            if (punto_venta == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.PUNTO_VENTA.Remove(punto_venta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, punto_venta);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}