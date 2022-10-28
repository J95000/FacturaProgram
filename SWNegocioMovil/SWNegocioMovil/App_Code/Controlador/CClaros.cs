using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de CClaros
/// </summary>
public class CClaros
{
    private AAquaCorp aAquacorp;
    public CClaros()
    {
        try
        {
            aAquacorp = new AAquaCorp();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
    }


    #region ACCESO

    public bool Acceso_Ci_Contrasena_Async(string ci, string contrasena)
    {
        bool resultado = false;
        List<SWDatos.EEmpleadoSimple> lstEEmpleadoSimple = new List<SWDatos.EEmpleadoSimple>();
        SWDatos.EEmpleadoSimple eEmpleadoSimple = new SWDatos.EEmpleadoSimple();
        SWDatos.EUsuarioSimple eUsuarioSimple = new SWDatos.EUsuarioSimple();
        try
        {
            lstEEmpleadoSimple = aAquacorp.Obtener_Empleado();
            eEmpleadoSimple = lstEEmpleadoSimple.First(t => t.Ci == ci);
            eUsuarioSimple = aAquacorp.Obtener_Usuario_Id_Usuario(eEmpleadoSimple.IdPersona);
            if (eUsuarioSimple.Contrasena == GetSHA256(contrasena)) resultado = true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            resultado = false;
        }
        return resultado;
    }

    public EUsuarioCortaCompleja Acceso_Ci_Contrasena_Usuario_Async(string ci, string contrasena)
    {
        EUsuarioCompleja eUsuarioCompleja = new EUsuarioCompleja();
        EUsuarioCortaCompleja eUsuarioCortaCompleja = new EUsuarioCortaCompleja();
        List<SWDatos.EEmpleadoSimple> lstEEmpleadoSimple = new List<SWDatos.EEmpleadoSimple>();
        SWDatos.EEmpleadoSimple eEmpleadoSimple = new SWDatos.EEmpleadoSimple();
        SWDatos.EUsuarioSimple eUsuarioSimple = new SWDatos.EUsuarioSimple();
        try
        {
            lstEEmpleadoSimple = aAquacorp.Obtener_Empleado();
            eEmpleadoSimple = lstEEmpleadoSimple.First(t => t.Ci == ci);
            eUsuarioSimple = aAquacorp.Obtener_Usuario_Id_Usuario(eEmpleadoSimple.IdPersona);
            if (eUsuarioSimple.Contrasena == GetSHA256(contrasena))
            {
                eUsuarioCompleja = Obtener_Empleado_Id_Empleado_Async(ci);
                eUsuarioCortaCompleja = new EUsuarioCortaCompleja() { 
                IdUsuario= eUsuarioCompleja.IdUsuario,
                NombreCompleto= eUsuarioCompleja.NombreCompleto,
                Cargo= eUsuarioCompleja.Cargo
                };
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
           
        }
        return eUsuarioCortaCompleja;
    }
    public bool Restablecer_Contrasena_Usuario(string contrasena, int idUsuario)
    {

        try
        {
            SWDatos.EUsuarioSimple eUsuarioSimpleMod = aAquacorp.Obtener_Usuario_Id_Usuario(idUsuario);

            SWDatos.EUsuarioSimple eUsuarioSimple = new SWDatos.EUsuarioSimple()
            {
                IdUsuario = eUsuarioSimpleMod.IdUsuario,
                Contrasena = GetSHA256(contrasena),
                FechaRegistro = eUsuarioSimpleMod.FechaRegistro,
                FechaModificacion = eUsuarioSimpleMod.FechaModificacion,
                Estado = eUsuarioSimpleMod.Estado

            };
            aAquacorp.Actualizar_Usuario(eUsuarioSimple);
            return true;

        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }
    }
    #endregion

    #region EXCEPCION

    public void Insertar_Exception_LocalDatos(EExceptionCompleja eExceptionCompleja)
    {

        SWDatos.EExceptionSimple eExistenciaSimple = new SWDatos.EExceptionSimple()
        {
            Fecha = ObtenerFechaZonaLocal(),
            IdUsuario = eExceptionCompleja.IdUsuario,
            NombreMetodo = eExceptionCompleja.NombreMetodo,
            Mensaje = eExceptionCompleja.Mensaje,
            ExceptionMensaje = eExceptionCompleja.ExceptionMensaje

        };
        aAquacorp.Insertar_Exception_LocalDatos(eExistenciaSimple);
    }



    #endregion

    #region PRODUCTO


    public bool Insertar_Producto_Async(EProductoCompleja eProductoCompleja)
    {
        try
        {
            SWDatos.EProductoSimple eProductoSimple = new SWDatos.EProductoSimple()
            {

                NombreProducto = eProductoCompleja.NombreProducto,
                FotoProducto = eProductoCompleja.FotoProducto,
                Descripcion = eProductoCompleja.Descripcion,
                Consumible = eProductoCompleja.Consumible,
                FechaRegistro = ObtenerFechaZonaLocal(),
                FechaModificacion = ObtenerFechaZonaLocal(),
                Estado = "HA"
            };
            aAquacorp.Insertar_Producto(eProductoSimple);
            return true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }

    }
    public bool Actualizar_Producto_Async(EProductoCompleja eProductoCompleja)
    {
        try
        {
            SWDatos.EProductoSimple eProductoSimple = new SWDatos.EProductoSimple()
            {
                IdProducto = eProductoCompleja.IdProducto,
                NombreProducto = eProductoCompleja.NombreProducto,
                FotoProducto = eProductoCompleja.FotoProducto,
                Descripcion = eProductoCompleja.Descripcion,
                Consumible = eProductoCompleja.Consumible,
                FechaRegistro = eProductoCompleja.FechaRegistro,
                FechaModificacion = ObtenerFechaZonaLocal(),
                Estado = eProductoCompleja.Estado

            };
            aAquacorp.Actualizar_Producto(eProductoSimple);
            return true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }
    }
    public EProductoCompleja Obtener_Producto_Id_Producto_Async(int IdProducto)
    {
        EProductoCompleja eProductoCompleja = new EProductoCompleja();
        try
        {
            SWDatos.EProductoSimple eProductoSimple = aAquacorp.Obtener_Producto_Id_Producto(IdProducto);
            List<EPrecioSugeridoCompleja> lstEPrecioSugeridoCompleja = Obtener_PrecioSugerido_IdProducto(eProductoSimple.IdProducto);
            string precios = "";
            foreach (EPrecioSugeridoCompleja item in lstEPrecioSugeridoCompleja)
            {
                precios += item.Precio + ", ";
            }
            if (precios.Length > 2)
            {
                precios = precios.Substring(0, precios.Length - 2);
            }
            eProductoCompleja = new EProductoCompleja()
            {
                IdProducto = eProductoSimple.IdProducto,
                NombreProducto = eProductoSimple.NombreProducto,
                FotoProducto = eProductoSimple.FotoProducto,
                Descripcion = eProductoSimple.Descripcion,
                PrecioSugerido = precios,
                Consumible = eProductoSimple.Consumible,
                FechaRegistro = eProductoSimple.FechaRegistro,
                FechaModificacion = eProductoSimple.FechaModificacion,
                Estado = eProductoSimple.Estado

            };
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eProductoCompleja;
    }

    

public EProductoFoto Obtener_Producto_Id_Producto_Foto_Async(int IdProducto)
    {
        EProductoFoto eProductoCompleja = new EProductoFoto();
        try
        {
            SWDatos.EProductoSimple eProductoSimple = aAquacorp.Obtener_Producto_Id_Producto(IdProducto);
            List<EPrecioSugeridoCompleja> lstEPrecioSugeridoCompleja = Obtener_PrecioSugerido_IdProducto(eProductoSimple.IdProducto);
            string precios = "";
            foreach (EPrecioSugeridoCompleja item in lstEPrecioSugeridoCompleja)
            {
                precios += item.Precio + ", ";
            }
            if (precios.Length > 2)
            {
                precios = precios.Substring(0, precios.Length - 2);
            }
            eProductoCompleja = new EProductoFoto()
            {
                IdProducto = eProductoSimple.IdProducto,
                FotoProducto = eProductoSimple.FotoProducto

            };
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eProductoCompleja;
    }


    public List<EProductoCompleja> Obtener_Producto_Async()
    {
        List<EProductoCompleja> lstEProductoCompleja = new List<EProductoCompleja>();
        int cont = 0;
        try
        {
            List<SWDatos.EProductoSimple> lstEProductoSimple = aAquacorp.Obtener_Producto();
            foreach (SWDatos.EProductoSimple eProductoSimple in lstEProductoSimple)
            {
                if (eProductoSimple.Estado == "HA")
                {
                    cont++;
                    List<EPrecioSugeridoCompleja> lstEPrecioSugeridoCompleja = Obtener_PrecioSugerido_IdProducto(eProductoSimple.IdProducto);
                    string precios = "";
                    foreach (EPrecioSugeridoCompleja item in lstEPrecioSugeridoCompleja)
                    {
                        precios += item.Precio.ToString().Replace(",", ".") + ", ";
                    }
                    if (precios.Length > 2)
                    {
                        precios = precios.Substring(0, precios.Length - 2);
                    }

                    EProductoCompleja eProductoCompleja = new EProductoCompleja()
                    {
                        Cont = cont,
                        IdProducto = eProductoSimple.IdProducto,
                        NombreProducto = eProductoSimple.NombreProducto,
                        FotoProducto = eProductoSimple.FotoProducto,
                        Descripcion = eProductoSimple.Descripcion,
                        PrecioSugerido = precios,
                        Consumible = eProductoSimple.Consumible,
                        FechaRegistro = eProductoSimple.FechaRegistro,
                        FechaModificacion = eProductoSimple.FechaModificacion,
                        Estado = eProductoSimple.Estado

                    };
                    lstEProductoCompleja.Add(eProductoCompleja);
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstEProductoCompleja;
    }

    public List<EProductoCompleja> Obtener_Producto_SinFoto_Async()
    {
        List<EProductoCompleja> lstEProductoCompleja = new List<EProductoCompleja>();
        int cont = 0;
        try
        {
            List<SWDatos.EProductoSimple> lstEProductoSimple = aAquacorp.Obtener_Producto();
            foreach (SWDatos.EProductoSimple eProductoSimple in lstEProductoSimple)
            {
                if (eProductoSimple.Estado == "HA")
                {
                    cont++;
                    List<EPrecioSugeridoCompleja> lstEPrecioSugeridoCompleja = Obtener_PrecioSugerido_IdProducto(eProductoSimple.IdProducto);
                    string precios = "";
                    foreach (EPrecioSugeridoCompleja item in lstEPrecioSugeridoCompleja)
                    {
                        precios += item.Precio.ToString().Replace(",", ".") + ", ";
                    }
                    if (precios.Length > 2)
                    {
                        precios = precios.Substring(0, precios.Length - 2);
                    }

                    EProductoCompleja eProductoCompleja = new EProductoCompleja()
                    {
                        Cont = cont,
                        IdProducto = eProductoSimple.IdProducto,
                        NombreProducto = eProductoSimple.NombreProducto,
                        Descripcion = eProductoSimple.Descripcion,
                        PrecioSugerido = precios,
                        Consumible = eProductoSimple.Consumible,
                        FechaRegistro = eProductoSimple.FechaRegistro,
                        FechaModificacion = eProductoSimple.FechaModificacion,
                        Estado = eProductoSimple.Estado

                    };
                    lstEProductoCompleja.Add(eProductoCompleja);
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstEProductoCompleja;
    }
    public List<EProductoCortaCompleja> Obtener_Producto_Mobil()
    {
        List<EProductoCortaCompleja> lstEProductoCompleja = new List<EProductoCortaCompleja>();

        try
        {
            List<SWDatos.EProductoSimple> lstEProductoSimple = aAquacorp.Obtener_Producto_Mobil();
            foreach (SWDatos.EProductoSimple eProductoSimple in lstEProductoSimple)
            {


                EProductoCortaCompleja eProductoCompleja = new EProductoCortaCompleja()
                {

                    IdProducto = eProductoSimple.IdProducto,
                    NombreProducto = eProductoSimple.NombreProducto


                };
                lstEProductoCompleja.Add(eProductoCompleja);


            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstEProductoCompleja;
    }

    public List<EProductoCortaCompleja> Obtener_Producto_Catalogo()
    {
        List<EProductoCortaCompleja> lstEProductoCompleja = new List<EProductoCortaCompleja>();
        int cont = 0;
        try
        {
            List<SWDatos.EProductoSimple> lstEProductoSimple = aAquacorp.Obtener_Producto();
            foreach (SWDatos.EProductoSimple eProductoSimple in lstEProductoSimple)
            {
                if (eProductoSimple.Estado == "HA")
                {
                    if (eProductoSimple.Consumible == "SI")
                    {
                        cont++;
                        List<EPrecioSugeridoCompleja> lstEPrecioSugeridoCompleja = Obtener_PrecioSugerido_IdProducto(eProductoSimple.IdProducto);
                        string precios = "";
                        foreach (EPrecioSugeridoCompleja item in lstEPrecioSugeridoCompleja)
                        {
                            precios = item.Precio.ToString();
                        }

                        SWDatos.EProductoSimple eProductoSimple1 = aAquacorp.Obtener_Producto_Id_Producto(eProductoSimple.IdProducto);
                        EProductoCortaCompleja eProductoCompleja = new EProductoCortaCompleja()
                        {

                            IdProducto = eProductoSimple.IdProducto,
                            NombreProducto = eProductoSimple.NombreProducto,
                            FotoProducto = "data:image/jpg;base64," + Convert.ToBase64String(eProductoSimple1.FotoProducto),
                            Descripcion = eProductoSimple.Descripcion,
                            PrecioSugerido = precios


                        };
                        lstEProductoCompleja.Add(eProductoCompleja);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstEProductoCompleja;
    }


    public byte Verificar_Producto_NombreProducto(string nombreProducto)
    {
        byte verificado = 0;

        try
        {
            List<SWDatos.EProductoSimple> lstEProductoSimple = aAquacorp.Obtener_Producto();
            foreach (SWDatos.EProductoSimple eProductoSimple in lstEProductoSimple)
            {
                if (eProductoSimple.NombreProducto == nombreProducto)
                {
                    if (eProductoSimple.Estado == "HA")
                    {
                        verificado = 1;
                        break;
                    }
                    else
                    {
                        if (eProductoSimple.Estado == "IN")
                        {
                            verificado = 2;
                            break;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return verificado;
    }

    public int Verificar_Producto_IdProducto_NombreProducto(int id, string nombreProducto)
    {
        int verificado = 0;

        try
        {
            List<SWDatos.EProductoSimple> lstEProductoSimple = aAquacorp.Obtener_Producto();
            foreach (SWDatos.EProductoSimple eProductoSimple in lstEProductoSimple)
            {
                if (eProductoSimple.IdProducto != id)
                {
                    if (eProductoSimple.NombreProducto == nombreProducto)
                    {
                        if (eProductoSimple.Estado == "HA")
                        {
                            verificado = 1;
                            break;
                        }
                        else
                        {
                            if (eProductoSimple.Estado == "IN")
                            {
                                verificado = 2;
                                break;
                            }
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return verificado;
    }

    public int ObtenerId_Producto_NombreProducto_Async(string nombreProducto)
    {
        int verificado = 0;

        try
        {
            List<SWDatos.EProductoSimple> lstEProductoSimple = aAquacorp.Obtener_Producto();
            foreach (SWDatos.EProductoSimple eProductoSimple in lstEProductoSimple)
            {
                if (eProductoSimple.NombreProducto == nombreProducto)
                {

                    verificado = eProductoSimple.IdProducto;
                    break;


                }
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return verificado;
    }


    public int Obtener_Ultimo_Id_Producto()
    {
        int id = 0;
        try
        {
            List<SWDatos.EProductoSimple> lstEProductoSimple = aAquacorp.Obtener_Producto();
            foreach (SWDatos.EProductoSimple eProductoSimple in lstEProductoSimple)
            {
                id = eProductoSimple.IdProducto;
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }


        return id;
    }

    public List<EProductoCompleja> Obtener_Producto_SinContador()
    {
        List<EProductoCompleja> lstEProductoCompleja = new List<EProductoCompleja>();

        try
        {
            List<SWDatos.EProductoSimple> lstEProductoSimple = aAquacorp.Obtener_Producto();
            foreach (SWDatos.EProductoSimple eProductoSimple in lstEProductoSimple)
            {
                if (eProductoSimple.Estado == "HA")
                {
                    List<EPrecioSugeridoCompleja> lstEPrecioSugeridoCompleja = Obtener_PrecioSugerido_IdProducto(eProductoSimple.IdProducto);
                    string precios = "";
                    foreach (EPrecioSugeridoCompleja item in lstEPrecioSugeridoCompleja)
                    {
                        precios += item.Precio + ", ";
                    }
                    if (precios.Length > 2)
                    {
                        precios = precios.Substring(0, precios.Length - 2);
                    }
                    EProductoCompleja eProductoCompleja = new EProductoCompleja()
                    {

                        IdProducto = eProductoSimple.IdProducto,
                        NombreProducto = eProductoSimple.NombreProducto,
                        FotoProducto = eProductoSimple.FotoProducto,
                        Descripcion = eProductoSimple.Descripcion,
                        PrecioSugerido = precios,
                        Consumible = eProductoSimple.Consumible,
                        FechaRegistro = eProductoSimple.FechaRegistro,
                        FechaModificacion = eProductoSimple.FechaModificacion,
                        Estado = eProductoSimple.Estado

                    };
                    lstEProductoCompleja.Add(eProductoCompleja);
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstEProductoCompleja;
    }
    #endregion

    #region PRECIO SUGERIDO

    public bool Insertar_PrecioSugerido_Async(EPrecioSugeridoCompleja ePrecioSugeridoCompleja)
    {
        try
        {
            SWDatos.EPrecioSugeridoSimple ePrecioSugeridoSimple = new SWDatos.EPrecioSugeridoSimple()
            {
                IdProducto = ePrecioSugeridoCompleja.IdProducto,
                Precio = ePrecioSugeridoCompleja.Precio,
                FechaRegistro = ObtenerFechaZonaLocal(),
                FechaModificacion = ObtenerFechaZonaLocal(),
                Estado = "HA"
            };
            aAquacorp.Insertar_PrecioSugerido(ePrecioSugeridoSimple);
            return true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }

    }
    public bool Actualizar_PrecioSugerido_Async(EPrecioSugeridoCompleja ePrecioSugeridoCompleja)
    {
        try
        {
            SWDatos.EPrecioSugeridoSimple ePrecioSugeridoSimple = new SWDatos.EPrecioSugeridoSimple()
            {
                IdPrecioSugerido = ePrecioSugeridoCompleja.IdPrecioSugerido,
                IdProducto = ePrecioSugeridoCompleja.IdProducto,
                Precio = ePrecioSugeridoCompleja.Precio,
                FechaRegistro = ePrecioSugeridoCompleja.FechaRegistro,
                FechaModificacion = ObtenerFechaZonaLocal(),
                Estado = ePrecioSugeridoCompleja.Estado

            };
            aAquacorp.Actualizar_PrecioSugerido(ePrecioSugeridoSimple);
            return true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }
    }
    public EPrecioSugeridoCompleja Obtener_PrecioSugerido_Id_PrecioSugerido(int IdPrecioSugerido)
    {
        EPrecioSugeridoCompleja ePrecioSugeridoCompleja = new EPrecioSugeridoCompleja();
        try
        {
            SWDatos.EPrecioSugeridoSimple ePrecioSugeridoSimple = aAquacorp.Obtener_PrecioSugerido_Id_PrecioSugerido(IdPrecioSugerido);
            ePrecioSugeridoCompleja = new EPrecioSugeridoCompleja()
            {
                IdPrecioSugerido = ePrecioSugeridoSimple.IdPrecioSugerido,
                IdProducto = ePrecioSugeridoSimple.IdProducto,
                Precio = ePrecioSugeridoSimple.Precio,
                FechaRegistro = ePrecioSugeridoSimple.FechaRegistro,
                FechaModificacion = ePrecioSugeridoSimple.FechaModificacion,
                Estado = ePrecioSugeridoSimple.Estado

            };
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return ePrecioSugeridoCompleja;
    }
    public List<EPrecioSugeridoCompleja> Obtener_PrecioSugerido()
    {
        List<EPrecioSugeridoCompleja> lstEPrecioSugeridoCompleja = new List<EPrecioSugeridoCompleja>();
        byte cont = 0;
        try
        {
            List<SWDatos.EPrecioSugeridoSimple> lstEPrecioSugeridoSimple = aAquacorp.Obtener_PrecioSugerido();
            foreach (SWDatos.EPrecioSugeridoSimple ePrecioSugeridoSimple in lstEPrecioSugeridoSimple)
            {
                if (ePrecioSugeridoSimple.Estado == "HA")
                {
                    cont++;
                    EPrecioSugeridoCompleja ePrecioSugeridoCompleja = new EPrecioSugeridoCompleja()
                    {

                        Cont = cont,
                        IdPrecioSugerido = ePrecioSugeridoSimple.IdPrecioSugerido,
                        IdProducto = ePrecioSugeridoSimple.IdProducto,
                        Precio = ePrecioSugeridoSimple.Precio,
                        FechaRegistro = ePrecioSugeridoSimple.FechaRegistro,
                        FechaModificacion = ePrecioSugeridoSimple.FechaModificacion,
                        Estado = ePrecioSugeridoSimple.Estado

                    };
                    lstEPrecioSugeridoCompleja.Add(ePrecioSugeridoCompleja);
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstEPrecioSugeridoCompleja;
    }

    public List<EPrecioSugeridoCompleja> Obtener_PrecioSugerido_IdProducto(int idProducto)
    {
        List<EPrecioSugeridoCompleja> lstEPrecioSugeridoCompleja = new List<EPrecioSugeridoCompleja>();
        int cont = 0;
        try
        {
            List<SWDatos.EPrecioSugeridoSimple> lstEPrecioSugeridoSimple = aAquacorp.Obtener_PrecioSugerido();
            foreach (SWDatos.EPrecioSugeridoSimple ePrecioSugeridoSimple in lstEPrecioSugeridoSimple)
            {
                if (ePrecioSugeridoSimple.Estado == "HA")
                {
                    if (ePrecioSugeridoSimple.IdProducto == idProducto)
                    {

                        cont++;
                        EPrecioSugeridoCompleja ePrecioSugeridoCompleja = new EPrecioSugeridoCompleja()
                        {

                            Cont = cont,
                            IdPrecioSugerido = ePrecioSugeridoSimple.IdPrecioSugerido,
                            IdProducto = ePrecioSugeridoSimple.IdProducto,
                            Precio = ePrecioSugeridoSimple.Precio,
                            FechaRegistro = ePrecioSugeridoSimple.FechaRegistro,
                            FechaModificacion = ePrecioSugeridoSimple.FechaModificacion,
                            Estado = ePrecioSugeridoSimple.Estado

                        };
                        lstEPrecioSugeridoCompleja.Add(ePrecioSugeridoCompleja);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstEPrecioSugeridoCompleja;
    }



    #endregion

    #region USUARIO


    public EUsuarioCompleja Obtener_Empleado_Id_Empleado_Async(string ci)
    {
        EUsuarioCompleja eUsuarioCompleja = new EUsuarioCompleja();
        try
        {
            List<SWDatos.EUsuarioSimple> lstEUsuarioSimple = aAquacorp.Obtener_Usuario();

            foreach (SWDatos.EUsuarioSimple eUsuarioSimple in lstEUsuarioSimple)
            {


                SWDatos.EEmpleadoSimple eEmpleadoSimple = aAquacorp.Obtener_Empleado_Id_Empleado(eUsuarioSimple.IdUsuario);
                if (eEmpleadoSimple.Ci == ci)
                {

                    SWDatos.ECargoSimple eCargoSimple = aAquacorp.Obtener_Cargo_Id_Cargo(eEmpleadoSimple.IdCargo);
                    eUsuarioCompleja = new EUsuarioCompleja()
                    {
                        IdUsuario = eUsuarioSimple.IdUsuario,
                        NombreCompleto = eEmpleadoSimple.Nombres + " " + eEmpleadoSimple.PrimerApellido + " " + eEmpleadoSimple.SegundoApellido,
                        NombreUsuario = eEmpleadoSimple.Ci,
                        Contrasena = eUsuarioSimple.Contrasena,
                        Cargo = eCargoSimple.NombreCargo,
                        FechaRegistro = eUsuarioSimple.FechaRegistro,
                        FechaModificacion = eUsuarioSimple.FechaModificacion,
                        Estado = eUsuarioSimple.Estado

                    };
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eUsuarioCompleja;


    }

    //public EUsuarioCompleja Obtener_Empleado_Id_Empleado_Async(string ci)
    //{
    //    EUsuarioCompleja eUsuarioCompleja = new EUsuarioCompleja();
    //    try
    //    {
    //        List<SWDatos.EUsuarioSimple> lstEUsuarioSimple = aAquacorp.Obtener_Usuario();

    //        foreach (SWDatos.EUsuarioSimple eUsuarioSimple in lstEUsuarioSimple)
    //        {


    //            SWDatos.EEmpleadoSimple eEmpleadoSimple = aAquacorp.Obtener_Empleado_Id_Empleado(eUsuarioSimple.IdUsuario);
    //            if (eEmpleadoSimple.Ci == ci)
    //            {

    //                SWDatos.ECargoSimple eCargoSimple = aAquacorp.Obtener_Cargo_Id_Cargo(eEmpleadoSimple.IdCargo);
    //                eUsuarioCompleja = new EUsuarioCompleja()
    //                {
    //                    IdUsuario = eUsuarioSimple.IdUsuario,
    //                    NombreCompleto = eEmpleadoSimple.Nombres + " " + eEmpleadoSimple.PrimerApellido + " " + eEmpleadoSimple.SegundoApellido,
    //                    NombreUsuario = eEmpleadoSimple.Ci,
    //                    Contrasena = eUsuarioSimple.Contrasena,
    //                    Cargo = eCargoSimple.NombreCargo,
    //                    FechaRegistro = eUsuarioSimple.FechaRegistro,
    //                    FechaModificacion = eUsuarioSimple.FechaModificacion,
    //                    Estado = eUsuarioSimple.Estado

    //                };
    //            }

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

    //    }
    //    return eUsuarioCompleja;
    //}
    //public EUsuarioCompleja Obtener_Usuario_Empleado_Ci_Async(string ci)
    //{
    //    EUsuarioCompleja eUsuarioCompleja = new EUsuarioCompleja();
    //    try
    //    {
    //        List<SWDatos.EEmpleadoSimple> listEEmpleadoSimple = aAquacorp.Obtener_Empleado();

    //        foreach (SWDatos.EEmpleadoSimple item in listEEmpleadoSimple)
    //        {
    //            if(item.Estado == "HA")
    //            {
    //                if (item.Ci == ci)
    //                {

    //                    SWDatos.EUsuarioSimple  eUsuarioSimple= aAquacorp.Obtener_Usuario_Id_Usuario(item.IdEmpleado);
    //                    eUsuarioCompleja = new EUsuarioCompleja() {
    //                    IdUsuario = eUsuarioSimple.IdUsuario,
    //                    Contrasena = eUsuarioSimple.Contrasena,
    //                    FechaRegistro = eUsuarioSimple.FechaRegistro,
    //                    FechaModificacion = eUsuarioSimple.FechaModificacion,
    //                    Estado = eUsuarioSimple.Estado

    //                };
    //                }

    //            }


    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

    //    }
    //    return eUsuarioCompleja;
    //}

    #endregion

    #region EMPLEADO

    public EEmpleadoCortaCompleja Obtener_Empleado_Id_Empleado_Async(int IdEmpleado)
    {
        EEmpleadoCortaCompleja eEmpleadoCompleja = new EEmpleadoCortaCompleja();

        try
        {
            SWDatos.EEmpleadoSimple eEmpleadoSimple = aAquacorp.Obtener_Empleado_Id_Empleado(IdEmpleado);
            SWDatos.ECargoSimple eCargoSimple = aAquacorp.Obtener_Cargo_Id_Cargo(eEmpleadoSimple.IdCargo);
            SWDatos.ECiudadSimple eCiudadSimple = aAquacorp.Obtener_Ciudad_Id_Ciudad(eEmpleadoSimple.IdCiudad);

            SWDatos.ECiudadSimple eCiudadSimpleNaci = aAquacorp.Obtener_Ciudad_Id_Ciudad(eEmpleadoSimple.LugarNacimiento);

            eEmpleadoCompleja = new EEmpleadoCortaCompleja()
            {

                IdEmpleado = eEmpleadoSimple.IdEmpleado,
                NombreCompleto = eEmpleadoSimple.Nombres + " " + eEmpleadoSimple.PrimerApellido + " " + eEmpleadoSimple.SegundoApellido,
                IdCargo = eEmpleadoSimple.IdCargo,
                NombreCargo = eCargoSimple.NombreCargo,

            };

        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eEmpleadoCompleja;
    }

    //public EEmpleadoCompleja Obtener_Empleado_Id_Empleado_Async(int IdEmpleado)
    //{
    //    EEmpleadoCompleja eEmpleadoCompleja = new EEmpleadoCompleja();

    //    try
    //    {
    //        SWDatos.EEmpleadoSimple eEmpleadoSimple = aAquacorp.Obtener_Empleado_Id_Empleado(IdEmpleado);
    //        SWDatos.ECargoSimple eCargoSimple = aAquacorp.Obtener_Cargo_Id_Cargo(eEmpleadoSimple.IdCargo);
    //        SWDatos.ECiudadSimple eCiudadSimple = aAquacorp.Obtener_Ciudad_Id_Ciudad(eEmpleadoSimple.IdCiudad);

    //        SWDatos.ECiudadSimple eCiudadSimpleNaci = aAquacorp.Obtener_Ciudad_Id_Ciudad(eEmpleadoSimple.LugarNacimiento);

    //        eEmpleadoCompleja = new EEmpleadoCompleja()
    //        {

    //            IdEmpleado = eEmpleadoSimple.IdEmpleado,
    //            IdCargo = eEmpleadoSimple.IdCargo,
    //            NombreCargo = eCargoSimple.NombreCargo,
    //            FechaNacimiento = eEmpleadoSimple.FechaNacimiento,
    //            Ci = eEmpleadoSimple.Ci,
    //            IdCiudad = eEmpleadoSimple.IdCiudad,
    //            NombreCiudadAbreviado = AbreviarCiudades(eCiudadSimpleNaci.NombreCiudad),
    //            LugarNacimiento = eEmpleadoSimple.LugarNacimiento,
    //            NombreCiudad = eCiudadSimple.NombreCiudad,
    //            TelefonoRespaldo = eEmpleadoSimple.TelefonoRespaldo,
    //            EstadoCivil = eEmpleadoSimple.EstadoCivil,
    //            NombresPadre = eEmpleadoSimple.NombresPadre,
    //            PrimerApellidoPadre = eEmpleadoSimple.PrimerApellidoPadre,
    //            SegundoApellidoPadre = eEmpleadoSimple.SegundoApellidoPadre,
    //            OcupacionPadre = eEmpleadoSimple.OcupacionPadre,
    //            NombresMadre = eEmpleadoSimple.NombresMadre,
    //            PrimerApellidoMadre = eEmpleadoSimple.PrimerApellidoMadre,
    //            SegundoApellidoMadre = eEmpleadoSimple.SegundoApellidoMadre,
    //            OcupacionMadre = eEmpleadoSimple.OcupacionMadre,
    //            UltimoCurso = eEmpleadoSimple.UltimoCurso,
    //            ColegioUnidadEducativa = eEmpleadoSimple.ColegioUnidadEducativa,
    //            FechaInicioTrabajo = eEmpleadoSimple.FechaInicioTrabajo,
    //            Garantia = eEmpleadoSimple.Garantia,
    //            Fotografia = eEmpleadoSimple.Fotografia

    //        };

    //    }
    //    catch (Exception ex)
    //    {
    //        Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
    //    }
    //    return eEmpleadoCompleja;
    //}


    #endregion

    #region EXISTENCIA


    public bool Insertar_Existencia_Async(EExistenciaCompleja eExistenciaCompleja)
    {
        try
        {
            SWDatos.EExistenciaSimple eExistenciaSimple = new SWDatos.EExistenciaSimple()
            {
                Cantidad = eExistenciaCompleja.Cantidad,
                Estado = eExistenciaCompleja.Estado,
                FechaModificacion = ObtenerFechaZonaLocal(),
                FechaRegistro = ObtenerFechaZonaLocal(),
                IdExistencia = eExistenciaCompleja.IdExistencia,
                IdPersona = eExistenciaCompleja.IdPersona,
                IdProducto = eExistenciaCompleja.IdProducto,
                IdUsuario = eExistenciaCompleja.IdUsuario,
                TipoExistencia = eExistenciaCompleja.TipoExistencia
            };

            aAquacorp.Insertar_Existencia(eExistenciaSimple);
            return true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }

    }
    public bool Actualizar_Existencia_Async(EExistenciaCompleja eExistenciaCompleja)
    {
        try
        {
            SWDatos.EExistenciaSimple eExistenciaSimple = new SWDatos.EExistenciaSimple()
            {
                Cantidad = eExistenciaCompleja.Cantidad,
                Estado = eExistenciaCompleja.Estado,
                FechaModificacion = ObtenerFechaZonaLocal(),
                FechaRegistro = eExistenciaCompleja.FechaRegistro,
                IdExistencia = eExistenciaCompleja.IdExistencia,
                IdPersona = eExistenciaCompleja.IdPersona,
                IdProducto = eExistenciaCompleja.IdProducto,
                IdUsuario = eExistenciaCompleja.IdUsuario,
                TipoExistencia = eExistenciaCompleja.TipoExistencia
            };

            aAquacorp.Actualizar_Existencia(eExistenciaSimple);
            return true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }
    }

    public EExistenciaCortaCompleja Obtener_Existencia_Id_Existencia_Async(int IdExistencia)
    {
        EExistenciaCortaCompleja eExistenciaCompleja = new EExistenciaCortaCompleja();
        try
        {
            SWDatos.EExistenciaSimple eExistenciaSimple = aAquacorp.Obtener_Existencia_Id_Existencia(IdExistencia);
            SWDatos.EProductoSimple eProductoSimple = aAquacorp.Obtener_Producto_Id_Producto(eExistenciaSimple.IdProducto);
            SWDatos.EEmpleadoSimple eEmpleadoSimplePersona = aAquacorp.Obtener_Empleado_Id_Empleado(eExistenciaSimple.IdPersona);
            SWDatos.EEmpleadoSimple eEmpleadoSimpleUsuario = aAquacorp.Obtener_Empleado_Id_Empleado(eExistenciaSimple.IdUsuario);

            eExistenciaCompleja = new EExistenciaCortaCompleja()
            {
                IdExistencia = eExistenciaSimple.IdExistencia,
                TipoExistencia = eExistenciaSimple.TipoExistencia,
                Cantidad = eExistenciaSimple.Cantidad,
                IdProducto = eExistenciaSimple.IdProducto,
                NombreProducto = eProductoSimple.NombreProducto


            };
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eExistenciaCompleja;
    }


    public EExistenciaCompleja Obtener_Existencia_Id_Existencia_Completa_Async(int IdExistencia)
    {
        EExistenciaCompleja eExistenciaCompleja = new EExistenciaCompleja();
        try
        {
            SWDatos.EExistenciaSimple eExistenciaSimple = aAquacorp.Obtener_Existencia_Id_Existencia(IdExistencia);
            SWDatos.EProductoSimple eProductoSimple = aAquacorp.Obtener_Producto_Id_Producto(eExistenciaSimple.IdProducto);
            SWDatos.EEmpleadoSimple eEmpleadoSimplePersona = aAquacorp.Obtener_Empleado_Id_Empleado(eExistenciaSimple.IdPersona);
            SWDatos.EEmpleadoSimple eEmpleadoSimpleUsuario = aAquacorp.Obtener_Empleado_Id_Empleado(eExistenciaSimple.IdUsuario);

            eExistenciaCompleja = new EExistenciaCompleja()
            {
                IdExistencia = eExistenciaSimple.IdExistencia,
                TipoExistencia = eExistenciaSimple.TipoExistencia,
                Cantidad = eExistenciaSimple.Cantidad,
                IdProducto = eExistenciaSimple.IdProducto,
                NombreProducto = eProductoSimple.NombreProducto,
                Estado = eExistenciaSimple.Estado,
                FechaModificacion = eExistenciaSimple.FechaModificacion,
                FechaRegistro = eExistenciaSimple.FechaRegistro,
                IdPersona = eExistenciaSimple.IdPersona,
                IdUsuario = eExistenciaSimple.IdUsuario

            };
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eExistenciaCompleja;
    }

    public List<EExistenciaCompleja> Obtener_Existencia_Async()
    {
        List<EExistenciaCompleja> lstEExistenciaCompleja = new List<EExistenciaCompleja>();
        int cont = 0;
        int cantidad = 0;
        try
        {
            List<SWDatos.EExistenciaSimple> lstEExistenciaSimple = aAquacorp.Obtener_Existencia();
            List<SWDatos.EProductoSimple> lstEProductoSimple = aAquacorp.Obtener_Producto();
            EExistenciaCompleja eExistenciaCompleja = new EExistenciaCompleja();
            foreach (SWDatos.EProductoSimple productoSimple in lstEProductoSimple)
            {
                cantidad = 0;

                foreach (SWDatos.EExistenciaSimple eExistenciaSimple in lstEExistenciaSimple)
                {
                    if (eExistenciaSimple.IdProducto == productoSimple.IdProducto)
                    {
                        if (eExistenciaSimple.Estado == "HA")
                        {
                            cont++;
                            cantidad += eExistenciaSimple.Cantidad;
                            SWDatos.EProductoSimple eProductoSimple = aAquacorp.Obtener_Producto_Id_Producto(eExistenciaSimple.IdProducto);
                            SWDatos.EEmpleadoSimple eEmpleadoSimplePersona = aAquacorp.Obtener_Empleado_Id_Empleado(eExistenciaSimple.IdPersona);
                            SWDatos.EEmpleadoSimple eEmpleadoSimpleUsuario = aAquacorp.Obtener_Empleado_Id_Empleado(eExistenciaSimple.IdUsuario);

                            eExistenciaCompleja = new EExistenciaCompleja()
                            {

                                Cont = cont,
                                IdExistencia = eExistenciaSimple.IdExistencia,
                                TipoExistencia = eExistenciaSimple.TipoExistencia,
                                Cantidad = cantidad,
                                IdProducto = eExistenciaSimple.IdProducto,
                                NombreProducto = eProductoSimple.NombreProducto,
                                IdPersona = eExistenciaSimple.IdPersona,
                                NombreCompletoPersonaRegistra = eEmpleadoSimplePersona.Nombres + " " + eEmpleadoSimplePersona.PrimerApellido + " " + eEmpleadoSimplePersona.SegundoApellido,
                                IdUsuario = eExistenciaSimple.IdUsuario,
                                NombreCompletoUsuarioValida = eEmpleadoSimpleUsuario.Nombres + " " + eEmpleadoSimpleUsuario.PrimerApellido + " " + eEmpleadoSimpleUsuario.SegundoApellido,
                                FechaRegistro = eExistenciaSimple.FechaRegistro,
                                FechaModificacion = eExistenciaSimple.FechaModificacion,
                                Estado = eExistenciaSimple.Estado

                            };

                        }
                    }

                }
                lstEExistenciaCompleja.Add(eExistenciaCompleja);

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstEExistenciaCompleja;
    }

    public List<EExistenciaCortaCompleja> Obtener_Existencia_Fecha_Async(int idPersona)
    {
        List<EExistenciaCortaCompleja> lstEExistenciaCompleja = new List<EExistenciaCortaCompleja>();
        int cont = 0;

        try
        {
            List<SWDatos.EExistenciaSimple> lstEExistenciaSimple = aAquacorp.Obtener_Existencia();
            EExistenciaCortaCompleja eExistenciaCompleja = new EExistenciaCortaCompleja();
            foreach (SWDatos.EExistenciaSimple eExistenciaSimple in lstEExistenciaSimple)
            {
                if (eExistenciaSimple.IdPersona == idPersona)
                {
                    if (eExistenciaSimple.FechaRegistro.Date == ObtenerFechaZonaLocal().Date)
                    {
                        if (eExistenciaSimple.Estado == "HA")
                        {
                            SWDatos.EProductoSimple eProductoSimple = aAquacorp.Obtener_Producto_Id_Producto(eExistenciaSimple.IdProducto);
                            SWDatos.EEmpleadoSimple eEmpleadoSimplePersona = aAquacorp.Obtener_Empleado_Id_Empleado(eExistenciaSimple.IdPersona);
                            SWDatos.EEmpleadoSimple eEmpleadoSimpleUsuario = aAquacorp.Obtener_Empleado_Id_Empleado(eExistenciaSimple.IdUsuario);
                            cont++;
                            eExistenciaCompleja = new EExistenciaCortaCompleja()
                            {
                                Cont = cont,
                                IdExistencia = eExistenciaSimple.IdExistencia,
                                TipoExistencia = eExistenciaSimple.TipoExistencia,
                                Cantidad = eExistenciaSimple.Cantidad,
                                IdProducto = eExistenciaSimple.IdProducto,
                                NombreProducto = eProductoSimple.NombreProducto,



                            };
                            lstEExistenciaCompleja.Add(eExistenciaCompleja);

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstEExistenciaCompleja;
    }


    public List<EExistenciaMovilCompleja> Obtener_Existencia_Fecha_Movil(int idPersona, DateTime fecha)
    {
        List<EExistenciaMovilCompleja> lstEExistenciaCompleja = new List<EExistenciaMovilCompleja>();
        int cont = 0;

        try
        {
            List<SWDatos.EExistenciaSimple> lstEExistenciaSimple = aAquacorp.Obtener_Existencia();
            EExistenciaMovilCompleja eExistenciaCompleja = new EExistenciaMovilCompleja();
            foreach (SWDatos.EExistenciaSimple eExistenciaSimple in lstEExistenciaSimple)
            {
                if (eExistenciaSimple.IdPersona == idPersona)
                {
                    if (eExistenciaSimple.FechaRegistro.Date == fecha.Date)
                    {
                        if (eExistenciaSimple.Estado == "HA")
                        {
                            SWDatos.EProductoSimple eProductoSimple = aAquacorp.Obtener_Producto_Id_Producto(eExistenciaSimple.IdProducto);
                            SWDatos.EEmpleadoSimple eEmpleadoSimplePersona = aAquacorp.Obtener_Empleado_Id_Empleado(eExistenciaSimple.IdPersona);
                            SWDatos.EEmpleadoSimple eEmpleadoSimpleUsuario = aAquacorp.Obtener_Empleado_Id_Empleado(eExistenciaSimple.IdUsuario);
                            cont++;
                            eExistenciaCompleja = new EExistenciaMovilCompleja()
                            {
                                Id = eExistenciaSimple.IdExistencia,
                                Text = cont + ".-  " + eProductoSimple.NombreProducto,
                                Description = eExistenciaSimple.Cantidad + " " + eExistenciaSimple.TipoExistencia.ToLower() + "(s)"
                            };
                            lstEExistenciaCompleja.Add(eExistenciaCompleja);

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstEExistenciaCompleja;
    }




    #endregion


    #region DISTRIBUIDOR

    public bool Insertar_UbicacionDistribuidor(EUbicacionDistribuidorCompleja eUbicacionDistribuidorCompleja)
    {
        try
        {

            SWDatos.EUbicacionDistribuidorSimple lstEUbicacionDistribuidorSimpl = new SWDatos.EUbicacionDistribuidorSimple()
            {

                IdUsuario = eUbicacionDistribuidorCompleja.IdUsuario,
                NombreDispositivo = eUbicacionDistribuidorCompleja.NombreDispositivo,
                Latitud = eUbicacionDistribuidorCompleja.Latitud,
                Longitud = eUbicacionDistribuidorCompleja.Longitud,
                Fecha = ObtenerFechaZonaLocal()
            };

            aAquacorp.Insertar_UbicacionDistribuidor(lstEUbicacionDistribuidorSimpl);
            return true;

        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }

    }

    public bool Insertar_Cliente(EClienteCompleja eClienteCompleja)
    {
        try
        {
            SWDatos.EClienteSimple eClienteSimple = new SWDatos.EClienteSimple()
            {

                Nombres = eClienteCompleja.Nombres,
                PrimerApellido = eClienteCompleja.PrimerApellido,
                SegundoApellido = eClienteCompleja.SegundoApellido,
                Telefono = eClienteCompleja.Telefono,
                Direccion = eClienteCompleja.Direccion,
                FechaRegistro = ObtenerFechaZonaLocal(),
                FechaModificacion = ObtenerFechaZonaLocal(),
                Estado = "HA",
                IdCategoriaCliente = eClienteCompleja.IdCategoriaCliente,
                CorreoElectronico = eClienteCompleja.CorreoElectronico,
                Latitud = eClienteCompleja.Latitud,
                Longitud = eClienteCompleja.Longitud,
                IdZona = eClienteCompleja.IdZona,
                FotoUbicacion = eClienteCompleja.FotoUbicacion,
                Contrato = eClienteCompleja.Contrato

            };
            aAquacorp.Insertar_Cliente(eClienteSimple);
            return true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }

    }





    public List<ECategoriaClienteCompleja> Obtener_CategoriaCliente()
    {
        List<ECategoriaClienteCompleja> lstECategoriaClienteCompleja = new List<ECategoriaClienteCompleja>();
        byte cont = 0;
        try
        {
            List<SWDatos.ECategoriaClienteSimple> lstECategoriaClienteSimple = aAquacorp.Obtener_CategoriaCliente();
            foreach (SWDatos.ECategoriaClienteSimple eCategoriaClienteSimple in lstECategoriaClienteSimple)
            {
                if (eCategoriaClienteSimple.Estado == "HA")
                {
                    cont++;
                    ECategoriaClienteCompleja eCategoriaClienteCompleja = new ECategoriaClienteCompleja()
                    {

                        Cont = cont,
                        IdCategoriaCliente = eCategoriaClienteSimple.IdCategoriaCliente,
                        NombreCategoriaCliente = eCategoriaClienteSimple.NombreCategoriaCliente,
                        FechaRegistro = eCategoriaClienteSimple.FechaRegistro,
                        FechaModificacion = eCategoriaClienteSimple.FechaModificacion,
                        Estado = eCategoriaClienteSimple.Estado

                    };
                    lstECategoriaClienteCompleja.Add(eCategoriaClienteCompleja);
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstECategoriaClienteCompleja;
    }




    public List<EZonaCompleja> Obtener_Zona()
    {
        List<EZonaCompleja> lstEZonaCompleja = new List<EZonaCompleja>();
        byte cont = 0;
        try
        {
            List<SWDatos.EZonaSimple> lstEZonaSimple = aAquacorp.Obtener_Zona();
            foreach (SWDatos.EZonaSimple eZonaSimple in lstEZonaSimple)
            {
                if (eZonaSimple.Estado == "HA")
                {
                    cont++;
                    EZonaCompleja eZonaCompleja = new EZonaCompleja()
                    {

                        Cont = cont,
                        IdZona = eZonaSimple.IdZona,
                        NombreZona = eZonaSimple.NombreZona,
                        FechaRegistro = eZonaSimple.FechaRegistro,
                        FechaModificacion = eZonaSimple.FechaModificacion,
                        Estado = eZonaSimple.Estado

                    };
                    lstEZonaCompleja.Add(eZonaCompleja);
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstEZonaCompleja;
    }



    public List<EClienteNombres> Obtener_Cliente()
    {
        List<EClienteNombres> lstEClienteCompleja = new List<EClienteNombres>();
        byte cont = 0;
        try
        {
            List<SWDatos.EClienteSimple> lstEClienteSimple = aAquacorp.Obtener_Cliente();
            foreach (SWDatos.EClienteSimple eClienteSimple in lstEClienteSimple)
            {
                if (eClienteSimple.Estado == "HA")
                {
                    cont++;

                    SWDatos.ECategoriaClienteSimple eCategoriaClienteSimple = aAquacorp.Obtener_CategoriaCliente_Id_CategoriaCliente(eClienteSimple.IdCategoriaCliente);
                    SWDatos.EZonaSimple eZonaSimple = aAquacorp.Obtener_Zona_Id_Zona(eClienteSimple.IdZona);
                    EClienteNombres eClienteCompleja = new EClienteNombres()
                    {
                       
                        IdPersona = eClienteSimple.IdPersona,
                        Nombres = eClienteSimple.Nombres,
                        PrimerApellido = eClienteSimple.PrimerApellido,
                        SegundoApellido = eClienteSimple.SegundoApellido,
                        Telefono = eClienteSimple.Telefono,
                        Direccion = eClienteSimple.Direccion,
                        FechaRegistro = eClienteSimple.FechaRegistro,
                        FechaModificacion = eClienteSimple.FechaModificacion,
                        Estado = eClienteSimple.Estado,
                        IdCliente = eClienteSimple.IdCliente
                     
                    };
                    lstEClienteCompleja.Add(eClienteCompleja);
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstEClienteCompleja;
    }




    public EClienteCompleja Obtener_Cliente_Buscador_NombreCompleto(string nombre)
    {
        EClienteCompleja eClienteCompleja = new EClienteCompleja();
        byte cont = 0;
        try
        {
            List<SWDatos.EClienteSimple> lstEClienteSimple = aAquacorp.Obtener_Cliente();
            foreach (SWDatos.EClienteSimple eClienteSimple in lstEClienteSimple)
            {
                string nombreCompleto = eClienteSimple.Nombres + " " + eClienteSimple.PrimerApellido + " " + eClienteSimple.SegundoApellido;
                if (nombreCompleto.Trim() == nombre.Trim())
                {
                    if (eClienteSimple.Estado == "HA")
                    {
                        cont++;

                        SWDatos.ECategoriaClienteSimple eCategoriaClienteSimple = aAquacorp.Obtener_CategoriaCliente_Id_CategoriaCliente(eClienteSimple.IdCategoriaCliente);
                        SWDatos.EZonaSimple eZonaSimple = aAquacorp.Obtener_Zona_Id_Zona(eClienteSimple.IdZona);

                        eClienteCompleja = new EClienteCompleja()
                        {
                            Cont = cont,
                            IdPersona = eClienteSimple.IdPersona,
                            Nombres = eClienteSimple.Nombres,
                            PrimerApellido = eClienteSimple.PrimerApellido,
                            SegundoApellido = eClienteSimple.SegundoApellido,
                            Telefono = eClienteSimple.Telefono,
                            Direccion = eClienteSimple.Direccion,
                            FechaRegistro = eClienteSimple.FechaRegistro,
                            FechaModificacion = eClienteSimple.FechaModificacion,
                            Estado = eClienteSimple.Estado,
                            IdCliente = eClienteSimple.IdCliente,
                            IdCategoriaCliente = eClienteSimple.IdCategoriaCliente,
                            NombreCategoriaCliente = eCategoriaClienteSimple.NombreCategoriaCliente,
                            CorreoElectronico = eClienteSimple.CorreoElectronico,
                            Latitud = eClienteSimple.Latitud,
                            Longitud = eClienteSimple.Longitud,
                            IdZona = eClienteSimple.IdZona,
                            NombreZona = eZonaSimple.NombreZona,
                            FotoUbicacion = eClienteSimple.FotoUbicacion,
                            Contrato = eClienteSimple.Contrato
                        };
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return eClienteCompleja;
    }

    public EClienteNombres Obtener_Cliente_Buscador_NombreCompleto_Corta(string nombre)
    {
        EClienteNombres eClienteCompleja = new EClienteNombres();
        byte cont = 0;
        try
        {
            List<SWDatos.EClienteSimple> lstEClienteSimple = aAquacorp.Obtener_Cliente();
            foreach (SWDatos.EClienteSimple eClienteSimple in lstEClienteSimple)
            {
                string nombreCompleto = eClienteSimple.Nombres + " " + eClienteSimple.PrimerApellido + " " + eClienteSimple.SegundoApellido;
                if (nombreCompleto.Trim() == nombre.Trim())
                {
                    if (eClienteSimple.Estado == "HA")
                    {
                        cont++;

                        SWDatos.ECategoriaClienteSimple eCategoriaClienteSimple = aAquacorp.Obtener_CategoriaCliente_Id_CategoriaCliente(eClienteSimple.IdCategoriaCliente);
                        SWDatos.EZonaSimple eZonaSimple = aAquacorp.Obtener_Zona_Id_Zona(eClienteSimple.IdZona);

                        eClienteCompleja = new EClienteNombres()
                        {
                            
                            IdPersona = eClienteSimple.IdPersona,
                            Nombres = eClienteSimple.Nombres,
                            PrimerApellido = eClienteSimple.PrimerApellido,
                            SegundoApellido = eClienteSimple.SegundoApellido,
                            Telefono = eClienteSimple.Telefono,
                            Direccion = eClienteSimple.Direccion,
                            FechaRegistro = eClienteSimple.FechaRegistro,
                            FechaModificacion = eClienteSimple.FechaModificacion,
                            Estado = eClienteSimple.Estado,
                            IdCliente = eClienteSimple.IdCliente
                             
                        };
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return eClienteCompleja;
    }


    public bool Insertar_Movimiento(EMovimientoCompleja eMovimientoCompleja)
    {
        try
        {
            SWDatos.EMovimientoSimple eMovimientoSimple = new SWDatos.EMovimientoSimple()
            {
                IdCliente = eMovimientoCompleja.IdCliente,
                IdUsuario = eMovimientoCompleja.IdUsuario,
                TipoMovimiento = eMovimientoCompleja.TipoMovimiento,
                FechaRegistro = ObtenerFechaZonaLocal(),
                FechaModificacion = ObtenerFechaZonaLocal(),
                Estado = "HA"
            };
            aAquacorp.Insertar_Movimiento(eMovimientoSimple);
            return true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }

    }




    public int Obtener_Ultimo_IdMovimiento()
    {
        int id = 0;
        try
        {
            List<SWDatos.EMovimientoSimple> lstEMovimientoSimple = aAquacorp.Obtener_Movimiento();
            EMovimientoCompleja eMovimientoCompleja = new EMovimientoCompleja();
            foreach (SWDatos.EMovimientoSimple eMovimientoSimple in lstEMovimientoSimple)
            {
                if (id < eMovimientoSimple.IdMovimiento)
                {
                    id = eMovimientoSimple.IdMovimiento;
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return id;
    }


    public bool Verificar_Pedido_IdUsuario(int IdUsuario)
    {
        bool ban = false;
        try
        {
            List<SWDatos.EMovimientoSimple> lstEMovimientoSimple = aAquacorp.Obtener_Movimiento();
            EMovimientoCompleja eMovimientoCompleja = new EMovimientoCompleja();
            foreach (SWDatos.EMovimientoSimple eMovimientoSimple in lstEMovimientoSimple)
            {
                if (eMovimientoSimple.TipoMovimiento == "PEDIDO")
                {
                    if (eMovimientoSimple.IdUsuario == IdUsuario)
                    {
                        if (eMovimientoSimple.Estado == "AS")
                        {
                            if (eMovimientoSimple.FechaRegistro.Date == ObtenerFechaZonaLocal().Date)
                            {
                                ban = true;
                            }
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return ban;
    }

    public bool Insertar_DetalleMovimiento(EDetalleMovimientoCompleja eDetalleMovimientoCompleja)
    {
        try
        {
            SWDatos.EDetalleMovimientoSimple eDetalleMovimientoSimple = new SWDatos.EDetalleMovimientoSimple()
            {
                IdMovimiento = eDetalleMovimientoCompleja.IdMovimiento,
                IdProducto = eDetalleMovimientoCompleja.IdProducto,
                PrecioUnitario = eDetalleMovimientoCompleja.PrecioUnitario,
                Cantidad = eDetalleMovimientoCompleja.Cantidad,
                FechaRegistro = ObtenerFechaZonaLocal(),
                FechaModificacion = ObtenerFechaZonaLocal(),
                Estado = "HA"
            };
            aAquacorp.Insertar_DetalleMovimiento(eDetalleMovimientoSimple);
            return true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }

    }




    public List<EClienteCompleja> Obtener_Cliente_Buscador_ConContrato(string nombre)
    {
        List<EClienteCompleja> lstEClienteCompleja = new List<EClienteCompleja>();
        byte cont = 0;
        try
        {
            List<SWDatos.EClienteSimple> lstEClienteSimple = aAquacorp.Obtener_Cliente_Buscador(nombre);
            foreach (SWDatos.EClienteSimple eClienteSimple in lstEClienteSimple)
            {
                if (eClienteSimple.Contrato)
                {
                    if (eClienteSimple.Estado == "HA")
                    {
                        cont++;

                        SWDatos.ECategoriaClienteSimple eCategoriaClienteSimple = aAquacorp.Obtener_CategoriaCliente_Id_CategoriaCliente(eClienteSimple.IdCategoriaCliente);
                        SWDatos.EZonaSimple eZonaSimple = aAquacorp.Obtener_Zona_Id_Zona(eClienteSimple.IdZona);

                        EClienteCompleja eClienteCompleja = new EClienteCompleja()
                        {
                            Cont = cont,
                            IdPersona = eClienteSimple.IdPersona,
                            Nombres = eClienteSimple.Nombres,
                            PrimerApellido = eClienteSimple.PrimerApellido,
                            SegundoApellido = eClienteSimple.SegundoApellido,
                            Telefono = eClienteSimple.Telefono,
                            Direccion = eClienteSimple.Direccion,
                            FechaRegistro = eClienteSimple.FechaRegistro,
                            FechaModificacion = eClienteSimple.FechaModificacion,
                            Estado = eClienteSimple.Estado,
                            IdCliente = eClienteSimple.IdCliente,
                            IdCategoriaCliente = eClienteSimple.IdCategoriaCliente,
                            NombreCategoriaCliente = eCategoriaClienteSimple.NombreCategoriaCliente,
                            CorreoElectronico = eClienteSimple.CorreoElectronico,
                            Latitud = eClienteSimple.Latitud,
                            Longitud = eClienteSimple.Longitud,
                            IdZona = eClienteSimple.IdZona,
                            NombreZona = eZonaSimple.NombreZona,
                            FotoUbicacion = eClienteSimple.FotoUbicacion,
                            Contrato = eClienteSimple.Contrato
                        };
                        lstEClienteCompleja.Add(eClienteCompleja);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstEClienteCompleja;
    }




    public List<ETipoGastoCompleja> Obtener_TipoGasto_Distribuccion()
    {
        List<ETipoGastoCompleja> lstETipoGastoCompleja = new List<ETipoGastoCompleja>();
        byte cont = 0;
        try
        {
            List<SWDatos.ETipoGastoSimple> lstETipoGastoSimple = aAquacorp.Obtener_TipoGasto();
            foreach (SWDatos.ETipoGastoSimple eTipoGastoSimple in lstETipoGastoSimple)
            {
                if (eTipoGastoSimple.Estado == "HA")
                {
                    if (eTipoGastoSimple.Tipo == "DISTRIBUCCION")
                    {
                        cont++;
                        ETipoGastoCompleja eTipoGastoCompleja = new ETipoGastoCompleja()
                        {

                            Cont = cont,
                            IdTipoGasto = eTipoGastoSimple.IdTipoGasto,
                            NombreTipoGasto = eTipoGastoSimple.NombreTipoGasto,
                            Tipo = eTipoGastoSimple.Tipo,
                            FechaRegistro = eTipoGastoSimple.FechaRegistro,
                            FechaModificacion = eTipoGastoSimple.FechaModificacion,
                            Estado = eTipoGastoSimple.Estado

                        };
                        lstETipoGastoCompleja.Add(eTipoGastoCompleja);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstETipoGastoCompleja;
    }





    #endregion




    #region GASTO
    public bool Insertar_Gasto(EGastoCompleja eGastoCompleja)
    {
        try
        {
            SWDatos.EGastoSimple eGastoSimple = new SWDatos.EGastoSimple()
            {

                IdTipoGasto = eGastoCompleja.IdTipoGasto,
                Cantidad = eGastoCompleja.Cantidad,
                Precio = eGastoCompleja.Precio,
                IdUsuario = eGastoCompleja.IdUsuario,
                IdAprovador = eGastoCompleja.IdAprovador,
                FechaRegistro = ObtenerFechaZonaLocal(),
                FechaModificacion = ObtenerFechaZonaLocal(),
                Estado = "HA"


            };
            aAquacorp.Insertar_Gasto(eGastoSimple);
            return true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }

    }
    public bool Actualizar_Gasto(EGastoCompleja eGastoCompleja)
    {
        try
        {
            SWDatos.EGastoSimple eGastoSimple = new SWDatos.EGastoSimple()
            {
                IdGasto = eGastoCompleja.IdGasto,
                IdTipoGasto = eGastoCompleja.IdTipoGasto,
                Cantidad = eGastoCompleja.Cantidad,
                Precio = eGastoCompleja.Precio,
                IdUsuario = eGastoCompleja.IdUsuario,
                IdAprovador = eGastoCompleja.IdAprovador,
                FechaRegistro = eGastoCompleja.FechaRegistro,
                FechaModificacion = ObtenerFechaZonaLocal(),
                Estado = eGastoCompleja.Estado



            };
            aAquacorp.Actualizar_Gasto(eGastoSimple);
            return true;
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return false;
        }
    }
    public EGastoCompleja Obtener_Gasto_Id_Gasto(int IdGasto)
    {
        EGastoCompleja eGastoCompleja = new EGastoCompleja();
        try
        {
            SWDatos.EGastoSimple eGastoSimple = aAquacorp.Obtener_Gasto_Id_Gasto(IdGasto);
            SWDatos.ETipoGastoSimple eTipoGastoSimple = aAquacorp.Obtener_TipoGasto_Id_TipoGasto(eGastoSimple.IdTipoGasto);
            eGastoCompleja = new EGastoCompleja()
            {

                IdGasto = eGastoSimple.IdGasto,
                IdTipoGasto = eGastoSimple.IdTipoGasto, 
                NombreTipoGasto= eTipoGastoSimple.NombreTipoGasto,
                Cantidad = eGastoSimple.Cantidad,
                Precio = eGastoSimple.Precio,
                IdUsuario = eGastoSimple.IdUsuario,
                IdAprovador = eGastoSimple.IdAprovador,
                FechaRegistro = eGastoSimple.FechaRegistro,
                FechaModificacion = eGastoSimple.FechaModificacion,
                Estado = eGastoSimple.Estado

            };
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eGastoCompleja;
    }

    public List<EGastoCompleja> Obtener_Gasto_Id_Usuario_Fecha(int idUsuario)
    {
        List<EGastoCompleja> lstEGastoCompleja = new List<EGastoCompleja>();
        int cont = 0;
        try
        {
            List<SWDatos.EGastoSimple> lstEGastoSimple = aAquacorp.Obtener_Gasto();
            foreach (SWDatos.EGastoSimple eGastoSimple in lstEGastoSimple)
            {
                if (eGastoSimple.IdUsuario == idUsuario)
                {
                    if (eGastoSimple.FechaRegistro.Date == ObtenerFechaZonaLocal().Date)
                    {
                        if (eGastoSimple.Estado == "HA")
                        {
                            cont++;
                            SWDatos.ETipoGastoSimple eTipoGastoSimple = aAquacorp.Obtener_TipoGasto_Id_TipoGasto(eGastoSimple.IdTipoGasto);
                            EGastoCompleja eGastoCompleja = new EGastoCompleja()
                            {
                                Cont = cont,
                                IdGasto = eGastoSimple.IdGasto,
                                IdTipoGasto = eGastoSimple.IdTipoGasto,
                                NombreTipoGasto = eTipoGastoSimple.NombreTipoGasto,
                                Cantidad = eGastoSimple.Cantidad,
                                Precio = eGastoSimple.Precio,
                                IdUsuario = eGastoSimple.IdUsuario,
                                IdAprovador = eGastoSimple.IdAprovador,
                                FechaRegistro = eGastoSimple.FechaRegistro,
                                FechaModificacion = eGastoSimple.FechaModificacion,
                                Estado = eGastoSimple.Estado

                            };
                            lstEGastoCompleja.Add(eGastoCompleja);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }

        return lstEGastoCompleja;
    }

    public decimal Obtener_Cantidad_Gasto_Id_Usuario(int idUsuario)
    {
        decimal cantidad = 0;
        try
        {
            List<SWDatos.EGastoSimple> lstEGastoSimple = aAquacorp.Obtener_Gasto();
            foreach (SWDatos.EGastoSimple eGastoSimple in lstEGastoSimple)
            {
                if (eGastoSimple.IdUsuario == idUsuario)
                {
                    if (eGastoSimple.FechaRegistro.Date == ObtenerFechaZonaLocal().Date)
                    {
                        if (eGastoSimple.Estado == "HA")
                        {
                            cantidad += eGastoSimple.Precio;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }

        return cantidad;
    }

    public List<EGastoCompleja> Obtener_Gasto()
    {
        List<EGastoCompleja> lstEGastoCompleja = new List<EGastoCompleja>();
        int cont = 0;
        try
        {
            List<SWDatos.EGastoSimple> lstEGastoSimple = aAquacorp.Obtener_Gasto();
            foreach (SWDatos.EGastoSimple eGastoSimple in lstEGastoSimple)
            {
                if (eGastoSimple.Estado == "HA")
                {
                    cont++;

                    SWDatos.ETipoGastoSimple eTipoGastoSimple = aAquacorp.Obtener_TipoGasto_Id_TipoGasto(eGastoSimple.IdTipoGasto);
                    EGastoCompleja eGastoCompleja = new EGastoCompleja()
                    {
                        Cont = cont,
                        IdGasto = eGastoSimple.IdGasto,
                        IdTipoGasto = eGastoSimple.IdTipoGasto,
                        NombreTipoGasto = eTipoGastoSimple.NombreTipoGasto,
                        Cantidad = eGastoSimple.Cantidad,
                        Precio = eGastoSimple.Precio,
                        IdUsuario = eGastoSimple.IdUsuario,
                         IdAprovador = eGastoSimple.IdAprovador,
                         FechaRegistro = eGastoSimple.FechaRegistro,
                        FechaModificacion = eGastoSimple.FechaModificacion,
                        Estado = eGastoSimple.Estado

                    };
                    lstEGastoCompleja.Add(eGastoCompleja);
                }

            }
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }

        return lstEGastoCompleja;
    }
    #endregion


    #region METODOS PRIVADOS
    private string GetSHA256(string str)
    {
        try
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        catch (Exception ex)
        {

            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

            return "";
        }
    }


    public DateTime ObtenerFechaZonaLocal()
    {
        try
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Venezuela Standard Time")).ToUniversalTime().ToLocalTime();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return DateTime.Now;
        }
    }


    private int NumeroSemana(DateTime time)
    {
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            time = time.AddDays(3);
        }
        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    public DateTime ObtenerPrimerDiaSemana(DateTime fecha)
    {
        //CultureInfo.CurrentCulture = new CultureInfo("es-BO");

        return primerDíaSemana(NumeroSemana(fecha) == 52 ? fecha.AddYears(-1).Year : fecha.Year, NumeroSemana(fecha), new CultureInfo("es-BO"));


    }

    private DateTime primerDíaSemana(int year, int weekOfYear, System.Globalization.CultureInfo ci)
    {
        DateTime jan1 = new DateTime(year, 1, 1);
        int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
        DateTime firstWeekDay = jan1.AddDays(daysOffset);
        int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
        if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
        {
            weekOfYear -= 1;
        }
        return firstWeekDay.AddDays(weekOfYear * 7);
    }
    private string AbreviarCiudades(string ciudad)
    {
        string abr = "";
        switch (ciudad)
        {
            case "LA PAZ":
                abr = "LP";
                break;
            case "SANTA CRUZ":
                abr = "SC";
                break;
            case "COCHABAMBA":
                abr = "CB";
                break;
            case "ORURO":
                abr = "OR";
                break;
            case "PANDO":
                abr = "PD";
                break;
            case "BENI":
                abr = "BE";
                break;
            case "POTOSI":
                abr = "PT";
                break;
            case "CHUQUISACA":
                abr = "CH";
                break;
            case "TARIJA":
                abr = "TJ";
                break;
        }
        return abr;
    }
    #endregion



    public static string stringBetween(string Source, string Start, string End)
    {
        string result = "";
        if (Source.Contains(Start) && Source.Contains(End))
        {
            int StartIndex = Source.IndexOf(Start, 0) + Start.Length;
            int EndIndex = Source.IndexOf(End, StartIndex);
            result = Source.Substring(StartIndex, EndIndex - StartIndex);
            return result;
        }

        return result;
    }
    public string LinkVacuna(string ci, string fecha)
    {
        HtmlWeb oWeb = new HtmlWeb();
        string cas = "https://sus.minsalud.gob.bo/buscar_vacuna_pagina?tipodocumento_vacuna=1&nrodocumento_vacuna=" + ci + "&fechanacimiento_vacuna=" + fecha;
        HtmlDocument doc = oWeb.Load(cas);

        // HtmlNode Body = doc.DocumentNode.CssSelect("table").First();
        HtmlNode Body = doc.DocumentNode;
        string sBody = Body.InnerHtml;
        //string s = " < dt > Nombre completo: </ dt >  < dd > ANDRES MAX JALDIN SANCHEZ </ dd >< dt > Documento de Identidad:</ dt >  < dd > 5312510 </ dd >   < dt > Fecha nacimiento:</ dt > < dd > 28 / 12 / 1988 </ dd >  < dt > Departamento:</ dt > < dd > COCHABAMBA </ dd >  ";

        sBody = sBody.Replace('\"', '\'');
        // sBody = sBody.Replace(" ", string.Empty);

        string word1 = "align='left'>";
        string word2 = "</td>";
        string nombre = stringBetween(sBody, word1, word2);


        string word11 = "href='";
        string word22 = "' target";
        return "https://sus.minsalud.gob.bo" + stringBetween(sBody, word11, word22);
    }
}