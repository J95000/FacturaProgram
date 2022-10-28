using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CReferenciaLaboral
/// </summary>
public class CReferenciaLaboral
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_ReferenciaLaboral(EReferenciaLaboralSimple eReferenciaLaboralSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_ReferenciaLaboral_I(eReferenciaLaboralSimple.IdEmpleado, eReferenciaLaboralSimple.NombreEmpresa, eReferenciaLaboralSimple.NombresJefe, eReferenciaLaboralSimple.PrimerApellidoJefe, eReferenciaLaboralSimple.SegundoApellidoJefe, eReferenciaLaboralSimple.TiempoTrabajo, eReferenciaLaboralSimple.FuncionTrabajo, eReferenciaLaboralSimple.FechaRegistro, eReferenciaLaboralSimple.FechaModificacion, eReferenciaLaboralSimple.Estado);
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

    public void Actualizar_ReferenciaLaboral(EReferenciaLaboralSimple eReferenciaLaboralSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_ReferenciaLaboral_A(eReferenciaLaboralSimple.IdReferenciaLaboral, eReferenciaLaboralSimple.IdEmpleado, eReferenciaLaboralSimple.NombreEmpresa, eReferenciaLaboralSimple.NombresJefe, eReferenciaLaboralSimple.PrimerApellidoJefe, eReferenciaLaboralSimple.SegundoApellidoJefe, eReferenciaLaboralSimple.TiempoTrabajo, eReferenciaLaboralSimple.FuncionTrabajo, eReferenciaLaboralSimple.FechaRegistro, eReferenciaLaboralSimple.FechaModificacion, eReferenciaLaboralSimple.Estado);
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
    public EReferenciaLaboralSimple Obtener_ReferenciaLaboral_Id_Empleado(int IdEmpleado)
    {
        EReferenciaLaboralSimple eReferenciaLaboralSimple = new EReferenciaLaboralSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_ReferenciaLaboral_O_IdEmpleado(IdEmpleado);
                foreach (var p in Persona)
                {
                    eReferenciaLaboralSimple = new EReferenciaLaboralSimple
                    {
                        IdReferenciaLaboral = p.IdReferenciaLaboral,

                        IdEmpleado = p.IdEmpleado,
                        NombreEmpresa = p.NombreEmpresa,
                        NombresJefe = p.NombresJefe,
                        PrimerApellidoJefe = p.PrimerApellidoJefe,
                        SegundoApellidoJefe = p.SegundoApellidoJefe,
                        TiempoTrabajo = p.TiempoTrabajo,
                        FuncionTrabajo = p.FuncionTrabajo,
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
        return eReferenciaLaboralSimple;
    }



    public List<EReferenciaLaboralSimple> Obtener_ReferenciaLaboral()
    {
        List<EReferenciaLaboralSimple> lstECReferenciaLaboralSimple = new List<EReferenciaLaboralSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_ReferenciaLaboral_O();
                foreach (var p in Persona)
                {
                    EReferenciaLaboralSimple eReferenciaLaboralSimple = new EReferenciaLaboralSimple
                    {
                        IdReferenciaLaboral = p.IdReferenciaLaboral,

                        IdEmpleado = p.IdEmpleado,
                        NombreEmpresa = p.NombreEmpresa,
                        NombresJefe = p.NombresJefe,
                        PrimerApellidoJefe = p.PrimerApellidoJefe,
                        SegundoApellidoJefe = p.SegundoApellidoJefe,
                        TiempoTrabajo = p.TiempoTrabajo,
                        FuncionTrabajo = p.FuncionTrabajo,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado



                    };
                    lstECReferenciaLaboralSimple.Add(eReferenciaLaboralSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECReferenciaLaboralSimple;
    }
    #endregion

}