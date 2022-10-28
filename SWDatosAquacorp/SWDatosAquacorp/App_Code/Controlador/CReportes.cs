using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CReportes
/// </summary>
public class CReportes
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
 


   public List<ERepAsistenciaSimple> Reporte_Asistencias(int idPersona, DateTime fechaInicio, DateTime fechaFinal, int tipo)
        {
            List<ERepAsistenciaSimple> lstERepAsistenciaSimple = new List<ERepAsistenciaSimple>();
            try
            {
                using (aquacorpbddEntities db = new aquacorpbddEntities())
                {
                    var Persona = db.Proc_Reporte_Asistencia(  idPersona,  fechaInicio,  fechaFinal,  tipo);
                    foreach (var p in Persona)
                    {
                        ERepAsistenciaSimple eCargoSimple = new ERepAsistenciaSimple
                        {
                            NombreCompleto = p.NombreCompleto,
                        FechaRegistro = (DateTime)p.FechaRegistro,
                        HoraEntrada = p.HoraEntrada,
                        HoraSalida =p.HoraSalida,
                        Modificado =p.Modificado,
                        num = p.num


                    };
                        lstERepAsistenciaSimple.Add(eCargoSimple);
                    }
                }
            }
            catch (Exception ex)
            {
                cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            }
            return lstERepAsistenciaSimple;
        }

    public List<ERepClientesZonaSimple> Reporte_Cliente_Zona(byte idZona,   int tipo)
    {
        List<ERepClientesZonaSimple> lstERepAsistenciaSimple = new List<ERepClientesZonaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Rep_Cliente_Zona(idZona, tipo);
                foreach (var p in Persona)
                {
                    ERepClientesZonaSimple eCargoSimple = new ERepClientesZonaSimple
                    {
                        NombreCompleto = p.NombreCompleto,
        
                    Telefono = p.Telefono,
                    Direccion =p.Direccion,
                    CorreoElectronico = p.CorreoElectronico,
                    Mapa = p.Mapa,
                    NombreZona = p.NombreZona,
                    Contrato = p.Contrato


                };
                    lstERepAsistenciaSimple.Add(eCargoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstERepAsistenciaSimple;
    }

    public List<ERepClientesCategoriaSimple> Reporte_Cliente_Categoria(byte idCategoria, int tipo)
    {
        List<ERepClientesCategoriaSimple> lstERepAsistenciaSimple = new List<ERepClientesCategoriaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Reporte_Cliente_Categoria(idCategoria, tipo);
                foreach (var p in Persona)
                {
                    ERepClientesCategoriaSimple eCargoSimple = new ERepClientesCategoriaSimple
                    {
                        NombreCategoriaCliente = p.NombreCategoriaCliente,
                        NombreCompleto = p.NombreCompleto,
                        Telefono = p.Telefono,
                        Direccion = p.Direccion,
                        Contrato = p.Contrato,
                         num = p.num

                };
                    lstERepAsistenciaSimple.Add(eCargoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstERepAsistenciaSimple;
    }



    #endregion

}