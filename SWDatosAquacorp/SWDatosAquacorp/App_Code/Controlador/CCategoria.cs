using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CCategoria
/// </summary>
public class CCategoria
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Categoria(ECategoriaSimple eCategoriaSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Categoria_I(eCategoriaSimple.NombreCategoria, eCategoriaSimple.FechaRegistro, eCategoriaSimple.FechaModificacion, eCategoriaSimple.Estado);
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
    public void Actualizar_Categoria(ECategoriaSimple eCategoriaSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Categoria_A(eCategoriaSimple.IdCategoria, eCategoriaSimple.NombreCategoria, eCategoriaSimple.FechaRegistro, eCategoriaSimple.FechaModificacion, eCategoriaSimple.Estado);
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
    public ECategoriaSimple Obtener_Categoria_Id_Categoria(byte IdCategoria)
    {
        ECategoriaSimple eCategoriaSimple = new ECategoriaSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Categoria_O_IdCategoria(IdCategoria);
                foreach (var p in Persona)
                {
                    eCategoriaSimple = new ECategoriaSimple
                    {
                        IdCategoria = p.IdCategoria,
                        NombreCategoria = p.NombreCategoria,
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
        return eCategoriaSimple;
    }



    public List<ECategoriaSimple> Obtener_Categoria()
    {
        List<ECategoriaSimple> lstECCategoriaSimple = new List<ECategoriaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Categoria_O();
                foreach (var p in Persona)
                {
                    ECategoriaSimple eCategoriaSimple = new ECategoriaSimple
                    {

                        IdCategoria = p.IdCategoria,
                        NombreCategoria = p.NombreCategoria,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado



                    };
                    lstECCategoriaSimple.Add(eCategoriaSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECCategoriaSimple;
    }
    #endregion
}