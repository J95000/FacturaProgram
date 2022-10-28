using System;
using System.Runtime.Serialization;


/// <summary>
/// Descripción breve de ECalificacionSimple
/// </summary>
/// 

[DataContract]
public class ECalificacionSimple
{
    [DataMember]
    public int IdCalificacion { get; set; }
    [DataMember]
    public byte Pregunta { get; set; }
    [DataMember]
    public bool Puntaje { get; set; }
    [DataMember]
    public byte IdControlSanitario { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public ECalificacionSimple()
    {
        IdCalificacion = 0;
        Pregunta = 0;
        Puntaje = false;
        IdControlSanitario = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}