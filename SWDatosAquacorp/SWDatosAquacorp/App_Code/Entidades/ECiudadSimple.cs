using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de ECiudadSimple
/// </summary>

[DataContract]
public class ECiudadSimple
{
    [DataMember]
    public byte IdCiudad { get; set; }
    [DataMember]
    public string NombreCiudad { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public ECiudadSimple()
    {
        IdCiudad = 0;
        NombreCiudad = string.Empty;
    }
}