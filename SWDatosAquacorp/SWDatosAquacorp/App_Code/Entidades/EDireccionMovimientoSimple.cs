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
public class EDireccionMovimientoSimple
{
    [DataMember]
    public int IdDireccionMovimiento { get; set; }
    [DataMember]
    public int IdDireccion { get; set; }
    [DataMember]
    public int IdMovimiento { get; set; }
    public EDireccionMovimientoSimple()
    {
        IdDireccionMovimiento = 0;
            IdDireccion = 0;
        IdMovimiento = 0;
    }
}