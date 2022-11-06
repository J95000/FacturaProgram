using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class SWDatosAquacorp : ISWDatosAquacorp
{

    #region PERSONA
    public void Insertar_Persona(EPersonaSimple ePersonaSimple)
    {
        CPersona cPersona = new CPersona();
        cPersona.Insertar_Persona(ePersonaSimple);
    }
    public void Actualizar_Persona(EPersonaSimple ePersonaSimple)
    {
        CPersona cPersona = new CPersona();
        cPersona.Actualizar_Persona(ePersonaSimple);
    }
    public EPersonaSimple Obtener_Persona_Id_Persona(int IdPersona)
    {
        CPersona cPersona = new CPersona();
        return cPersona.Obtener_Persona_Id_Persona(IdPersona);
    }
    public List<EPersonaSimple> Obtener_Persona()
    {
        CPersona cPersona = new CPersona();
        return cPersona.Obtener_Persona();
    }
    public int Obtener_Ultimo_Id_Empleado()
    {
        CPersona cPersona = new CPersona();
        return cPersona.Obtener_Ultimo_Id_Empleado();
    }
    public int Obtener_Ultimo_Id(string nombreTabla, string nombreId)
    {
        CPersona cPersona = new CPersona();
        return cPersona.Obtener_Ultimo_Id(nombreTabla,  nombreId);
    }
    #endregion

    #region CARGO
    public void Insertar_Cargo(ECargoSimple eCargoSimple)
    {
        CCargo cCargo = new CCargo();
        cCargo.Insertar_Cargo(eCargoSimple);
    }
    public void Actualizar_Cargo(ECargoSimple eCargoSimple)
    {
        CCargo cCargo = new CCargo();
        cCargo.Actualizar_Cargo(eCargoSimple);
    }
    public ECargoSimple Obtener_Cargo_Id_Cargo(byte IdCargo)
    {
        CCargo cCargo = new CCargo();
        return cCargo.Obtener_Cargo_Id_Cargo(IdCargo);
    }
    public List<ECargoSimple> Obtener_Cargo()
    {
        CCargo cCargo = new CCargo();
        return cCargo.Obtener_Cargo();
    }
    #endregion

    #region USUARIO
    public void Insertar_Usuario(EUsuarioSimple eUsuarioSimple)
    {
        CUsuario cUsuario = new CUsuario();
        cUsuario.Insertar_Usuario(eUsuarioSimple);
    }
    public void Actualizar_Usuario(EUsuarioSimple eUsuarioSimple)
    {
        CUsuario cUsuario = new CUsuario();
        cUsuario.Actualizar_Usuario(eUsuarioSimple);
    }
    public EUsuarioSimple Obtener_Usuario_Id_Usuario(int IdUsuario)
    {
        CUsuario cUsuario = new CUsuario();
        return cUsuario.Obtener_Usuario_Id_Usuario(IdUsuario);
    }
    public List<EUsuarioSimple> Obtener_Usuario()
    {
        CUsuario cUsuario = new CUsuario();
        return cUsuario.Obtener_Usuario();
    }
    #endregion

    #region CIUDAD

    public ECiudadSimple Obtener_Ciudad_Id_Ciudad(byte IdCiudad)
    {
        CCiudad cCiudad = new CCiudad();
        return cCiudad.Obtener_Ciudad_Id_Ciudad(IdCiudad);
    }
    public List<ECiudadSimple> Obtener_Ciudad()
    {
        CCiudad cCiudad = new CCiudad();
        return cCiudad.Obtener_Ciudad();
    }
    #endregion

    #region EMPLEADO
    public void Insertar_Empleado(EEmpleadoSimple eEmpleadoSimple)
    {
        CEmpleado cEmpleado = new CEmpleado();
        cEmpleado.Insertar_Empleado(eEmpleadoSimple);
    }
    public void Actualizar_Empleado(EEmpleadoSimple eEmpleadoSimple)
    {
        CEmpleado cEmpleado = new CEmpleado();
        cEmpleado.Actualizar_Empleado(eEmpleadoSimple);
    }
    public EEmpleadoSimple Obtener_Empleado_Id_Empleado(int IdEmpleado)
    {
        CEmpleado cEmpleado = new CEmpleado();
        return cEmpleado.Obtener_Empleado_Id_Empleado(IdEmpleado);
    }
    public List<EEmpleadoSimple> Obtener_Empleado()
    {
        CEmpleado cEmpleado = new CEmpleado();
        return cEmpleado.Obtener_Empleado();
    }
    public List<EEmpleadoSimple> Obtener_Empleado_Buscador(string nombre)
    {
        CEmpleado cEmpleado = new CEmpleado();
        return cEmpleado.Obtener_Empleado_Buscador(nombre);
    }
    #endregion

    #region REFERENCIAPERSONAL
    public void Insertar_ReferenciaPersonal(EReferenciaPersonalSimple eReferenciaPersonalSimple)
    {
        CReferenciaPersonal cReferenciaPersonal = new CReferenciaPersonal();
        cReferenciaPersonal.Insertar_ReferenciaPersonal(eReferenciaPersonalSimple);
    }
    public void Actualizar_ReferenciaPersonal(EReferenciaPersonalSimple eReferenciaPersonalSimple)
    {
        CReferenciaPersonal cReferenciaPersonal = new CReferenciaPersonal();
        cReferenciaPersonal.Actualizar_ReferenciaPersonal(eReferenciaPersonalSimple);
    }
    public EReferenciaPersonalSimple Obtener_ReferenciaPersonal_Id_Empleado(int IdEmpleado)
    {
        CReferenciaPersonal cReferenciaPersonal = new CReferenciaPersonal();
        return cReferenciaPersonal.Obtener_ReferenciaPersonal_Id_Empleado(IdEmpleado);
    }
    public List<EReferenciaPersonalSimple> Obtener_ReferenciaPersonal()
    {
        CReferenciaPersonal cReferenciaPersonal = new CReferenciaPersonal();
        return cReferenciaPersonal.Obtener_ReferenciaPersonal();
    }

    #endregion

    #region REFERENCIALABORAL

    public void Insertar_ReferenciaLaboral(EReferenciaLaboralSimple eReferenciaLaboralSimple)
    {
        CReferenciaLaboral cReferenciaLaboral = new CReferenciaLaboral();
        cReferenciaLaboral.Insertar_ReferenciaLaboral(eReferenciaLaboralSimple);
    }
    public void Actualizar_ReferenciaLaboral(EReferenciaLaboralSimple eReferenciaLaboralSimple)
    {
        CReferenciaLaboral cReferenciaLaboral = new CReferenciaLaboral();
        cReferenciaLaboral.Actualizar_ReferenciaLaboral(eReferenciaLaboralSimple);
    }
    public EReferenciaLaboralSimple Obtener_ReferenciaLaboral_Id_Empleado(int IdReferenciaLaboral)
    {
        CReferenciaLaboral cReferenciaLaboral = new CReferenciaLaboral();
        return cReferenciaLaboral.Obtener_ReferenciaLaboral_Id_Empleado(IdReferenciaLaboral);
    }
    public List<EReferenciaLaboralSimple> Obtener_ReferenciaLaboral()
    {
        CReferenciaLaboral cReferenciaLaboral = new CReferenciaLaboral();
        return cReferenciaLaboral.Obtener_ReferenciaLaboral();
    }
    #endregion

    #region CONYUGUE
    public void Insertar_Conyugue(EConyugueSimple eConyugueSimple)
    {
        CConyugue cConyugue = new CConyugue();
        cConyugue.Insertar_Conyugue(eConyugueSimple);
    }
    public void Actualizar_Conyugue(EConyugueSimple eConyugueSimple)
    {
        CConyugue cConyugue = new CConyugue();
        cConyugue.Actualizar_Conyugue(eConyugueSimple);
    }
    public EConyugueSimple Obtener_Conyugue_Id_Empleado(int IdEmpleado)
    {
        CConyugue cConyugue = new CConyugue();
        return cConyugue.Obtener_Conyugue_Id_Empleado(IdEmpleado);
    }
    public List<EConyugueSimple> Obtener_Conyugue()
    {
        CConyugue cConyugue = new CConyugue();
        return cConyugue.Obtener_Conyugue();
    }


    #endregion

    #region DESPIDO
    public void Insertar_Despido(EDespidoSimple eDespidoSimple)
    {
        CDespido cDespido = new CDespido();
        cDespido.Insertar_Despido(eDespidoSimple);
    }
    public void Actualizar_Despido(EDespidoSimple eDespidoSimple)
    {
        CDespido cDespido = new CDespido();
        cDespido.Actualizar_Despido(eDespidoSimple);
    }
    public EDespidoSimple Obtener_Despido_Id_Empleado(int IdEmpleado)
    {
        CDespido cDespido = new CDespido();
        return cDespido.Obtener_Despido_Id_Empleado(IdEmpleado);
    }
    public List<EDespidoSimple> Obtener_Despido()
    {
        CDespido cDespido = new CDespido();
        return cDespido.Obtener_Despido();
    }

    #endregion

    #region HABILIDAD

    public void Insertar_Habilidad(EHabilidadSimple eHabilidadSimple)
    {
        CHabilidad cHabilidad = new CHabilidad();
        cHabilidad.Insertar_Habilidad(eHabilidadSimple);
    }
    public void Actualizar_Habilidad(EHabilidadSimple eHabilidadSimple)
    {
        CHabilidad cHabilidad = new CHabilidad();
        cHabilidad.Actualizar_Habilidad(eHabilidadSimple);
    }
    public EHabilidadSimple Obtener_Habilidad_Id_Empleado(int IdEmpleado)
    {
        CHabilidad cHabilidad = new CHabilidad();
        return cHabilidad.Obtener_Habilidad_Id_Empleado(IdEmpleado);
    }
    public List<EHabilidadSimple> Obtener_Habilidad()
    {
        CHabilidad cHabilidad = new CHabilidad();
        return cHabilidad.Obtener_Habilidad();
    }

    #endregion

    #region PROVEEDOR
    public void Insertar_Proveedor(EProveedorSimple eProveedorSimple)
    {
        CProveedor cProveedor = new CProveedor();
        cProveedor.Insertar_Proveedor(eProveedorSimple);
    }
    public void Actualizar_Proveedor(EProveedorSimple eProveedorSimple)
    {
        CProveedor cProveedor = new CProveedor();
        cProveedor.Actualizar_Proveedor(eProveedorSimple);
    }
    public EProveedorSimple Obtener_Proveedor_Id_Proveedor(int Id_Proveedor)
    {
        CProveedor cProveedor = new CProveedor();
        return cProveedor.Obtener_Proveedor_Id_Proveedor(Id_Proveedor);
    }
    public List<EProveedorSimple> Obtener_Proveedor()
    {
        CProveedor cProveedor = new CProveedor();
        return cProveedor.Obtener_Proveedor();
    }
    #endregion

    #region MATERIAL
    public void Insertar_Material(EMaterialSimple eMaterialSimple)
    {
        CMaterial cMaterial = new CMaterial();
        cMaterial.Insertar_Material(eMaterialSimple);
    }
    public void Actualizar_Material(EMaterialSimple eMaterialSimple)
    {
        CMaterial cMaterial = new CMaterial();
        cMaterial.Actualizar_Material(eMaterialSimple);
    }
    public EMaterialSimple Obtener_Material_IdMaterial(int IdMaterial)
    {
        CMaterial cMaterial = new CMaterial();
        return cMaterial.Obtener_Material_IdMaterial(IdMaterial);
    }
    public List<EMaterialSimple> Obtener_Material()
    {
        CMaterial cMaterial = new CMaterial();
        return cMaterial.Obtener_Material();
    }
    #endregion

    #region CLIENTE
    public void Insertar_Cliente(EClienteSimple eClienteSimple)
    {
        CCliente cCliente = new CCliente();
        cCliente.Insertar_Cliente(eClienteSimple);
    }
    public void Actualizar_Cliente(EClienteSimple eClienteSimple)
    {
        CCliente cCliente = new CCliente();
        cCliente.Actualizar_Cliente(eClienteSimple);

    }
    public EClienteSimple Obtener_Cliente_Id_Cliente(int Id_Cliente)
    {
        CCliente cCliente = new CCliente();
        return cCliente.Obtener_Cliente_Id_Cliente(Id_Cliente);
    }
    public List<EClienteSimple> Obtener_Cliente()
    {
        CCliente cCliente = new CCliente();
        return cCliente.Obtener_Cliente();
    }
    public List<EClienteSimple> Obtener_Cliente_Buscador(string nombre)
    {
        CCliente cCliente = new CCliente();
        return cCliente.Obtener_Cliente_Buscador(nombre);
    }
    public void Actualizar_Cliente_Corta(EClienteCortaSimple eClienteCortaSimple)
    {
        CCliente cCliente = new CCliente();
          cCliente.Actualizar_Cliente_Corta(eClienteCortaSimple);
    }
    #endregion

    #region CATEGORIACLIENTE

    public void Insertar_CategoriaCliente(ECategoriaClienteSimple eCategoriaClienteSimple)
    {
        CCategoriaCliente cCategoriaCliente = new CCategoriaCliente();
        cCategoriaCliente.Insertar_CategoriaCliente(eCategoriaClienteSimple);
    }
    public void Actualizar_CategoriaCliente(ECategoriaClienteSimple eCategoriaClienteSimple)
    {
        CCategoriaCliente cCategoriaCliente = new CCategoriaCliente();
        cCategoriaCliente.Actualizar_CategoriaCliente(eCategoriaClienteSimple);
    }
    public ECategoriaClienteSimple Obtener_CategoriaCliente_Id_CategoriaCliente(byte IdCategoriaCliente)
    {
        CCategoriaCliente cCategoriaCliente = new CCategoriaCliente();
        return cCategoriaCliente.Obtener_CategoriaCliente_Id_CategoriaCliente(IdCategoriaCliente);
    }
    public List<ECategoriaClienteSimple> Obtener_CategoriaCliente()
    {
        CCategoriaCliente cCategoriaCliente = new CCategoriaCliente();
        return cCategoriaCliente.Obtener_CategoriaCliente();
    }

    #endregion

    #region CONTROLENTRADA
    public void Insertar_ControlEntrada(EControlEntradaSimple eControlEntradaSimple)
    {
        CControlEntrada cControlEntrada = new CControlEntrada();
        cControlEntrada.Insertar_ControlEntrada(eControlEntradaSimple);
    }
    public void Actualizar_ControlEntrada(EControlEntradaSimple eControlEntradaSimple)
    {
        CControlEntrada cControlEntrada = new CControlEntrada();
        cControlEntrada.Actualizar_ControlEntrada(eControlEntradaSimple);

    }
    public EControlEntradaSimple Obtener_ControlEntrada_Id_ControlEntrada(int Id_ControlEntrada)
    {
        CControlEntrada cControlEntrada = new CControlEntrada();
        return cControlEntrada.Obtener_ControlEntrada_Id_ControlEntrada(Id_ControlEntrada);
    }
    public List<EControlEntradaSimple> Obtener_ControlEntrada()
    {
        CControlEntrada cControlEntrada = new CControlEntrada();
        return cControlEntrada.Obtener_ControlEntrada();
    }
    #endregion

    #region ZONA
    public void Insertar_Zona(EZonaSimple eZonaSimple)
    {
        CZona cZona = new CZona();
        cZona.Insertar_Zona(eZonaSimple);
    }
    public void Actualizar_Zona(EZonaSimple eZonaSimple)
    {
        CZona cZona = new CZona();
        cZona.Actualizar_Zona(eZonaSimple);
    }
    public EZonaSimple Obtener_Zona_Id_Zona(byte IdZona)
    {
        CZona cZona = new CZona();
        return cZona.Obtener_Zona_Id_Zona(IdZona);
    }
    public List<EZonaSimple> Obtener_Zona()
    {
        CZona cZona = new CZona();
        return cZona.Obtener_Zona();
    }
    #endregion

    #region PUNTOZONA
    public void Insertar_PuntoZona(EPuntoZonaSimple ePuntoZonaSimple)
    {
        CPuntoZona cPuntoZona = new CPuntoZona();
        cPuntoZona.Insertar_PuntoZona(ePuntoZonaSimple);
    }
    public void Actualizar_PuntoZona(EPuntoZonaSimple ePuntoZonaSimple)
    {
        CPuntoZona cPuntoZona = new CPuntoZona();
        cPuntoZona.Actualizar_PuntoZona(ePuntoZonaSimple);



    }
    public EPuntoZonaSimple Obtener_PuntoZona_Id_PuntoZona(int IdPuntoZona)
    {
        CPuntoZona cPuntoZona = new CPuntoZona();
        return cPuntoZona.Obtener_PuntoZona_Id_PuntoZona(IdPuntoZona);
    }
    public List<EPuntoZonaSimple> Obtener_PuntoZona()
    {
        CPuntoZona cPuntoZona = new CPuntoZona();
        return cPuntoZona.Obtener_PuntoZona();
    }

    public List<EPuntosSimple> Obtener_PuntoZona_Puntos(byte id)
    {
        CPuntoZona cPuntoZona = new CPuntoZona();
        return cPuntoZona.Obtener_PuntoZona_Puntos(id);
    }
    #endregion

    #region PRODUCCION
    public void Insertar_Produccion(EProduccionSimple eProduccionSimple)
    {
        CProduccion cProduccion = new CProduccion();
        cProduccion.Insertar_Produccion(eProduccionSimple);
    }
    public void Actualizar_Produccion(EProduccionSimple eProduccionSimple)
    {
        CProduccion cProduccion = new CProduccion();
        cProduccion.Actualizar_Produccion(eProduccionSimple);
    }
    public EProduccionSimple Obtener_Produccion_IdProduccion(int IdProduccion)
    {
        CProduccion cProduccion = new CProduccion();
        return cProduccion.Obtener_Produccion_IdProduccion(IdProduccion);
    }
    public List<EProduccionSimple> Obtener_Produccion()
    {
        CProduccion cProduccion = new CProduccion();
        return cProduccion.Obtener_Produccion();
    }
    #endregion

    #region MATERIAPRIMA
    public void Insertar_MateriaPrima(EMateriaPrimaSimple eMateriaPrimaSimple)
    {
        CMateriaPrima cMateriaPrima = new CMateriaPrima();
        cMateriaPrima.Insertar_MateriaPrima(eMateriaPrimaSimple);
    }
    public void Actualizar_MateriaPrima(EMateriaPrimaSimple eMateriaPrimaSimple)
    {
        CMateriaPrima cMateriaPrima = new CMateriaPrima();
        cMateriaPrima.Actualizar_MateriaPrima(eMateriaPrimaSimple);
    }
    public EMateriaPrimaSimple Obtener_MateriaPrima_IdMateriaPrima(int IdMateriaPrima)
    {
        CMateriaPrima cMateriaPrima = new CMateriaPrima();
        return cMateriaPrima.Obtener_MateriaPrima_IdMateriaPrima(IdMateriaPrima);
    }
    public List<EMateriaPrimaSimple> Obtener_MateriaPrima()
    {
        CMateriaPrima cMateriaPrima = new CMateriaPrima();
        return cMateriaPrima.Obtener_MateriaPrima();
    }
    #endregion

    #region PROVISION
    public void Insertar_Provision(EProvisionSimple eProvisionSimple)
    {
        CProvision cProvision = new CProvision();
        cProvision.Insertar_Provision(eProvisionSimple);
    }
    public void Actualizar_Provision(EProvisionSimple eProvisionSimple)
    {
        CProvision cProvision = new CProvision();
        cProvision.Actualizar_Provision(eProvisionSimple);
    }
    public EProvisionSimple Obtener_Provision_IdProvision(int IdProvision)
    {
        CProvision cProvision = new CProvision();
        return cProvision.Obtener_Provision_IdProvision(IdProvision);
    }
    public List<EProvisionSimple> Obtener_Provision()
    {
        CProvision cProvision = new CProvision();
        return cProvision.Obtener_Provision();
    }
    #endregion



    #region EXISTENCIAMATERIAPRIMA
    public void Insertar_ExistenciaMateriaPrima(EExistenciaMateriaPrimaSimple eExistenciaMateriaPrimaSimple)
    {
        CExistenciaMateriaPrima cExistenciaMateriaPrima = new CExistenciaMateriaPrima();
        cExistenciaMateriaPrima.Insertar_ExistenciaMateriaPrima(eExistenciaMateriaPrimaSimple);
    }
    public void Actualizar_ExistenciaMateriaPrima(EExistenciaMateriaPrimaSimple eExistenciaMateriaPrimaSimple)
    {
        CExistenciaMateriaPrima cExistenciaMateriaPrima = new CExistenciaMateriaPrima();
        cExistenciaMateriaPrima.Actualizar_ExistenciaMateriaPrima(eExistenciaMateriaPrimaSimple);
    }
    public EExistenciaMateriaPrimaSimple Obtener_ExistenciaMateriaPrima_IdExistenciaMateriaPrima(int IdExistenciaMateriaPrima)
    {
        CExistenciaMateriaPrima cExistenciaMateriaPrima = new CExistenciaMateriaPrima();
        return cExistenciaMateriaPrima.Obtener_ExistenciaMateriaPrima_IdExistenciaMateriaPrima(IdExistenciaMateriaPrima);
    }
    public List<EExistenciaMateriaPrimaSimple> Obtener_ExistenciaMateriaPrima()
    {
        CExistenciaMateriaPrima cExistenciaMateriaPrima = new CExistenciaMateriaPrima();
        return cExistenciaMateriaPrima.Obtener_ExistenciaMateriaPrima();
    }
    #endregion






    #region EXCEPTION
    public void Insertar_Exception(EExceptionSimple eExceptionSimple)
    {
        CException cException = new CException();
        cException.Insertar_Exception(eExceptionSimple);
    }
    public EExceptionSimple Obtener_Exception_Id_Exception(int IdException)
    {
        CException cException = new CException();
        return cException.Obtener_Exception_Id_Exception(IdException);
    }

    public List<EExceptionSimple> Obtener_Exception()
    {
        CException cException = new CException();
        return cException.Obtener_Exception();
    }
    #endregion

    #region GASTO
    public void Insertar_Gasto(EGastoSimple eGastoSimple)
    {
        CGasto cGasto = new CGasto();
        cGasto.Insertar_Gasto(eGastoSimple);
    }
    public void Actualizar_Gasto(EGastoSimple eGastoSimple)
    {
        CGasto cGasto = new CGasto();
        cGasto.Actualizar_Gasto(eGastoSimple);
    }
    public EGastoSimple Obtener_Gasto_Id_Gasto(int IdGasto)
    {
        CGasto cGasto = new CGasto();
        return cGasto.Obtener_Gasto_Id_Gasto(IdGasto);
    }
    public List<EGastoSimple> Obtener_Gasto()
    {
        CGasto cGasto = new CGasto();
        return cGasto.Obtener_Gasto();
    }
    public List<EArqueoGastoSimple> Arqueo_Gasto(int idUsuario, DateTime fecha)
    {
        CGasto cGasto = new CGasto();
        return cGasto.Arqueo_Gasto( idUsuario,  fecha);
    }
    #endregion

    #region  TIPOGASTO
    public void Insertar_TipoGasto(ETipoGastoSimple eTipoGastoSimple)
    {
        CTipoGasto cTipoGasto = new CTipoGasto();
        cTipoGasto.Insertar_TipoGasto(eTipoGastoSimple);
    }
    public void Actualizar_TipoGasto(ETipoGastoSimple eTipoGastoSimple)
    {
        CTipoGasto cTipoGasto = new CTipoGasto();
        cTipoGasto.Actualizar_TipoGasto(eTipoGastoSimple);
    }
    public ETipoGastoSimple Obtener_TipoGasto_Id_TipoGasto(byte IdTipoGasto)
    {
        CTipoGasto cTipoGasto = new CTipoGasto();
        return cTipoGasto.Obtener_TipoGasto_Id_TipoGasto(IdTipoGasto);
    }
    public List<ETipoGastoSimple> Obtener_TipoGasto()
    {
        CTipoGasto cTipoGasto = new CTipoGasto();
        return cTipoGasto.Obtener_TipoGasto();
    }
    #endregion

    #region MOVIMIENTO
    public void Insertar_Movimiento(EMovimientoSimple eMovimientoSimple)
    {
        CMovimiento cMovimiento = new CMovimiento();
        cMovimiento.Insertar_Movimiento(eMovimientoSimple);
    }
    public void Actualizar_Movimiento(EMovimientoSimple eMovimientoSimple)
    {
        CMovimiento cMovimiento = new CMovimiento();
        cMovimiento.Actualizar_Movimiento(eMovimientoSimple);
    }
    public EMovimientoSimple Obtener_Movimiento_Id_Movimiento(int IdMovimiento)
    {
        CMovimiento cMovimiento = new CMovimiento();
        return cMovimiento.Obtener_Movimiento_Id_Movimiento(IdMovimiento);
    }
    public List<EMovimientoSimple> Obtener_Movimiento()
    {
        CMovimiento cMovimiento = new CMovimiento();
        return cMovimiento.Obtener_Movimiento();
    }
    public EMovimientoSimple Obtener_Movimiento_Codigo(string codigo)
    {
        CMovimiento cMovimiento = new CMovimiento();
        return cMovimiento.Obtener_Movimiento_Codigo(codigo);
    }
    public List<ERepMovimientoSimple> Reporte_Movimiento(string tipoMovimiento, int idUsuario, DateTime inicio, DateTime final, int tipo)
    {
        CMovimiento cMovimiento = new CMovimiento();
        return cMovimiento.Reporte_Movimiento( tipoMovimiento,  idUsuario,  inicio,  final,  tipo);
    }
    public List<EArqueoMovimientoSimple> Arqueo_Movimiento(int idUsuario, DateTime fecha, string tipoMovimiento)
    {
        CMovimiento cMovimiento = new CMovimiento();
        return cMovimiento.Arqueo_Movimiento( idUsuario,  fecha,  tipoMovimiento);
    }
    public List<EArqueoSimple> Arqueo_Retorno(int idUsuario, DateTime fecha)
    {
        CMovimiento cMovimiento = new CMovimiento();
        return cMovimiento.Arqueo_Retorno(idUsuario, fecha);
    }
    public List<EMovimientoPedidoSimple> Obtener_Movimiento_O_Pedido_IdUsuario(int IdUsuario, DateTime fecha)
    {
        CMovimiento cMovimiento = new CMovimiento();
        return cMovimiento.Obtener_Movimiento_O_Pedido_IdUsuario(IdUsuario, fecha);
    }
    public void Insertar_Movimiento_ConFactura(EMovimientoSimple eMovimientoSimple)
    {
            CMovimiento cMovimiento = new CMovimiento();
             cMovimiento.Insertar_Movimiento_ConFactura(eMovimientoSimple);
    }
    public void Insertar_Movimiento_SinFactura(EMovimientoSimple eMovimientoSimple)
    {
        CMovimiento cMovimiento = new CMovimiento();
        cMovimiento.Insertar_Movimiento_SinFactura(eMovimientoSimple);

    }
    #endregion

    #region  DETALLEMOVIMIENTO
    public void Insertar_DetalleMovimiento(EDetalleMovimientoSimple eDetalleMovimientoSimple)
    {
        CDetalleMovimiento cDetalleMovimiento = new CDetalleMovimiento();
        cDetalleMovimiento.Insertar_DetalleMovimiento(eDetalleMovimientoSimple);
    }
    public void Actualizar_DetalleMovimiento(EDetalleMovimientoSimple eDetalleMovimientoSimple)
    {
        CDetalleMovimiento cDetalleMovimiento = new CDetalleMovimiento();
        cDetalleMovimiento.Actualizar_DetalleMovimiento(eDetalleMovimientoSimple);
    }
    public EDetalleMovimientoSimple Obtener_DetalleMovimiento_Id_Movimiento(int IdMovimiento)
    {
        CDetalleMovimiento cDetalleMovimiento = new CDetalleMovimiento();
        return cDetalleMovimiento.Obtener_DetalleMovimiento_Id_Movimiento(IdMovimiento);
    }
    public List<EDetalleMovimientoSimple> Obtener_DetalleMovimiento()
    {
        CDetalleMovimiento cDetalleMovimiento = new CDetalleMovimiento();
        return cDetalleMovimiento.Obtener_DetalleMovimiento();
    }
    public void Insertar_Movimiento_Cancelado(EMovimientoCanceladoSimple eMovimientoCanceladoSimple)
    {
        CDetalleMovimiento cDetalleMovimiento = new CDetalleMovimiento();
        cDetalleMovimiento.Insertar_Movimiento_Cancelado(eMovimientoCanceladoSimple);
    }
    public List<EDetalleMovimientoPedidoSimple> Obtener_DetalleMovimiento_Pedido(int idMovimiento)
    {
        CDetalleMovimiento cDetalleMovimiento = new CDetalleMovimiento();
        return cDetalleMovimiento.Obtener_DetalleMovimiento_Pedido(idMovimiento);
    }
    #endregion

    #region PRODUCTO
    public void Insertar_Producto(EProductoSimple eProductoSimple)
    {
        CProducto cProducto = new CProducto();
        cProducto.Insertar_Producto(eProductoSimple);
    }
    public void Actualizar_Producto(EProductoSimple eProductoSimple)
    {
        CProducto cProducto = new CProducto();
        cProducto.Actualizar_Producto(eProductoSimple);
    }
    public EProductoSimple Obtener_Producto_Id_Producto(int IdProducto)
    {
        CProducto cProducto = new CProducto();
        return cProducto.Obtener_Producto_Id_Producto(IdProducto);
    }
    public List<EProductoSimple> Obtener_Producto()
    {
        CProducto cProducto = new CProducto();
        return cProducto.Obtener_Producto();
    }
    public List<EProductoSimple> Obtener_Producto_SinFoto()
    {
        CProducto cProducto = new CProducto();
        return cProducto.Obtener_Producto_SinFoto();
    }
    public List<EProductoSimple> Obtener_Producto_Mobil()
    {
        CProducto cProducto = new CProducto();
        return cProducto.Obtener_Producto_Mobil();
    }
    #endregion

    #region PRECIO SUGERIDO
    public void Insertar_PrecioSugerido(EPrecioSugeridoSimple ePrecioSugeridoSimple)
    {
        CPrecioSugerido cPrecioSugerido = new CPrecioSugerido();
        cPrecioSugerido.Insertar_PrecioSugerido(ePrecioSugeridoSimple);
    }
    public void Actualizar_PrecioSugerido(EPrecioSugeridoSimple ePrecioSugeridoSimple)
    {
        CPrecioSugerido cPrecioSugerido = new CPrecioSugerido();
        cPrecioSugerido.Actualizar_PrecioSugerido(ePrecioSugeridoSimple);
    }
    public EPrecioSugeridoSimple Obtener_PrecioSugerido_Id_PrecioSugerido(int IdPrecioSugerido)
    {
        CPrecioSugerido cPrecioSugerido = new CPrecioSugerido();
        return cPrecioSugerido.Obtener_PrecioSugerido_Id_PrecioSugerido(IdPrecioSugerido);
    }
    public List<EPrecioSugeridoSimple> Obtener_PrecioSugerido()
    {
        CPrecioSugerido cPrecioSugerido = new CPrecioSugerido();
        return cPrecioSugerido.Obtener_PrecioSugerido();
    }
    #endregion

    #region CONTROLSANITARIO
    public void Insertar_ControlSanitario(EControlSanitarioSimple eControlSanitarioSimple)
    {
        CControlSanitario cControlSanitario = new CControlSanitario();
        cControlSanitario.Insertar_ControlSanitario(eControlSanitarioSimple);
    }
    public void Actualizar_ControlSanitario(EControlSanitarioSimple eControlSanitarioSimple)
    {
        CControlSanitario cControlSanitario = new CControlSanitario();
        cControlSanitario.Actualizar_ControlSanitario(eControlSanitarioSimple);
    }
    public EControlSanitarioSimple Obtener_ControlSanitario_Id_ControlSanitario(byte IdControlSanitario)
    {
        CControlSanitario cControlSanitario = new CControlSanitario();
        return cControlSanitario.Obtener_ControlSanitario_Id_ControlSanitario(IdControlSanitario);
    }
    public List<EControlSanitarioSimple> Obtener_ControlSanitario()
    {
        CControlSanitario cControlSanitario = new CControlSanitario();
        return cControlSanitario.Obtener_ControlSanitario();
    }
    public List<ERepControlSanitarioSimple> Obtener_ControlSanitario_Reporte_Fecha(DateTime fecha)
    {
        CControlSanitario cControlSanitario = new CControlSanitario();
        return cControlSanitario.Obtener_ControlSanitario_Reporte_Fecha(fecha);
    }


    #endregion

    #region CALIFICACION
    public void Insertar_Calificacion(ECalificacionSimple eCalificacionSimple)
    {
        CCalificacion cCalificacion = new CCalificacion();
        cCalificacion.Insertar_Calificacion(eCalificacionSimple);
    }
    public void Actualizar_Calificacion(ECalificacionSimple eCalificacionSimple)
    {
        CCalificacion cCalificacion = new CCalificacion();
        cCalificacion.Actualizar_Calificacion(eCalificacionSimple);
    }
    public ECalificacionSimple Obtener_Calificacion_Id_Calificacion(int IdCalificacion)
    {
        CCalificacion cCalificacion = new CCalificacion();
        return cCalificacion.Obtener_Calificacion_Id_Calificacion(IdCalificacion);
    }
    public List<ECalificacionSimple> Obtener_Calificacion()
    {
        CCalificacion cCalificacion = new CCalificacion();
        return cCalificacion.Obtener_Calificacion();
    }
    #endregion

    #region EXISTENCIA
    public void Insertar_Existencia(EExistenciaSimple eExistenciaSimple)
    {
        CExistencia cExistencia = new CExistencia();
        cExistencia.Insertar_Existencia(eExistenciaSimple);
    }
    public void Actualizar_Existencia(EExistenciaSimple eExistenciaSimple)
    {
        CExistencia cExistencia = new CExistencia();
        cExistencia.Actualizar_Existencia(eExistenciaSimple);
    }
    public EExistenciaSimple Obtener_Existencia_Id_Existencia(int IdExistencia)
    {
        CExistencia cExistencia = new CExistencia();
        return cExistencia.Obtener_Existencia_Id_Existencia(IdExistencia);
    }
    public List<EExistenciaSimple> Obtener_Existencia()
    {
        CExistencia cExistencia = new CExistencia();
        return cExistencia.Obtener_Existencia();
    }
    public List<ERepExistenciaSimple> Reporte_Existencia(int idProducto, int idPersona, string tipoExistencia, DateTime inicio, DateTime final, int tipo)
    {
        CExistencia cExistencia = new CExistencia();
        return cExistencia.Reporte_Existencia(idProducto, idPersona, tipoExistencia, inicio, final, tipo);
    }
    public List<ERepExistenciaSimple> Reporte_Existencia_Nuevo(int idProducto, int idPersona, string tipoExistencia, DateTime inicio, DateTime final, int tipo)
    {
        CExistencia cExistencia = new CExistencia();
        return cExistencia.Reporte_Existencia_Nuevo(idProducto, idPersona, tipoExistencia, inicio, final, tipo);
    }
    public List<EArqueoExistenciaSimple> Arqueo_Existencia(int idUsuario, DateTime fecha, string tipoExistencia)
    {
        CExistencia cExistencia = new CExistencia();
        return cExistencia.Arqueo_Existencia( idUsuario,  fecha,  tipoExistencia);
    }
    #endregion

    #region PAGO
    public void Insertar_Pago(EPagoSimple ePagoSimple)
    {
        CPago cPago = new CPago();
        cPago.Insertar_Pago(ePagoSimple);
    }
    public void Actualizar_Pago(EPagoSimple ePagoSimple)
    {
        CPago cPago = new CPago();
        cPago.Actualizar_Pago(ePagoSimple);
    }
    public EPagoSimple Obtener_Pago_Id_Pago(int IdPago)
    {
        CPago cPago = new CPago();
        return cPago.Obtener_Pago_Id_Pago(IdPago);
    }
    public List<EPagoSimple> Obtener_Pago()
    {
        CPago cPago = new CPago();
        return cPago.Obtener_Pago();
    }
    public List<ERepDeudasSimple> Reporte_Deuda(int idCliente,DateTime fechaFinal,int tipo)
    {
        CPago cPago = new CPago();
        return cPago.Reporte_Deuda(idCliente, fechaFinal,  tipo);
    }
    public List<EArqueoPagoSimple> Arqueo_Pago(int idUsuario, DateTime fecha)
    {
        CPago cPago = new CPago();
        return cPago.Arqueo_Pago( idUsuario,  fecha);
    }
    #endregion

    #region SALDO
    public void Insertar_Saldo(ESaldoSimple eSaldoSimple)
    {
        CSaldo cSaldo = new CSaldo();
        cSaldo.Insertar_Saldo(eSaldoSimple);
    }
    public void Actualizar_Saldo(ESaldoSimple eSaldoSimple)
    {
        CSaldo cSaldo = new CSaldo();
        cSaldo.Actualizar_Saldo(eSaldoSimple);
    }
    public ESaldoSimple Obtener_Saldo_Id_Saldo(int idSaldo)
    {
        CSaldo cSaldo = new CSaldo();
        return cSaldo.Obtener_Saldo_Id_Saldo(idSaldo);
    }
    public List<ESaldoSimple> Obtener_Saldo()
    {
        CSaldo cSaldo = new CSaldo();
        return cSaldo.Obtener_Saldo();
    }
    public List<ERepSaldoSimple> Reporte_Saldo(int idEmpleado, DateTime inicio, DateTime final, int tipo)
    {
        CSaldo cSaldo = new CSaldo();
        return cSaldo.Reporte_Saldo(idEmpleado,  inicio,  final,  tipo);
    }
    #endregion

    #region ARTICULO
    public void Insertar_Articulo(EArticuloSimple eArticuloSimple)
    {
        CArticulo cArticulo = new CArticulo();
        cArticulo.Insertar_Articulo(eArticuloSimple);
    }

    public void Actualizar_Articulo(EArticuloSimple eArticuloSimple)
    {
        CArticulo cArticulo = new CArticulo();
        cArticulo.Actualizar_Articulo(eArticuloSimple);
    }
    public EArticuloSimple Obtener_Articulo_Id_Articulo(int IdArticulo)
    {
        CArticulo cArticulo = new CArticulo();
        return cArticulo.Obtener_Articulo_Id_Articulo(IdArticulo);
    }

    public List<EArticuloSimple> Obtener_Articulo()
    {
        CArticulo cArticulo = new CArticulo();
        return cArticulo.Obtener_Articulo();
    }
    #endregion

    #region CATEGORIA
    public void Insertar_Categoria(ECategoriaSimple eCategoriaSimple)
    {
        CCategoria cCategoria = new CCategoria();
        cCategoria.Insertar_Categoria(eCategoriaSimple);
    }

    public void Actualizar_Categoria(ECategoriaSimple eCategoriaSimple)
    {
        CCategoria cCategoria = new CCategoria();
        cCategoria.Actualizar_Categoria(eCategoriaSimple);
    }
    public ECategoriaSimple Obtener_Categoria_Id_Categoria(byte IdCategoria)
    {
        CCategoria cCategoria = new CCategoria();
        return cCategoria.Obtener_Categoria_Id_Categoria(IdCategoria);
    }

    public List<ECategoriaSimple> Obtener_Categoria()
    {
        CCategoria cCategoria = new CCategoria();
        return cCategoria.Obtener_Categoria();
    }
    #endregion

    #region ARQUEO
    public void Insertar_Arqueo(EArqueoTSimple eArqueoSimple)
    {
        CArqueo cArqueo = new CArqueo();
        cArqueo.Insertar_Arqueo(eArqueoSimple);
    }

    public void Actualizar_Arqueo(EArqueoTSimple eArqueoSimple)
    {
        CArqueo cArqueo = new CArqueo();
        cArqueo.Actualizar_Arqueo(eArqueoSimple);
    }
    public EArqueoTSimple Obtener_Arqueo_Id_Arqueo(int IdArqueo)
    {
        CArqueo cArqueo = new CArqueo();
        return cArqueo.Obtener_Arqueo_Id_Arqueo(IdArqueo);
    }

    public List<EArqueoTSimple> Obtener_Arqueo()
    {
        CArqueo cArqueo = new CArqueo();
        return cArqueo.Obtener_Arqueo();
    }

    public List<EArqueoTSimple> Obtener_Arqueo_Fecha(DateTime fecha)
    {
        CArqueo cArqueo = new CArqueo();
        return cArqueo.Obtener_Arqueo_Fecha( fecha);
    }

    #endregion

    #region REPORTES



    public List<ERepAsistenciaSimple> Reporte_Asistencias(int idPersona, DateTime fechaInicio, DateTime fechaFinal, int tipo)
    {
        CReportes cArqueo = new CReportes();
       return cArqueo.Reporte_Asistencias( idPersona,  fechaInicio,  fechaFinal,  tipo);
    }

    public List<ERepClientesZonaSimple> Reporte_Cliente_Zona(byte idZona, int tipo)
    {
        CReportes cArqueo = new CReportes();
        return cArqueo.Reporte_Cliente_Zona(idZona, tipo);
    }


    public List<ERepClientesCategoriaSimple> Reporte_Cliente_Categoria(byte idCategoria, int tipo)
    {
        CReportes cArqueo = new CReportes();
        return cArqueo.Reporte_Cliente_Categoria(idCategoria, tipo);
    }



    #endregion

    #region UBICACION
    public void Insertar_Ubicacion(EUbicacionSimple eUbicacionSimple)
    {
        CUbicacion cCategoria = new CUbicacion();
        cCategoria.Insertar_Ubicacion(eUbicacionSimple);
    }
    public void Insertar_UbicacionDistribuidor(EUbicacionDistribuidorSimple eUbicacionSimple)
    {
        CUbicacion cCategoria = new CUbicacion();
        cCategoria.Insertar_UbicacionDistribuidor(eUbicacionSimple);
    }

    public EUbicacionDistribuidorSimple Obtener_UbicacionDistribuidor_IdUsuario(int IdUsuario)
    {
        CUbicacion cCategoria = new CUbicacion();
        return cCategoria.Obtener_UbicacionDistribuidor_IdUsuario(IdUsuario);
    }

    #endregion
}
