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
    
    public partial class PortafolioProyectos
    {
        public PortafolioProyectos()
        {
            this.Proyecto = new HashSet<Proyecto>();
        }
    
        public int idPortafolioProyecto { get; set; }
        public string nbrPortafolioProyecto { get; set; }
        public string descripcionPortafolioProyectos { get; set; }
    
        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
