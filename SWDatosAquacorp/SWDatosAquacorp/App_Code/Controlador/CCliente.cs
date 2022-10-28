using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CCliente
/// </summary>
public class CCliente
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Cliente(EClienteSimple eClienteSimple)
    {

        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Persona_Cliente_I(eClienteSimple.Nombres, eClienteSimple.PrimerApellido, eClienteSimple.SegundoApellido, eClienteSimple.Telefono, eClienteSimple.Direccion, eClienteSimple.FechaRegistro, eClienteSimple.FechaModificacion, eClienteSimple.Estado, eClienteSimple.IdCategoriaCliente, eClienteSimple.CorreoElectronico, eClienteSimple.Latitud, eClienteSimple.Longitud, eClienteSimple.IdZona, eClienteSimple.FotoUbicacion, eClienteSimple.Contrato);

            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }

    }

    public void Actualizar_Cliente(EClienteSimple eClienteSimple)
    {


        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {

                db.Proc_Persona_Cliente_A(eClienteSimple.IdPersona, eClienteSimple.Nombres, eClienteSimple.PrimerApellido, eClienteSimple.SegundoApellido, eClienteSimple.Telefono, eClienteSimple.Direccion, eClienteSimple.FechaRegistro, eClienteSimple.FechaModificacion, eClienteSimple.Estado, eClienteSimple.IdCliente, eClienteSimple.IdCategoriaCliente, eClienteSimple.CorreoElectronico, eClienteSimple.Latitud, eClienteSimple.Longitud, eClienteSimple.IdZona, eClienteSimple.FotoUbicacion, eClienteSimple.Contrato);
            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }

    }
    public EClienteSimple Obtener_Cliente_Id_Cliente(int IdCliente)
    {
        EClienteSimple eClienteSimple = new EClienteSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Persona_Cliente_O_IdCliente(IdCliente);
                foreach (var p in Persona)
                {
                    eClienteSimple = new EClienteSimple
                    {
                        IdPersona = p.IdPersona,
                        Nombres = p.Nombres,
                        PrimerApellido = p.PrimerApellido,
                        SegundoApellido = p.SegundoApellido,
                        Telefono = p.Telefono,
                        Direccion = p.Direccion,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,

                        IdCliente = p.IdCliente,
                        IdCategoriaCliente = p.IdCategoriaCliente,
                        CorreoElectronico = p.CorreoElectronico,
                        Latitud = p.Latitud,
                        Longitud = p.Longitud,
                        IdZona = p.IdZona
                        ,
                        FotoUbicacion = p.FotoUbicacion
                        ,
                        Contrato = p.Contrato
                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eClienteSimple;
    }



    public List<EClienteSimple> Obtener_Cliente()
    {
        List<EClienteSimple> lstECClienteSimple = new List<EClienteSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Persona_Cliente_O();
                foreach (var p in Persona)
                {
                    EClienteSimple eClienteSimple = new EClienteSimple
                    {
                        IdPersona = p.IdPersona,
                        Nombres = p.Nombres,
                        PrimerApellido = p.PrimerApellido,
                        SegundoApellido = p.SegundoApellido,
                        Telefono = p.Telefono,
                        Direccion = p.Direccion,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,

                        IdCliente = p.IdCliente,
                        IdCategoriaCliente = p.IdCategoriaCliente,
                        CorreoElectronico = p.CorreoElectronico,
                        Latitud = p.Latitud,
                        Longitud = p.Longitud,
                        IdZona = p.IdZona,

                        Contrato = p.Contrato
                    };
                    lstECClienteSimple.Add(eClienteSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECClienteSimple;
    }

    public List<EClienteSimple> Obtener_Cliente_Buscador(string nombre)
    {
        List<EClienteSimple> lstECClienteSimple = new List<EClienteSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Persona_Cliente_O_Buscador(nombre);
                foreach (var p in Persona)
                {
                    EClienteSimple eClienteSimple = new EClienteSimple
                    {
                        IdPersona = p.IdPersona,
                        Nombres = p.Nombres,
                        PrimerApellido = p.PrimerApellido,
                        SegundoApellido = p.SegundoApellido,
                        Telefono = p.Telefono,
                        Direccion = p.Direccion,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado,

                        IdCliente = p.IdCliente,
                        IdCategoriaCliente = p.IdCategoriaCliente,
                        CorreoElectronico = p.CorreoElectronico,
                        Latitud = p.Latitud,
                        Longitud = p.Longitud,
                        IdZona = p.IdZona,
                        FotoUbicacion = p.FotoUbicacion,
                        Contrato = p.Contrato
                    };
                    lstECClienteSimple.Add(eClienteSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECClienteSimple;
    }
    #endregion

}