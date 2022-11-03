using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

/// <summary>
/// Descripción breve de CPersona
/// </summary>
/// 


public class CPersona
{
   private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Persona(EPersonaSimple ePersonaSimple)
    {



        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Persona_I(
                    ePersonaSimple.Nombres, 
                    ePersonaSimple.PrimerApellido,
                    ePersonaSimple.SegundoApellido,
                    ePersonaSimple.Telefono,
                    ePersonaSimple.FechaRegistro, 
                    ePersonaSimple.FechaModificacion, 
                    ePersonaSimple.Estado);

            }
        }

        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
           
 
      
    }
    public void Actualizar_Persona(EPersonaSimple ePersonaSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Persona_A(
                    ePersonaSimple.IdPersona, 
                    ePersonaSimple.Nombres, 
                    ePersonaSimple.PrimerApellido, 
                    ePersonaSimple.SegundoApellido, 
                    ePersonaSimple.Telefono, 
                    ePersonaSimple.FechaRegistro,
                    ePersonaSimple.FechaModificacion, 
                    ePersonaSimple.Estado);
               
            }
        }
        catch (Exception ex)
        {
        
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
           
    }
    public EPersonaSimple Obtener_Persona_Id_Persona(int Id_Persona)
    {
        EPersonaSimple ePersonaSimple = new EPersonaSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Persona_O_IdPersona(Id_Persona);
                foreach (var p in Persona)
                {
                    ePersonaSimple = new EPersonaSimple
                    {
                        IdPersona = p.IdPersona,
                        Nombres = p.Nombres,
                        PrimerApellido = p.PrimerApellido,
                        SegundoApellido = p.SegundoApellido,
                        Telefono = p.Telefono,
                        Direccion = p.Direccion,
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
        return ePersonaSimple;
    }
    public List<EPersonaSimple> Obtener_Persona()
    {
        List<EPersonaSimple> lstECPersonaSimple = new List<EPersonaSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Persona_O();
                foreach (var p in Persona)
                {
                    EPersonaSimple ePersonaSimple = new EPersonaSimple
                    {
                        IdPersona = p.IdPersona,
                        Nombres = p.Nombres,
                        PrimerApellido = p.PrimerApellido,
                        SegundoApellido = p.SegundoApellido,
                        Telefono = p.Telefono,
                        Direccion = p.Direccion,
                        FechaRegistro = p.FechaRegistro,
                        FechaModificacion = p.FechaModificacion,
                        Estado = p.Estado
                    };
                    lstECPersonaSimple.Add(ePersonaSimple);
                }
            }
        }
        catch (Exception ex)
        {
           cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECPersonaSimple;
    }
    public int Obtener_Ultimo_Id_Empleado()
    {
        int idPersona = 0;
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var ids = db.Proc_Ultimo_IdPersonal_O();
                foreach (int itemd in ids)
                {
                    idPersona = itemd;
                }
                //idPersona = int.Parse(ids.ToString());
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return idPersona;
    }

    public int Obtener_Ultimo_Id(string nombreTabla, string nombreId)
    {
        int idPersona = 0;
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var idss = db.Proc_Ultimo_Id(nombreTabla, nombreId);
                //foreach (int itemd in idss)
                //{
                //    idPersona = idss;
                //}
                idPersona = int.Parse(idss.ToString());
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return idPersona;
    }
    #endregion

}