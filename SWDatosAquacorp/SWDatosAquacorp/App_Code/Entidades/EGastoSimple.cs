using System;

using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EGastoSimple
/// </summary>

[DataContract]
public class EGastoSimple
{
    [DataMember]
    public int IdGasto { get; set; }
    [DataMember]
    public byte IdTipoGasto { get; set; }
    [DataMember]
    public int Cantidad { get; set; }
    [DataMember]
    public decimal Precio { get; set; }
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public int IdAprovador { get; set; }

    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public EGastoSimple()
    {
        IdGasto = 0;
        IdTipoGasto = 0;
        Cantidad = 0;
        Precio = 0;
        IdUsuario = 0;
        IdAprovador = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;

    }
}