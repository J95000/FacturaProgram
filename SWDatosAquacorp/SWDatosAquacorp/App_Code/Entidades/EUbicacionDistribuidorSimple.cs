using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EUbicacionDistribuidorSimple
/// </summary>
/// 
[DataContract]
public class EUbicacionDistribuidorSimple
{
    [DataMember]
    public int IdUbicacion { get; set; }
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public string NombreCompleto { get; set; }
    [DataMember]
    public string NombreDispositivo { get; set; }
    [DataMember]
    public decimal Latitud { get; set; }
    [DataMember]
    public decimal Longitud { get; set; }
    [DataMember]
    public DateTime Fecha { get; set; }
    public EUbicacionDistribuidorSimple()
    {
        IdUbicacion = 0;
        IdUsuario = 0;
        NombreCompleto = string.Empty;
        NombreDispositivo = string.Empty;
        Latitud = 0;
        Longitud = 0;
        Fecha = DateTime.Now;
    }
}