using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de ERepControlSanitarioSimple
/// </summary>
/// 
[DataContract]
public class ERepControlSanitarioSimple
{
    [DataMember]
    public byte Pregunta { get; set; }
    [DataMember]
    public bool? Puntaje { get; set; }
    public ERepControlSanitarioSimple()
    {
        Pregunta = 0;
        Puntaje =null;
  
    }
}