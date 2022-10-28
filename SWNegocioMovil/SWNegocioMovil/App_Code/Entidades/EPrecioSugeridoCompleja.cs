using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EPrecioSugeridoCompleja
/// </summary>

[DataContract]
public class EPrecioSugeridoCompleja
{
    [DataMember]
    public int Cont { get; set; }
    [DataMember]
    public int IdPrecioSugerido { get; set; }
    [DataMember]
    public int IdProducto { get; set; }
    [DataMember]
    public string NombreProducto { get; set; }

    [DataMember]
    public decimal Precio { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }
    public EPrecioSugeridoCompleja()
    {
        Cont = 0;
        IdPrecioSugerido = 0;
        IdProducto = 0;
        NombreProducto = string.Empty;
        Precio = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}