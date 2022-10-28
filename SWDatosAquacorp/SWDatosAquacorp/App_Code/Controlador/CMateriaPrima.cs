using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CMateriaPrima
/// </summary>
public class CMateriaPrima
{

    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_MateriaPrima(EMateriaPrimaSimple eMateriaPrimaSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_MateriaPrima_I(eMateriaPrimaSimple.NombreMateriaPrima, eMateriaPrimaSimple.DescripcionMateriaPrima, eMateriaPrimaSimple.UnidadMedida, eMateriaPrimaSimple.CantidadMinima, eMateriaPrimaSimple.FechaRegistro, eMateriaPrimaSimple.FechaModificacion, eMateriaPrimaSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public void Actualizar_MateriaPrima(EMateriaPrimaSimple eMateriaPrimaSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_MateriaPrima_A(eMateriaPrimaSimple.IdMateriaPrima, eMateriaPrimaSimple.NombreMateriaPrima, eMateriaPrimaSimple.DescripcionMateriaPrima, eMateriaPrimaSimple.UnidadMedida, eMateriaPrimaSimple.CantidadMinima, eMateriaPrimaSimple.FechaRegistro, eMateriaPrimaSimple.FechaModificacion, eMateriaPrimaSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public EMateriaPrimaSimple Obtener_MateriaPrima_IdMateriaPrima(int IdMateriaPrima)
    {
        EMateriaPrimaSimple eMateriaPrimaSimple = new EMateriaPrimaSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var obje = db.Proc_MateriaPrima_O_IdMateriaPrima(IdMateriaPrima);
                foreach (var obj in obje)
                {
                    eMateriaPrimaSimple = new EMateriaPrimaSimple
                    {
                        IdMateriaPrima = obj.IdMateriaPrima
                    ,
                        NombreMateriaPrima = obj.NombreMateriaPrima
                    ,
                        DescripcionMateriaPrima = obj.DescripcionMateriaPrima
                    ,
                        UnidadMedida = obj.UnidadMedida
                    ,
                        CantidadMinima = obj.CantidadMinima
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
        return eMateriaPrimaSimple;
    }

    public List<EMateriaPrimaSimple> Obtener_MateriaPrima()
    {
        List<EMateriaPrimaSimple> lstEMateriaPrimaSimple = new List<EMateriaPrimaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var obje = db.Proc_MateriaPrima_O();
                foreach (var obj in obje)
                {
                    EMateriaPrimaSimple eMateriaPrimaSimple = new EMateriaPrimaSimple
                    {
                        IdMateriaPrima = obj.IdMateriaPrima
                    ,
                        NombreMateriaPrima = obj.NombreMateriaPrima
                    ,
                        DescripcionMateriaPrima = obj.DescripcionMateriaPrima
                    ,
                        UnidadMedida = obj.UnidadMedida
                    ,
                        CantidadMinima = obj.CantidadMinima
                    ,
                        FechaRegistro = obj.FechaRegistro
                    ,
                        FechaModificacion = obj.FechaModificacion
                    ,
                        Estado = obj.Estado
                    };
                    lstEMateriaPrimaSimple.Add(eMateriaPrimaSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEMateriaPrimaSimple;
    }

    #endregion
}
