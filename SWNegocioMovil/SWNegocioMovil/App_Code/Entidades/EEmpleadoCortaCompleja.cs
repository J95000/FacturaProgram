using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EEmpleadoCompleja
/// </summary>
[DataContract]
public class EEmpleadoCortaCompleja
{

    [DataMember]
    public int IdEmpleado { get; set; }
    [DataMember]
    public string NombreCompleto { get; set; }
    [DataMember]
    public byte IdCargo { get; set; }
    [DataMember]
    public string NombreCargo { get; set; }

    public EEmpleadoCortaCompleja()
    {
        IdEmpleado = 0;
        NombreCompleto = string.Empty;
        IdCargo = 0;
        NombreCargo = string.Empty;

    }
}