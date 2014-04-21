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
    public class SolicitudPedidoAPIController : ApiController
    {
        private mobLibraryEntities db = new mobLibraryEntities();

        // GET api/SolicitudPedidoAPI
        public IEnumerable<SOLICITUD_PEDIDO> GetSOLICITUD_PEDIDO()
        {
            //var solicitud_pedido = db.SOLICITUD_PEDIDO.Include(s => s.INVENTARIO_PDV).Include(s => s.USUARIO);
            //return solicitud_pedido.AsEnumerable();
            return db.SOLICITUD_PEDIDO.Select(x => new
            {
                CANTIDAD = x.CANTIDAD,
                ESTADO = x.ESTADO,
                FECHA = x.FECHA,
                ID_LIBRERIA = x.ID_LIBRERIA,
                ID_PDV = x.ID_PDV,
                ID_PEDIDO = x.ID_PEDIDO,
                ID_USUARIO = x.ID_USUARIO,
                //INVENTARIO_PDV = x.INVENTARIO_PDV, 
                ISBN = x.ISBN,
                //USUARIO = x.USUARIO 
            }).ToList().Select(t => new SOLICITUD_PEDIDO
            {
                CANTIDAD = t.CANTIDAD,
                ESTADO = t.ESTADO,
                FECHA = t.FECHA,
                ID_LIBRERIA = t.ID_LIBRERIA,
                ID_PDV = t.ID_PDV,
                ID_PEDIDO = t.ID_PEDIDO,
                ID_USUARIO = t.ID_USUARIO,
                //INVENTARIO_PDV = t.INVENTARIO_PDV, 
                ISBN = t.ISBN,
                //USUARIO = t.USUARIO 
            });

        }

        // GET api/SolicitudPedidoAPI/5
        public SOLICITUD_PEDIDO GetSOLICITUD_PEDIDO(int id)
        {
            SOLICITUD_PEDIDO solicitud_pedido = db.SOLICITUD_PEDIDO.Select(x => new
            {
                CANTIDAD = x.CANTIDAD,
                ESTADO = x.ESTADO,
                FECHA = x.FECHA,
                ID_LIBRERIA = x.ID_LIBRERIA,
                ID_PDV = x.ID_PDV,
                ID_PEDIDO = x.ID_PEDIDO,
                ID_USUARIO = x.ID_USUARIO,
                //INVENTARIO_PDV = x.INVENTARIO_PDV, 
                ISBN = x.ISBN,
                //USUARIO = x.USUARIO 
            }).ToList().Select(t => new SOLICITUD_PEDIDO
            {
                CANTIDAD = t.CANTIDAD,
                ESTADO = t.ESTADO,
                FECHA = t.FECHA,
                ID_LIBRERIA = t.ID_LIBRERIA,
                ID_PDV = t.ID_PDV,
                ID_PEDIDO = t.ID_PEDIDO,
                ID_USUARIO = t.ID_USUARIO,
                //INVENTARIO_PDV = t.INVENTARIO_PDV, 
                ISBN = t.ISBN,
                //USUARIO = t.USUARIO 
            }).Where(l => l.ID_PEDIDO == id).FirstOrDefault();

            if (solicitud_pedido == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return solicitud_pedido;
        }

        // PUT api/SolicitudPedidoAPI/5
        public HttpResponseMessage PutSOLICITUD_PEDIDO(int id, SOLICITUD_PEDIDO solicitud_pedido)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != solicitud_pedido.ID_PEDIDO)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(solicitud_pedido).State = EntityState.Modified;

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

        // PUT api/SolicitudPedidoAPI/5
        public HttpResponseMessage PutSOLICITUD_PEDIDO(int id_pedido, int id_usuario, int id_libreria, int id_pdv, long isbn, string fecha, string estado, int cantidad)
        {
            SOLICITUD_PEDIDO solicitud_pedido = db.SOLICITUD_PEDIDO.Find(id_pedido);

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (solicitud_pedido == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            solicitud_pedido.ID_USUARIO = id_usuario;
            solicitud_pedido.ID_LIBRERIA = id_libreria;
            solicitud_pedido.ID_PDV = id_pdv;
            solicitud_pedido.ISBN = isbn;

            int anio = Int32.Parse(fecha.Split('-').ElementAt(2));
            int mes = Int32.Parse(fecha.Split('-').ElementAt(1));
            int dia = Int32.Parse(fecha.Split('-').ElementAt(0));

            solicitud_pedido.FECHA = new DateTime(anio, mes, dia);
            solicitud_pedido.ESTADO = estado;
            solicitud_pedido.CANTIDAD = cantidad;

            db.Entry(solicitud_pedido).State = EntityState.Modified;

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

        // POST api/SolicitudPedidoAPI
        public HttpResponseMessage PostSOLICITUD_PEDIDO(SOLICITUD_PEDIDO solicitud_pedido)
        {
            if (ModelState.IsValid)
            {
                db.SOLICITUD_PEDIDO.Add(solicitud_pedido);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, solicitud_pedido);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = solicitud_pedido.ID_PEDIDO }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // POST api/SolicitudPedidoAPI
        public HttpResponseMessage PostSOLICITUD_PEDIDO(int id_usuario, int id_libreria, int id_pdv, long isbn, string fecha, string estado, int cantidad)
        {
            SOLICITUD_PEDIDO solicitud_pedido = new SOLICITUD_PEDIDO();
            solicitud_pedido.ID_PEDIDO = 0;
            solicitud_pedido.ID_USUARIO = id_usuario;
            solicitud_pedido.ID_LIBRERIA = id_libreria;
            solicitud_pedido.ID_PDV = id_pdv;
            solicitud_pedido.ISBN = isbn;

            int anio = Int32.Parse(fecha.Split('-').ElementAt(2));
            int mes = Int32.Parse(fecha.Split('-').ElementAt(1));
            int dia = Int32.Parse(fecha.Split('-').ElementAt(0));

            solicitud_pedido.FECHA = new DateTime(anio, mes, dia);
            solicitud_pedido.ESTADO = estado;
            solicitud_pedido.CANTIDAD = cantidad;

            if (ModelState.IsValid)
            {
                db.SOLICITUD_PEDIDO.Add(solicitud_pedido);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, solicitud_pedido);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = solicitud_pedido.ID_PEDIDO }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/SolicitudPedidoAPI/5
        public HttpResponseMessage DeleteSOLICITUD_PEDIDO(int id)
        {
            SOLICITUD_PEDIDO solicitud_pedido = db.SOLICITUD_PEDIDO.Find(id);
            if (solicitud_pedido == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.SOLICITUD_PEDIDO.Remove(solicitud_pedido);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, solicitud_pedido);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}