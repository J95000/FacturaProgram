using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EArqueoPagoSimple
/// </summary>
/// 
[DataContract]
public class EArqueoPagoSimple
{
    [DataMember]
    public int IdPago { get; set; }
    [DataMember]
    public string Codigo { get; set; }
    [DataMember]
    public decimal CantidadPago { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    public EArqueoPagoSimple()
    {
        IdPago = 0;
        Codigo = string.Empty;
        CantidadPago = 0;
        FechaRegistro = DateTime.Now;
    }
}