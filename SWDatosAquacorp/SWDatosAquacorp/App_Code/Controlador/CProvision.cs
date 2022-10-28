using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CProvision
/// </summary>
public class CProvision
{

    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Provision(EProvisionSimple eProvisionSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Provision_I(eProvisionSimple.IdProveedor, eProvisionSimple.IdMateriaPrima, eProvisionSimple.CantidadProvision, eProvisionSimple.FechaRegistro, eProvisionSimple.FechaModificacion, eProvisionSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public void Actualizar_Provision(EProvisionSimple eProvisionSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Provision_A(eProvisionSimple.IdProvision, eProvisionSimple.IdProveedor, eProvisionSimple.IdMateriaPrima, eProvisionSimple.CantidadProvision, eProvisionSimple.FechaRegistro, eProvisionSimple.FechaModificacion, eProvisionSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public EProvisionSimple Obtener_Provision_IdProvision(int IdProvision)
    {
        EProvisionSimple eProvisionSimple = new EProvisionSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var obje = db.Proc_Provision_O_IdProvision(IdProvision);
                foreach (var obj in obje)
                {
                    eProvisionSimple = new EProvisionSimple
                    {
                        IdProvision = obj.IdProvision
                    ,
                        IdProveedor = obj.IdProveedor
                    ,
                        IdMateriaPrima = obj.IdMateriaPrima
                    ,
                        CantidadProvision = obj.CantidadProvision
                    ,
                        FechaRegistro = obj.FechaRegistro
                    ,
                        FechaModificacion = obj.FechaModificacion
                    ,
                        Estado = obj.Estado
                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eProvisionSimple;
    }

    public List<EProvisionSimple> Obtener_Provision()
    {
        List<EProvisionSimple> lstEProvisionSimple = new List<EProvisionSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var obje = db.Proc_Provision_O();
                foreach (var obj in obje)
                {
                    EProvisionSimple eProvisionSimple = new EProvisionSimple
                    {
                        IdProvision = obj.IdProvision
                    ,
                        IdProveedor = obj.IdProveedor
                    ,
                        IdMateriaPrima = obj.IdMateriaPrima
                    ,
                        CantidadProvision = obj.CantidadProvision
                    ,
                        FechaRegistro = obj.FechaRegistro
                    ,
                        FechaModificacion = obj.FechaModificacion
                    ,
                        Estado = obj.Estado
                    };
                    lstEProvisionSimple.Add(eProvisionSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEProvisionSimple;
    }

    #endregion
}
