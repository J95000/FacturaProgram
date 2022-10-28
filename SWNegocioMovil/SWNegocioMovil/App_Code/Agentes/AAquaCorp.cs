using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de AAquaCorp
/// </summary>
public class AAquaCorp : System.Web.UI.Page
{
    SWDatos.SWDatosAquacorpClient cliente;
    public AAquaCorp()
    {
        try
        {

            cliente = new SWDatos.SWDatosAquacorpClient();
        }
        catch (Exception ex)
        {

              Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
    }
    public void Insertar_Zona(SWDatos.EZonaSimple eZonaSimple)
    {
        try
        {
            cliente.Insertar_Zona(eZonaSimple);
        }
        catch (Exception ex)
        {
             Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }

    }
    //public List<SWDatos.EZonaSimple> Obtener_Zona()
    //{
    //    List<SWDatos.EZonaSimple> lstEZonaSimple = new List<SWDatos.EZonaSimple>();
    //    try
    //    {
    //        lstEZonaSimple = cliente.Obtener_Zona().ToList();
    //    }
    //    catch (Exception ex)
    //    {
    //         Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

    //    }
    //    return lstEZonaSimple;
    //}


    #region EXCEPCION
    public void Insertar_Exception_LocalDatos(SWDatos.EExceptionSimple eExceptionSimple)
    {
        try
        {
            cliente.Insertar_Exception(eExceptionSimple);
        }
        catch (Exception ex)
        {
            LlenadoArchivo(new EExceptionCompleja() { Fecha = ObtenerFechaZonaLocal(), IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        

    }
    public void LlenadoArchivo(EExceptionCompleja eExceptionCompleja)
    {

        string mes = DateTime.Now.ToString("MMMM");
        string ruta = Server.MapPath("~/LogException/" + mes + ".txt");
        Byte[] eException = new UTF8Encoding(true).GetBytes(Environment.NewLine + ObtenerFechaZonaLocal() + "|" + eExceptionCompleja.IdUsuario + "|" + eExceptionCompleja.NombreMetodo + "|" + eExceptionCompleja.Mensaje + "|" + eExceptionCompleja.ExceptionMensaje);
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
        catch (Exception )
        {
          //  Insertar_Exception_LocalDatos(new EExceptionCompleja() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
            return DateTime.Now;
        }
    }
    #endregion


    #region EXISTENCIA


    public void Insertar_Existencia(SWDatos.EExistenciaSimple eExistenciaSimple)
    {
        try
        {
            cliente.Insertar_Existencia(eExistenciaSimple);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }

    }
    public void Actualizar_Existencia(SWDatos.EExistenciaSimple eExistenciaSimple)
    {
        try
        {
            cliente.Actualizar_Existencia(eExistenciaSimple);
        }
        catch (Exception ex)
        {
             Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
    }

    public SWDatos.EExistenciaSimple Obtener_Existencia_Id_Existencia(int IdExistencia)
    {
        SWDatos.EExistenciaSimple eExistenciaSimple = new SWDatos.EExistenciaSimple();
        try
        {
            eExistenciaSimple = cliente.Obtener_Existencia_Id_Existencia(IdExistencia);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eExistenciaSimple;
    }

    public List<SWDatos.EExistenciaSimple> Obtener_Existencia()
    {
        List<SWDatos.EExistenciaSimple> EExistenciaSimples = new List<SWDatos.EExistenciaSimple>();
        try
        {
            EExistenciaSimples = cliente.Obtener_Existencia().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return EExistenciaSimples;
    }


    #endregion


    #region PRODUCTO
    public void Insertar_Producto(SWDatos.EProductoSimple eProductoSimple)
    {
        try
        {
            cliente.Insertar_Producto(eProductoSimple);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }

    }
   
    public void Actualizar_Producto(SWDatos.EProductoSimple eProductoSimple)
    {
        try
        {
            cliente.Actualizar_Producto(eProductoSimple);
        }
        catch (Exception ex)
        {
             Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
    }
    public SWDatos.EProductoSimple Obtener_Producto_Id_Producto(int IdProducto)
    {
        SWDatos.EProductoSimple eProductoSimple = new SWDatos.EProductoSimple();
        try
        {
            eProductoSimple = cliente.Obtener_Producto_Id_Producto(IdProducto);
        }
        catch (Exception ex)
        {
             Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eProductoSimple;
    }
    public List<SWDatos.EProductoSimple> Obtener_Producto()
    {
        List<SWDatos.EProductoSimple> lstEProductoSimple = new List<SWDatos.EProductoSimple>();
        try
        {
            lstEProductoSimple = cliente.Obtener_Producto().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstEProductoSimple;
    }

    public List<SWDatos.EProductoSimple> Obtener_Producto_SinFoto()
    {
        List<SWDatos.EProductoSimple> lstEProductoSimple = new List<SWDatos.EProductoSimple>();
        try
        {
            lstEProductoSimple = cliente.Obtener_Producto_SinFoto().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstEProductoSimple;
    }

    public List<SWDatos.EProductoSimple> Obtener_Producto_Mobil()
    {
        List<SWDatos.EProductoSimple> lstEProductoSimple = new List<SWDatos.EProductoSimple>();
        try
        {
            lstEProductoSimple = cliente.Obtener_Producto_Mobil().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstEProductoSimple;
    }
    #endregion


    #region PRECIO SUGERIDO
    public void Insertar_PrecioSugerido(SWDatos.EPrecioSugeridoSimple ePrecioSugeridoSimple)
    {
        try
        {
            cliente.Insertar_PrecioSugerido(ePrecioSugeridoSimple);
        }
        catch (Exception ex)
        {
         Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }

    }
    public void Actualizar_PrecioSugerido(SWDatos.EPrecioSugeridoSimple ePrecioSugeridoSimple)
    {
        try
        {
            cliente.Actualizar_PrecioSugerido(ePrecioSugeridoSimple);
        }
        catch (Exception ex)
        {
             Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
    }
    public SWDatos.EPrecioSugeridoSimple Obtener_PrecioSugerido_Id_PrecioSugerido(int IdPrecioSugerido)
    {
        SWDatos.EPrecioSugeridoSimple ePrecioSugeridoSimple = new SWDatos.EPrecioSugeridoSimple();
        try
        {
            ePrecioSugeridoSimple = cliente.Obtener_PrecioSugerido_Id_PrecioSugerido(IdPrecioSugerido);
        }
        catch (Exception ex)
        {
          Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return ePrecioSugeridoSimple;
    }
    public List<SWDatos.EPrecioSugeridoSimple> Obtener_PrecioSugerido()
    {
        List<SWDatos.EPrecioSugeridoSimple> lstEPrecioSugeridoSimple = new List<SWDatos.EPrecioSugeridoSimple>();
        try
        {
            lstEPrecioSugeridoSimple = cliente.Obtener_PrecioSugerido().ToList();
        }
        catch (Exception ex)
        {
             Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstEPrecioSugeridoSimple;
    }
    #endregion


    #region EMPLEADO

    public SWDatos.EEmpleadoSimple Obtener_Empleado_Id_Empleado(int IdEmpleado)
    {
        SWDatos.EEmpleadoSimple eEmpleadoSimple = new SWDatos.EEmpleadoSimple();
        try
        {
            eEmpleadoSimple = cliente.Obtener_Empleado_Id_Empleado(IdEmpleado);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eEmpleadoSimple;
    }
    public List<SWDatos.EEmpleadoSimple> Obtener_Empleado()
    {
        List<SWDatos.EEmpleadoSimple> eEmpleadoSimple = new List<SWDatos.EEmpleadoSimple>();
        try
        {
            eEmpleadoSimple = cliente.Obtener_Empleado().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eEmpleadoSimple;
    }

    #endregion


    #region USUARIO
    public void Actualizar_Usuario(SWDatos.EUsuarioSimple eUsuarioSimple)
    {
        
        try
        {
             cliente.Actualizar_Usuario(eUsuarioSimple);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        
    }
    public SWDatos.EUsuarioSimple Obtener_Usuario_Id_Usuario(int IdUsuario)
    {
        SWDatos.EUsuarioSimple eUsuarioSimple = new SWDatos.EUsuarioSimple();
        try
        {
            eUsuarioSimple = cliente.Obtener_Usuario_Id_Usuario(IdUsuario);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eUsuarioSimple;
    }
    public List<SWDatos.EUsuarioSimple> Obtener_Usuario()
    {
        List<SWDatos.EUsuarioSimple> eUsuarioSimple = new List<SWDatos.EUsuarioSimple>();
        try
        {
            eUsuarioSimple = cliente.Obtener_Usuario().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eUsuarioSimple;
    }

    #endregion


    #region CIUDAD

    public SWDatos.ECiudadSimple Obtener_Ciudad_Id_Ciudad(byte IdCiudad)
    {
        SWDatos.ECiudadSimple eCiudadSimple = new SWDatos.ECiudadSimple();
        try
        {
            eCiudadSimple = cliente.Obtener_Ciudad_Id_Ciudad(IdCiudad);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eCiudadSimple;
    }


    #endregion

    #region CARGO

    public SWDatos.ECargoSimple Obtener_Cargo_Id_Cargo(byte IdCargo)
    {
        SWDatos.ECargoSimple eCargoSimple = new SWDatos.ECargoSimple();
        try
        {
            eCargoSimple = cliente.Obtener_Cargo_Id_Cargo(IdCargo);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eCargoSimple;
    }


    #endregion



    #region DISTRIBUIDOR
    public void Insertar_UbicacionDistribuidor(SWDatos.EUbicacionDistribuidorSimple eUbicacionDistribuidorCompleja)
    {
        try
        {
            cliente.Insertar_UbicacionDistribuidor(eUbicacionDistribuidorCompleja);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }

    }

    public void Insertar_Cliente(SWDatos.EClienteSimple eClienteCompleja)
    {
        try
        {
            cliente.Insertar_Cliente(eClienteCompleja);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }

    }

    public List<SWDatos.ECategoriaClienteSimple> Obtener_CategoriaCliente()
    {
        List<SWDatos.ECategoriaClienteSimple> lstECategoriaClienteCompleja = new List<SWDatos.ECategoriaClienteSimple>();
 
        try
        {
            lstECategoriaClienteCompleja = cliente.Obtener_CategoriaCliente().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }


        return lstECategoriaClienteCompleja;
    }

    public List<SWDatos.EZonaSimple> Obtener_Zona()
    {
        List<SWDatos.EZonaSimple> lstEZonaCompleja = new List<SWDatos.EZonaSimple>();
        try
        {
            lstEZonaCompleja = cliente.Obtener_Zona().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }




        return lstEZonaCompleja;
    }
    
    public List<SWDatos.EClienteSimple> Obtener_Cliente()
    {
        List<SWDatos.EClienteSimple> lstEClienteCompleja = new List<SWDatos.EClienteSimple>();
        try
        {
            lstEClienteCompleja = cliente.Obtener_Cliente().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }



        return lstEClienteCompleja;
    }

    public void Insertar_Movimiento(SWDatos.EMovimientoSimple eMovimientoCompleja)
    {

        try
        {
            cliente.Insertar_Movimiento(eMovimientoCompleja);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
    }

    public void Insertar_DetalleMovimiento(SWDatos.EDetalleMovimientoSimple eDetalleMovimientoCompleja)
    {
        try
        {
            cliente.Insertar_DetalleMovimiento(eDetalleMovimientoCompleja);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }

    }

    public List<SWDatos.ETipoGastoSimple> Obtener_TipoGasto()
    {
        List<SWDatos.ETipoGastoSimple> lstETipoGastoCompleja = new List<SWDatos.ETipoGastoSimple>();
        try
        {
            lstETipoGastoCompleja = cliente.Obtener_TipoGasto().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstETipoGastoCompleja;
    }

    public  SWDatos.ETipoGastoSimple  Obtener_TipoGasto_Id_TipoGasto(byte idTipoGasto )
    {
         SWDatos.ETipoGastoSimple  lstETipoGastoCompleja = new SWDatos.ETipoGastoSimple();
        try
        {
            lstETipoGastoCompleja = cliente.Obtener_TipoGasto_Id_TipoGasto(idTipoGasto);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstETipoGastoCompleja;
    }

    public List<SWDatos.EMovimientoSimple> Obtener_Movimiento()
    {
        List<SWDatos.EMovimientoSimple> lstEMovimientoCompleja = new List<SWDatos.EMovimientoSimple>();
        try
        {
            lstEMovimientoCompleja = cliente.Obtener_Movimiento().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstEMovimientoCompleja;
    }

    public SWDatos.ECategoriaClienteSimple Obtener_CategoriaCliente_Id_CategoriaCliente(byte IdCategoriaCliente)
    {
        SWDatos.ECategoriaClienteSimple lstECategoriaClienteCompleja = new SWDatos.ECategoriaClienteSimple();
        try
        {
            lstECategoriaClienteCompleja = cliente.Obtener_CategoriaCliente_Id_CategoriaCliente(IdCategoriaCliente);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstECategoriaClienteCompleja;
    }
    public SWDatos.EZonaSimple Obtener_Zona_Id_Zona(byte IdZona)
    {
        SWDatos.EZonaSimple lstEZonaCompleja = new SWDatos.EZonaSimple();
        try
        {
            lstEZonaCompleja = cliente.Obtener_Zona_Id_Zona(IdZona);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstEZonaCompleja;
    }
    public List<SWDatos.EClienteSimple> Obtener_Cliente_Buscador(string nombre)
    {
        List<SWDatos.EClienteSimple> lstEClienteCompleja = new List<SWDatos.EClienteSimple>();
        try
        {
            lstEClienteCompleja = cliente.Obtener_Cliente_Buscador(nombre).ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstEClienteCompleja;
    }
    #endregion



    #region GASTO
    public void Insertar_Gasto(SWDatos.EGastoSimple eGastoSimple)
    {
        try
        {
            cliente.Insertar_Gasto(eGastoSimple);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }

    }
    public void Actualizar_Gasto(SWDatos.EGastoSimple eGastoSimple)
    {
        try
        {
            cliente.Actualizar_Gasto(eGastoSimple);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
    }
    public SWDatos.EGastoSimple Obtener_Gasto_Id_Gasto(int IdGasto)
    {
        SWDatos.EGastoSimple eGastoSimple = new SWDatos.EGastoSimple();
        try
        {
            eGastoSimple = cliente.Obtener_Gasto_Id_Gasto(IdGasto);
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return eGastoSimple;
    }
    public List<SWDatos.EGastoSimple> Obtener_Gasto()
    {
        List<SWDatos.EGastoSimple> lstEGastoSimple = new List<SWDatos.EGastoSimple>();
        try
        {
            lstEGastoSimple = cliente.Obtener_Gasto().ToList();
        }
        catch (Exception ex)
        {
            Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

        }
        return lstEGastoSimple;
    }

    //public List<SWDatos.EArqueoGastoSimple> Arqueo_Gasto(int idUsuario, DateTime fecha)
    //{
    //    List<SWDatos.EArqueoGastoSimple> lstEGastoSimple = new List<SWDatos.EArqueoGastoSimple>();
    //    try
    //    {
    //        lstEGastoSimple = cliente.Arqueo_Gasto(idUsuario, fecha).ToList();
    //    }
    //    catch (Exception ex)
    //    {
    //        Insertar_Exception_LocalDatos(new SWDatos.EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });

    //    }
    //    return lstEGastoSimple;
    //}
    #endregion
}