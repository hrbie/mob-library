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
    
    public partial class EscalaProbabilidad
    {
        public EscalaProbabilidad()
        {
            this.EscalaPuntaje = new HashSet<EscalaPuntaje>();
        }
    
        public int idEscalaProbabilidad { get; set; }
        public string nbrEscalaProbabilidad { get; set; }
        public string descripcionEscala { get; set; }
        public int valorMinimo { get; set; }
        public int valorMaximo { get; set; }
    
        public virtual ICollection<EscalaPuntaje> EscalaPuntaje { get; set; }
    }
}