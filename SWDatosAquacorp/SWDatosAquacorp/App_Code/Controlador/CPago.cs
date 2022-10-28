using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CPago
/// </summary>
public class CPago
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Pago(EPagoSimple ePagoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Pago_I(ePagoSimple.IdMovimiento, ePagoSimple.IdUsuario, ePagoSimple.CantidadPago, ePagoSimple.FechaRegistro, ePagoSimple.FechaModificacion, ePagoSimple.Estado);
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

    public void Actualizar_Pago(EPagoSimple ePagoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Pago_A(ePagoSimple.IdPago, ePagoSimple.IdMovimiento, ePagoSimple.IdUsuario, ePagoSimple.CantidadPago, ePagoSimple.FechaRegistro, ePagoSimple.FechaModificacion, ePagoSimple.Estado);
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
    public EPagoSimple Obtener_Pago_Id_Pago(int IdPago)
    {
        EPagoSimple ePagoSimple = new EPagoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Pago_O_IdPago(IdPago);
                foreach (var p in Persona)
                {
                    ePagoSimple = new EPagoSimple
                    {
                        IdPago = p.IdPago,
                        IdMovimiento = p.IdMovimiento,
                        IdUsuario = p.IdUsuario,
                        CantidadPago = p.CantidadPago,


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
        return ePagoSimple;
    }



    public List<EPagoSimple> Obtener_Pago()
    {
        List<EPagoSimple> lstECPagoSimple = new List<EPagoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Pago_O();
                foreach (var p in Persona)
                {
                    EPagoSimple ePagoSimple = new EPagoSimple
                    {
                        IdPago = p.IdPago,
                        IdMovimiento = p.IdMovimiento,
                        IdUsuario = p.IdUsuario,
                        CantidadPago = p.CantidadPago,

                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,



                    };
                    lstECPagoSimple.Add(ePagoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECPagoSimple;
    }

    public List<ERepDeudasSimple> Reporte_Deuda(int idCliente, DateTime fechaFinal, int tipo)
    {
        List<ERepDeudasSimple> lstECPagoSimple = new List<ERepDeudasSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Reporte_Deuda(idCliente, fechaFinal, tipo);
                foreach (var p in Persona)
                {
                    ERepDeudasSimple ePagoSimple = new ERepDeudasSimple
                    {
                        IdMovimiento = p.IdMovimiento,
                        NombrePersonal = p.NombrePersonal,
                        Codigo = p.Codigo,
                        Fecha = (DateTime)p.Fecha,
                        Total = p.Total,
                        Pago = (decimal)p.Pago,
                        Saldo = (decimal)p.Saldo,
                        Tipo = (int)p.Tipo

                    };
                    lstECPagoSimple.Add(ePagoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECPagoSimple;
    }


    public List<EArqueoPagoSimple> Arqueo_Pago(int idUsuario, DateTime fecha)
    {
        List<EArqueoPagoSimple> lstECPagoSimple = new List<EArqueoPagoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Arqueo_Pago_IdUsuario_Fecha(idUsuario, fecha);
                foreach (var p in Persona)
                {
                    EArqueoPagoSimple ePagoSimple = new EArqueoPagoSimple
                    {
                        IdPago = p.IdPago,
                        Codigo = p.Codigo,
                        CantidadPago = p.CantidadPago,
                        FechaRegistro = p.FechaRegistro,
                    };
                    lstECPagoSimple.Add(ePagoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECPagoSimple;
    }

    #endregion

}