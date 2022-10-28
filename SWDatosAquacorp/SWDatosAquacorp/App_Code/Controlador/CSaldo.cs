using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

/// <summary>
/// Descripción breve de CSaldo
/// </summary>
public class CSaldo
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Saldo(ESaldoSimple eSaldoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Saldo_I(eSaldoSimple.IdEmpleado,  eSaldoSimple.Cantidad, eSaldoSimple.Tipo, eSaldoSimple.Descripcion, eSaldoSimple.FechaRegistro, eSaldoSimple.FechaModificacion, eSaldoSimple.Estado);
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
    public void Actualizar_Saldo(ESaldoSimple eSaldoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Saldo_A(eSaldoSimple.IdSaldo, eSaldoSimple.IdEmpleado,   eSaldoSimple.Cantidad, eSaldoSimple.Tipo, eSaldoSimple.Descripcion, eSaldoSimple.FechaRegistro, eSaldoSimple.FechaModificacion, eSaldoSimple.Estado);
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
    public ESaldoSimple Obtener_Saldo_Id_Saldo(int IdSaldo)
    {
        ESaldoSimple eSaldoSimple = new ESaldoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var saldo = db.Proc_Saldo_O_IdSaldo(IdSaldo);
                foreach (var p in saldo)
                {
                    eSaldoSimple = new ESaldoSimple
                    {
                        IdSaldo = p.IdSaldo,
                        IdEmpleado = p.IdEmpleado,
                        Cantidad = p.Cantidad,
                        Tipo=p.Tipo,
                        Descripcion=p.Descripcion,
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
        return eSaldoSimple;
    }



    public List<ESaldoSimple> Obtener_Saldo()
    {
        List<ESaldoSimple> lstECSaldoSimple = new List<ESaldoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var saldo = db.Proc_Saldo_O();
                foreach (var p in saldo)
                {
                    ESaldoSimple eSaldoSimple = new ESaldoSimple
                    {
                        IdSaldo = p.IdSaldo,
                        IdEmpleado = p.IdEmpleado,
                        Cantidad = p.Cantidad,
                        Tipo = p.Tipo,
                        Descripcion = p.Descripcion,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,

                    };
                    lstECSaldoSimple.Add(eSaldoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECSaldoSimple;
    }

    public List<ERepSaldoSimple> Reporte_Saldo(int idEmpleado, DateTime inicio, DateTime final, int tipo)
    {
        List<ERepSaldoSimple> lstECSaldoSimple = new List<ERepSaldoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var saldo = db.Proc_Reporte_Saldo(idEmpleado,  inicio,  final,  tipo);
                foreach (var p in saldo)
                {
                    ERepSaldoSimple eSaldoSimple = new ERepSaldoSimple
                    {
                        NombrePersonal = p.NombrePersonal,
                        Cantidad = p.Cantidad,
                        TipoMovimiento =p.TipoMovimiento,
                        Fecha = (DateTime)p.Fecha,
                        Descripcion = p.Descripcion,
                        FechaInicio = (DateTime)p.FechaInicio,
                        FechaFinal = (DateTime)p.FechaFinal,
                        Tipo = (int)p.Tipo

                };
                    lstECSaldoSimple.Add(eSaldoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECSaldoSimple;
    }

    #endregion

}