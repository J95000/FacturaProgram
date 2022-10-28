using System;

using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EExistenciaSimple
/// </summary>

[DataContract]
public class EExistenciaSimple
{
    [DataMember]
    public int IdExistencia { get; set; }
    [DataMember]
    public string TipoExistencia { get; set; }
    [DataMember]
    public int Cantidad { get; set; }
    [DataMember]
    public int IdProducto { get; set; }
    [DataMember]
    public int IdPersona { get; set; }
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
    public EExistenciaSimple()
    {
        IdExistencia = 0;
        TipoExistencia = string.Empty;
        Cantidad = 0;
        IdProducto = 0;
        IdPersona = 0;
        IdUsuario = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}