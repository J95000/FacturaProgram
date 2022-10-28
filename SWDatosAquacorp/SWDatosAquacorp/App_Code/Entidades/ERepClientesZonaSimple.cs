using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de ERepClientesZonaSimple
/// </summary>

[DataContract]
public class ERepClientesZonaSimple
{
    [DataMember]
    public string NombreCompleto { get; set; }
 
    [DataMember]
    public string Telefono { get; set; }
    [DataMember]
    public string Direccion { get; set; }
    [DataMember]
    public string CorreoElectronico { get; set; }
    [DataMember]
    public string Mapa { get; set; }
    [DataMember]
    public string NombreZona { get; set; }
    [DataMember]
    public string Contrato { get; set; }
    public ERepClientesZonaSimple()
    {
 NombreCompleto = string.Empty;
        Telefono = string.Empty;
        Direccion = string.Empty;
        CorreoElectronico = string.Empty;
        Mapa = string.Empty;
        NombreZona = string.Empty;
        Contrato = string.Empty;

    }
}