using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mobLibrary.Controllers
{
    public partial class LISTA_LIBROS_2
    {
        public string USUARIO { get; set; }
        public long ISBN { get; set; }
        public Nullable<int> CALIFICACION { get; set; }
        public string OPINION { get; set; }
        public string ESTADO { get; set; }

    }
}