using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Descripción breve de ERepAsistenciaSimple
/// </summary>

[DataContract]
public class ERepAsistenciaSimple
{
    [DataMember]
    public string NombreCompleto { get; set; }
    [DataMember]
    public DateTime FechaRegistro { get; set; }
    [DataMember]
    public string HoraEntrada { get; set; }
    [DataMember]
    public string HoraSalida { get; set; }
    [DataMember]
    public string Modificado { get; set; }
    [DataMember]
    public int num { get; set; }
    public ERepAsistenciaSimple()
    {
        NombreCompleto = string.Empty;
        FechaRegistro = DateTime.Now;
            HoraEntrada = string.Empty;
        HoraSalida = string.Empty;
        Modificado = string.Empty;
        num = 0;
    }
}