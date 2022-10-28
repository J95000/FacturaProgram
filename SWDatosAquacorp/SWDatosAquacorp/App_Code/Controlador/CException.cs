using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
using System.Text;
using System.IO;


/// <summary>
/// Descripción breve de CException
/// </summary>
public class CException : System.Web.UI.Page
{


    #region METODOS PUBLICOS
    public void Insertar_Exception(EExceptionSimple eExceptionSimple)
    {

        using (aquacorpbddEntities db = new aquacorpbddEntities())
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Proc_Exception_I(ObtenerFechaZonaLocal(), eExceptionSimple.IdUsuario, eExceptionSimple.NombreMetodo, eExceptionSimple.Mensaje, eExceptionSimple.ExceptionMensaje);
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LlenadoArchivo(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
                }
            }
        }
    }

    public EExceptionSimple Obtener_Exception_Id_Exception(int IdException)
    {
        EExceptionSimple eExceptionSimple = new EExceptionSimple();
        try
        {

            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Exception_O_IdException(IdException);
                foreach (var p in Persona)
                {
                    eExceptionSimple = new EExceptionSimple
                    {
                        IdException = p.IdException,
                        Fecha = p.Fecha,
                        IdUsuario = p.IdUsuario,
                        NombreMetodo = p.NombreMetodo,
                        Mensaje = p.Mensaje,
                        ExceptionMensaje = p.ExcepcionMensaje

                    };
                }
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }

        return eExceptionSimple;
    }



    public List<EExceptionSimple> Obtener_Exception()
    {
        List<EExceptionSimple> lstECExceptionSimple = new List<EExceptionSimple>();
        try
        {

            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Exception_O();
                foreach (var p in Persona)
                {
                    EExceptionSimple eExceptionSimple = new EExceptionSimple
                    {
                        IdException = p.IdException,
                        Fecha = p.Fecha,
                        IdUsuario = p.IdUsuario,
                        NombreMetodo = p.NombreMetodo,
                        Mensaje = p.Mensaje,
                        ExceptionMensaje = p.ExcepcionMensaje




                    };
                    lstECExceptionSimple.Add(eExceptionSimple);
                }
            }
        }
        catch (Exception ex)
        {

            Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECExceptionSimple;
    }



    public void Insertar_Exception_LocalDatos(EExceptionSimple eExceptionSimple)
    {
        try
        {
            Insertar_Exception(eExceptionSimple);
        }
        catch (Exception ex)
        {
            LlenadoArchivo(new EExceptionSimple() { Fecha = ObtenerFechaZonaLocal(), IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        finally
        {
            LlenadoArchivo(eExceptionSimple);
        }
    }
    public void LlenadoArchivo(EExceptionSimple eExceptionSimple)
    {
        string mes = DateTime.Now.ToString("MMMM");
        string ruta = Server.MapPath("~/LogException/" + mes + ".txt");
        Byte[] eException = new UTF8Encoding(true).GetBytes(Environment.NewLine + ObtenerFechaZonaLocal() + "|" + eExceptionSimple.IdUsuario + "|" + eExceptionSimple.NombreMetodo + "|" + eExceptionSimple.Mensaje + "|" + eExceptionSimple.ExceptionMensaje);
        if (File.Exists(ruta))
        {
            using (FileStream fst = File.Open(ruta, FileMode.Append, FileAccess.Write))
            {
                fst.Write(eException, 0, eException.Length);
            }
        }
        else
        {
            using (FileStream fst = File.Create(ruta))
            {
                fst.Write(eException, 0, eException.Length);
            }

        }
    }
    private DateTime ObtenerFechaZonaLocal()
    {
        try
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Venezuela Standard Time")).ToUniversalTime().ToLocalTime();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return DateTime.Now;
        }
    }
    #endregion
}