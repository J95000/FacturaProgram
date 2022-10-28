using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EPuntoZonaSimple
/// </summary>

[DataContract]
public class EPuntosSimple
{
    [DataMember]
    public int IdPuntoZona { get; set; }

 
    public EPuntosSimple()
    {
        IdPuntoZona = 0;
     
    }
}