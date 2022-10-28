using System;

using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de ESaldoSimple
/// </summary>

[DataContract]
public class ESaldoSimple
{

    [DataMember]
    public int IdSaldo { get; set; }
    [DataMember]
    public int IdEmpleado { get; set; }
    [DataMember]
    public decimal Cantidad { get; set; }
    [DataMember]
    public string Tipo { get; set; }
    [DataMember]
    public string Descripcion { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ESaldoSimple()
    {
        IdSaldo = 0;
        IdEmpleado = 0;
        Cantidad = 0;
        Tipo = string.Empty;
        Descripcion = string.Empty;
        FechaRegistro = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = string.Empty;
    }
}