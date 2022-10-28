using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISWNegocioMovil" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface ISWNegocioMovil
{
 





    #region PRODUCTOs
//    [OperationContract]
//    [WebInvoke(Method = "POST",
//UriTemplate = "/AddPayee/{Name}/{City}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
//    bool AddPayee(string Name, string City);



    //[OperationContract]
    //[WebInvoke(UriTemplate = "/{nombreProducto}/{descripcion}/{consumible}/{fotoProducto}",
    //        RequestFormat = WebMessageFormat.Json,
    //        BodyStyle = WebMessageBodyStyle.Wrapped,
    //        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    //bool Insertar_Producto(string nombreProducto, string descripcion, string consumible, string fotoProducto);

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    //[OperationContract]
    //[WebInvoke(UriTemplate = "/InsertarZona",
    //    RequestFormat = WebMessageFormat.Json,
    //    ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    //bool Insertar_Zona(EZonaCompleja eZonaCompleja);

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////


    //[OperationContract]
    //[WebInvoke(UriTemplate = "/InsertarProducto",
    //  RequestFormat = WebMessageFormat.Json,
    //  ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    //bool Insertar_Productoo(EProductoPrueba eProductoPrueba);



    #endregion



    #region ACCESO

    //se dejara de usar
    [OperationContract]
    [WebGet( 
        
        RequestFormat = WebMessageFormat.Json, 
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Acceso_Ci_Contrasena/{ci}/{contrasena}")]
    bool Acceso_Ci_Contrasena_Async(string ci, string contrasena);





    [OperationContract]
    [WebGet(

    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Acceso_Ci_Contrasena_Usuario/{ci}/{contrasena}")]
    EUsuarioCortaCompleja Acceso_Ci_Contrasena_Usuario_Async(string ci, string contrasena);



    [OperationContract]
    [WebGet(

        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/ObtenerFechaZonaLocal")]
    DateTime ObtenerFechaZonaLocal();
    [OperationContract]
    [WebGet(

      RequestFormat = WebMessageFormat.Json,
      ResponseFormat = WebMessageFormat.Json,
  UriTemplate = "/Restablecer_Contrasena_Usuario/{contrasena}/{idUsuario}")]
    bool Restablecer_Contrasena_Usuario(string contrasena, string idUsuario);
    #endregion



    #region PRODUCTO


    [OperationContract]
    [WebInvoke(UriTemplate = "/InsertarProducto",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Insertar_Producto_Async(EProductoCompleja eProductoCompleja);
       [OperationContract]
    [WebInvoke(UriTemplate = "/ActualizarProducto",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Actualizar_Producto_Async(EProductoCompleja eProductoCompleja);




    [OperationContract]
    [WebGet( 
         
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Producto_Id_Producto/{IdProducto}")]
    EProductoCompleja Obtener_Producto_Id_Producto_Async(string IdProducto);

    [OperationContract]
    [WebGet(

       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
   UriTemplate = "/Obtener_Producto_Id_Producto_Foto/{IdProducto}")]
    EProductoFoto Obtener_Producto_Id_Producto_Foto_Async(string IdProducto);


    [OperationContract]
    [WebGet(

       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
   UriTemplate = "/Obtener_Producto")]
    List<EProductoCompleja> Obtener_Producto_Async();
   [OperationContract]
    List<EProductoCompleja> Obtener_Producto_SinFoto_Async();
      [OperationContract]
    [WebGet(

        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Producto_Mobil")]
    List<EProductoCortaCompleja> Obtener_Producto_Mobil();
      [OperationContract]
    List<EProductoCortaCompleja> Obtener_Producto_Catalogo();
      [OperationContract]
    byte Verificar_Producto_NombreProducto(string nombreProducto);
       //[OperationContract]
    //int Verificar_Producto_IdProducto_NombreProducto(string id, string nombreProducto);




        [OperationContract]
    [WebGet(

        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/ObtenerId_Producto_NombreProducto/{nombreProducto}")]
    int ObtenerId_Producto_NombreProducto_Async(string nombreProducto);





       [OperationContract]
    int Obtener_Ultimo_Id_Producto();
       [OperationContract]
    List<EProductoCompleja> Obtener_Producto_SinContador();

    #endregion

    #region PRECIO SUGERIDO

    [OperationContract]
    [WebInvoke(UriTemplate = "/InsertarPrecioSugerido",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Insertar_PrecioSugerido_Async(EPrecioSugeridoCompleja ePrecioSugeridoCompleja);
      [OperationContract]
    [WebInvoke(UriTemplate = "/ActualizarPrecioSugerido",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Actualizar_PrecioSugerido_Async(EPrecioSugeridoCompleja ePrecioSugeridoCompleja);





      [OperationContract]
    EPrecioSugeridoCompleja Obtener_PrecioSugerido_Id_PrecioSugerido(string IdPrecioSugerido);
       [OperationContract]
    List<EPrecioSugeridoCompleja> Obtener_PrecioSugerido();



       [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_PrecioSugerido_IdProducto/{idProducto}")]
    List<EPrecioSugeridoCompleja> Obtener_PrecioSugerido_IdProducto(string idProducto);



    #endregion

    #region USUARIO



    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Usuario_Empleado_Ci/{ci}")]
    EUsuarioCompleja Obtener_Usuario_Empleado_Ci_Async(string ci);


    #endregion

    #region EMPLEADO

    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Empleado_Id_Empleado/{IdEmpleado}")]
    EEmpleadoCortaCompleja Obtener_Empleado_Id_Empleado_Async(string IdEmpleado);


    #endregion

    #region EXISTENCIA


    [OperationContract]
    [WebInvoke(UriTemplate = "/InsertarExistencia",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Insertar_Existencia_Async(EExistenciaCompleja eExistenciaCompleja);
      [OperationContract]
    [WebInvoke(UriTemplate = "/ActualizarExistencia",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Actualizar_Existencia_Async(EExistenciaCompleja eExistenciaCompleja);





      [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Existencia_Id_Existencia/{IdExistencia}")]
    EExistenciaCortaCompleja Obtener_Existencia_Id_Existencia_Async(string IdExistencia);

    [OperationContract]
    [WebGet(
      RequestFormat = WebMessageFormat.Json,
      ResponseFormat = WebMessageFormat.Json,
  UriTemplate = "/Obtener_Existencia_Id_Existencia_Completa/{IdExistencia}")]
    EExistenciaCompleja Obtener_Existencia_Id_Existencia_Completa_Async(string IdExistencia);


    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Existencia")]
    List<EExistenciaCompleja> Obtener_Existencia_Async();
    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Existencia_Fecha/{idPersona}")]
    List<EExistenciaCortaCompleja> Obtener_Existencia_Fecha_Async(string idPersona);
    //   [OperationContract]
    //List<EExistenciaMovilCompleja> Obtener_Existencia_Fecha_Movil(string idPersona, DateTime fecha);





    #endregion


    #region DISTRIBUIDOR



    [OperationContract]
    [WebInvoke(UriTemplate = "/InsertarUbicacionDistribuidor",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Insertar_UbicacionDistribuidor(EUbicacionDistribuidorCompleja eUbicacionDistribuidorCompleja);
    [OperationContract]
    [WebInvoke(UriTemplate = "/InsertarCliente",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Insertar_Cliente(EClienteCompleja eClienteCompleja);
    [OperationContract]
    [WebInvoke(UriTemplate = "/InsertarMovimiento",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Insertar_Movimiento(EMovimientoCompleja eMovimientoCompleja);

    [OperationContract]
    [WebInvoke(UriTemplate = "/InsertarDetalleMovimiento",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Insertar_DetalleMovimiento(EDetalleMovimientoCompleja eDetalleMovimientoCompleja);



    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Verificar_Pedido_IdUsuario/{IdUsuario}")]
    bool Verificar_Pedido_IdUsuario(string IdUsuario);






    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_CategoriaCliente")]
    List<ECategoriaClienteCompleja> Obtener_CategoriaCliente();



    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Zona")]
    List<EZonaCompleja> Obtener_Zona();




    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Cliente")]
    List<EClienteNombres> Obtener_Cliente();


    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Cliente_Buscador_NombreCompleto/{nombre}")]
    EClienteCompleja Obtener_Cliente_Buscador_NombreCompleto(string nombre);


    [OperationContract]
    [WebGet(
      RequestFormat = WebMessageFormat.Json,
      ResponseFormat = WebMessageFormat.Json,
  UriTemplate = "/Obtener_Cliente_Buscador_NombreCompleto_Corta/{nombre}")]
    EClienteNombres Obtener_Cliente_Buscador_NombreCompleto_Corta(string nombre);



    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Ultimo_IdMovimiento")]
    int Obtener_Ultimo_IdMovimiento();



    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Cliente_Buscador_ConContrato/{nombre}")]
    List<EClienteCompleja> Obtener_Cliente_Buscador_ConContrato(string nombre);


    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_TipoGasto_Distribuccion")]
    List<ETipoGastoCompleja> Obtener_TipoGasto_Distribuccion();

    #endregion


    [OperationContract]
    [WebGet(
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
   UriTemplate = "/LinkVacuna/{ci}/{fecha}")]
    string LinkVacuna(string ci, string fecha);




    #region GASTO
    [OperationContract]
    [WebInvoke(UriTemplate = "/Insertar_Gasto",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Insertar_Gasto(EGastoCompleja eGastoCompleja);


    [OperationContract]
    [WebInvoke(UriTemplate = "/Actualizar_Gasto",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
    bool Actualizar_Gasto(EGastoCompleja eGastoCompleja);



    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Gasto_Id_Gasto/{IdGasto}")]
    EGastoCompleja Obtener_Gasto_Id_Gasto(string IdGasto);


    [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Gasto_Id_Usuario_Fecha/{idUsuario}")]
    List<EGastoCompleja> Obtener_Gasto_Id_Usuario_Fecha(string idUsuario);



     [OperationContract]
    [WebGet(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/Obtener_Cantidad_Gasto_Id_Usuario/{idUsuario}")]
    decimal Obtener_Cantidad_Gasto_Id_Usuario(string idUsuario);

    [OperationContract]
    [WebGet(
      RequestFormat = WebMessageFormat.Json,
      ResponseFormat = WebMessageFormat.Json,
  UriTemplate = "/Obtener_Gasto")]
    List<EGastoCompleja> Obtener_Gasto();
    #endregion
}
