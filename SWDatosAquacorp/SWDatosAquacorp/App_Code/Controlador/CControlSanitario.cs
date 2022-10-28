using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;


/// <summary>
/// Descripción breve de CControlSanitario
/// </summary>
public class CControlSanitario
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_ControlSanitario(EControlSanitarioSimple eControlSanitarioSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_ControlSanitario_I(eControlSanitarioSimple.IdUsuario, eControlSanitarioSimple.FechaRegistro, eControlSanitarioSimple.FechaModificacion, eControlSanitarioSimple.Estado);
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

    public void Actualizar_ControlSanitario(EControlSanitarioSimple eControlSanitarioSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_ControlSanitario_A(eControlSanitarioSimple.IdControlSanitario, eControlSanitarioSimple.IdUsuario, eControlSanitarioSimple.FechaRegistro, eControlSanitarioSimple.FechaModificacion, eControlSanitarioSimple.Estado);
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

    public EControlSanitarioSimple Obtener_ControlSanitario_Id_ControlSanitario(byte IdControlSanitario)
    {
        EControlSanitarioSimple eControlSanitarioSimple = new EControlSanitarioSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var ControlSanitario = db.Proc_ControlSanitario_O_IdControlSanitario(IdControlSanitario);
                foreach (var c in ControlSanitario)
                {
                    eControlSanitarioSimple = new EControlSanitarioSimple
                    {
                        IdControlSanitario = c.IdControlSanitario,
                        IdUsuario = c.IdUsuario,
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
        return eControlSanitarioSimple;
    }



    public List<EControlSanitarioSimple> Obtener_ControlSanitario()
    {
        List<EControlSanitarioSimple> lstEControlSanitarioSimple = new List<EControlSanitarioSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var ControlSanitario = db.Proc_ControlSanitario_O();
                foreach (var c in ControlSanitario)
                {
                    EControlSanitarioSimple eControlSanitarioSimple = new EControlSanitarioSimple
                    {
                        IdControlSanitario = c.IdControlSanitario,
                        IdUsuario = c.IdUsuario,
                        FechaRegistro = c.FechaRegistro,
                        FechaModificacion = c.FechaModificacion,
                        Estado = c.Estado

                    };
                    lstEControlSanitarioSimple.Add(eControlSanitarioSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEControlSanitarioSimple;
    }


    public List<ERepControlSanitarioSimple> Obtener_ControlSanitario_Reporte_Fecha(DateTime fecha)
    {
        List<ERepControlSanitarioSimple> lstERepControlSanitarioSimple = new List<ERepControlSanitarioSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var ControlSanitarioRep = db.Proc_ControlSanitario_Reporte_Fecha(fecha);
                foreach (var cc in ControlSanitarioRep)
                {
                    ERepControlSanitarioSimple eControlSanitarioSimple = new ERepControlSanitarioSimple
                    {
                        Pregunta=cc.Pregunta,
                        Puntaje= cc.Puntaje
                    };
                    lstERepControlSanitarioSimple.Add(eControlSanitarioSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstERepControlSanitarioSimple;
    }
    #endregion
}