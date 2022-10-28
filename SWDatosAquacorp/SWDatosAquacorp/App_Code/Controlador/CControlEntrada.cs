using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

/// <summary>
/// Descripción breve de CControlEntrada
/// </summary>
public class CControlEntrada
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_ControlEntrada(EControlEntradaSimple eControlEntradaSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_ControlEntrada_I(eControlEntradaSimple.IdPersona, eControlEntradaSimple.IdUsuario, eControlEntradaSimple.FechaHoraEntrada, eControlEntradaSimple.FechaHoraSalida, eControlEntradaSimple.FechaRegistro, eControlEntradaSimple.FechaModificacion, eControlEntradaSimple.Estado);
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
    public void Actualizar_ControlEntrada(EControlEntradaSimple eControlEntradaSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_ControlEntrada_A(eControlEntradaSimple.IdControlEntrada, eControlEntradaSimple.IdPersona, eControlEntradaSimple.IdUsuario, eControlEntradaSimple.FechaHoraEntrada, eControlEntradaSimple.FechaHoraSalida, eControlEntradaSimple.FechaRegistro, eControlEntradaSimple.FechaModificacion, eControlEntradaSimple.Estado);
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
    public EControlEntradaSimple Obtener_ControlEntrada_Id_ControlEntrada(int IdControlEntrada)
    {
        EControlEntradaSimple eControlEntradaSimple = new EControlEntradaSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_ControlEntrada_O_IdControlEntrada(IdControlEntrada);
                foreach (var p in Persona)
                {
                    eControlEntradaSimple = new EControlEntradaSimple
                    {
                        IdControlEntrada = p.IdControlEntrada,
                        IdPersona = p.IdPersona,
                        IdUsuario = p.IdUsuario,
                        FechaHoraEntrada = p.FechaHoraEntrada,
                        FechaHoraSalida = p.FechaHoraSalida,
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
        return eControlEntradaSimple;
    }



    public List<EControlEntradaSimple> Obtener_ControlEntrada()
    {
        List<EControlEntradaSimple> lstECControlEntradaSimple = new List<EControlEntradaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_ControlEntrada_O();
                foreach (var p in Persona)
                {
                    EControlEntradaSimple eControlEntradaSimple = new EControlEntradaSimple
                    {
                        IdControlEntrada = p.IdControlEntrada,
                        IdPersona = p.IdPersona,
                        IdUsuario = p.IdUsuario,
                        FechaHoraEntrada = p.FechaHoraEntrada,
                        FechaHoraSalida = p.FechaHoraSalida,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,



                    };
                    lstECControlEntradaSimple.Add(eControlEntradaSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECControlEntradaSimple;
    }
    #endregion

}