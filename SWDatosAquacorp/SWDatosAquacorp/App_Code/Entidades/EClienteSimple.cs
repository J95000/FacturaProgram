using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EClienteSimple
/// </summary>


[DataContract]
public class EClienteSimple : EPersonaSimple
{

    [DataMember]
    public int IdCliente { get; set; }
    [DataMember]
    public string RazonSocial { get; set; }
    [DataMember]
    public string NitCi { get; set; }
    [DataMember]
    public string CorreoElectronico { get; set; }
    [DataMember]
    public byte[] FotoUbicacion { get; set; }
    [DataMember]
    public string NombreDireccion { get; set; }
    [DataMember]
    public decimal Latitud { get; set; }
    [DataMember]
    public decimal Longitud { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public EClienteSimple()
    {
        IdCliente = 0;
        RazonSocial = string.Empty;
        NitCi = string.Empty;
        CorreoElectronico = string.Empty;
        FotoUbicacion = new Byte[0];
        NombreDireccion = string.Empty;
        Latitud = 0;
        Longitud = 0;
    }
}