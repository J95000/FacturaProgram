using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EReferenciaPersonalSimple
/// </summary>

[DataContract]
public class EReferenciaPersonalSimple
{
    [DataMember]
    public int IdReferenciaPersonal { get; set; }
    [DataMember]
    public int IdEmpleado { get; set; }
    [DataMember]
    public string NombresFamiliar { get; set; }
    [DataMember]
    public string PrimerApellidoFamiliar { get; set; }
    [DataMember]
    public string SegundoApellidoFamiliar { get; set; }
    [DataMember]
    public string Parentesco { get; set; }
    [DataMember]
    public string Direccion { get; set; }
    [DataMember]
    public string Telefono { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public EReferenciaPersonalSimple()
    {
        IdReferenciaPersonal = 0;
        IdEmpleado = 0;
        NombresFamiliar = string.Empty;
        PrimerApellidoFamiliar = string.Empty;
        SegundoApellidoFamiliar = string.Empty;
        Parentesco = string.Empty;
        Direccion = string.Empty;
        Telefono = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}