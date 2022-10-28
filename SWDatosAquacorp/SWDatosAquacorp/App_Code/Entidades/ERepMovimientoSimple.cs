using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de ERepMovimientoSimple
/// </summary>

[DataContract]
public class ERepMovimientoSimple
{
    [DataMember]
    public string Codigo { get; set; }
    [DataMember]
    public string Cliente { get; set; }
    [DataMember]
    public string Personal { get; set; }
    [DataMember]
    public DateTime Fecha { get; set; }
    [DataMember]
    public DateTime FechaInicio { get; set; }
    [DataMember]
    public DateTime FechaFinal { get; set; }
    [DataMember]
    public int Tipo { get; set; }
    public ERepMovimientoSimple()
    {
        Codigo = string.Empty;
        Cliente = string.Empty;
        Personal = string.Empty;
        Fecha = DateTime.Now;
        FechaInicio = DateTime.Now;
        FechaFinal = DateTime.Now;
        Tipo = 0;

    }
}