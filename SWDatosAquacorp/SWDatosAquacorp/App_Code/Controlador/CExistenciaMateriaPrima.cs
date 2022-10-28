using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CExistenciaMateriaPrima
/// </summary>
public class CExistenciaMateriaPrima
{

    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_ExistenciaMateriaPrima(EExistenciaMateriaPrimaSimple eExistenciaMateriaPrimaSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_ExistenciaMateriaPrima_I(eExistenciaMateriaPrimaSimple.IdMateriaPrima, eExistenciaMateriaPrimaSimple.CantidadActual, eExistenciaMateriaPrimaSimple.CantidadCambio, eExistenciaMateriaPrimaSimple.FechaRegistro, eExistenciaMateriaPrimaSimple.FechaModificacion, eExistenciaMateriaPrimaSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public void Actualizar_ExistenciaMateriaPrima(EExistenciaMateriaPrimaSimple eExistenciaMateriaPrimaSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_ExistenciaMateriaPrima_A(eExistenciaMateriaPrimaSimple.IdExistenciaMateriaPrima, eExistenciaMateriaPrimaSimple.IdMateriaPrima, eExistenciaMateriaPrimaSimple.CantidadActual, eExistenciaMateriaPrimaSimple.CantidadCambio, eExistenciaMateriaPrimaSimple.FechaRegistro, eExistenciaMateriaPrimaSimple.FechaModificacion, eExistenciaMateriaPrimaSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public EExistenciaMateriaPrimaSimple Obtener_ExistenciaMateriaPrima_IdExistenciaMateriaPrima(int IdExistenciaMateriaPrima)
    {
        EExistenciaMateriaPrimaSimple eExistenciaMateriaPrimaSimple = new EExistenciaMateriaPrimaSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var obje = db.Proc_ExistenciaMateriaPrima_O_IdExistenciaMateriaPrima(IdExistenciaMateriaPrima);
                foreach (var obj in obje)
                {
                    eExistenciaMateriaPrimaSimple = new EExistenciaMateriaPrimaSimple
                    {
                        IdExistenciaMateriaPrima = obj.IdExistenciaMateriaPrima
                    ,
                        IdMateriaPrima = obj.IdMateriaPrima
                    ,
                        CantidadActual = obj.CantidadActual
                    ,
                        CantidadCambio = obj.CantidadCambio
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
        return eExistenciaMateriaPrimaSimple;
    }

    public List<EExistenciaMateriaPrimaSimple> Obtener_ExistenciaMateriaPrima()
    {
        List<EExistenciaMateriaPrimaSimple> lstEExistenciaMateriaPrimaSimple = new List<EExistenciaMateriaPrimaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var obje = db.Proc_ExistenciaMateriaPrima_O();
                foreach (var obj in obje)
                {
                    EExistenciaMateriaPrimaSimple eExistenciaMateriaPrimaSimple = new EExistenciaMateriaPrimaSimple
                    {
                        IdExistenciaMateriaPrima = obj.IdExistenciaMateriaPrima
                    ,
                        IdMateriaPrima = obj.IdMateriaPrima
                    ,
                        CantidadActual = obj.CantidadActual
                    ,
                        CantidadCambio = obj.CantidadCambio
                    ,
                        FechaRegistro = obj.FechaRegistro
                    ,
                        FechaModificacion = obj.FechaModificacion
                    ,
                        Estado = obj.Estado
                    };
                    lstEExistenciaMateriaPrimaSimple.Add(eExistenciaMateriaPrimaSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEExistenciaMateriaPrimaSimple;
    }

    #endregion
}
