using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EArqueoTSimple
/// </summary>
/// 
[DataContract]
public class EArqueoTSimple
{
    [DataMember]
    public int IdArqueo { get; set; }
    [DataMember]
    public int IdPersona { get; set; }
    [DataMember]
    public int IdUsuario { get; set; }

    [DataMember]
    public decimal Ingreso { get; set; }
    [DataMember]
    public decimal OtroIngreso { get; set; }
    [DataMember]
    public decimal TotalIngreso { get; set; }
    [DataMember]
    public decimal TotalEfectivo { get; set; }
    [DataMember]
    public decimal TotalGasto { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }
    public EArqueoTSimple()
    {
        IdArqueo = 0;
        IdPersona = 0;
        IdUsuario = 0;
        Ingreso = 0;
        OtroIngreso = 0;
        TotalIngreso = 0;
        TotalEfectivo = 0;
        TotalGasto = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;

    }
}