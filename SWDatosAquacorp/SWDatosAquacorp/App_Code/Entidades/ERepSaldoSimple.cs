using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de ERepSaldoSimple
/// </summary>

[DataContract]
public class ERepSaldoSimple
{
 
    [DataMember]
    public string NombrePersonal { get; set; }
    [DataMember]
    public decimal Cantidad { get; set; }
    [DataMember]
    public string TipoMovimiento { get; set; }
    [DataMember]
    public DateTime Fecha { get; set; }
    [DataMember]
    public string Descripcion { get; set; }
    [DataMember]
    public DateTime FechaInicio { get; set; }
    [DataMember]
    public DateTime FechaFinal { get; set; }
    [DataMember]
    public int Tipo { get; set; }

    public ERepSaldoSimple()
    {
        NombrePersonal = string.Empty;
        Cantidad = 0;
        TipoMovimiento = string.Empty;
        Fecha = DateTime.Now;
        Descripcion = string.Empty;
        FechaInicio = DateTime.Now;
        FechaFinal = DateTime.Now;
        Tipo = 0;

    }
}