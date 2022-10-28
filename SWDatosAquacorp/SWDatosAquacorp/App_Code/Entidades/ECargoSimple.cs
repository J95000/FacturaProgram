using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de ECargoSimple
/// </summary>

[DataContract]
public class ECargoSimple
{
    [DataMember]
    public byte IdCargo { get; set; }
    [DataMember]
    public string NombreCargo { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public ECargoSimple()
    {
        IdCargo = 0;
        NombreCargo = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}