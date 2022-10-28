using System;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de ECategoriaSimple
/// </summary>

[DataContract]
public class ECategoriaSimple
{
    [DataMember]
    public byte IdCategoria { get; set; }
    [DataMember]
    public string NombreCategoria { get; set; }
    [DataMember]
    public string Imagen { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }
    public ECategoriaSimple()
    {
        IdCategoria = 0;
        NombreCategoria = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}