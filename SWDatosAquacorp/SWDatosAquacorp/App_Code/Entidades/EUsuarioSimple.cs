using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EUsuarioSimple
/// </summary>


[DataContract]
public class EUsuarioSimple
{
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public string Contrasena { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public EUsuarioSimple()
    {
        IdUsuario = 0;
        Contrasena = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;

    }
}