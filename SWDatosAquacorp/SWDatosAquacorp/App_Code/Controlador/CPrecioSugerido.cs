using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

/// <summary>
/// Descripción breve de CPrecioSugerido
/// </summary>
public class CPrecioSugerido
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_PrecioSugerido(EPrecioSugeridoSimple ePrecioSugeridoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_PrecioSugerido_I(ePrecioSugeridoSimple.IdProducto, ePrecioSugeridoSimple.Precio, ePrecioSugeridoSimple.FechaRegistro, ePrecioSugeridoSimple.FechaModificacion, ePrecioSugeridoSimple.Estado);
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
    public void Actualizar_PrecioSugerido(EPrecioSugeridoSimple ePrecioSugeridoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_PrecioSugerido_A(ePrecioSugeridoSimple.IdPrecioSugerido, ePrecioSugeridoSimple.IdProducto, ePrecioSugeridoSimple.Precio, ePrecioSugeridoSimple.FechaRegistro, ePrecioSugeridoSimple.FechaModificacion, ePrecioSugeridoSimple.Estado);
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
    public EPrecioSugeridoSimple Obtener_PrecioSugerido_Id_PrecioSugerido(int IdPrecioSugerido)
    {
        EPrecioSugeridoSimple ePrecioSugeridoSimple = new EPrecioSugeridoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_PrecioSugerido_O_IdPrecioSugerido(IdPrecioSugerido);
                foreach (var p in Persona)
                {
                    ePrecioSugeridoSimple = new EPrecioSugeridoSimple
                    {
                        IdPrecioSugerido = p.IdPrecioSugerido,
                        IdProducto = p.IdProducto,
                        Precio = p.Precio,
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
        return ePrecioSugeridoSimple;
    }



    public List<EPrecioSugeridoSimple> Obtener_PrecioSugerido()
    {
        List<EPrecioSugeridoSimple> lstECPrecioSugeridoSimple = new List<EPrecioSugeridoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_PrecioSugerido_O();
                foreach (var p in Persona)
                {
                    EPrecioSugeridoSimple ePrecioSugeridoSimple = new EPrecioSugeridoSimple
                    {
                        IdPrecioSugerido = p.IdPrecioSugerido,
                        IdProducto = p.IdProducto,
                        Precio = p.Precio,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,



                    };
                    lstECPrecioSugeridoSimple.Add(ePrecioSugeridoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECPrecioSugeridoSimple;
    }
    #endregion
}