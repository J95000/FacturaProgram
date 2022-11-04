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
    public byte IdCategoriaCliente { get; set; }
    [DataMember]
    public string CorreoElectronico { get; set; }
    [DataMember]
    public decimal Latitud { get; set; }
    [DataMember]
    public decimal Longitud { get; set; }
    [DataMember]
    public byte IdZona { get; set; }
    [DataMember]
    public byte[] FotoUbicacion { get; set; }
    [DataMember]
    public bool Contrato { get; set; }
    [DataMember]
    public string RazonSocial{ get; set; }
    [DataMember]
    public string NitCi{ get; set; }
    /// <summary>
    /// 
    /// </summary>
    public EClienteSimple()
    {
        IdCliente = 0;
        IdCategoriaCliente = 0;
        CorreoElectronico = string.Empty;
        Latitud = 0;
        Longitud = 0;
        IdZona = 0;
        FotoUbicacion = new Byte[0];
        Contrato = false;
        NitCi = "0";
        RazonSocial = string.Empty;
    }
}