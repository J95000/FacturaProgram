using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EPuntoZonaSimple
/// </summary>

[DataContract]
public class EPuntoZonaSimple
{
    [DataMember]
    public int IdPuntoZona { get; set; }
    [DataMember]
    public byte IdZona { get; set; }
    [DataMember]
    public decimal LatitudZona { get; set; }
    [DataMember]
    public decimal LongitudZona { get; set; }

    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public EPuntoZonaSimple()
    {
        IdPuntoZona = 0;
        IdZona = 0;
        LatitudZona = 0;
        LongitudZona = 0;

        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;

    }
}