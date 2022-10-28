using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


/// <summary>
/// Descripción breve de EZonaCompleja
/// </summary>
/// 
[DataContract]
public class EZonaCompleja
{
    [DataMember(Name = "Cont", IsRequired = false)]
    public byte Cont { get; set; }
    [DataMember(Name = "IdZona", IsRequired = false)]
    public byte IdZona { get; set; }
    [DataMember(Name = "NombreZona", IsRequired = false)]
    public string NombreZona { get; set; }
    [DataMember(Name = "FechaRegistro", IsRequired = false)]
    public DateTime FechaRegistro { get; set; }
    [DataMember(Name = "FechaModificacion", IsRequired = false)]
    public DateTime FechaModificacion { get; set; }
    [DataMember(Name = "Estado", IsRequired = false)]
    public string Estado { get; set; }

    public EZonaCompleja()
    {
        Cont = 0;
        IdZona = 0;
        NombreZona = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;


    }
}