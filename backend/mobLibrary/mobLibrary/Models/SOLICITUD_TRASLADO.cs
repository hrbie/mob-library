//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class SOLICITUD_TRASLADO
{
    public int ID_TRASLADO { get; set; }
    public int ID_USUARIO { get; set; }
    public int ID_LIBRERIA { get; set; }
    public int ID_PDV_ORIGEN { get; set; }
    public int ID_PDV_DESTINO { get; set; }
    public long ISBN { get; set; }
    public Nullable<System.DateTime> FECHA { get; set; }
    public Nullable<int> CANTIDAD { get; set; }
    public string ESTADO { get; set; }

    public virtual INVENTARIO_PDV INVENTARIO_PDV { get; set; }
    public virtual PUNTO_VENTA PUNTO_VENTA { get; set; }
    public virtual PUNTO_VENTA PUNTO_VENTA1 { get; set; }
    public virtual USUARIO USUARIO1 { get; set; }
}
