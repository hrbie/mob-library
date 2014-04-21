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
    public class SolicitudTrasladoAPIController : ApiController
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        // GET api/SolicitudTrasladoAPI
        public IEnumerable<SOLICITUD_TRASLADO> GetSOLICITUD_TRASLADO()
        {
            //var solicitud_traslado = db.SOLICITUD_TRASLADO.Include(s => s.INVENTARIO_PDV).Include(s => s.PUNTO_VENTA).Include(s => s.USUARIO);
            //return solicitud_traslado.AsEnumerable();
            return db.SOLICITUD_TRASLADO.Select(x => new
            {
                CANTIDAD = x.CANTIDAD,
                ESTADO = x.ESTADO,
                FECHA = x.FECHA,
                ID_LIBRERIA = x.ID_LIBRERIA,
                ID_PDV_DESTINO = x.ID_PDV_DESTINO,
                ID_PDV_ORIGEN = x.ID_PDV_ORIGEN,
                ID_TRASLADO = x.ID_TRASLADO,
                ID_USUARIO = x.ID_USUARIO,
                //x.INVENTARIO_PDV,
                ISBN = x.ISBN,
                //x.PUNTO_VENTA,
                //x.USUARIO
            }).ToList().Select(t => new SOLICITUD_TRASLADO
            {
                CANTIDAD = t.CANTIDAD,
                ESTADO = t.ESTADO,
                FECHA = t.FECHA,
                ID_LIBRERIA = t.ID_LIBRERIA,
                ID_PDV_DESTINO = t.ID_PDV_DESTINO,
                ID_PDV_ORIGEN = t.ID_PDV_ORIGEN,
                ID_TRASLADO = t.ID_TRASLADO,
                ID_USUARIO = t.ID_USUARIO,
                //t.INVENTARIO_PDV,
                ISBN = t.ISBN,
                //t.PUNTO_VENTA,
                //t.USUARIO
            });
        }

        // GET api/SolicitudTrasladoAPI/5
        public SOLICITUD_TRASLADO GetSOLICITUD_TRASLADO(int id)
        {
            SOLICITUD_TRASLADO solicitud_traslado = db.SOLICITUD_TRASLADO.Select(x => new
            {
                CANTIDAD = x.CANTIDAD,
                ESTADO = x.ESTADO,
                FECHA = x.FECHA,
                ID_LIBRERIA = x.ID_LIBRERIA,
                ID_PDV_DESTINO = x.ID_PDV_DESTINO,
                ID_PDV_ORIGEN = x.ID_PDV_ORIGEN,
                ID_TRASLADO = x.ID_TRASLADO,
                ID_USUARIO = x.ID_USUARIO,
                //x.INVENTARIO_PDV,
                ISBN = x.ISBN,
                //x.PUNTO_VENTA,
                //x.USUARIO
            }).ToList().Select(t => new SOLICITUD_TRASLADO
            {
                CANTIDAD = t.CANTIDAD,
                ESTADO = t.ESTADO,
                FECHA = t.FECHA,
                ID_LIBRERIA = t.ID_LIBRERIA,
                ID_PDV_DESTINO = t.ID_PDV_DESTINO,
                ID_PDV_ORIGEN = t.ID_PDV_ORIGEN,
                ID_TRASLADO = t.ID_TRASLADO,
                ID_USUARIO = t.ID_USUARIO,
                //t.INVENTARIO_PDV,
                ISBN = t.ISBN,
                //t.PUNTO_VENTA,
                //t.USUARIO
            }).Where(l => l.ID_TRASLADO == id).FirstOrDefault();

            if (solicitud_traslado == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return solicitud_traslado;
        }

        // PUT api/SolicitudTrasladoAPI/5
        public HttpResponseMessage PutSOLICITUD_TRASLADO(int id, SOLICITUD_TRASLADO solicitud_traslado)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != solicitud_traslado.ID_TRASLADO)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(solicitud_traslado).State = EntityState.Modified;

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

        // PUT api/SolicitudTrasladoAPI/5
        public HttpResponseMessage PutSOLICITUD_TRASLADO(int id_traslado, int id_usuario, int id_pdv_origen, int id_pdv_destino, int isbn, string fecha, int cantidad, string estado)
        {
            SOLICITUD_TRASLADO solicitud_traslado = db.SOLICITUD_TRASLADO.Find(id_traslado);

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (solicitud_traslado == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            solicitud_traslado.ID_USUARIO = id_usuario;
            solicitud_traslado.ID_PDV_ORIGEN = id_pdv_origen;
            solicitud_traslado.ID_PDV_DESTINO = id_pdv_destino;
            solicitud_traslado.ISBN = isbn;
            int anio = Int32.Parse(fecha.Split('-').ElementAt(2));
            int mes = Int32.Parse(fecha.Split('-').ElementAt(1));
            int dia = Int32.Parse(fecha.Split('-').ElementAt(0));

            solicitud_traslado.FECHA = new DateTime(anio, mes, dia);
            solicitud_traslado.CANTIDAD = cantidad;
            solicitud_traslado.ESTADO = estado;

            db.Entry(solicitud_traslado).State = EntityState.Modified;

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

        // POST api/SolicitudTrasladoAPI
        public HttpResponseMessage PostSOLICITUD_TRASLADO(SOLICITUD_TRASLADO solicitud_traslado)
        {
            if (ModelState.IsValid)
            {
                db.SOLICITUD_TRASLADO.Add(solicitud_traslado);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, solicitud_traslado);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = solicitud_traslado.ID_TRASLADO }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // POST api/SolicitudTrasladoAPI
        public HttpResponseMessage PostSOLICITUD_TRASLADO( int id_usuario, int id_libreria, int id_pdv_origen, int id_pdv_destino,int isbn, string fecha, int cantidad, string estado)
        {
            SOLICITUD_TRASLADO solicitud_traslado = new SOLICITUD_TRASLADO();
            solicitud_traslado.ID_TRASLADO = 0;
            solicitud_traslado.ID_LIBRERIA = id_libreria;
            solicitud_traslado.ID_USUARIO = id_usuario;
            solicitud_traslado.ID_PDV_ORIGEN = id_pdv_origen;
            solicitud_traslado.ID_PDV_DESTINO = id_pdv_destino;
            solicitud_traslado.ISBN = isbn;
            int anio = Int32.Parse(fecha.Split('-').ElementAt(2));
            int mes = Int32.Parse(fecha.Split('-').ElementAt(1));
            int dia = Int32.Parse(fecha.Split('-').ElementAt(0));

            solicitud_traslado.FECHA = new DateTime(anio, mes, dia);
            solicitud_traslado.CANTIDAD = cantidad;
            solicitud_traslado.ESTADO = estado;

            if (ModelState.IsValid)
            {
                db.SOLICITUD_TRASLADO.Add(solicitud_traslado);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, solicitud_traslado);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = solicitud_traslado.ID_TRASLADO }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/SolicitudTrasladoAPI/5
        public HttpResponseMessage DeleteSOLICITUD_TRASLADO(int id)
        {
            SOLICITUD_TRASLADO solicitud_traslado = db.SOLICITUD_TRASLADO.Find(id);
            if (solicitud_traslado == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.SOLICITUD_TRASLADO.Remove(solicitud_traslado);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, solicitud_traslado);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}