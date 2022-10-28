using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de ECategoriaClienteSimple
/// </summary>

[DataContract]
public class ECategoriaClienteSimple
{
    [DataMember]
    public byte IdCategoriaCliente { get; set; }
    [DataMember]
    public string NombreCategoriaCliente { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public ECategoriaClienteSimple()
    {
        IdCategoriaCliente = 0;
        NombreCategoriaCliente = string.Empty;

        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}