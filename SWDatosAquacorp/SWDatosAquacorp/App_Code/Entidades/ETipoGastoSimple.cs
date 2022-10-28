using System;

using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de ETipoGastoSimple
/// </summary>


[DataContract]
public class ETipoGastoSimple
{
    [DataMember]
    public byte IdTipoGasto { get; set; }
    [DataMember]
    public string NombreTipoGasto { get; set; }
    [DataMember]
    public string Tipo { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ETipoGastoSimple()
    {
        IdTipoGasto = 0;
        NombreTipoGasto = string.Empty;
        Tipo = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}