using System;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EArticuloSimple
/// </summary>

[DataContract]
public class EArticuloSimple
{
    [DataMember]
    public int IdArticulo { get; set; }
    [DataMember]
    public byte IdCategoria { get; set; }
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public string Titulo { get; set; }
    [DataMember]
    public string Descripcion { get; set; }
    [DataMember]
    public string Contenido { get; set; }
    [DataMember]
    public string Imagen { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    public EArticuloSimple()
    {
        IdArticulo = 0;
        IdCategoria = 0;
        IdUsuario = 0;
        Titulo = string.Empty;
        Descripcion = string.Empty;
        Contenido = string.Empty;
        Imagen = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}