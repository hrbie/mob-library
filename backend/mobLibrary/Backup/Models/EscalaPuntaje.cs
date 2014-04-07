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
    
    public partial class EscalaPuntaje
    {
        public EscalaPuntaje()
        {
            this.Proyecto = new HashSet<Proyecto>();
            this.Categoria = new HashSet<Categoria>();
        }
    
        public int idEscala { get; set; }
        public string nbrEscala { get; set; }
        public string descripcionEscala { get; set; }
        public Nullable<int> valorMinimo { get; set; }
        public Nullable<int> valorMaximo { get; set; }
        public int idEscalaProbabilidad_fk { get; set; }
        public int idEscalaImpacto_fk { get; set; }
    
        public virtual EscalaImpacto EscalaImpacto { get; set; }
        public virtual EscalaProbabilidad EscalaProbabilidad { get; set; }
        public virtual ICollection<Proyecto> Proyecto { get; set; }
        public virtual ICollection<Categoria> Categoria { get; set; }
    }
}
