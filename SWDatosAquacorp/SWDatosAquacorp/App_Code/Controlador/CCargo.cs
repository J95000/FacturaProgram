using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CCargo
/// </summary>
public class CCargo
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Cargo(ECargoSimple eCargoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Cargo_I(eCargoSimple.NombreCargo, eCargoSimple.FechaRegistro, eCargoSimple.FechaModificacion, eCargoSimple.Estado);
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

    public void Actualizar_Cargo(ECargoSimple eCargoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Cargo_A(eCargoSimple.IdCargo, eCargoSimple.NombreCargo, eCargoSimple.FechaRegistro, eCargoSimple.FechaModificacion, eCargoSimple.Estado);
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
    public ECargoSimple Obtener_Cargo_Id_Cargo(byte IdCargo)
    {
        ECargoSimple eCargoSimple = new ECargoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Cargo_O_IdCargo(IdCargo);
                foreach (var p in Persona)
                {
                    eCargoSimple = new ECargoSimple
                    {
                        IdCargo = p.IdCargo,
                        NombreCargo = p.NombreCargo,
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
        return eCargoSimple;
    }



    public List<ECargoSimple> Obtener_Cargo()
    {
        List<ECargoSimple> lstECCargoSimple = new List<ECargoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Cargo_O();
                foreach (var p in Persona)
                {
                    ECargoSimple eCargoSimple = new ECargoSimple
                    {
                        IdCargo = p.IdCargo,
                        NombreCargo = p.NombreCargo,

                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,



                    };
                    lstECCargoSimple.Add(eCargoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECCargoSimple;
    }
    #endregion

}