using System;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EMaterialSimple
/// </summary>

[DataContract]
public class EMaterialSimple
{
    [DataMember]
    public int IdMaterial { get; set; }
    [DataMember]
    public int IdProveedor { get; set; }
    [DataMember]
    public int IdMateriaPrima { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    public EMaterialSimple()
    {
        IdMaterial = 0;
        IdProveedor = 0;
        IdMateriaPrima = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}

