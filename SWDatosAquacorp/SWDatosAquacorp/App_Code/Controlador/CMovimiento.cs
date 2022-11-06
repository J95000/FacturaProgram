using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CMovimiento
/// </summary>
public class CMovimiento
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Movimiento(EMovimientoSimple eMovimientoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Movimiento_I(eMovimientoSimple.IdCliente, eMovimientoSimple.IdUsuario, eMovimientoSimple.TipoMovimiento, eMovimientoSimple.FechaRegistro, eMovimientoSimple.FechaModificacion, eMovimientoSimple.Estado);
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

    public void Actualizar_Movimiento(EMovimientoSimple eMovimientoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Movimiento_A(eMovimientoSimple.IdMovimiento, eMovimientoSimple.Codigo, eMovimientoSimple.IdCliente, eMovimientoSimple.IdUsuario, eMovimientoSimple.TipoMovimiento, eMovimientoSimple.FechaRegistro, eMovimientoSimple.FechaModificacion, eMovimientoSimple.Estado);
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
    public EMovimientoSimple Obtener_Movimiento_Id_Movimiento(int IdMovimiento)
    {
        EMovimientoSimple eMovimientoSimple = new EMovimientoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Movimiento = db.Proc_Movimiento_O_IdMovimiento(IdMovimiento);
                foreach (var v in Movimiento)
                {
                    eMovimientoSimple = new EMovimientoSimple
                    {
                        IdMovimiento = v.IdMovimiento,
                        Codigo = v.Codigo,
                        IdCliente = v.IdCliente,
                        IdUsuario = v.IdUsuario,
                        TipoMovimiento = v.TipoMovimiento,
                        FechaRegistro = v.FechaRegistro,
                        FechaModificacion = v.FechaModificacion,
                        Estado = v.Estado
                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eMovimientoSimple;
    }

    public List<EMovimientoSimple> Obtener_Movimiento()
    {
        List<EMovimientoSimple> lstEMovimientoSimple = new List<EMovimientoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Movimiento = db.Proc_Movimiento_O();
                foreach (var v in Movimiento)
                {
                    EMovimientoSimple eMovimientoSimple = new EMovimientoSimple
                    {
                        IdMovimiento = v.IdMovimiento,
                        Codigo = v.Codigo,
                        IdCliente = v.IdCliente,
                        IdUsuario = v.IdUsuario,
                        TipoMovimiento = v.TipoMovimiento,
                        FechaRegistro = v.FechaRegistro,
                        FechaModificacion = v.FechaModificacion,
                        Estado = v.Estado

                    };
                    lstEMovimientoSimple.Add(eMovimientoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEMovimientoSimple;
    }

    public EMovimientoSimple Obtener_Movimiento_Codigo(string codigo)
    {
        EMovimientoSimple eMovimientoSimple = new EMovimientoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Movimiento = db.Proc_Movimiento_O_Codigo(codigo);
                foreach (var v in Movimiento)
                {
                    eMovimientoSimple = new EMovimientoSimple
                    {
                        IdMovimiento = v.IdMovimiento,
                        Codigo = v.Codigo,
                        IdCliente = v.IdCliente,
                        IdUsuario = v.IdUsuario,
                        TipoMovimiento = v.TipoMovimiento,
                        FechaRegistro = v.FechaRegistro,
                        FechaModificacion = v.FechaModificacion,
                        Estado = v.Estado
                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eMovimientoSimple;
    }

    public List<ERepMovimientoSimple> Reporte_Movimiento(string tipoMovimiento, int idUsuario, DateTime inicio, DateTime final, int tipo)
    {
        List<ERepMovimientoSimple> lstEMovimientoSimple = new List<ERepMovimientoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Movimi = db.Proc_Reporte_Movimiento(tipoMovimiento,  idUsuario,  inicio,  final,  tipo);
                foreach (var v in Movimi)
                {
                    ERepMovimientoSimple eMovimientoSimple = new ERepMovimientoSimple
                    {
                        Codigo = v.Codigo,
                        Cliente = v.Cliente,
                        Personal = v.Personal,
                        Fecha = (DateTime)v.Fecha,
                        FechaInicio = (DateTime)v.FechaInicio,
                        FechaFinal = (DateTime)v.FechaFinal,
                        Tipo = (int)v.Tipo

                };
                    lstEMovimientoSimple.Add(eMovimientoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEMovimientoSimple;
    }

    public List<EArqueoMovimientoSimple> Arqueo_Movimiento(int idUsuario,DateTime fecha, string tipoMovimiento )
    {
        List<EArqueoMovimientoSimple> lstEArqueoMovimientoSimple = new List<EArqueoMovimientoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Movimi = db.Proc_Movimiento_O_IdUsuario_Fecha_TipoMovimiento( idUsuario, fecha, tipoMovimiento);
                foreach (var v in Movimi)
                {
                    EArqueoMovimientoSimple eArqueoMovimientoSimple = new EArqueoMovimientoSimple
                    {
                    Cont = (int)v.Cont,
                    IdMovimiento = v.IdMovimiento,
                    Codigo = v.Codigo,
                    IdCliente = v.IdCliente,
                    NombreCliente = v.NombreCliente,
                    IdUsuario = (int)v.IdUsuario,
                    NombreUsuario = v.NombreUsuario,
                    TipoMovimiento = v.TipoMovimiento,
                    FechaRegistro = v.FechaRegistro,
                    FechaModificacion = v.FechaModificacion,
                    Estado = v.Estado

                };
                    lstEArqueoMovimientoSimple.Add(eArqueoMovimientoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEArqueoMovimientoSimple;
    }


    public List<EArqueoSimple> Arqueo_Retorno(int idUsuario, DateTime fecha)
    {
        List<EArqueoSimple> lstEArqueoMovimientoSimple = new List<EArqueoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Movimi = db.Proc_Arqueo_O_IdUsuario_Fecha(idUsuario, fecha);
                foreach (var v in Movimi)
                {
                    EArqueoSimple eArqueoMovimientoSimple = new EArqueoSimple
                    {
                        IdProducto = v.IdProducto,
                        Cantidad = (int)v.Cantidad,

                    };
                    lstEArqueoMovimientoSimple.Add(eArqueoMovimientoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEArqueoMovimientoSimple;
    }



    public List<EMovimientoPedidoSimple> Obtener_Movimiento_O_Pedido_IdUsuario(int IdUsuario, DateTime fecha)
    {
        List<EMovimientoPedidoSimple> lstEMovimientoPedidoSimple = new List<EMovimientoPedidoSimple>();
        EMovimientoPedidoSimple eMovimientoPedidoSimple = new EMovimientoPedidoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Movimiento = db.Proc_Movimiento_O_Pedido_IdUsuario(IdUsuario, fecha);
                foreach (var v in Movimiento)
                {
                    eMovimientoPedidoSimple = new EMovimientoPedidoSimple
                    {
                    IdMovimiento = v.IdMovimiento,
                    Codigo = v.Codigo,
                    IdCliente = v.IdCliente,
                    NombreCliente = v.NombreCliente,
                    Telefono = v.Telefono,
                    IdDireccion = v.IdDireccion,
                    NombreDireccion = v.NombreDireccion,
                    Latitud = v.Latitud,
                    Longitud = v.Longitud,
                    FechaRegistro = v.FechaRegistro,
                    FechaModificacion = v.FechaModificacion,
                    RazonSocial = v.RazonSocial,
                    NitCi = v.NitCi,
                    FotoUbicacion = v.FotoUbicacion
                };
                    lstEMovimientoPedidoSimple.Add(eMovimientoPedidoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEMovimientoPedidoSimple;
    }
    public void Insertar_Movimiento_ConFactura(EMovimientoSimple eMovimientoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Movimiento_I_ConFactura(eMovimientoSimple.IdCliente, eMovimientoSimple.IdUsuario, eMovimientoSimple.TipoMovimiento, eMovimientoSimple.FechaRegistro, eMovimientoSimple.FechaModificacion, eMovimientoSimple.Estado, eMovimientoSimple.PrecioTotal, eMovimientoSimple.IdDosificacion, eMovimientoSimple.NroMovimiento, eMovimientoSimple.CodigoControl, eMovimientoSimple.RazonSocial, eMovimientoSimple.NitCi);
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
    public void Insertar_Movimiento_SinFactura(EMovimientoSimple eMovimientoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Movimiento_I_SinFactura(eMovimientoSimple.IdCliente, eMovimientoSimple.IdUsuario, eMovimientoSimple.TipoMovimiento, eMovimientoSimple.FechaRegistro, eMovimientoSimple.FechaModificacion, eMovimientoSimple.Estado, eMovimientoSimple.PrecioTotal);
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
    #endregion

}

