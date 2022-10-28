using System;

using System.Runtime.Serialization;


/// <summary>
/// Descripción breve de EControlSanitarioSimple
/// </summary>

[DataContract]
public class EControlSanitarioSimple
{
    [DataMember]
    public byte IdControlSanitario { get; set; }
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public EControlSanitarioSimple()
    {
        IdControlSanitario = 0;
        IdUsuario = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;

    }
}