using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EExceptionCompleja
/// </summary>
/// 
[DataContract]
public class EExceptionCompleja
{
    [DataMember]
    public int Cont { get; set; }
    [DataMember]
    public int IdException { get; set; }
    [DataMember]
    public DateTime Fecha { get; set; }
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public string NombreCompletoUsuario { get; set; }
    [DataMember]
    public string NombreMetodo { get; set; }
    [DataMember]
    public string Mensaje { get; set; }
    [DataMember]
    public string ExceptionMensaje { get; set; }
    public EExceptionCompleja()
    {
        Cont = 0;
        IdException = 0;
        Fecha = DateTime.Now;
        IdUsuario = 0;
        NombreCompletoUsuario = string.Empty;
        NombreMetodo = string.Empty;
        Mensaje = string.Empty;
        ExceptionMensaje = string.Empty;

    }
}