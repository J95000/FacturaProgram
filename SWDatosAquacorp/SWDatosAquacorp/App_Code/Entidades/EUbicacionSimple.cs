using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EUbicacionSimple
/// </summary>
/// 
[DataContract]
public class EUbicacionSimple
{
    [DataMember]
    public string NombreCelu { get; set; }
    [DataMember]
    public decimal Latitud { get; set; }
    [DataMember]
    public decimal Longitud { get; set; }
    [DataMember]
    public DateTime Fecha { get; set; }

    public EUbicacionSimple()
    {
        NombreCelu = string.Empty;
        Latitud = 0;
        Longitud = 0;
        Fecha = DateTime.Now;
    }
}