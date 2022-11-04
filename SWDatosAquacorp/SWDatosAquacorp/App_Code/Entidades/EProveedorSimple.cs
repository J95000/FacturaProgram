using System;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EProveedorSimple
/// </summary>

[DataContract]
public class EProveedorSimple : EPersonaSimple
{
    [DataMember]
    public int IdProveedor { get; set; }
    [DataMember]
    public string Direccion { get; set; }
    [DataMember]
    public string TelefonoRespaldo { get; set; }



    /// <summary>
    /// 
    /// </summary>
    public EProveedorSimple()
    {
        IdProveedor = 0;
        Direccion = string.Empty;
        TelefonoRespaldo = string.Empty;
   
    }
}