using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de ETipoGastoCompleja
/// </summary>

[DataContract]
public class ETipoGastoCompleja
{

    [DataMember]
    public byte Cont { get; set; }
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
    public ETipoGastoCompleja()
    {
        Cont = 0;
        IdTipoGasto = 0;
        NombreTipoGasto = string.Empty;
        Tipo = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}