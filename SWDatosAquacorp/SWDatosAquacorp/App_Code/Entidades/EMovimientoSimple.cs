using System;

using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EMovimientoSimple
/// </summary>

[DataContract]
public class EMovimientoSimple
{
    [DataMember]
    public int IdMovimiento { get; set; }
    [DataMember]
    public string Codigo { get; set; }
    [DataMember]
    public int IdCliente { get; set; }
    [DataMember]
    public int? IdUsuario { get; set; }
    [DataMember]
    public string TipoMovimiento { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public EMovimientoSimple()
    {
        IdMovimiento = 0;
        Codigo= string.Empty;
        IdCliente = 0;
        IdUsuario = 0;
        TipoMovimiento = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}