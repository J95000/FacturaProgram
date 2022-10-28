using System;

using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EPrecioSugeridoSimple
/// </summary>

[DataContract]
public class EPrecioSugeridoSimple
{
    [DataMember]
    public int IdPrecioSugerido { get; set; }
    [DataMember]
    public int IdProducto { get; set; }
    [DataMember]
    public decimal Precio { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    public EPrecioSugeridoSimple()
    {
        IdPrecioSugerido = 0;
        IdProducto = 0;
        Precio = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}