using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Drawing;
using Newtonsoft.Json;

/// <summary>
/// Descripción breve de EProductoCompleja
/// </summary>

[DataContract]
public class EProductoCompleja 
{
    [DataMember]
    public int Cont { get; set; }
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
    public string PrecioSugerido { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }




    //[JsonProperty("Cont")]
    //public int Cont { get; set; }
    //[JsonProperty("IdProducto")]
    //public int IdProducto { get; set; }
    //[JsonProperty("NombreProducto")]
    //public string NombreProducto { get; set; }
    //[JsonProperty("FotoProducto")]
    //public byte[] FotoProducto { get; set; }
    //[JsonProperty("Descripcion")]
    //public string Descripcion { get; set; }
    //[JsonProperty("Consumible")]
    //public string Consumible { get; set; }
    //[JsonProperty("PrecioSugerido")]
    //public string PrecioSugerido { get; set; }
    //[JsonProperty("FechaRegistro")]
    //public DateTime FechaRegistro { get; set; }
    //[JsonProperty("FechaModificacion")]
    //public DateTime FechaModificacion { get; set; }
    //[JsonProperty("Estado")]
    //public string Estado { get; set; }


    public EProductoCompleja()
    {
        Cont = 0;
        IdProducto = 0;
        NombreProducto = string.Empty;
        FotoProducto = new Byte[0];
        Descripcion = string.Empty;
        PrecioSugerido = string.Empty;
        Consumible = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}