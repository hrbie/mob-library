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
    
    public partial class MatrizRiesgos
    {
        public int idMatrizRiesgos { get; set; }
        public int idRiesgo_fk { get; set; }
    
        public virtual Riesgo Riesgo { get; set; }
    }
}