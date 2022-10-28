using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CMaterial
/// </summary>
public class CMaterial
{

    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Material(EMaterialSimple eMaterialSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Material_I(eMaterialSimple.IdProveedor, eMaterialSimple.IdMateriaPrima, eMaterialSimple.FechaRegistro, eMaterialSimple.FechaModificacion, eMaterialSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public void Actualizar_Material(EMaterialSimple eMaterialSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Material_A(eMaterialSimple.IdMaterial, eMaterialSimple.IdProveedor, eMaterialSimple.IdMateriaPrima, eMaterialSimple.FechaRegistro, eMaterialSimple.FechaModificacion, eMaterialSimple.Estado);
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public EMaterialSimple Obtener_Material_IdMaterial(int IdMaterial)
    {
        EMaterialSimple eMaterialSimple = new EMaterialSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var obje = db.Proc_Material_O_IdMaterial(IdMaterial);
                foreach (var obj in obje)
                {
                    eMaterialSimple = new EMaterialSimple
                    {
                        IdMaterial = obj.IdMaterial
                    ,
                        IdProveedor = obj.IdProveedor
                    ,
                        IdMateriaPrima = obj.IdMateriaPrima
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
        return eMaterialSimple;
    }

    public List<EMaterialSimple> Obtener_Material()
    {
        List<EMaterialSimple> lstEMaterialSimple = new List<EMaterialSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var obje = db.Proc_Material_O();
                foreach (var obj in obje)
                {
                    EMaterialSimple eMaterialSimple = new EMaterialSimple
                    {
                        IdMaterial = obj.IdMaterial
                    ,
                        IdProveedor = obj.IdProveedor
                    ,
                        IdMateriaPrima = obj.IdMateriaPrima
                    ,
                        FechaRegistro = obj.FechaRegistro
                    ,
                        FechaModificacion = obj.FechaModificacion
                    ,
                        Estado = obj.Estado
                    };
                    lstEMaterialSimple.Add(eMaterialSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEMaterialSimple;
    }

    #endregion
}
