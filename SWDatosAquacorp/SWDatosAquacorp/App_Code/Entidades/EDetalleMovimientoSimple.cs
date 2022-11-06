using System;

using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EDetalleMovimientoSimple
/// </summary>


[DataContract]
public class EDetalleMovimientoSimple
{
    [DataMember]
    public int IdDetalleMovimiento { get; set; }
    [DataMember]
    public int IdMovimiento { get; set; }
    [DataMember]
    public int IdProducto { get; set; }
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
    [DataMember]
    public decimal? SubTotal { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public EDetalleMovimientoSimple()
    {
        IdDetalleMovimiento = 0;
        IdMovimiento = 0;
        IdProducto = 0;
        PrecioUnitario = 0;
        Cantidad = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
        SubTotal = null;
    }
}