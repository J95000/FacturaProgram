using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CHabilidad
/// </summary>
public class CHabilidad
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Habilidad(EHabilidadSimple eHabilidadSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Habilidad_I(eHabilidadSimple.IdEmpleado, eHabilidadSimple.TipoHabilidad, eHabilidadSimple.Detalle, eHabilidadSimple.FechaRegistro, eHabilidadSimple.FechaModificacion, eHabilidadSimple.Estado);
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

    public void Actualizar_Habilidad(EHabilidadSimple eHabilidadSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Habilidad_A(eHabilidadSimple.IdHabilidad, eHabilidadSimple.IdEmpleado, eHabilidadSimple.TipoHabilidad, eHabilidadSimple.Detalle, eHabilidadSimple.FechaRegistro, eHabilidadSimple.FechaModificacion, eHabilidadSimple.Estado);
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
    public EHabilidadSimple Obtener_Habilidad_Id_Empleado(int IdEmpleado)
    {
        EHabilidadSimple eHabilidadSimple = new EHabilidadSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Habilidad_O_IdEmpleado(IdEmpleado);
                foreach (var p in Persona)
                {
                    eHabilidadSimple = new EHabilidadSimple
                    {
                        IdHabilidad = p.IdHabilidad,
                        IdEmpleado = p.IdEmpleado,
                        TipoHabilidad = p.TipoHabilidad,
                        Detalle = p.Detalle,
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
        return eHabilidadSimple;
    }



    public List<EHabilidadSimple> Obtener_Habilidad()
    {
        List<EHabilidadSimple> lstECHabilidadSimple = new List<EHabilidadSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Habilidad_O();
                foreach (var p in Persona)
                {
                    EHabilidadSimple eHabilidadSimple = new EHabilidadSimple
                    {
                        IdHabilidad = p.IdHabilidad,
                        IdEmpleado = p.IdEmpleado,
                        TipoHabilidad = p.TipoHabilidad,
                        Detalle = p.Detalle,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado



                    };
                    lstECHabilidadSimple.Add(eHabilidadSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECHabilidadSimple;
    }
    #endregion

}