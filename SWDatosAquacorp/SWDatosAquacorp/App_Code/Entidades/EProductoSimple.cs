using System;

using System.Runtime.Serialization;


/// <summary>
/// Descripción breve de EProductoSimple
/// </summary>

[DataContract]
public class EProductoSimple
{
    [DataMember]
    public int IdProducto { get; set; }
    [DataMember]
    public string NombreProducto { get; set; }
    [DataMember]
    public byte[] FotoProducto { get; set; }
    [DataMember]
    public string Descripcion { get; set; }
    [DataMember]
    public string Consumible { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public EProductoSimple()
    {
        IdProducto = 0;
        NombreProducto = string.Empty;
        FotoProducto = new Byte[0];
        Descripcion = string.Empty;
        Consumible = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}