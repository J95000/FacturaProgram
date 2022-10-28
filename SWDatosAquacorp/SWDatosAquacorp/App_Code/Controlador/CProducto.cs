using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;


/// <summary>
/// Descripción breve de CProducto
/// </summary>
public class CProducto
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Producto(EProductoSimple eProductoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Producto_I(eProductoSimple.NombreProducto, eProductoSimple.FotoProducto, eProductoSimple.Descripcion, eProductoSimple.Consumible, eProductoSimple.FechaRegistro, eProductoSimple.FechaModificacion, eProductoSimple.Estado);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
                }
            }
        } }

    public void Actualizar_Producto(EProductoSimple eProductoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Producto_A(eProductoSimple.IdProducto, eProductoSimple.NombreProducto, eProductoSimple.FotoProducto, eProductoSimple.Descripcion, eProductoSimple.Consumible, eProductoSimple.FechaRegistro, eProductoSimple.FechaModificacion, eProductoSimple.Estado);
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

    public EProductoSimple Obtener_Producto_Id_Producto(int IdProducto)
    {
        EProductoSimple eProductoSimple = new EProductoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Producto = db.Proc_Producto_O_IdProducto(IdProducto);
                foreach (var p in Producto)
                {
                    eProductoSimple = new EProductoSimple
                    {
                        IdProducto = p.idProducto,
                        NombreProducto = p.NombreProducto,
                        FotoProducto = p.FotoProducto,
                        Descripcion = p.Descripcion,
                        Consumible=p.Consumible,
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
        return eProductoSimple;
    }



    public List<EProductoSimple> Obtener_Producto()
    {
        List<EProductoSimple> lstEProductoSimple = new List<EProductoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Producto = db.Proc_Producto_O();
                foreach (var p in Producto)
                {
                    EProductoSimple eProductoSimple = new EProductoSimple
                    {
                        IdProducto = p.idProducto,
                        NombreProducto = p.NombreProducto,
                        FotoProducto = p.FotoProducto,
                        Descripcion = p.Descripcion,
                        Consumible = p.Consumible,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado

                    };
                    lstEProductoSimple.Add(eProductoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEProductoSimple;
    }

    public List<EProductoSimple> Obtener_Producto_SinFoto()
    {
        List<EProductoSimple> lstEProductoSimple = new List<EProductoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Producto = db.Proc_Producto_O();
                foreach (var p in Producto)
                {
                    EProductoSimple eProductoSimple = new EProductoSimple
                    {
                        IdProducto = p.idProducto,
                        NombreProducto = p.NombreProducto,
                        Descripcion = p.Descripcion,
                        Consumible = p.Consumible,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado

                    };
                    lstEProductoSimple.Add(eProductoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEProductoSimple;
    }

    public List<EProductoSimple> Obtener_Producto_Mobil()
    {
        List<EProductoSimple> lstEProductoSimple = new List<EProductoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Producto = db.Proc_Producto_O_Mobil();
                foreach (var p in Producto)
                {
                    EProductoSimple eProductoSimple = new EProductoSimple
                    {
                        IdProducto = p.IdProducto,
                        NombreProducto = p.NombreProducto
                    };
                    lstEProductoSimple.Add(eProductoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEProductoSimple;
    }



    #endregion

}