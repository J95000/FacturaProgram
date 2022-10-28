using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EDespidoSimple
/// </summary>


[DataContract]
public class EDespidoSimple
{
    [DataMember]
    public int IdDespido { get; set; }
    [DataMember]
    public int IdEmpleado { get; set; }
    [DataMember]
    public DateTime FechaDespido { get; set; }
    [DataMember]
    public string Motivo { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public EDespidoSimple()
    {
        IdDespido = 0;
        IdEmpleado = 0;
        FechaDespido = DateTime.Now;
        Motivo = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}