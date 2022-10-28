using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EClienteCompleja
/// </summary>
/// 
[DataContract]
public class EClienteCompleja : EPersonaCompleja
{
    [DataMember]
    public int Cont { get; set; }
    [DataMember]
    public int IdCliente { get; set; }
    [DataMember]
    public byte IdCategoriaCliente { get; set; }
    [DataMember]
    public string NombreCategoriaCliente { get; set; }
    [DataMember]
    public string CorreoElectronico { get; set; }
    [DataMember]
    public decimal Latitud { get; set; }
    [DataMember]
    public decimal Longitud { get; set; }
    [DataMember]
    public byte IdZona { get; set; }
    [DataMember]
    public string NombreZona { get; set; }
    [DataMember]
    public byte[] FotoUbicacion { get; set; }
    [DataMember]
    public bool Contrato { get; set; }
    public EClienteCompleja()
    {
        Cont = 0;
        IdCliente = 0;
        IdCategoriaCliente = 0;
        NombreCategoriaCliente = string.Empty;
        CorreoElectronico = string.Empty;
        Latitud = 0;
        Longitud = 0;
        IdZona = 0;
        NombreZona = string.Empty;
        FotoUbicacion = new Byte[0];
        Contrato = false;
    }
}
