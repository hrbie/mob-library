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
using System.Globalization;

namespace mobLibrary.Controllers
{
    public class LibroAPIController : ApiController
    {
        private mobLibraryEntities db = new mobLibraryEntities();


        private IEnumerable<LIBRO> Libros() {
            return db.LIBRO.Select(x => new
            {
                ISBN = x.ISBN,
                NOMBRE = x.NOMBRE,
                AUTOR = x.AUTOR,
                EDITORIAL = x.EDITORIAL,
                PRECIO = x.PRECIO,
                ANIO = x.ANIO,
                CALIFICACION = x.CALIFICACION
            }).ToList().Select(t => new LIBRO
            {
                ISBN = t.ISBN,
                NOMBRE = t.NOMBRE,
                AUTOR = t.AUTOR,
                EDITORIAL = t.EDITORIAL,
                PRECIO = t.PRECIO,
                ANIO = t.ANIO,
                CALIFICACION = t.CALIFICACION
            });
        }

        // GET api/LibroControllerAPI/GetLIBROs
        [HttpGet]
        public IEnumerable<LIBRO> GetLIBROs()
        {
            //return db.LIBRO.AsEnumerable();
            return Libros();
        }

        // GET api/LibroControllerAPI/GetLIBRO/5
        [HttpGet]
        public LIBRO GetLIBRO(long id)
        {
            //LIBRO libro = db.LIBRO.Find(id);
            LIBRO libro = Libros().Where(l => l.ISBN == id).FirstOrDefault();

            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return libro;
        }

        // GET api/LibroControllerAPI/GetLIBROByName/{nombre}
        [HttpGet]
        public IEnumerable<LIBRO> GetLIBROByName(string id)
        {

            IEnumerable<LIBRO> libro = Libros().Where(p => p.NOMBRE.ToLower().Contains(id.ToLower()));

            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return libro;
        }

        // GET api/LibroControllerAPI/GetLIBROByAuthor/{nombre}
        [HttpGet]
        public IEnumerable<LIBRO> GetLIBROByAuthor(string id)
        {
            IEnumerable<LIBRO> libro = Libros().Where(p => p.AUTOR.Contains(id));
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return libro;
        }

        // GET api/LibroControllerAPI/GetLIBROByGenero/{nombre}
        [HttpGet]
        public IEnumerable<LIBRO> GetLIBROByGenero(string id)
        {
            //probar este
            IEnumerable<LIBRO> libro = Libros().Where(p => p.GENERO.Where(g => g.GENERO1 == id) != null);
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return libro;
        }
        
        // GET api/LibroControllerAPI/GetLIBROByAnio/{anio}
        [HttpGet]
        public IEnumerable<LIBRO> GetLIBROByAnio(int id)
        {
            IEnumerable<LIBRO> libro = Libros().Where(p => p.ANIO == id);
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return libro;
        }

        [HttpGet]
        public IEnumerable<LIBRO> GetLIBROByEditorial(string id)
        {
            IEnumerable<LIBRO> libro = Libros().Where(p => p.EDITORIAL == id);
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return libro;
        }

        public IEnumerable<LIBRO> GetLIBROByISBN(long id)
        {
            IEnumerable<LIBRO> libro = Libros().Where(p => p.ISBN == id);
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return libro;
        }

        public IEnumerable<LIBRO> GetLIBROByCalificacion(int id)
        {
            IEnumerable<LIBRO> libro = Libros().Where(p => p.CALIFICACION == id);
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return libro;
        }

        public IEnumerable<LIBRO> GetLIBROByLibreria(int id)
        {
            //seleccionar los libros tq esté asociado en el catálogo de la librería
            IEnumerable<CATALOGO_LIBRERIA> catalogo = db.CATALOGO_LIBRERIA.Where(c => c.ID_LIBRERIA == id);
            
            List<long> ISBNs = new List<long>();
            foreach (CATALOGO_LIBRERIA c in catalogo){
                ISBNs.Add(c.ISBN);
            }

            IEnumerable<LIBRO> libro = Libros().Where(l => ISBNs.Contains(l.ISBN));
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return libro;
        }

        public IEnumerable<LIBRO> GetLIBROByLibreriaAndKeyword(int id_libreria,string nombre)
        {
            //seleccionar los libros tq esté asociado en el catálogo de la librería
            IEnumerable<CATALOGO_LIBRERIA> catalogo = db.CATALOGO_LIBRERIA.Where(c => c.ID_LIBRERIA == id_libreria);
            List<long> ISBNs = new List<long>();
            foreach (CATALOGO_LIBRERIA c in catalogo)
            {
                ISBNs.Add(c.ISBN);
            }
            IEnumerable<LIBRO> libro = Libros().Where(l => (ISBNs.Contains(l.ISBN)) && l.NOMBRE.ToLower().Contains(nombre.ToLower()));
            //System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(nombre)
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return libro;
        }

