using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

/// <summary>
/// Descripción breve de CTipoGasto
/// </summary>
public class CTipoGasto
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_TipoGasto(ETipoGastoSimple eTipoGastoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var tansaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_TipoGasto_I(eTipoGastoSimple.NombreTipoGasto, eTipoGastoSimple.Tipo, eTipoGastoSimple.FechaRegistro, eTipoGastoSimple.FechaModificacion, eTipoGastoSimple.Estado);

                    tansaction.Commit();

                }
                catch (Exception ex)
                {
                    tansaction.Rollback();
                    cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
                }
            }
        }
    }

    public void Actualizar_TipoGasto(ETipoGastoSimple eTipoGastoSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var tansaction = db.Database.BeginTransaction())
            {

                try
                {
                    db.Proc_TipoGasto_A(eTipoGastoSimple.IdTipoGasto, eTipoGastoSimple.NombreTipoGasto, eTipoGastoSimple.Tipo, eTipoGastoSimple.FechaRegistro, eTipoGastoSimple.FechaModificacion, eTipoGastoSimple.Estado);
                    tansaction.Commit();
                }
                catch (Exception ex)
                {
                    tansaction.Rollback();
                    cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
                }
            }
        }
    }
    public ETipoGastoSimple Obtener_TipoGasto_Id_TipoGasto(byte IdTipoGasto)
    {
        ETipoGastoSimple eTipoGastoSimple = new ETipoGastoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_TipoGasto_O_IdTipoGasto(IdTipoGasto);
                foreach (var p in Persona)
                {
                    eTipoGastoSimple = new ETipoGastoSimple
                    {
                        IdTipoGasto = p.IdTipoGasto,
                        NombreTipoGasto = p.NombreTipoGasto,
                        Tipo=p.Tipo,
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
        return eTipoGastoSimple;
    }



    public List<ETipoGastoSimple> Obtener_TipoGasto()
    {
        List<ETipoGastoSimple> lstECTipoGastoSimple = new List<ETipoGastoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_TipoGasto_O();
                foreach (var p in Persona)
                {
                    ETipoGastoSimple eTipoGastoSimple = new ETipoGastoSimple
                    {
                        IdTipoGasto = p.IdTipoGasto,
                        NombreTipoGasto = p.NombreTipoGasto,
                        Tipo = p.Tipo,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,



                    };
                    lstECTipoGastoSimple.Add(eTipoGastoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECTipoGastoSimple;
    }
    #endregion


}