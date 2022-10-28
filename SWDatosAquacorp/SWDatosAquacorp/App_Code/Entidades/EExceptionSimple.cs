using System;

using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EExceptionSimple
/// </summary>

[DataContract]
public class EExceptionSimple
{
    [DataMember]
    public int IdException { get; set; }
    [DataMember]
    public DateTime Fecha { get; set; }
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public string NombreMetodo { get; set; }
    [DataMember]
    public string Mensaje { get; set; }
    [DataMember]
    public string ExceptionMensaje { get; set; }



    public EExceptionSimple()
    {
        IdException = 0;
        Fecha = DateTime.Now;
        IdUsuario = 0;
        NombreMetodo = string.Empty;
        Mensaje = string.Empty;
        ExceptionMensaje = string.Empty;

    }
}