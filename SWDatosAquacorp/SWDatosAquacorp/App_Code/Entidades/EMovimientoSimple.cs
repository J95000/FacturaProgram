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
    [DataMember]
    public decimal? PrecioTotal { get; set; }
    [DataMember]
    public int? IdDosificacion { get; set; }
    [DataMember]
    public int? NroMovimiento { get; set; }
    [DataMember]
    public string CodigoControl { get; set; }
    [DataMember]
    public string RazonSocial { get; set; }
    [DataMember]
    public string NitCi { get; set; }
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

        PrecioTotal = null;
        IdDosificacion = null;
        NroMovimiento = null;
        CodigoControl = string.Empty;
        RazonSocial = string.Empty;
        NitCi = string.Empty;
    }
}