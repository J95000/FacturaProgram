using System;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EProduccionSimple
/// </summary>

[DataContract]
public class EProduccionSimple
{
    [DataMember]
    public int IdProduccion { get; set; }
    [DataMember]
    public int IdMateriaPrima { get; set; }
    [DataMember]
    public int IdProducto { get; set; }
    [DataMember]
    public decimal CantidadProduccion { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    public EProduccionSimple()
    {
        IdProduccion = 0;
        IdMateriaPrima = 0;
        IdProducto = 0;
        CantidadProduccion = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}

