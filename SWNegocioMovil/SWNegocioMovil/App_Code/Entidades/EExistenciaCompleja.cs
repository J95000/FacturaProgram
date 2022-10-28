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

public class EExistenciaCompleja
{
    [DataMember(Name = "Cantidad", IsRequired = false)]
    public int Cantidad { get; set; }
    [DataMember(Name = "Cont", IsRequired = false)]
    public int Cont { get; set; }
    [DataMember(Name = "Estado", IsRequired = false)]
    public string Estado { get; set; }
    [DataMember(Name = "FechaModificacion", IsRequired = false)]
    public DateTime FechaModificacion { get; set; }
    [DataMember(Name = "FechaRegistro", IsRequired = false)]
    public DateTime FechaRegistro { get; set; }
    [DataMember(Name = "IdExistencia", IsRequired = false)]
    public int IdExistencia { get; set; }
    [DataMember(Name = "IdPersona", IsRequired = false)]
    public int IdPersona { get; set; }
    [DataMember(Name = "IdProducto", IsRequired = false)]
    public int IdProducto { get; set; }
    [DataMember(Name = "IdUsuario", IsRequired = false)]
    public int IdUsuario { get; set; }
    [DataMember(Name = "NombreCompletoPersonaRegistra", IsRequired = false)]
    public string NombreCompletoPersonaRegistra { get; set; }
    [DataMember(Name = "NombreCompletoUsuarioValida", IsRequired = false)]
    public string NombreCompletoUsuarioValida { get; set; }
    [DataMember(Name = "NombreProducto", IsRequired = false)]
    public string NombreProducto { get; set; }
    [DataMember(Name = "TipoExistencia", IsRequired = false)]
    public string TipoExistencia { get; set; }


    public EExistenciaCompleja()
    {
        Cantidad = 0;
        Cont = 0;
        Estado = string.Empty;
        FechaModificacion = DateTime.Now;
        FechaRegistro = DateTime.Now;
        IdExistencia = 0;
        IdPersona = 0;
        IdProducto = 0;
        IdUsuario = 0;
        NombreCompletoPersonaRegistra = string.Empty;
        NombreCompletoUsuarioValida = string.Empty;
        NombreProducto = string.Empty;
        TipoExistencia = string.Empty;


    }
}