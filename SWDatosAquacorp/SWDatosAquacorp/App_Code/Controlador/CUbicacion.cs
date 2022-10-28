using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
/// <summary>
/// Descripción breve de CUbicacion
/// </summary>
public class CUbicacion
{
    private readonly CException cException = new CException();
    public void Insertar_Ubicacion(EUbicacionSimple eUbicacionSimple)
    {
        try
        {

            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {



                db.Proc_Ubicacion_I(eUbicacionSimple.NombreCelu, eUbicacionSimple.Latitud, eUbicacionSimple.Longitud, eUbicacionSimple.Fecha);


            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public void Insertar_UbicacionDistribuidor(EUbicacionDistribuidorSimple eUbicacionSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_UbicacionDistribuidor_I(eUbicacionSimple.IdUsuario, eUbicacionSimple.NombreDispositivo, eUbicacionSimple.Latitud, eUbicacionSimple.Longitud, eUbicacionSimple.Fecha);

            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
    }

    public EUbicacionDistribuidorSimple Obtener_UbicacionDistribuidor_IdUsuario(int IdUsuario)
    {
        EUbicacionDistribuidorSimple eUbicacionDistribuidorSimple = new EUbicacionDistribuidorSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
               var dis= db.Proc_UbicacionDistribuidor_O_IdUsuario(IdUsuario);
                foreach (var u in dis)
                {
                    eUbicacionDistribuidorSimple = new EUbicacionDistribuidorSimple() { 
                    IdUbicacion=u.IdUbicacion,
                    IdUsuario=u.IdUsuario,
                    NombreCompleto=u.NombreCompleto,
                    NombreDispositivo=u.NombreDispositivo,
                    Latitud=u.Latitud,
                    Longitud=u.Longitud,
                    Fecha=u.Fecha
                    };


                }
            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eUbicacionDistribuidorSimple;
    }
}