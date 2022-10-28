using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CReferenciaPersonal
/// </summary>
public class CReferenciaPersonal
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_ReferenciaPersonal(EReferenciaPersonalSimple eReferenciaPersonalSimple)
    {
        
            using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_ReferenciaPersonal_I(eReferenciaPersonalSimple.IdEmpleado, eReferenciaPersonalSimple.NombresFamiliar, eReferenciaPersonalSimple.PrimerApellidoFamiliar, eReferenciaPersonalSimple.SegundoApellidoFamiliar, eReferenciaPersonalSimple.Parentesco, eReferenciaPersonalSimple.Direccion, eReferenciaPersonalSimple.Telefono, eReferenciaPersonalSimple.FechaRegistro, eReferenciaPersonalSimple.FechaModificacion, eReferenciaPersonalSimple.Estado);
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

    public void Actualizar_ReferenciaPersonal(EReferenciaPersonalSimple eReferenciaPersonalSimple)
    {
        
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_ReferenciaPersonal_A(eReferenciaPersonalSimple.IdReferenciaPersonal, eReferenciaPersonalSimple.IdEmpleado, eReferenciaPersonalSimple.NombresFamiliar, eReferenciaPersonalSimple.PrimerApellidoFamiliar, eReferenciaPersonalSimple.SegundoApellidoFamiliar, eReferenciaPersonalSimple.Parentesco, eReferenciaPersonalSimple.Direccion, eReferenciaPersonalSimple.Telefono, eReferenciaPersonalSimple.FechaRegistro, eReferenciaPersonalSimple.FechaModificacion, eReferenciaPersonalSimple.Estado);
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
    public EReferenciaPersonalSimple Obtener_ReferenciaPersonal_Id_Empleado(int IdEmpleado)
    {
        EReferenciaPersonalSimple eReferenciaPersonalSimple = new EReferenciaPersonalSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_ReferenciaPersonal_O_IdEmpleado(IdEmpleado);
                foreach (var p in Persona)
                {
                    eReferenciaPersonalSimple = new EReferenciaPersonalSimple
                    {
                        IdReferenciaPersonal = p.IdReferenciaPersonal,

                        IdEmpleado = p.IdEmpleado,
                        NombresFamiliar = p.NombresFamiliar,
                        PrimerApellidoFamiliar = p.PrimerApellidoFamiliar,
                        SegundoApellidoFamiliar = p.SegundoApellidoFamiliar,
                        Parentesco = p.Parentesco,
                        Direccion = p.Direccion,
                        Telefono = p.Telefono,
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
        return eReferenciaPersonalSimple;
    }



    public List<EReferenciaPersonalSimple> Obtener_ReferenciaPersonal()
    {
        List<EReferenciaPersonalSimple> lstECReferenciaPersonalSimple = new List<EReferenciaPersonalSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_ReferenciaPersonal_O();
                foreach (var p in Persona)
                {
                    EReferenciaPersonalSimple eReferenciaPersonalSimple = new EReferenciaPersonalSimple
                    {
                        IdReferenciaPersonal = p.IdReferenciaPersonal,
                        IdEmpleado = p.IdEmpleado,
                        NombresFamiliar = p.NombresFamiliar,
                        PrimerApellidoFamiliar = p.PrimerApellidoFamiliar,
                        SegundoApellidoFamiliar = p.SegundoApellidoFamiliar,
                        Parentesco = p.Parentesco,
                        Direccion = p.Direccion,
                        Telefono = p.Telefono,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado


                    };
                    lstECReferenciaPersonalSimple.Add(eReferenciaPersonalSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECReferenciaPersonalSimple;
    }
    #endregion

}