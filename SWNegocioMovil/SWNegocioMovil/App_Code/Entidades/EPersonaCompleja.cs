using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EPersonaCompleja
/// </summary>
/// 
[DataContract]
public class EPersonaCompleja
{
    [DataMember]
    public int IdPersona { get; set; }
    [DataMember]
    public string Nombres { get; set; }
    [DataMember]
    public string PrimerApellido { get; set; }
    [DataMember]
    public string SegundoApellido { get; set; }
    [DataMember]
    public string Telefono { get; set; }
    [DataMember]
    public string Direccion { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    public EPersonaCompleja()
    {
        IdPersona = 0;
        Nombres = string.Empty;
        PrimerApellido = string.Empty;
        SegundoApellido = string.Empty;
        Telefono = string.Empty;
        Direccion = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}