        public IEnumerable<LIBRO> GetLIBROByLibreriaAndEditorial(int id_libreria, string editorial)
        {
            //seleccionar los libros tq esté asociado en el catálogo de la librería
            IEnumerable<CATALOGO_LIBRERIA> catalogo = db.CATALOGO_LIBRERIA.Where(c => c.ID_LIBRERIA == id_libreria);
            List<long> ISBNs = new List<long>();
            foreach (CATALOGO_LIBRERIA c in catalogo)
            {
                ISBNs.Add(c.ISBN);
            }
            IEnumerable<LIBRO> libro = Libros().Where(l => (ISBNs.Contains(l.ISBN)) && l.EDITORIAL.ToLower().Contains(editorial.ToLower()));
            //System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(nombre)
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return libro;
        }

        public IEnumerable<LIBRO> GetLIBROByLibreriaAndAutor(int id_libreria, string autor)
        {
            //seleccionar los libros tq esté asociado en el catálogo de la librería
            IEnumerable<CATALOGO_LIBRERIA> catalogo = db.CATALOGO_LIBRERIA.Where(c => c.ID_LIBRERIA == id_libreria);
            List<long> ISBNs = new List<long>();
            foreach (CATALOGO_LIBRERIA c in catalogo)
            {
                ISBNs.Add(c.ISBN);
            }
            IEnumerable<LIBRO> libro = Libros().Where(l => (ISBNs.Contains(l.ISBN)) && l.AUTOR.ToLower().Contains(autor.ToLower()));
            //System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(nombre)
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return libro;
        }

        public IEnumerable<LIBRO> GetLIBROByLibreriaAndCalificacion(int id_libreria, int calificacion)
        {
            //seleccionar los libros tq esté asociado en el catálogo de la librería
            IEnumerable<CATALOGO_LIBRERIA> catalogo = db.CATALOGO_LIBRERIA.Where(c => c.ID_LIBRERIA == id_libreria);
            List<long> ISBNs = new List<long>();
            foreach (CATALOGO_LIBRERIA c in catalogo)
            {
                ISBNs.Add(c.ISBN);
            }
            IEnumerable<LIBRO> libro = Libros().Where(l => (ISBNs.Contains(l.ISBN)) && l.CALIFICACION == calificacion);
            //System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(nombre)
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return libro;
        }

        public IEnumerable<LIBRO> GetLIBROByLibreriaAndRangoPrecios(int id_libreria, int precioMin, int precioMax)
        {
            //seleccionar los libros tq esté asociado en el catálogo de la librería
            IEnumerable<CATALOGO_LIBRERIA> catalogo = db.CATALOGO_LIBRERIA.Where(c => c.ID_LIBRERIA == id_libreria);
            List<long> ISBNs = new List<long>();
            foreach (CATALOGO_LIBRERIA c in catalogo)
            {
                ISBNs.Add(c.ISBN);
            }
            IEnumerable<LIBRO> libro = Libros().Where(l => (ISBNs.Contains(l.ISBN)) && l.PRECIO >= precioMin && l.PRECIO <= precioMax);
            //System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(nombre)
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return libro;
        }

        public IEnumerable<LIBRO> GetLIBROByLibreriaAndGenero(int id_libreria, string genero)
        {
            //seleccionar los libros tq esté asociado en el catálogo de la librería
            IEnumerable<CATALOGO_LIBRERIA> catalogo = db.CATALOGO_LIBRERIA.Where(c => c.ID_LIBRERIA == id_libreria);
            List<long> ISBNs = new List<long>();
            foreach (CATALOGO_LIBRERIA c in catalogo)
            {
                ISBNs.Add(c.ISBN);
            }
            //Lista de libros del genero
            IEnumerable<LIBRO> librosGenero = db.GENERO.Where(x => x.GENERO1 == genero).FirstOrDefault().LIBRO;
            //lista de libros de la libreria
            IEnumerable<LIBRO> librosLibreria = Libros().Where(l => (ISBNs.Contains(l.ISBN)));

            IEnumerable<LIBRO> result = librosGenero.Intersect(librosLibreria);

            //System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(nombre)
            if (result == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return result;
        }



        // PUT api/LibroControllerAPI/5
        [HttpPut]
        public HttpResponseMessage PutLIBRO(long id, LIBRO libro)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != libro.ISBN)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(libro).State = EntityState.Modified;

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

        // POST api/LibroControllerAPI
        [HttpPost]
        public HttpResponseMessage PostLIBRO(LIBRO libro)
        {
            if (ModelState.IsValid)
            {
                db.LIBRO.Add(libro);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, libro);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = libro.ISBN }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/LibroControllerAPI/5
        [HttpDelete]
        public HttpResponseMessage DeleteLIBRO(long id)
        {
            LIBRO libro = db.LIBRO.Find(id);
            if (libro == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.LIBRO.Remove(libro);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, libro);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}