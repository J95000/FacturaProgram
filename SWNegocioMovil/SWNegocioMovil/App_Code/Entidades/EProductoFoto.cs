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
public class EProductoFoto
{
    [DataMember]
    public int IdProducto { get; set; }
    [DataMember]
    public byte[] FotoProducto { get; set; }
    public EProductoFoto()
    {
        IdProducto = 0;
        FotoProducto = new Byte[0];
    }
}