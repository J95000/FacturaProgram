using System;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EMateriaPrimaSimple
/// </summary>

[DataContract]
public class EMateriaPrimaSimple
{
    [DataMember]
    public int IdMateriaPrima { get; set; }
    [DataMember]
    public string NombreMateriaPrima { get; set; }
    [DataMember]
    public string DescripcionMateriaPrima { get; set; }
    [DataMember]
    public string UnidadMedida { get; set; }
    [DataMember]
    public int CantidadMinima { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    public EMateriaPrimaSimple()
    {
        IdMateriaPrima = 0;
        NombreMateriaPrima = string.Empty;
        DescripcionMateriaPrima = string.Empty;
        UnidadMedida = string.Empty;
        CantidadMinima = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}

