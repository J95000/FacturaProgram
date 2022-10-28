using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EArqueoExistenciaSimple
/// </summary>
/// 
[DataContract]
public class EArqueoExistenciaSimple
{
    [DataMember]
    public int Cont { get; set; }

    [DataMember]
    public int IdExistencia { get; set; }
    [DataMember]
    public string TipoExistencia { get; set; }
    [DataMember]
    public int Cantidad { get; set; }
    [DataMember]
    public int IdProducto { get; set; }
    [DataMember]
    public string NombreProducto { get; set; }
    [DataMember]
    public int IdPersona { get; set; }
    [DataMember]
    public string NombreCompletoPersonaRegistra { get; set; }

    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public string NombreCompletoUsuarioValida { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }
    public EArqueoExistenciaSimple()
    {
        Cont = 0;
        IdExistencia = 0;
        TipoExistencia = string.Empty;
        Cantidad = 0;
        IdProducto = 0;
        NombreProducto = string.Empty;
        IdPersona = 0;
        NombreCompletoPersonaRegistra = string.Empty;
        IdUsuario = 0;
        NombreCompletoUsuarioValida = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}