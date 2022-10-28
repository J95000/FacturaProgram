using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CExistencia
/// </summary>
public class CExistencia
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Existencia(EExistenciaSimple eExistenciaSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Existencia_I(eExistenciaSimple.TipoExistencia, eExistenciaSimple.Cantidad, eExistenciaSimple.IdProducto, eExistenciaSimple.IdPersona, eExistenciaSimple.IdUsuario, eExistenciaSimple.FechaRegistro, eExistenciaSimple.FechaModificacion, eExistenciaSimple.Estado);
                    transaction.Commit();
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
                }
            }
        } }

    public void Actualizar_Existencia(EExistenciaSimple eExistenciaSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Existencia_A(eExistenciaSimple.IdExistencia, eExistenciaSimple.TipoExistencia, eExistenciaSimple.Cantidad, eExistenciaSimple.IdProducto, eExistenciaSimple.IdPersona, eExistenciaSimple.IdUsuario, eExistenciaSimple.FechaRegistro, eExistenciaSimple.FechaModificacion, eExistenciaSimple.Estado);
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

    public EExistenciaSimple Obtener_Existencia_Id_Existencia(int IdExistencia)
    {
        EExistenciaSimple eExistenciaSimple = new EExistenciaSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Existencia = db.Proc_Existencia_O_IdExistencia(IdExistencia);
                foreach (var e in Existencia)
                {
                    eExistenciaSimple = new EExistenciaSimple
                    {
                        IdExistencia = e.IdExistencia,
                        TipoExistencia = e.TipoExistencia,
                        Cantidad = e.Cantidad,
                        IdProducto = e.IdProducto,
                        IdPersona = e.IdPersona,
                        IdUsuario = e.IdUsuario,
                        FechaRegistro = e.FechaRegistro,
                        FechaModificacion = e.FechaModificacion,
                        Estado = e.Estado
                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eExistenciaSimple;
    }



    public List<EExistenciaSimple> Obtener_Existencia()
    {
        List<EExistenciaSimple> lstEExistenciaSimple = new List<EExistenciaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Existencia = db.Proc_Existencia_O();
                foreach (var e in Existencia)
                {
                    EExistenciaSimple eExistenciaSimple = new EExistenciaSimple
                    {
                        IdExistencia = e.IdExistencia,
                        TipoExistencia = e.TipoExistencia,
                        Cantidad = e.Cantidad,
                        IdProducto = e.IdProducto,
                        IdPersona = e.IdPersona,
                        IdUsuario = e.IdUsuario,
                        FechaRegistro = e.FechaRegistro,
                        FechaModificacion = e.FechaModificacion,
                        Estado = e.Estado

                    };
                    lstEExistenciaSimple.Add(eExistenciaSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEExistenciaSimple;
    }

    public List<ERepExistenciaSimple> Reporte_Existencia(int idProducto, int idPersona,string tipoExistencia, DateTime inicio, DateTime final, int tipo)
    {
        List<ERepExistenciaSimple> lstEExistenciaSimple = new List<ERepExistenciaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Existencia = db.Proc_Reporte_Existencia( idProducto,  idPersona,  tipoExistencia,  inicio,  final,  tipo);
                foreach (var e in Existencia)
                {
                    ERepExistenciaSimple eExistenciaSimple = new ERepExistenciaSimple
                    {
                        Producto = e.Producto,
                        TipoExistencia = e.Movimiento,
                        Cantidad = e.Cantidad,
                        NombrePersonal = e.NombrePersonal,
                        Fecha = (DateTime)e.Fecha,
                        FechaInicio = (DateTime)e.FechaInicio,
                        FechaFinal= (DateTime)e.FechaFinal,
                        Tipo= (int)e.Tipo
                    };
                    lstEExistenciaSimple.Add(eExistenciaSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEExistenciaSimple;
    }
    public List<ERepExistenciaSimple> Reporte_Existencia_Nuevo(int idProducto, int idPersona, string tipoExistencia, DateTime inicio, DateTime final, int tipo)
    {
        List<ERepExistenciaSimple> lstEExistenciaSimple = new List<ERepExistenciaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Existencia = db.Proc_Reporte_Existencia_Nuevo(idProducto, idPersona, tipoExistencia, inicio, final, tipo);
                foreach (var e in Existencia)
                {
                    ERepExistenciaSimple eExistenciaSimple = new ERepExistenciaSimple
                    {
                        Producto = e.Producto,
                        TipoExistencia = e.Movimiento,
                        Cantidad = e.Cantidad,
                        NombrePersonal = e.NombrePersonal,
                        Fecha = (DateTime)e.Fecha,
                        FechaInicio = (DateTime)e.FechaInicio,
                        FechaFinal = (DateTime)e.FechaFinal,
                        Tipo = (int)e.Tipo
                    };
                    lstEExistenciaSimple.Add(eExistenciaSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEExistenciaSimple;
    }
    public List<EArqueoExistenciaSimple> Arqueo_Existencia( int idUsuario,   DateTime fecha,   string tipoExistencia)
    {
        List<EArqueoExistenciaSimple> lstEArqueoExistenciaSimple = new List<EArqueoExistenciaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Existencia = db.Proc_Existencia_O_IdUsuario_Fecha_TipoExistencia(idUsuario,  fecha,  tipoExistencia);
                foreach (var e in Existencia)
                {
                    EArqueoExistenciaSimple eEArqueoExistenciaSimple = new EArqueoExistenciaSimple
                    {
                        Cont = (int)e.Cont,
                    IdExistencia =e.IdExistencia,
                    TipoExistencia = e.TipoExistencia,
                    Cantidad = e.Cantidad,
                    IdProducto = e.IdProducto,
                    NombreProducto = e.NombreProducto,
                    IdPersona = e.IdPersona,
                    NombreCompletoPersonaRegistra = e.NombreCompletoPersonaRegistra,
                    IdUsuario = e.IdUsuario,
                    NombreCompletoUsuarioValida = e.NombreCompletoUsuarioValida,
                    FechaRegistro =e.FechaRegistro,
                    FechaModificacion = e.FechaModificacion,
                    Estado = e.Estado
                };
                    lstEArqueoExistenciaSimple.Add(eEArqueoExistenciaSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstEArqueoExistenciaSimple;
    }
    #endregion

}