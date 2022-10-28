using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CDespido
/// </summary>
public class CDespido
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Despido(EDespidoSimple eDespidoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Despido_I(eDespidoSimple.IdEmpleado, eDespidoSimple.FechaDespido, eDespidoSimple.Motivo, eDespidoSimple.FechaRegistro, eDespidoSimple.FechaModificacion, eDespidoSimple.Estado);
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

    public void Actualizar_Despido(EDespidoSimple eDespidoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Despido_A(eDespidoSimple.IdDespido, eDespidoSimple.IdEmpleado, eDespidoSimple.FechaDespido, eDespidoSimple.Motivo, eDespidoSimple.FechaRegistro, eDespidoSimple.FechaModificacion, eDespidoSimple.Estado);
                    transaction.Commit();
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
                }
            }
    } }
    public EDespidoSimple Obtener_Despido_Id_Empleado(int IdEmpleado)
    {
        EDespidoSimple eDespidoSimple = new EDespidoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Despido_O_IdEmpleado(IdEmpleado);
                foreach (var p in Persona)
                {
                    eDespidoSimple = new EDespidoSimple
                    {
                        IdDespido = p.IdDespido,
                        IdEmpleado = p.IdEmpleado,
                        FechaDespido = p.FechaDespido,
                        Motivo = p.Motivo,
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
        return eDespidoSimple;
    }



    public List<EDespidoSimple> Obtener_Despido()
    {
        List<EDespidoSimple> lstECDespidoSimple = new List<EDespidoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Despido_O();
                foreach (var p in Persona)
                {
                    EDespidoSimple eDespidoSimple = new EDespidoSimple
                    {
                        IdDespido = p.IdDespido,
                        IdEmpleado = p.IdEmpleado,
                        FechaDespido = p.FechaDespido,
                        Motivo = p.Motivo,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado



                    };
                    lstECDespidoSimple.Add(eDespidoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECDespidoSimple;
    }
    #endregion

}