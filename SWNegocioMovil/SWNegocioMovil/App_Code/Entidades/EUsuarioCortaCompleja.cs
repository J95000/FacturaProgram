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
/// <summary>
/// Descripción breve de EUsuarioCortaCompleja
/// </summary>
public class EUsuarioCortaCompleja
{
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public string NombreCompleto { get; set; }

    [DataMember]
    public string Cargo { get; set; }

    public EUsuarioCortaCompleja()
    {
      
        IdUsuario = 0;
        NombreCompleto = string.Empty;
        Cargo = string.Empty;

    }
}