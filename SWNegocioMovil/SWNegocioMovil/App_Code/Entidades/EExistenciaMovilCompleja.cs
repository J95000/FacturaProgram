using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de EExistenciaMovilCompleja
/// </summary>
/// 
[DataContract]
public class EExistenciaMovilCompleja
{

    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Text { get; set; }
    [DataMember]
    public string Description { get; set; }

    public EExistenciaMovilCompleja()
    {
        Id = 0;
        Text = "";
        Description = "";
    }
}