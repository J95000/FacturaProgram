using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de EEmpleadoCompleja
/// </summary>
[DataContract]
public class EEmpleadoCompleja : EPersonaCompleja
{
    [DataMember]
    public int Cont { get; set; }
    [DataMember]
    public int IdEmpleado { get; set; }
    [DataMember]
    public byte IdCargo { get; set; }
    [DataMember]
    public string NombreCargo { get; set; }
    [DataMember]
    public DateTime FechaNacimiento { get; set; }
    [DataMember]
    public string Ci { get; set; }
    [DataMember]
    public byte IdCiudad { get; set; }
    [DataMember]
    public string NombreCiudadAbreviado { get; set; }
    [DataMember]
    public byte LugarNacimiento { get; set; }
    [DataMember]
    public string NombreCiudad { get; set; }
    [DataMember]
    public string TelefonoRespaldo { get; set; }
    [DataMember]
    public string EstadoCivil { get; set; }
    [DataMember]
    public string NombresPadre { get; set; }
    [DataMember]
    public string PrimerApellidoPadre { get; set; }
    [DataMember]
    public string SegundoApellidoPadre { get; set; }
    [DataMember]
    public string OcupacionPadre { get; set; }
    [DataMember]
    public string NombresMadre { get; set; }
    [DataMember]
    public string PrimerApellidoMadre { get; set; }
    [DataMember]
    public string SegundoApellidoMadre { get; set; }
    [DataMember]
    public string OcupacionMadre { get; set; }
    [DataMember]
    public string UltimoCurso { get; set; }
    [DataMember]
    public string ColegioUnidadEducativa { get; set; }
    [DataMember]
    public DateTime FechaInicioTrabajo { get; set; }
    [DataMember]
    public string Garantia { get; set; }
    [DataMember]
    public byte[] Fotografia { get; set; }

    public EEmpleadoCompleja()
    {
        Cont = 0;
        IdEmpleado = 0;
        IdCargo = 0;
        NombreCargo = string.Empty;
        FechaNacimiento = DateTime.Now;
        Ci = string.Empty;
        IdCiudad = 0;
        NombreCiudadAbreviado = string.Empty;
        LugarNacimiento = 0;
        NombreCiudad = string.Empty;
        TelefonoRespaldo = string.Empty;
        EstadoCivil = string.Empty;
        NombresPadre = string.Empty;
        PrimerApellidoPadre = string.Empty;
        SegundoApellidoPadre = string.Empty;
        OcupacionPadre = string.Empty;
        NombresMadre = string.Empty;
        PrimerApellidoMadre = string.Empty;
        SegundoApellidoMadre = string.Empty;
        OcupacionMadre = string.Empty;
        UltimoCurso = string.Empty;
        ColegioUnidadEducativa = string.Empty;
        FechaInicioTrabajo = DateTime.Now;
        Garantia = string.Empty;
        Fotografia = new Byte[0];

    }
}