using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

/// <summary>
/// Descripción breve de CPuntoZona
/// </summary>
public class CPuntoZona
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_PuntoZona(EPuntoZonaSimple ePuntoZonaSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_PuntoZona_I(ePuntoZonaSimple.IdZona, ePuntoZonaSimple.LatitudZona, ePuntoZonaSimple.LongitudZona, ePuntoZonaSimple.FechaRegistro, ePuntoZonaSimple.FechaModificacion, ePuntoZonaSimple.Estado);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
                }
            }
        }
      
    }

    public void Actualizar_PuntoZona(EPuntoZonaSimple ePuntoZonaSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_PuntoZona_A(ePuntoZonaSimple.IdPuntoZona, ePuntoZonaSimple.IdZona, ePuntoZonaSimple.LatitudZona, ePuntoZonaSimple.LongitudZona, ePuntoZonaSimple.FechaRegistro, ePuntoZonaSimple.FechaModificacion, ePuntoZonaSimple.Estado);
                    transaction.Commit();
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
                }
            }
        }
      
    }
    public EPuntoZonaSimple Obtener_PuntoZona_Id_PuntoZona(int IdPuntoZona)
    {
        EPuntoZonaSimple ePuntoZonaSimple = new EPuntoZonaSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_PuntoZona_O_IdPuntoZona(IdPuntoZona);
                foreach (var p in Persona)
                {
                    ePuntoZonaSimple = new EPuntoZonaSimple
                    {
                        IdPuntoZona = p.IdPuntoZona,
                        IdZona = p.IdZona,
                        LatitudZona = p.LatitudZona,
                        LongitudZona = p.LongitudZona,

                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,


                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return ePuntoZonaSimple;
    }



    public List<EPuntoZonaSimple> Obtener_PuntoZona()
    {
        List<EPuntoZonaSimple> lstECPuntoZonaSimple = new List<EPuntoZonaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_PuntoZona_O();
                foreach (var p in Persona)
                {
                    EPuntoZonaSimple ePuntoZonaSimple = new EPuntoZonaSimple
                    {
                        IdPuntoZona = p.IdPuntoZona,
                        IdZona = p.IdZona,
                        LatitudZona = p.LatitudZona,
                        LongitudZona = p.LongitudZona,

                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,



                    };
                    lstECPuntoZonaSimple.Add(ePuntoZonaSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECPuntoZonaSimple;
    }
     public List<EPuntosSimple> Obtener_PuntoZona_Puntos(byte id)
    {
        List<EPuntosSimple> lstECPuntoZonaSimple = new List<EPuntosSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_PuntoZona_O_IdZona_Puntos(id);
                foreach (var p in Persona)
                {

                  
                        EPuntosSimple ePuntoZonaSimple = new EPuntosSimple
                        {
                            IdPuntoZona = p.Value

                        };
                        lstECPuntoZonaSimple.Add(ePuntoZonaSimple);
                    
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECPuntoZonaSimple;
    }
    #endregion

}