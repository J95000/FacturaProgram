using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EClienteSimple
/// </summary>


[DataContract]
public class EClienteCortaSimple
{
    [DataMember]
    public int IdCliente { get; set; }
    [DataMember]
    public string RazonSocial { get; set; }
    [DataMember]
    public string NitCi { get; set; }
    [DataMember]
    public byte[] FotoUbicacion { get; set; }

    public EClienteCortaSimple()
    {
        IdCliente = 0;
        RazonSocial = string.Empty;
        NitCi = string.Empty;
        FotoUbicacion = new Byte[0];
    
    }
}