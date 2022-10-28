using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de ERepExistenciaSimple
/// </summary>
/// 
[DataContract]
public class ERepExistenciaSimple
{
    [DataMember]
    public string Producto { get; set; }
    [DataMember]
    public string TipoExistencia { get; set; }
    [DataMember]
    public int Cantidad { get; set; }
    [DataMember]
    public string NombrePersonal { get; set; }
    [DataMember]
    public DateTime Fecha { get; set; }
    [DataMember]
    public DateTime FechaInicio { get; set; }
    [DataMember]
    public DateTime FechaFinal { get; set; }
    [DataMember]
    public int Tipo { get; set; }

    public ERepExistenciaSimple()
    {
        Producto = string.Empty;
        TipoExistencia = string.Empty;
        Cantidad = 0;
        NombrePersonal = string.Empty;
        Fecha = DateTime.Now;
        FechaInicio = DateTime.Now;
        FechaFinal = DateTime.Now;
        Tipo = 0;


    }
}