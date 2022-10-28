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
public class EListaProductos
{
    [DataMember(Name = "ProductosZonas", IsRequired = false)] public List<EZonaCompleja> ProductosZonas { get; set; }
  
}