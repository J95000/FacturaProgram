using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EZonaSimple
/// </summary>
/// 

[DataContract]
public class EZonaSimple
{
    [DataMember]
    public byte IdZona { get; set; }
    [DataMember]
    public string NombreZona { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public EZonaSimple()
    {
        IdZona = 0;
        NombreZona = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;

    }
}