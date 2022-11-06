using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EArqueoExistenciaSimple
/// </summary>
/// 
[DataContract]
public class EDireccionSimple
{
    [DataMember]
    public int IdDireccion { get; set; }
    [DataMember]
    public int IdCliente { get; set; }
    [DataMember]
    public string NombreDireccion { get; set; }
    [DataMember]
    public decimal Latitud { get; set; }
    [DataMember]
    public decimal Longitud { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public DateTime FechaModificacion { get; set; }
    [DataMember]
    public string Estado { get; set; }


    public EDireccionSimple()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}