using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de ERepDeudasSimple
/// </summary>

[DataContract]
public class ERepDeudasSimple
{
    [DataMember]
    public int IdMovimiento { get; set; }
    [DataMember]
    public string NombrePersonal { get; set; }
    [DataMember]
    public string Codigo { get; set; }
    [DataMember]
    public DateTime Fecha { get; set; }
    [DataMember]
    public decimal Total { get; set; }
    [DataMember]
    public decimal Pago { get; set; }
    [DataMember]
    public decimal Saldo { get; set; }
    [DataMember]
    public int Tipo { get; set; }


    public ERepDeudasSimple()
    {
        IdMovimiento = 0;
        NombrePersonal = string.Empty;
        Codigo = string.Empty;
        Fecha = DateTime.Now;
        Total = 0;
        Pago = 0;
        Saldo = 0;
        Tipo = 0;
    }
}