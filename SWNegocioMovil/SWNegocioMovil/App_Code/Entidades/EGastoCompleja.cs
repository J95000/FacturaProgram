using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EGastoCompleja
/// </summary>

[DataContract]
public class EGastoCompleja
{
    [DataMember]
    public int Cont { get; set; }
    [DataMember]
    public int IdGasto { get; set; }
    [DataMember]
    public byte IdTipoGasto { get; set; }
    [DataMember]
    public string NombreTipoGasto { get; set; }
    [DataMember]
    public int Cantidad { get; set; }
    [DataMember]
    public decimal Precio { get; set; }
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public int IdAprovador { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    public EGastoCompleja()
    {
        Cont = 0;
        IdGasto = 0;
        IdTipoGasto = 0;
        NombreTipoGasto = string.Empty;
        Cantidad = 0;
        Precio = 0;
        IdUsuario = 0;
        IdAprovador = 0;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}





