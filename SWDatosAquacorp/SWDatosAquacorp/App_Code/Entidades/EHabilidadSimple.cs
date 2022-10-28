using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EHabilidadSimple
/// </summary>

[DataContract]
public class EHabilidadSimple
{
    [DataMember]
    public int IdHabilidad { get; set; }
    [DataMember]
    public int IdEmpleado { get; set; }
    [DataMember]
    public string TipoHabilidad { get; set; }
    [DataMember]
    public string Detalle { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public EHabilidadSimple()
    {
        IdHabilidad = 0;
        IdEmpleado = 0;
        TipoHabilidad = string.Empty;
        Detalle = string.Empty;

        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}