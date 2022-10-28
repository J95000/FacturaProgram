using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de ERepClientesCategoriaSimple
/// </summary>

[DataContract]
public class ERepClientesCategoriaSimple
{
    [DataMember]
    public string NombreCategoriaCliente { get; set; }
    [DataMember]
    public string NombreCompleto { get; set; }
    [DataMember]
    public string Telefono { get; set; }
    [DataMember]
    public string Direccion { get; set; }
    [DataMember]
    public string Contrato { get; set; }
    [DataMember]
    public int num { get; set; }
    public ERepClientesCategoriaSimple()
    {
        NombreCategoriaCliente = string.Empty;
        NombreCompleto = string.Empty;
        Telefono = string.Empty;
        Direccion = string.Empty;
        Contrato = string.Empty;
        num = 0;
    }
}