using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CProduccion
/// </summary>
public class CProduccion
{

    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Produccion(EProduccionSimple eProduccionSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Produccion_I(eProduccionSimple.IdMateriaPrima, eProduccionSimple.IdProducto, eProduccionSimple.CantidadProduccion, eProduccionSimple.FechaRegistro, eProduccionSimple.FechaModificacion, eProduccionSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public void Actualizar_Produccion(EProduccionSimple eProduccionSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Produccion_A(eProduccionSimple.IdProduccion, eProduccionSimple.IdMateriaPrima, eProduccionSimple.IdProducto, eProduccionSimple.CantidadProduccion, eProduccionSimple.FechaRegistro, eProduccionSimple.FechaModificacion, eProduccionSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public EProduccionSimple Obtener_Produccion_IdProduccion(int IdProduccion)
    {
        EProduccionSimple eProduccionSimple = new EProduccionSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var obje = db.Proc_Produccion_O_IdProduccion(IdProduccion);
                foreach (var obj in obje)
                {
                    eProduccionSimple = new EProduccionSimple
                    {
                        IdProduccion = obj.IdProduccion
                    ,
                        IdMateriaPrima = obj.IdMateriaPrima
                    ,
                        IdProducto = obj.IdProducto
                    ,
                        CantidadProduccion = obj.CantidadProduccion
                    ,
                        FechaRegistro = obj.FechaRegistro
                    ,
                        FechaModificacion = obj.FechaModificacion
                    ,
                        Estado = obj.Estado
                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eProduccionSimple;
    }

    public List<EProduccionSimple> Obtener_Produccion()
    {
        List<EProduccionSimple> lstEProduccionSimple = new List<EProduccionSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var obje = db.Proc_Produccion_O();
                foreach (var obj in obje)
                {
                    EProduccionSimple eProduccionSimple = new EProduccionSimple
                    {
                        IdProduccion = obj.IdProduccion
                    ,
                        IdMateriaPrima = obj.IdMateriaPrima
                    ,
                        IdProducto = obj.IdProducto
                    ,
                        CantidadProduccion = obj.CantidadProduccion
                    ,
                        FechaRegistro = obj.FechaRegistro
                    ,
                        FechaModificacion = obj.FechaModificacion
                    ,
                        Estado = obj.Estado
                    };
                    lstEProduccionSimple.Add(eProduccionSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEProduccionSimple;
    }

    #endregion
}
