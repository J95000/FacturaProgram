using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CArticulo
/// </summary>
public class CArticulo
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Articulo(EArticuloSimple eArticuloSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Articulo_I(eArticuloSimple.IdCategoria, eArticuloSimple.IdUsuario, eArticuloSimple.Titulo, eArticuloSimple.Descripcion, eArticuloSimple.Contenido, eArticuloSimple.Imagen, eArticuloSimple.FechaRegistro, eArticuloSimple.FechaModificacion, eArticuloSimple.Estado);
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
    public void Actualizar_Articulo(EArticuloSimple eArticuloSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Articulo_A(eArticuloSimple.IdArticulo, eArticuloSimple.IdCategoria, eArticuloSimple.IdUsuario, eArticuloSimple.Titulo, eArticuloSimple.Descripcion, eArticuloSimple.Contenido, eArticuloSimple.Imagen, eArticuloSimple.FechaRegistro, eArticuloSimple.FechaModificacion, eArticuloSimple.Estado);
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
    public EArticuloSimple Obtener_Articulo_Id_Articulo(int IdArticulo)
    {
        EArticuloSimple eArticuloSimple = new EArticuloSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Articulo_O_IdArticulo(IdArticulo);
                foreach (var p in Persona)
                {
                    eArticuloSimple = new EArticuloSimple
                    {
                        IdArticulo = p.IdArticulo,
                        IdCategoria = p.IdCategoria,
                        IdUsuario = p.IdUsuario,
                        Titulo = p.Titulo,
                        Contenido = p.Contenido,
                        Descripcion = p.Descripcion,
                        Imagen = p.Imagen,
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
        return eArticuloSimple;
    }



    public List<EArticuloSimple> Obtener_Articulo()
    {
        List<EArticuloSimple> lstECArticuloSimple = new List<EArticuloSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Articulo_O();
                foreach (var p in Persona)
                {
                    EArticuloSimple eArticuloSimple = new EArticuloSimple
                    {
                        IdArticulo = p.IdArticulo,
                        IdCategoria = p.IdCategoria,
                        IdUsuario = p.IdUsuario,
                        Titulo = p.Titulo,
                        Descripcion = p.Descripcion,
                        Contenido = p.Contenido,
                        Imagen = p.Imagen,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado



                    };
                    lstECArticuloSimple.Add(eArticuloSimple);
                }
            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECArticuloSimple;
    }
    #endregion
}