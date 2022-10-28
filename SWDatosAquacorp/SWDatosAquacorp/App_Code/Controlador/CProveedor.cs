using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CProveedor
/// </summary>
public class CProveedor
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Proveedor(EProveedorSimple eProveedorSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Persona_Proveedor_I(eProveedorSimple.Nombres, eProveedorSimple.PrimerApellido, eProveedorSimple.SegundoApellido, eProveedorSimple.Telefono, eProveedorSimple.Direccion, eProveedorSimple.FechaRegistro, eProveedorSimple.FechaModificacion, eProveedorSimple.Estado, eProveedorSimple.TelefonoRespaldo);
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

    public void Actualizar_Proveedor(EProveedorSimple eProveedorSimple)
    {
        
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Persona_Proveedor_A(eProveedorSimple.IdPersona, eProveedorSimple.Nombres, eProveedorSimple.PrimerApellido, eProveedorSimple.SegundoApellido, eProveedorSimple.Telefono, eProveedorSimple.Direccion, eProveedorSimple.FechaRegistro, eProveedorSimple.FechaModificacion, eProveedorSimple.Estado, eProveedorSimple.IdProveedor, eProveedorSimple.TelefonoRespaldo);
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
    public EProveedorSimple Obtener_Proveedor_Id_Proveedor(int IdProveedor)
    {
        EProveedorSimple eProveedorSimple = new EProveedorSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Persona_Proveedor_O_IdProveedor(IdProveedor);
                foreach (var p in Persona)
                {
                    eProveedorSimple = new EProveedorSimple
                    {
                        IdPersona = p.IdPersona,
                        Nombres = p.Nombres,
                        PrimerApellido = p.PrimerApellido,
                        SegundoApellido = p.SegundoApellido,
                        Telefono = p.Telefono,
                        Direccion = p.Direccion,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,

                        IdProveedor = p.IdProveedor,
                        TelefonoRespaldo = p.TelefonoRespaldo
                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eProveedorSimple;
    }



    public List<EProveedorSimple> Obtener_Proveedor()
    {
        List<EProveedorSimple> lstECProveedorSimple = new List<EProveedorSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Persona_Proveedor_O();
                foreach (var p in Persona)
                {
                    EProveedorSimple eProveedorSimple = new EProveedorSimple
                    {
                        IdPersona = p.IdPersona,
                        Nombres = p.Nombres,
                        PrimerApellido = p.PrimerApellido,
                        SegundoApellido = p.SegundoApellido,
                        Telefono = p.Telefono,
                        Direccion = p.Direccion,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,

                        IdProveedor = p.IdProveedor,
                        TelefonoRespaldo = p.TelefonoRespaldo
                    };
                    lstECProveedorSimple.Add(eProveedorSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECProveedorSimple;
    }
    #endregion

}