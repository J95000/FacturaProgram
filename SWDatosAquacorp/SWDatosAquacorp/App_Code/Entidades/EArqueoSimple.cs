using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EArqueoSimple
/// </summary>
/// 
[DataContract]
public class EArqueoSimple
{
    [DataMember]
    public int IdProducto { get; set; }

    [DataMember]
    public int Cantidad { get; set; }
    public EArqueoSimple()
    {
        IdProducto = 0;
        Cantidad = 0;
    }
}