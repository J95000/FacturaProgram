using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CArqueo
/// </summary>
public class CArqueo
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Arqueo(EArqueoTSimple eArqueoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Arqueo_I(eArqueoSimple.IdPersona, eArqueoSimple.IdUsuario, eArqueoSimple.Ingreso, eArqueoSimple.OtroIngreso, eArqueoSimple.TotalIngreso, eArqueoSimple.TotalEfectivo, eArqueoSimple.TotalGasto, eArqueoSimple.FechaRegistro, eArqueoSimple.FechaModificacion, eArqueoSimple.Estado);
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
    public void Actualizar_Arqueo(EArqueoTSimple eArqueoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Arqueo_A(eArqueoSimple.IdArqueo, eArqueoSimple.IdPersona, eArqueoSimple.IdUsuario, eArqueoSimple.Ingreso, eArqueoSimple.OtroIngreso, eArqueoSimple.TotalIngreso, eArqueoSimple.TotalEfectivo, eArqueoSimple.TotalGasto, eArqueoSimple.FechaRegistro, eArqueoSimple.FechaModificacion, eArqueoSimple.Estado);
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
    public EArqueoTSimple Obtener_Arqueo_Id_Arqueo(int IdArqueo)
    {
        EArqueoTSimple eArqueoSimple = new EArqueoTSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Arqueo_O_IdArqueo(IdArqueo);
                foreach (var p in Persona)
                {
                    eArqueoSimple = new EArqueoTSimple
                    { 
                        IdArqueo =p.IdArqueo,
                        IdPersona = p.IdPersona,
                        IdUsuario = p.IdUsuario,
                        Ingreso = p.Ingreso,
                        OtroIngreso = p.OtroIngreso,
                        TotalIngreso = p.TotalIngreso,
                        TotalEfectivo =p.TotalEfectivo,
                        TotalGasto =p.TotalGasto,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado


                    };
                }
            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eArqueoSimple;
    }



    public List<EArqueoTSimple> Obtener_Arqueo()
    {
        List<EArqueoTSimple> lstECArqueoSimple = new List<EArqueoTSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Arqueo_O();
                foreach (var p in Persona)
                {
                    EArqueoTSimple eArqueoSimple = new EArqueoTSimple
                    {

                        IdArqueo = p.IdArqueo,
                        IdPersona = p.IdPersona,
                        IdUsuario = p.IdUsuario,
                        Ingreso = p.Ingreso,
                        OtroIngreso = p.OtroIngreso,
                        TotalIngreso = p.TotalIngreso,
                        TotalEfectivo = p.TotalEfectivo,
                        TotalGasto = p.TotalGasto,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado



                    };
                    lstECArqueoSimple.Add(eArqueoSimple);
                }
            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECArqueoSimple;
    }

    public List<EArqueoTSimple> Obtener_Arqueo_Fecha(DateTime fecha)
    {
        List<EArqueoTSimple> lstECArqueoSimple = new List<EArqueoTSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Arqueo_O_Fecha(fecha);
                foreach (var p in Persona)
                {
                    EArqueoTSimple eArqueoSimple = new EArqueoTSimple
                    {

                        IdArqueo = p.IdArqueo,
                        IdPersona = p.IdPersona,
                        IdUsuario = p.IdUsuario,
                        Ingreso = p.Ingreso,
                        OtroIngreso = p.OtroIngreso,
                        TotalIngreso = p.TotalIngreso,
                        TotalEfectivo = p.TotalEfectivo,
                        TotalGasto = p.TotalGasto,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado



                    };
                    lstECArqueoSimple.Add(eArqueoSimple);
                }
            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECArqueoSimple;
    }
    #endregion
}