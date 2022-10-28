using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

/// <summary>
/// Descripción breve de CZona
/// </summary>
public class CZona
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Zona(EZonaSimple eZonaSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Zona_I(eZonaSimple.NombreZona, eZonaSimple.FechaRegistro, eZonaSimple.FechaModificacion, eZonaSimple.Estado);
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

    public void Actualizar_Zona(EZonaSimple eZonaSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Zona_A(eZonaSimple.IdZona, eZonaSimple.NombreZona, eZonaSimple.FechaRegistro, eZonaSimple.FechaModificacion, eZonaSimple.Estado);
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
    public EZonaSimple Obtener_Zona_Id_Zona(byte IdZona)
    {
        EZonaSimple eZonaSimple = new EZonaSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Zona_O_IdZona(IdZona);
                foreach (var p in Persona)
                {
                    eZonaSimple = new EZonaSimple
                    {
                        IdZona = p.IdZona,
                        NombreZona = p.NombreZona,

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
        return eZonaSimple;
    }



    public List<EZonaSimple> Obtener_Zona()
    {
        List<EZonaSimple> lstECZonaSimple = new List<EZonaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Zona_O();
                foreach (var p in Persona)
                {
                    EZonaSimple eZonaSimple = new EZonaSimple
                    {
                        IdZona = p.IdZona,
                        NombreZona = p.NombreZona,

                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,



                    };
                    lstECZonaSimple.Add(eZonaSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECZonaSimple;
    }



    #endregion

}