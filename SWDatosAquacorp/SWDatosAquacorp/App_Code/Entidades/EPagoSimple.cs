using System;

using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EPagoSimple
/// </summary>

[DataContract]
public class EPagoSimple
{
    [DataMember]
    public int IdPago { get; set; }
    [DataMember]
    public int IdMovimiento { get; set; }
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public decimal CantidadPago { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]

    public string Estado { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public EPagoSimple()
    {
        IdPago = 0;
        IdMovimiento = 0;
        IdUsuario = 0;
        CantidadPago = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}