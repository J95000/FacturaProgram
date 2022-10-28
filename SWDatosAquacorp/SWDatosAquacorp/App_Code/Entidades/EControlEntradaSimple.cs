using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EControlEntradaSimple
/// </summary>

[DataContract]
public class EControlEntradaSimple
{
    [DataMember]
    public int IdControlEntrada { get; set; }
    [DataMember]
    public int IdPersona { get; set; }
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public DateTime FechaHoraEntrada { get; set; }
    [DataMember]
    public DateTime FechaHoraSalida { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public EControlEntradaSimple()
    {

        IdControlEntrada = 0;
        IdPersona = 0;
        IdUsuario = 0;
        FechaHoraEntrada = DateTime.Now;
        FechaHoraSalida = DateTime.Now;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;

    }
}