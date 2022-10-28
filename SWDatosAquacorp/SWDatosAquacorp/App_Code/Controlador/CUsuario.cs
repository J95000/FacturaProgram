using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CUsuario
/// </summary>
public class CUsuario
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Usuario(EUsuarioSimple eUsuarioSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Usuario_I(eUsuarioSimple.IdUsuario, eUsuarioSimple.Contrasena, eUsuarioSimple.FechaRegistro, eUsuarioSimple.FechaModificacion, eUsuarioSimple.Estado);
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

    public void Actualizar_Usuario(EUsuarioSimple eUsuarioSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Usuario_A(eUsuarioSimple.IdUsuario, eUsuarioSimple.Contrasena, eUsuarioSimple.FechaRegistro, eUsuarioSimple.FechaModificacion, eUsuarioSimple.Estado);
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
    public EUsuarioSimple Obtener_Usuario_Id_Usuario(int IdUsuario)
    {
        EUsuarioSimple eUsuarioSimple = new EUsuarioSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Usuario_O_IdUsuario(IdUsuario);
                foreach (var p in Persona)
                {
                    eUsuarioSimple = new EUsuarioSimple
                    {
                        IdUsuario = p.IdUsuario,
                        Contrasena = p.Contrasena,
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
        return eUsuarioSimple;
    }



    public List<EUsuarioSimple> Obtener_Usuario()
    {
        List<EUsuarioSimple> lstEUsuarioSimple = new List<EUsuarioSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Usuario_O();
                foreach (var p in Persona)
                {
                    EUsuarioSimple eUsuarioSimple = new EUsuarioSimple
                    {
                        IdUsuario = p.IdUsuario,
                        Contrasena = p.Contrasena,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado

                    };
                    lstEUsuarioSimple.Add(eUsuarioSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEUsuarioSimple;
    }
    #endregion

}