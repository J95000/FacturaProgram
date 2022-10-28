using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

/// <summary>
/// Descripción breve de CCalificacion
/// </summary>
public class CCalificacion
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Calificacion(ECalificacionSimple eCalificacionSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Calificacion_I(eCalificacionSimple.Pregunta, eCalificacionSimple.Puntaje, eCalificacionSimple.IdControlSanitario, eCalificacionSimple.FechaRegistro, eCalificacionSimple.FechaModificacion, eCalificacionSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public void Actualizar_Calificacion(ECalificacionSimple eCalificacionSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Calificacion_A(eCalificacionSimple.IdCalificacion, eCalificacionSimple.Pregunta, eCalificacionSimple.Puntaje, eCalificacionSimple.IdControlSanitario, eCalificacionSimple.FechaRegistro, eCalificacionSimple.FechaModificacion, eCalificacionSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public ECalificacionSimple Obtener_Calificacion_Id_Calificacion(int IdCalificacion)
    {
        ECalificacionSimple eCalificacionSimple = new ECalificacionSimple();
        try
        {


            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Calificacion = db.Proc_Calificacion_O_IdCalificacion(IdCalificacion);
                foreach (var c in Calificacion)
                {
                    eCalificacionSimple = new ECalificacionSimple
                    {
                        IdCalificacion = c.IdCalificacion,
                        Puntaje = c.Puntaje,
                        IdControlSanitario = c.IdControlSanitario,
                        FechaRegistro = c.FechaRegistro,
                        FechaModificacion = c.FechaModificacion,
                        Estado = c.Estado
                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eCalificacionSimple;
    }



    public List<ECalificacionSimple> Obtener_Calificacion()
    {
        List<ECalificacionSimple> lstECalificacionSimple = new List<ECalificacionSimple>();
        try
        {


            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Calificacion = db.Proc_Calificacion_O();
                foreach (var c in Calificacion)
                {
                    ECalificacionSimple eCalificacionSimple = new ECalificacionSimple
                    {
                        IdCalificacion = c.IdCalificacion,
                        Puntaje = c.Puntaje,
                        IdControlSanitario = c.IdControlSanitario,
                        FechaRegistro = c.FechaRegistro,
                        FechaModificacion = c.FechaModificacion,
                        Estado = c.Estado

                    };
                    lstECalificacionSimple.Add(eCalificacionSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECalificacionSimple;
    }
    #endregion
}