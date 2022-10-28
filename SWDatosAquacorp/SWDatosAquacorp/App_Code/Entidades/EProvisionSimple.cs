using System;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EProvisionSimple
/// </summary>

[DataContract]
public class EProvisionSimple
{
    [DataMember]
    public int IdProvision { get; set; }
    [DataMember]
    public int IdProveedor { get; set; }
    [DataMember]
    public int IdMateriaPrima { get; set; }
    [DataMember]
    public int CantidadProvision { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    public EProvisionSimple()
    {
        IdProvision = 0;
        IdProveedor = 0;
        IdMateriaPrima = 0;
        CantidadProvision = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}


