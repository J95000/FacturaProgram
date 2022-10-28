using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EArqueoGastoSimple
/// </summary>
/// 
[DataContract]
public class EArqueoGastoSimple
{
    [DataMember]
    public int Cont { get; set; }
    [DataMember]
    public int IdGasto { get; set; }
    [DataMember]
    public string NombreTipoGasto { get; set; }
    [DataMember]
    public byte IdTipoGasto { get; set; }
    [DataMember]
    public int Cantidad { get; set; }
    [DataMember]
    public decimal Precio { get; set; }
    [DataMember]
    public int IdUsuario { get; set; }
    [DataMember]
    public string NombreUsuario { get; set; }
    [DataMember]
    public int IdAprovador { get; set; }
    [DataMember]
    public string NombreAprobador { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }
    public EArqueoGastoSimple()
    {
        Cont = 0;
        IdGasto = 0;
        IdTipoGasto = 0;
        NombreTipoGasto = string.Empty;
        Cantidad = 0;
        Precio = 0;
        IdUsuario = 0;
        NombreUsuario = string.Empty;
        IdAprovador = 0;
        NombreAprobador = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}