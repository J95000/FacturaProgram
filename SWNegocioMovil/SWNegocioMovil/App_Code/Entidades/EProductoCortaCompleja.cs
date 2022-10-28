using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Drawing;

/// <summary>
/// Descripción breve de EProductoCompleja
/// </summary>

[DataContract]
public class EProductoCortaCompleja
{

    [DataMember]
    public int IdProducto { get; set; }
    [DataMember]
    public string NombreProducto { get; set; }
    [DataMember]
    public string FotoProducto { get; set; }
    [DataMember]
    public string Descripcion { get; set; }
    [DataMember]
    public string PrecioSugerido { get; set; }


    public EProductoCortaCompleja()
    {

        IdProducto = 0;
        NombreProducto = string.Empty;
        FotoProducto = string.Empty;
        Descripcion = string.Empty;
        PrecioSugerido = string.Empty;

    }
}