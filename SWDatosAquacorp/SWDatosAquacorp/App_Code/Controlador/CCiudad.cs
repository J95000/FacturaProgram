using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

/// <summary>
/// Descripción breve de CCiudad
/// </summary>
public class CCiudad
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS

    public ECiudadSimple Obtener_Ciudad_Id_Ciudad(byte IdCiudad)
    {
        ECiudadSimple eCiudadSimple = new ECiudadSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Ciudad = db.Proc_Ciudad_O_IdCiudad(IdCiudad);
                foreach (var p in Ciudad)
                {
                    eCiudadSimple = new ECiudadSimple
                    {
                        IdCiudad = p.IdCiudad,
                        NombreCiudad = p.NombreCiudad

                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eCiudadSimple;
    }



    public List<ECiudadSimple> Obtener_Ciudad()
    {
        List<ECiudadSimple> lstECiudadSimple = new List<ECiudadSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Ciudad = db.Proc_Ciudad_O();
                foreach (var p in Ciudad)
                {
                    ECiudadSimple eCiudadSimple = new ECiudadSimple
                    {
                        IdCiudad = p.IdCiudad,
                        NombreCiudad = p.NombreCiudad

                    };
                    lstECiudadSimple.Add(eCiudadSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECiudadSimple;
    }
    #endregion



}