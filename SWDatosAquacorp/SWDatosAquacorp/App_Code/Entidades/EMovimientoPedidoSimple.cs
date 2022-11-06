using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EMovimientoSimple
/// </summary>

[DataContract]
public class EMovimientoPedidoSimple
{
    [DataMember]
    public int IdMovimiento { get; set; }
    [DataMember]
    public string Codigo { get; set; }
    [DataMember]
    public int IdCliente { get; set; }
    [DataMember]
    public string NombreCliente { get; set; }
    [DataMember]
    public string Telefono { get; set; }
    [DataMember]
    public int IdDireccion { get; set; }
    [DataMember]
    public string NombreDireccion { get; set; }
    [DataMember]
    public decimal Latitud { get; set; }
    [DataMember]
    public decimal Longitud { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string RazonSocial { get; set; }
    [DataMember]
    public string NitCi { get; set; }
    [DataMember]
    public byte[] FotoUbicacion { get; set; }
    public EMovimientoPedidoSimple()
    {
        IdMovimiento = 0;
        Codigo = string.Empty;
        IdCliente = 0;
        NombreCliente = string.Empty;
        Telefono = string.Empty;
        IdDireccion = 0;
        NombreDireccion = string.Empty;
        Latitud = 0;
        Longitud = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion= DateTime.Now;
        RazonSocial = string.Empty;
        NitCi = string.Empty;
        FotoUbicacion = new Byte[0];
    }
}