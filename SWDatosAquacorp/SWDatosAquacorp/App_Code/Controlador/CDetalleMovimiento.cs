using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CDetalleMovimiento
/// </summary>
public class CDetalleMovimiento
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_DetalleMovimiento(EDetalleMovimientoSimple eDetalleMovimientoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_DetalleMovimiento_I(eDetalleMovimientoSimple.IdMovimiento, eDetalleMovimientoSimple.IdProducto, eDetalleMovimientoSimple.PrecioUnitario, eDetalleMovimientoSimple.Cantidad, eDetalleMovimientoSimple.FechaRegistro, eDetalleMovimientoSimple.FechaModificacion, eDetalleMovimientoSimple.Estado);
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
    public void Actualizar_DetalleMovimiento(EDetalleMovimientoSimple eDetalleMovimientoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_DetalleMovimiento_A(eDetalleMovimientoSimple.IdDetalleMovimiento, eDetalleMovimientoSimple.IdMovimiento, eDetalleMovimientoSimple.IdProducto, eDetalleMovimientoSimple.PrecioUnitario, eDetalleMovimientoSimple.Cantidad, eDetalleMovimientoSimple.FechaRegistro, eDetalleMovimientoSimple.FechaModificacion, eDetalleMovimientoSimple.Estado);
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
    public EDetalleMovimientoSimple Obtener_DetalleMovimiento_Id_Movimiento(int IdDetalleMovimiento)
    {
        EDetalleMovimientoSimple eDetalleMovimientoSimple = new EDetalleMovimientoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var DetalleMovimiento = db.Proc_DetalleMovimiento_O_IdDetalleMovimiento(IdDetalleMovimiento);
                foreach (var dp in DetalleMovimiento)
                {
                    eDetalleMovimientoSimple = new EDetalleMovimientoSimple
                    {
                        IdDetalleMovimiento = dp.IdDetalleMovimiento,
                        IdMovimiento = dp.IdMovimiento,
                        IdProducto = dp.IdProducto,
                        PrecioUnitario = dp.PrecioUnitario,
                        Cantidad = dp.Cantidad,
                        FechaRegistro = dp.FechaRegistro,
                        FechaModificacion = dp.FechaModificacion,
                        Estado = dp.Estado
                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eDetalleMovimientoSimple;
    }



  
    public List<EDetalleMovimientoSimple> Obtener_DetalleMovimiento()
    {
        List<EDetalleMovimientoSimple> lstEDetalleMovimientoSimple = new List<EDetalleMovimientoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var DetalleMovimiento = db.Proc_DetalleMovimiento_O();
                foreach (var dp in DetalleMovimiento)
                {
                    EDetalleMovimientoSimple eDetalleMovimientoSimple = new EDetalleMovimientoSimple
                    {
                        IdDetalleMovimiento = dp.IdDetalleMovimiento,
                        IdMovimiento = dp.IdMovimiento,
                        IdProducto = dp.IdProducto,
                        Cantidad = dp.Cantidad,
                        PrecioUnitario = dp.PrecioUnitario,
                        FechaRegistro = dp.FechaRegistro,
                        FechaModificacion = dp.FechaModificacion,
                        Estado = dp.Estado

                    };
                    lstEDetalleMovimientoSimple.Add(eDetalleMovimientoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEDetalleMovimientoSimple;
    }
    public void Insertar_Movimiento_Cancelado(EMovimientoCanceladoSimple eMovimientoCanceladoSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Movimiento_Pedido_Cancelar(eMovimientoCanceladoSimple.IdMovimiento, eMovimientoCanceladoSimple.Motivo, eMovimientoCanceladoSimple.FechaRegistro);
            }
        }

        catch (Exception ex)
        {
        
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }
    public List<EDetalleMovimientoPedidoSimple> Obtener_DetalleMovimiento_Pedido(int idMovimiento)
    {
        List<EDetalleMovimientoPedidoSimple> lstEDetalleMovimientoSimple = new List<EDetalleMovimientoPedidoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var DetalleMovimiento = db.Proc_DetalleMovimiento_O_Pedido_IdMovimiento(idMovimiento);
                foreach (var dp in DetalleMovimiento)
                {
                    EDetalleMovimientoPedidoSimple eDetalleMovimientoSimple = new EDetalleMovimientoPedidoSimple
                    {
                        IdDetalleMovimiento = dp.IdDetalleMovimiento,
                        IdMovimiento = dp.IdMovimiento,
                        IdProducto = dp.IdProducto,
                        NombreProducto = dp.NombreProducto,
                        PrecioUnitario = dp.PrecioUnitario,
                        Cantidad = dp.Cantidad,
                        SubTotal = (decimal)dp.SubTotal

                    };
                    lstEDetalleMovimientoSimple.Add(eDetalleMovimientoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEDetalleMovimientoSimple;
    }

    #endregion

}