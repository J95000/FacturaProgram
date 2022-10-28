using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EExistenciaCompleja
/// </summary>
/// 
[DataContract]
public class EExistenciaCortaCompleja
{
    [DataMember]
    public int Cantidad { get; set; }
    [DataMember]
    public int Cont { get; set; }    
    [DataMember]
    public int IdExistencia { get; set; }
    [DataMember]
    public int IdProducto { get; set; }
    [DataMember]
    public string NombreProducto { get; set; }
    [DataMember]
    public string TipoExistencia { get; set; }

    public EExistenciaCortaCompleja()
    {
        Cantidad = 0;
        Cont = 0;
        IdExistencia = 0;
        IdProducto = 0;
        NombreProducto = string.Empty;
        TipoExistencia = string.Empty;

    }
}