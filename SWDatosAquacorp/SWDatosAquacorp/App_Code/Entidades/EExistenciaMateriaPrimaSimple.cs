using System;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EExistenciaMateriaPrimaSimple
/// </summary>

[DataContract]
public class EExistenciaMateriaPrimaSimple
{
    [DataMember]
    public int IdExistenciaMateriaPrima { get; set; }
    [DataMember]
    public int IdMateriaPrima { get; set; }
    [DataMember]
    public decimal CantidadActual { get; set; }
    [DataMember]
    public decimal CantidadCambio { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    public EExistenciaMateriaPrimaSimple()
    {
        IdExistenciaMateriaPrima = 0;
        IdMateriaPrima = 0;
        CantidadActual = 0;
        CantidadCambio = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}

