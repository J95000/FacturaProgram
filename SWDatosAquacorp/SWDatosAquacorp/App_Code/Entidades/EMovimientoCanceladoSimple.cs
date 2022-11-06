using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EDetalleMovimientoSimple
/// </summary>


[DataContract]
public class EMovimientoCanceladoSimple
{
    [DataMember]
    public int IdMovimientoCancelado { get; set; }
    [DataMember]
    public int IdMovimiento { get; set; }
    [DataMember]
    public string Motivo { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }

    public EMovimientoCanceladoSimple()
    {
        IdMovimientoCancelado = 0;
        IdMovimiento = 0;
        Motivo = string.Empty;
        FechaRegistro = DateTime.Now;

    }
}