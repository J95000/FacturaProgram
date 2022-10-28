using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EUsuarioCompleja
/// </summary>
/// 
[DataContract]
public class EUsuarioCompleja
{

    [DataMember]
    public int Cont { get; set; }

    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public string NombreCompleto { get; set; }
    [DataMember]
    public string NombreUsuario { get; set; }
    [DataMember]
    public string Contrasena { get; set; }
    [DataMember]
    public string Cargo { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    public EUsuarioCompleja()
    {
        Cont = 0;
        IdUsuario = 0;
        NombreCompleto = string.Empty;
        NombreUsuario = string.Empty;
        Contrasena = string.Empty;
        Cargo = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}