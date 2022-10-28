using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EMovimientoCompleja
/// </summary>
/// 
[DataContract]
public class EMovimientoCompleja
{
    [DataMember]
    public int Cont { get; set; }
    [DataMember]
    public int IdMovimiento { get; set; }
    [DataMember]
    public string Codigo { get; set; }
    [DataMember]
    public int IdCliente { get; set; }
    [DataMember]
    public string NombreCliente { get; set; }
    [DataMember]
    public int? IdUsuario { get; set; }
    [DataMember]
    public string NombreUsuario { get; set; }
    [DataMember]
    public string TipoMovimiento { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }
    public EMovimientoCompleja()
    {
        Cont = 0;
        IdMovimiento = 0;
        Codigo = string.Empty;
        IdCliente = 0;
        NombreCliente = string.Empty;
        IdUsuario = 0;
        NombreUsuario = string.Empty;
        TipoMovimiento = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}
