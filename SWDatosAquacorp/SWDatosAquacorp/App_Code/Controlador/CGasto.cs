using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

/// <summary>
/// Descripción breve de CGasto
/// </summary>
public class CGasto
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Gasto(EGastoSimple eGastoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Gasto_I(eGastoSimple.IdTipoGasto, eGastoSimple.Cantidad, eGastoSimple.Precio, eGastoSimple.IdUsuario, eGastoSimple.IdAprovador, eGastoSimple.FechaRegistro, eGastoSimple.FechaModificacion, eGastoSimple.Estado);
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

    public void Actualizar_Gasto(EGastoSimple eGastoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Gasto_A(eGastoSimple.IdGasto, eGastoSimple.IdTipoGasto, eGastoSimple.Cantidad, eGastoSimple.Precio, eGastoSimple.IdUsuario, eGastoSimple.IdAprovador, eGastoSimple.FechaRegistro, eGastoSimple.FechaModificacion, eGastoSimple.Estado);
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
    public EGastoSimple Obtener_Gasto_Id_Gasto(int IdGasto)
    {
        EGastoSimple eGastoSimple = new EGastoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Gasto_O_IdGasto(IdGasto);
                foreach (var p in Persona)
                {
                    eGastoSimple = new EGastoSimple
                    {
                        IdGasto = p.IdGasto,
                        IdTipoGasto = p.IdTipoGasto,
                        Cantidad = p.Cantidad,
                        Precio = p.Precio,
                        IdUsuario = p.IdUsuario,
                        IdAprovador = p.IdAprovador,

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
        return eGastoSimple;
    }



    public List<EGastoSimple> Obtener_Gasto()
    {
        List<EGastoSimple> lstECGastoSimple = new List<EGastoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Gasto_O();
                foreach (var p in Persona)
                {
                    EGastoSimple eGastoSimple = new EGastoSimple
                    {
                        IdGasto = p.IdGasto,
                        IdTipoGasto = p.IdTipoGasto,
                        Cantidad = p.Cantidad,
                        Precio = p.Precio,
                        IdUsuario = p.IdUsuario,
                        IdAprovador = p.IdAprovador,

                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,



                    };
                    lstECGastoSimple.Add(eGastoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECGastoSimple;
    }

    public List<EArqueoGastoSimple> Arqueo_Gasto(int idUsuario, DateTime fecha)

    {
        List<EArqueoGastoSimple> lstEArqueoGastoSimple = new List<EArqueoGastoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Gasto_O_IdUsuario_Fecha(idUsuario,  fecha);
                foreach (var p in Persona)
                {
                    EArqueoGastoSimple eEArqueoGastoSimple = new EArqueoGastoSimple
                    {
                        Cont = (int)p.Cont,
                    IdGasto = p.IdGasto,
                    IdTipoGasto = p.IdTipoGasto,
                    NombreTipoGasto = p.NombreTipoGasto,
                    Cantidad =p.Cantidad,
                    Precio = p.Precio,
                    IdUsuario = p.IdUsuario,
                    NombreUsuario = p.NombreUsuario,
                    IdAprovador = p.IdAprovador,
                    NombreAprobador = p.NombreAprobador,
                
                    FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,



                    };
                    lstEArqueoGastoSimple.Add(eEArqueoGastoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEArqueoGastoSimple;
    }
    #endregion

}