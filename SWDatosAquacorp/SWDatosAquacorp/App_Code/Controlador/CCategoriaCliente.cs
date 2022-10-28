using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CCategoriaCliente
/// </summary>
public class CCategoriaCliente
{

    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_CategoriaCliente(ECategoriaClienteSimple eCategoriaClienteSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_CategoriaCliente_I(eCategoriaClienteSimple.NombreCategoriaCliente, eCategoriaClienteSimple.FechaRegistro, eCategoriaClienteSimple.FechaModificacion, eCategoriaClienteSimple.Estado);
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
    public void Actualizar_CategoriaCliente(ECategoriaClienteSimple eCategoriaClienteSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_CategoriaCliente_A(eCategoriaClienteSimple.IdCategoriaCliente, eCategoriaClienteSimple.NombreCategoriaCliente, eCategoriaClienteSimple.FechaRegistro, eCategoriaClienteSimple.FechaModificacion, eCategoriaClienteSimple.Estado);
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
    public ECategoriaClienteSimple Obtener_CategoriaCliente_Id_CategoriaCliente(byte IdCategoriaCliente)
    {
        ECategoriaClienteSimple eCategoriaClienteSimple = new ECategoriaClienteSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_CategoriaCliente_O_IdCategoriaCliente(IdCategoriaCliente);
                foreach (var p in Persona)
                {
                    eCategoriaClienteSimple = new ECategoriaClienteSimple
                    {
                        IdCategoriaCliente = p.IdCategoriaCliente,
                        NombreCategoriaCliente = p.NombreCategoriaCliente,
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
        return eCategoriaClienteSimple;
    }



    public List<ECategoriaClienteSimple> Obtener_CategoriaCliente()
    {
        List<ECategoriaClienteSimple> lstECCategoriaClienteSimple = new List<ECategoriaClienteSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_CategoriaCliente_O();
                foreach (var p in Persona)
                {
                    ECategoriaClienteSimple eCategoriaClienteSimple = new ECategoriaClienteSimple
                    {
                        IdCategoriaCliente = p.IdCategoriaCliente,
                        NombreCategoriaCliente = p.NombreCategoriaCliente,

                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,



                    };
                    lstECCategoriaClienteSimple.Add(eCategoriaClienteSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECCategoriaClienteSimple;
    }
    #endregion


}