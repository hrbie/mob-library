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
            var solicitud_pedido = db.SOLICITUD_PEDIDO.Include(s => s.INVENTARIO_PDV).Include(s => s.USUARIO);
            return solicitud_pedido.AsEnumerable();
        }

        // GET api/SolicitudPedidoAPI/5
        public SOLICITUD_PEDIDO GetSOLICITUD_PEDIDO(int id)
        {
            SOLICITUD_PEDIDO solicitud_pedido = db.SOLICITUD_PEDIDO.Find(id);
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