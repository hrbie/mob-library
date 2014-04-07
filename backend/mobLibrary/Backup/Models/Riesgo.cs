//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinalDisenio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Riesgo
    {
        public Riesgo()
        {
            this.Factor = new HashSet<Factor>();
            this.MatrizRiesgos = new HashSet<MatrizRiesgos>();
        }
    
        public int idRiesgo { get; set; }
        public string nbrRiesgo { get; set; }
        public Nullable<int> puntajeRiesgo { get; set; }
        public bool status { get; set; }
        public int idEstrategia_fk { get; set; }
        public int idTipoRiesgo_fk { get; set; }
        public string planRespuesta { get; set; }
        public string descripcionRiesgo { get; set; }
        public string nivelRiesgo { get; set; }
        public int idProyecto_fk { get; set; }
        public int idUsuario_fk { get; set; }
        public Nullable<int> Impacto { get; set; }
        public Nullable<int> Probabilidad { get; set; }
    
        public virtual Estrategia Estrategia { get; set; }
        public virtual ICollection<Factor> Factor { get; set; }
        public virtual ICollection<MatrizRiesgos> MatrizRiesgos { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual TipoRiesgo TipoRiesgo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
