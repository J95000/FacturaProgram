using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EReferenciaLaboralSimple
/// </summary>

[DataContract]
public class EReferenciaLaboralSimple
{
    [DataMember]
    public int IdReferenciaLaboral { get; set; }
    [DataMember]
    public int IdEmpleado { get; set; }
    [DataMember]
    public string NombreEmpresa { get; set; }
    [DataMember]
    public string NombresJefe { get; set; }
    [DataMember]
    public string PrimerApellidoJefe { get; set; }
    [DataMember]
    public string SegundoApellidoJefe { get; set; }
    [DataMember]
    public byte TiempoTrabajo { get; set; }
    [DataMember]
    public string FuncionTrabajo { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public EReferenciaLaboralSimple()
    {
        IdReferenciaLaboral = 0;
        IdEmpleado = 0;
        NombreEmpresa = string.Empty;
        NombresJefe = string.Empty;
        PrimerApellidoJefe = string.Empty;
        SegundoApellidoJefe = string.Empty;
        TiempoTrabajo = 0;
        FuncionTrabajo = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}