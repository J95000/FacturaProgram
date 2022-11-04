using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de EDosificacion
/// </summary>
[DataContract]
public class EDosificacion
{
    [DataMember]
    public int IdDosificacion { get; set; }
    [DataMember]
    public string NumeroAutorizacion { get; set; }
    [DataMember]
    public DateTime FechaLimite { get; set; }
    [DataMember]
    public string LlaveDosificacion { get; set; }
    [DataMember]
    public int NumeroInicialFactura { get; set; }
    [DataMember]
    public int NumeroFinalFactura { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    public EDosificacion()
    {
        IdDosificacion = 0;
        NumeroAutorizacion = string.Empty;
        FechaLimite = DateTime.Now;
        LlaveDosificacion = string.Empty;
        NumeroInicialFactura = 0;
        NumeroFinalFactura = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}