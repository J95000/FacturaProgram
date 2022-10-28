using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface ISWDatosAquacorp
{

    #region PERSONA
    [OperationContract]
    void Insertar_Persona(EPersonaSimple ePersonaSimple);
    [OperationContract]
    void Actualizar_Persona(EPersonaSimple ePersonaSimple);
    [OperationContract]
    EPersonaSimple Obtener_Persona_Id_Persona(int IdPersona);
    [OperationContract]
    List<EPersonaSimple> Obtener_Persona();
    [OperationContract]
    int Obtener_Ultimo_Id_Empleado();
    [OperationContract]
    int Obtener_Ultimo_Id(string nombreTabla, string nombreId);
    #endregion

    #region CARGO
    [OperationContract]
    void Insertar_Cargo(ECargoSimple eCargoSimple);
    [OperationContract]
    void Actualizar_Cargo(ECargoSimple eTCargoSimple);
    [OperationContract]
    ECargoSimple Obtener_Cargo_Id_Cargo(byte IdCargo);
    [OperationContract]
    List<ECargoSimple> Obtener_Cargo();

    #endregion

    #region USUARIO
    [OperationContract]
    void Insertar_Usuario(EUsuarioSimple eUsuarioSimple);
    [OperationContract]
    void Actualizar_Usuario(EUsuarioSimple eUsuarioSimple);
    [OperationContract]
    EUsuarioSimple Obtener_Usuario_Id_Usuario(int IdUsuario);
    [OperationContract]
    List<EUsuarioSimple> Obtener_Usuario();

    #endregion

    #region CIUDAD

    [OperationContract]
    ECiudadSimple Obtener_Ciudad_Id_Ciudad(byte IdCiudad);
    [OperationContract]
    List<ECiudadSimple> Obtener_Ciudad();

    #endregion

    #region EMPLEADO
    [OperationContract]
    void Insertar_Empleado(EEmpleadoSimple eEmpleadoSimple);
    [OperationContract]
    void Actualizar_Empleado(EEmpleadoSimple eEmpleadoSimple);
    [OperationContract]
    EEmpleadoSimple Obtener_Empleado_Id_Empleado(int IdEmpleado);
    [OperationContract]
    List<EEmpleadoSimple> Obtener_Empleado();
    [OperationContract]
    List<EEmpleadoSimple> Obtener_Empleado_Buscador(string nombre);
    #endregion

    #region REFERENCIAPERSONAL

    [OperationContract]
    void Insertar_ReferenciaPersonal(EReferenciaPersonalSimple eReferenciaPersonalSimple);
    [OperationContract]
    void Actualizar_ReferenciaPersonal(EReferenciaPersonalSimple eReferenciaPersonalSimple);
    [OperationContract]
    EReferenciaPersonalSimple Obtener_ReferenciaPersonal_Id_Empleado(int IdEmpleado);
    [OperationContract]
    List<EReferenciaPersonalSimple> Obtener_ReferenciaPersonal();

    #endregion

    #region REFERENCIALABORAL

    [OperationContract]
    void Insertar_ReferenciaLaboral(EReferenciaLaboralSimple eReferenciaLaboralSimple);
    [OperationContract]
    void Actualizar_ReferenciaLaboral(EReferenciaLaboralSimple eReferenciaLaboralSimple);
    [OperationContract]
    EReferenciaLaboralSimple Obtener_ReferenciaLaboral_Id_Empleado(int IdEmpleado);
    [OperationContract]
    List<EReferenciaLaboralSimple> Obtener_ReferenciaLaboral();

    #endregion

    #region CONYUGUE

    [OperationContract]
    void Insertar_Conyugue(EConyugueSimple eConyugueSimple);
    [OperationContract]
    void Actualizar_Conyugue(EConyugueSimple eConyugueSimple);
    [OperationContract]
    EConyugueSimple Obtener_Conyugue_Id_Empleado(int IdEmpleado);
    [OperationContract]
    List<EConyugueSimple> Obtener_Conyugue();

    #endregion

    #region DESPIDO

    [OperationContract]
    void Insertar_Despido(EDespidoSimple eDespidoSimple);
    [OperationContract]
    void Actualizar_Despido(EDespidoSimple eDespidoSimple);
    [OperationContract]
    EDespidoSimple Obtener_Despido_Id_Empleado(int IdEmpleado);
    [OperationContract]
    List<EDespidoSimple> Obtener_Despido();

    #endregion

    #region HABILIDAD

    [OperationContract]
    void Insertar_Habilidad(EHabilidadSimple eHabilidadSimple);
    [OperationContract]
    void Actualizar_Habilidad(EHabilidadSimple eHabilidadSimple);
    [OperationContract]
    EHabilidadSimple Obtener_Habilidad_Id_Empleado(int IdEmpleado);
    [OperationContract]
    List<EHabilidadSimple> Obtener_Habilidad();

    #endregion

    #region PROVEEDOR
    [OperationContract]
    void Insertar_Proveedor(EProveedorSimple eProveedorSimple);
    [OperationContract]
    void Actualizar_Proveedor(EProveedorSimple eProveedorSimple);
    [OperationContract]
    EProveedorSimple Obtener_Proveedor_Id_Proveedor(int Id_Proveedor);
    [OperationContract]
    List<EProveedorSimple> Obtener_Proveedor();

    #endregion

    #region MATERIAL
    [OperationContract]
    void Insertar_Material(EMaterialSimple eMaterialSimple);
    [OperationContract]
    void Actualizar_Material(EMaterialSimple eMaterialSimple);
    [OperationContract]
    EMaterialSimple Obtener_Material_IdMaterial(int IdMaterial);
    [OperationContract]
    List<EMaterialSimple> Obtener_Material();
    #endregion

    #region CLIENTE
    [OperationContract]
    void Insertar_Cliente(EClienteSimple eClienteSimple);
    [OperationContract]
    void Actualizar_Cliente(EClienteSimple eClienteSimple);
    [OperationContract]

    EClienteSimple Obtener_Cliente_Id_Cliente(int Id_Cliente);
    [OperationContract]
    List<EClienteSimple> Obtener_Cliente();
    [OperationContract]
    List<EClienteSimple> Obtener_Cliente_Buscador(string nombre);
    #endregion

    #region CATEGORIACLIENTE

    [OperationContract]
    void Insertar_CategoriaCliente(ECategoriaClienteSimple eCategoriaClienteSimple);
    [OperationContract]
    void Actualizar_CategoriaCliente(ECategoriaClienteSimple eCategoriaClienteSimple);
    [OperationContract]
    ECategoriaClienteSimple Obtener_CategoriaCliente_Id_CategoriaCliente(byte IdCategoriaCliente);
    [OperationContract]
    List<ECategoriaClienteSimple> Obtener_CategoriaCliente();

    #endregion

    #region CONTROLENTRADA
    [OperationContract]
    void Insertar_ControlEntrada(EControlEntradaSimple eControlEntradaSimple);
    [OperationContract]
    void Actualizar_ControlEntrada(EControlEntradaSimple eControlEntradaSimple);
    [OperationContract]
    EControlEntradaSimple Obtener_ControlEntrada_Id_ControlEntrada(int Id_ControlEntrada);
    [OperationContract]
    List<EControlEntradaSimple> Obtener_ControlEntrada();

    #endregion

    #region ZONA
    [OperationContract]
    void Insertar_Zona(EZonaSimple eZonaSimple);
    [OperationContract]
    void Actualizar_Zona(EZonaSimple eZonaSimple);
    [OperationContract]
    EZonaSimple Obtener_Zona_Id_Zona(byte IdZona);
    [OperationContract]
    List<EZonaSimple> Obtener_Zona();

    #endregion

    #region PUNTOZONA
    [OperationContract]
    void Insertar_PuntoZona(EPuntoZonaSimple ePuntoZonaSimple);
    [OperationContract]
    void Actualizar_PuntoZona(EPuntoZonaSimple ePuntoZonaSimple);
    [OperationContract]
    EPuntoZonaSimple Obtener_PuntoZona_Id_PuntoZona(int IdPuntoZona);
    [OperationContract]
    List<EPuntoZonaSimple> Obtener_PuntoZona();
    [OperationContract]
    List<EPuntosSimple> Obtener_PuntoZona_Puntos(byte id);
    #endregion

    #region PRODUCCION
    [OperationContract]
    void Insertar_Produccion(EProduccionSimple eProduccionSimple);
    [OperationContract]
    void Actualizar_Produccion(EProduccionSimple eProduccionSimple);
    [OperationContract]
    EProduccionSimple Obtener_Produccion_IdProduccion(int IdProduccion);
    [OperationContract]
    List<EProduccionSimple> Obtener_Produccion();
    #endregion

    #region MATERIAPRIMA
    [OperationContract]
    void Insertar_MateriaPrima(EMateriaPrimaSimple eMateriaPrimaSimple);
    [OperationContract]
    void Actualizar_MateriaPrima(EMateriaPrimaSimple eMateriaPrimaSimple);
    [OperationContract]
    EMateriaPrimaSimple Obtener_MateriaPrima_IdMateriaPrima(int IdMateriaPrima);
    [OperationContract]
    List<EMateriaPrimaSimple> Obtener_MateriaPrima();
    #endregion

    #region EXISTENCIAMATERIAPRIMA
    [OperationContract]
    void Insertar_ExistenciaMateriaPrima(EExistenciaMateriaPrimaSimple eExistenciaMateriaPrimaSimple);
    [OperationContract]
    void Actualizar_ExistenciaMateriaPrima(EExistenciaMateriaPrimaSimple eExistenciaMateriaPrimaSimple);
    [OperationContract]
    EExistenciaMateriaPrimaSimple Obtener_ExistenciaMateriaPrima_IdExistenciaMateriaPrima(int IdExistenciaMateriaPrima);
    [OperationContract]
    List<EExistenciaMateriaPrimaSimple> Obtener_ExistenciaMateriaPrima();
    #endregion

    #region PROVISION
    [OperationContract]
    void Insertar_Provision(EProvisionSimple eProvisionSimple);
    [OperationContract]
    void Actualizar_Provision(EProvisionSimple eProvisionSimple);
    [OperationContract]
    EProvisionSimple Obtener_Provision_IdProvision(int IdProvision);
    [OperationContract]
    List<EProvisionSimple> Obtener_Provision();
    #endregion





    #region EXCEPTION
    [OperationContract]
    void Insertar_Exception(EExceptionSimple eExceptionSimple);
    [OperationContract]
    EExceptionSimple Obtener_Exception_Id_Exception(int IdException);
    [OperationContract]
    List<EExceptionSimple> Obtener_Exception();

    #endregion

    #region GASTO
    [OperationContract]
    void Insertar_Gasto(EGastoSimple eGastoSimple);
    [OperationContract]
    void Actualizar_Gasto(EGastoSimple eGastoSimple);
    [OperationContract]
    EGastoSimple Obtener_Gasto_Id_Gasto(int IdGasto);
    [OperationContract]
    List<EGastoSimple> Obtener_Gasto();
    [OperationContract]
    List<EArqueoGastoSimple> Arqueo_Gasto(int idUsuario, DateTime fecha);
    #endregion

    #region  TIPOGASTO
    [OperationContract]
    void Insertar_TipoGasto(ETipoGastoSimple eTipoGastoSimple);
    [OperationContract]
    void Actualizar_TipoGasto(ETipoGastoSimple eTipoGastoSimple);
    [OperationContract]
    ETipoGastoSimple Obtener_TipoGasto_Id_TipoGasto(byte IdTipoGasto);
    [OperationContract]
    List<ETipoGastoSimple> Obtener_TipoGasto();

    #endregion

    #region MOVIMIENTO
    [OperationContract]
    void Insertar_Movimiento(EMovimientoSimple eMovimientoSimple);
    [OperationContract]
    void Actualizar_Movimiento(EMovimientoSimple eMovimientoSimple);
    [OperationContract]
    EMovimientoSimple Obtener_Movimiento_Id_Movimiento(int IdMovimiento);
    [OperationContract]
    List<EMovimientoSimple> Obtener_Movimiento();
    [OperationContract]
    EMovimientoSimple Obtener_Movimiento_Codigo(string codigo);
    [OperationContract]
    List<ERepMovimientoSimple> Reporte_Movimiento(string tipoMovimiento, int idUsuario, DateTime inicio, DateTime final, int tipo);
    [OperationContract]
    List<EArqueoMovimientoSimple> Arqueo_Movimiento(int idUsuario, DateTime fecha, string tipoMovimiento);
    [OperationContract]
    List<EArqueoSimple> Arqueo_Retorno(int idUsuario, DateTime fecha);
    #endregion

    #region DETALLEMOVIMIENTO
    [OperationContract]
    void Insertar_DetalleMovimiento(EDetalleMovimientoSimple eDetalleMovimientoSimple);
    [OperationContract]
    void Actualizar_DetalleMovimiento(EDetalleMovimientoSimple eMovimientoSimple);
    [OperationContract]
    EDetalleMovimientoSimple Obtener_DetalleMovimiento_Id_Movimiento(int IdMovimiento);
    [OperationContract]
    List<EDetalleMovimientoSimple> Obtener_DetalleMovimiento();
    #endregion

    #region PRODUCTO
    [OperationContract]
    void Insertar_Producto(EProductoSimple eProductoSimple);
    [OperationContract]
    void Actualizar_Producto(EProductoSimple eProductoSimple);
    [OperationContract]
    EProductoSimple Obtener_Producto_Id_Producto(int IdProducto);
    [OperationContract]
    List<EProductoSimple> Obtener_Producto();
    [OperationContract]
    List<EProductoSimple> Obtener_Producto_SinFoto();
    [OperationContract]
    List<EProductoSimple> Obtener_Producto_Mobil();

    #endregion

    #region PRECIO SUGERIDO
    [OperationContract]
    void Insertar_PrecioSugerido(EPrecioSugeridoSimple ePrecioSugeridoSimple);
    [OperationContract]
    void Actualizar_PrecioSugerido(EPrecioSugeridoSimple ePrecioSugeridoSimple);
    [OperationContract]
    EPrecioSugeridoSimple Obtener_PrecioSugerido_Id_PrecioSugerido(int IdPrecioSugerido);
    [OperationContract]
    List<EPrecioSugeridoSimple> Obtener_PrecioSugerido();

    #endregion

    #region CONTROLSANITARIO
    [OperationContract]
    void Insertar_ControlSanitario(EControlSanitarioSimple eControlSanitarioSimple);
    [OperationContract]
    void Actualizar_ControlSanitario(EControlSanitarioSimple eControlSanitarioSimple);
    [OperationContract]
    EControlSanitarioSimple Obtener_ControlSanitario_Id_ControlSanitario(byte IdControlSanitario);
    [OperationContract]
    List<EControlSanitarioSimple> Obtener_ControlSanitario();
    [OperationContract]
     List<ERepControlSanitarioSimple> Obtener_ControlSanitario_Reporte_Fecha(DateTime fecha);
    #endregion

    #region CALIFICACION
    [OperationContract]
    void Insertar_Calificacion(ECalificacionSimple eCalificacionSimple);
    [OperationContract]
    void Actualizar_Calificacion(ECalificacionSimple eCalificacionSimple);
    [OperationContract]
    ECalificacionSimple Obtener_Calificacion_Id_Calificacion(int IdCalificacion);
    [OperationContract]
    List<ECalificacionSimple> Obtener_Calificacion();
    #endregion

    #region EXISTENCIA
    [OperationContract]
    void Insertar_Existencia(EExistenciaSimple eExistenciaSimple);
    [OperationContract]
    void Actualizar_Existencia(EExistenciaSimple eExistenciaSimple);
    [OperationContract]
    EExistenciaSimple Obtener_Existencia_Id_Existencia(int IdExistencia);
    [OperationContract]
    List<EExistenciaSimple> Obtener_Existencia();
    [OperationContract]
    List<ERepExistenciaSimple> Reporte_Existencia(int idProducto, int idPersona, string tipoExistencia, DateTime inicio, DateTime final, int tipo);
    [OperationContract]
    List<ERepExistenciaSimple> Reporte_Existencia_Nuevo(int idProducto, int idPersona, string tipoExistencia, DateTime inicio, DateTime final, int tipo);
    [OperationContract]
    List<EArqueoExistenciaSimple> Arqueo_Existencia(int idUsuario, DateTime fecha, string tipoExistencia);
    #endregion

    #region PAGO

    [OperationContract]
    void Insertar_Pago(EPagoSimple ePagoSimple);

    [OperationContract]
    void Actualizar_Pago(EPagoSimple ePagoSimple);

    [OperationContract]
    EPagoSimple Obtener_Pago_Id_Pago(int IdPago);

    [OperationContract]
    List<EPagoSimple> Obtener_Pago();
    [OperationContract]
    List<ERepDeudasSimple> Reporte_Deuda(int idCliente, DateTime fechaFinal, int tipo);
    [OperationContract]
    List<EArqueoPagoSimple> Arqueo_Pago(int idUsuario, DateTime fecha);
    #endregion

    #region SALDO

    [OperationContract]
    void Insertar_Saldo(ESaldoSimple eSaldoSimple);

    [OperationContract]
    void Actualizar_Saldo(ESaldoSimple eSaldoSimple);

    [OperationContract]
    ESaldoSimple Obtener_Saldo_Id_Saldo(int idSaldo);

    [OperationContract]
    List<ESaldoSimple> Obtener_Saldo();
    [OperationContract]
    List<ERepSaldoSimple> Reporte_Saldo(int idEmpleado, DateTime inicio, DateTime final, int tipo);
    #endregion

    #region ARTICULO
    [OperationContract]
    void Insertar_Articulo(EArticuloSimple eArticuloSimple);
    [OperationContract]
    void Actualizar_Articulo(EArticuloSimple eArticuloSimple);
    [OperationContract]
    EArticuloSimple Obtener_Articulo_Id_Articulo(int IdArticulo);
    [OperationContract]
    List<EArticuloSimple> Obtener_Articulo();

    #endregion

    #region CATEGORIA
    [OperationContract]
    void Insertar_Categoria(ECategoriaSimple eCategoriaSimple);
    [OperationContract]
    void Actualizar_Categoria(ECategoriaSimple eCategoriaSimple);
    [OperationContract]
    ECategoriaSimple Obtener_Categoria_Id_Categoria(byte IdCategoria);
    [OperationContract]
    List<ECategoriaSimple> Obtener_Categoria();

    #endregion

    #region ARQUEO
    [OperationContract]
    void Insertar_Arqueo(EArqueoTSimple eArqueoSimple);
    [OperationContract]
    void Actualizar_Arqueo(EArqueoTSimple eArqueoSimple);
    [OperationContract]
    EArqueoTSimple Obtener_Arqueo_Id_Arqueo(int IdArqueo);
    [OperationContract]
    List<EArqueoTSimple> Obtener_Arqueo();
    [OperationContract]
    List<EArqueoTSimple> Obtener_Arqueo_Fecha(DateTime fecha);
    #endregion

    #region REPORTES

    [OperationContract]
    List<ERepAsistenciaSimple> Reporte_Asistencias(int idPersona, DateTime fechaInicio, DateTime fechaFinal, int tipo);
    [OperationContract]
    List<ERepClientesZonaSimple> Reporte_Cliente_Zona(byte idZona, int tipo);
    [OperationContract]
    List<ERepClientesCategoriaSimple> Reporte_Cliente_Categoria(byte idCategoria, int tipo);

    #endregion


    #region UBICACION
    [OperationContract]
    void Insertar_Ubicacion(EUbicacionSimple eUbicacionSimple);

    [OperationContract]
    void Insertar_UbicacionDistribuidor(EUbicacionDistribuidorSimple eUbicacionSimple);

    [OperationContract]
    EUbicacionDistribuidorSimple Obtener_UbicacionDistribuidor_IdUsuario(int IdUsuario);
    #endregion
}

