using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EConyugueSimple
/// </summary>

[DataContract]
public class EConyugueSimple
{
    [DataMember]
    public int IdConyugue { get; set; }
    [DataMember]
    public int IdEmpleado { get; set; }
    [DataMember]
    public string Nombres { get; set; }
    [DataMember]
    public string PrimerApellido { get; set; }
    [DataMember]
    public string SegundoApellido { get; set; }
    [DataMember]
    public string Telefono { get; set; }
    [DataMember]
    public string TelefonoRespaldo { get; set; }
    [DataMember]
    public byte NumeroHijos { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public EConyugueSimple()
    {
        IdConyugue = 0;
        IdEmpleado = 0;
        Nombres = string.Empty;
        PrimerApellido = string.Empty;
        SegundoApellido = string.Empty;
        Telefono = string.Empty;
        TelefonoRespaldo = string.Empty;
        NumeroHijos = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}