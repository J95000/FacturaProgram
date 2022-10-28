using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CConyugue
/// </summary>
public class CConyugue
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Conyugue(EConyugueSimple eConyugueSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Conyugue_I(eConyugueSimple.IdEmpleado, eConyugueSimple.Nombres, eConyugueSimple.PrimerApellido, eConyugueSimple.SegundoApellido, eConyugueSimple.Telefono, eConyugueSimple.TelefonoRespaldo, eConyugueSimple.NumeroHijos, eConyugueSimple.FechaRegistro, eConyugueSimple.FechaModificacion, eConyugueSimple.Estado);
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
    public void Actualizar_Conyugue(EConyugueSimple eConyugueSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Conyugue_A(eConyugueSimple.IdConyugue, eConyugueSimple.IdEmpleado, eConyugueSimple.Nombres, eConyugueSimple.PrimerApellido, eConyugueSimple.SegundoApellido, eConyugueSimple.Telefono, eConyugueSimple.TelefonoRespaldo, eConyugueSimple.NumeroHijos, eConyugueSimple.FechaRegistro, eConyugueSimple.FechaModificacion, eConyugueSimple.Estado);
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
    public EConyugueSimple Obtener_Conyugue_Id_Empleado(int IdEmpleado)
    {
        EConyugueSimple eConyugueSimple = new EConyugueSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Conyugue_O_IdEmpleado(IdEmpleado);
                foreach (var p in Persona)
                {
                    eConyugueSimple = new EConyugueSimple
                    {
                        IdConyugue = p.IdConyugue,
                        IdEmpleado = p.IdEmpleado,
                        Nombres = p.Nombres,
                        PrimerApellido = p.PrimerApellido,
                        SegundoApellido = p.SegundoApellido,
                        Telefono = p.Telefono,
                        TelefonoRespaldo = p.TelefonoRespaldo,
                        NumeroHijos = p.NumeroHijos,
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
        return eConyugueSimple;
    }



    public List<EConyugueSimple> Obtener_Conyugue()
    {
        List<EConyugueSimple> lstECConyugueSimple = new List<EConyugueSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Conyugue_O();
                foreach (var p in Persona)
                {
                    EConyugueSimple eConyugueSimple = new EConyugueSimple
                    {
                        IdConyugue = p.IdConyugue,
                        IdEmpleado = p.IdEmpleado,
                        Nombres = p.Nombres,
                        PrimerApellido = p.PrimerApellido,
                        SegundoApellido = p.SegundoApellido,
                        Telefono = p.Telefono,
                        TelefonoRespaldo = p.TelefonoRespaldo,
                        NumeroHijos = p.NumeroHijos,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado


                    };
                    lstECConyugueSimple.Add(eConyugueSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECConyugueSimple;
    }
    #endregion


}