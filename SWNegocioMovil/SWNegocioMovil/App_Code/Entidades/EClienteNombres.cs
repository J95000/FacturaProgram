using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EClienteCompleja
/// </summary>
/// 
[DataContract]
public class EClienteNombres : EPersonaCompleja
{
 
    [DataMember]
    public int IdCliente { get; set; }
 
 
    public EClienteNombres()
    {
        
        IdCliente = 0;
       
    }
}