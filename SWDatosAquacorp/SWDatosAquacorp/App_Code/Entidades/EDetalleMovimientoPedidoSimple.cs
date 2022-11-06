using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EDetalleMovimientoSimple
/// </summary>


[DataContract]
public class EDetalleMovimientoPedidoSimple
{
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
    public decimal SubTotal { get; set; }

    public EDetalleMovimientoPedidoSimple()
    {
        IdDetalleMovimiento = 0;
        IdMovimiento = 0;
        IdProducto = 0;
        NombreProducto = string.Empty;
        PrecioUnitario = 0;
        Cantidad = 0;
        SubTotal = 0;
    }
}