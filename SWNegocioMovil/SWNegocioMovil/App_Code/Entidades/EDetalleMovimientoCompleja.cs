using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EDetalleMovimientoCompleja
/// </summary>


[DataContract]
public class EDetalleMovimientoCompleja
{
    [DataMember]
    public int Cont { get; set; }
    [DataMember]
    public int IdDetalleMovimiento { get; set; }
    [DataMember]
    public int IdMovimiento { get; set; }
    [DataMember]
    public int IdProducto { get; set; }
    [DataMember]
    public string NombreProducto { get; set; }
    [DataMember]
    public decimal PrecioUnitario { get; set; }
    [DataMember]
    public byte Cantidad { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    public EDetalleMovimientoCompleja()
    {
        Cont = 0;
        IdDetalleMovimiento = 0;
        IdMovimiento = 0;
        IdProducto = 0;
        NombreProducto = string.Empty;
        PrecioUnitario = 0;
        Cantidad = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}