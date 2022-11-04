using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CDireccionMovimiento
/// </summary>
public class CDireccionMovimiento
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_DireccionMovimiento(EDireccionMovimientoSimple eDireccionMovimientoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_DireccionMovimiento_I(eDireccionMovimientoSimple.IdDireccion, eDireccionMovimientoSimple.IdMovimiento);
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
    public void Actualizar_DireccionMovimiento(EDireccionMovimientoSimple eDireccionMovimientoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_DireccionMovimiento_A(eDireccionMovimientoSimple.IdDireccionMovimiento, eDireccionMovimientoSimple.IdDireccion, eDireccionMovimientoSimple.IdMovimiento);
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
    public EDireccionMovimientoSimple Obtener_DireccionMovimiento_Id_DireccionMovimiento(int IdMovimiento)
    {
        EDireccionMovimientoSimple eDireccionMovimientoSimple = new EDireccionMovimientoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_DireccionMovimiento_O_IdMovimiento(IdMovimiento);
                foreach (var p in Persona)
                {
                    eDireccionMovimientoSimple = new EDireccionMovimientoSimple
                    {
                        IdDireccionMovimiento = p.IdDireccionMovimiento,
                      IdDireccion=p.IdDireccion,
                      IdMovimiento=p.IdMovimiento


                    };
                }
            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eDireccionMovimientoSimple;
    }



    public List<EDireccionMovimientoSimple> Obtener_DireccionMovimiento()
    {
        List<EDireccionMovimientoSimple> lstECDireccionMovimientoSimple = new List<EDireccionMovimientoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_DireccionMovimiento_O();
                foreach (var p in Persona)
                {
                    EDireccionMovimientoSimple eDireccionMovimientoSimple = new EDireccionMovimientoSimple
                    {
                        IdDireccionMovimiento = p.IdDireccionMovimiento,
                        IdDireccion = p.IdDireccion,
                        IdMovimiento = p.IdMovimiento



                    };
                    lstECDireccionMovimientoSimple.Add(eDireccionMovimientoSimple);
                }
            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECDireccionMovimientoSimple;
    }
    #endregion
}