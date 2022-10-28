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
public class EProductoPrueba
{
    [DataMember(Name = "Anuncio", IsRequired = false)]
    public string Anuncio { get; set; }
    [DataMember(Name = "FotoProducto", IsRequired = false)]
    public string FotoProducto { get; set; }
    public EProductoPrueba()
    {
        Anuncio = string.Empty;
        FotoProducto = string.Empty;
    }
}