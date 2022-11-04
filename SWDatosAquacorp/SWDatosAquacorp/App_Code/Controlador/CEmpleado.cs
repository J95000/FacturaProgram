using Modelo;
using System;
using System.Collections.Generic;
/// <summary>
/// Descripción breve de CEmpleado
/// </summary>
public class CEmpleado
{
    private readonly CException cException = new CException();

    #region METODOS PUBLICOS
    public void Insertar_Empleado(EEmpleadoSimple eEmpleadoSimple)
    {



        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Persona_Empleado_I(eEmpleadoSimple.Nombres,
                    eEmpleadoSimple.PrimerApellido,
                    eEmpleadoSimple.SegundoApellido,
                    eEmpleadoSimple.Telefono,
                    eEmpleadoSimple.FechaRegistro,
                    eEmpleadoSimple.FechaModificacion,
                    eEmpleadoSimple.Estado,
                    eEmpleadoSimple.IdCargo,
                    eEmpleadoSimple.FechaNacimiento,
                    eEmpleadoSimple.Ci,
                    eEmpleadoSimple.IdCiudad,
                    eEmpleadoSimple.LugarNacimiento,
                    eEmpleadoSimple.TelefonoRespaldo, 
                    eEmpleadoSimple.Direccion, 
                    eEmpleadoSimple.EstadoCivil, 
                    eEmpleadoSimple.NombresPadre,      
                    eEmpleadoSimple.PrimerApellidoPadre,
                    eEmpleadoSimple.SegundoApellidoPadre,
                    eEmpleadoSimple.OcupacionPadre, 
                    eEmpleadoSimple.NombresMadre, 
                    eEmpleadoSimple.PrimerApellidoMadre, 
                    eEmpleadoSimple.SegundoApellidoMadre, 
                    eEmpleadoSimple.OcupacionMadre, 
                    eEmpleadoSimple.UltimoCurso, 
                    eEmpleadoSimple.ColegioUnidadEducativa, 
                    eEmpleadoSimple.FechaInicioTrabajo, 
                    eEmpleadoSimple.Garantia, 
                    eEmpleadoSimple.Fotografia);
            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }

    }

    public void Actualizar_Empleado(EEmpleadoSimple eEmpleadoSimple)
    {
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                db.Proc_Persona_Empleado_A(
                    eEmpleadoSimple.IdPersona, 
                    eEmpleadoSimple.Nombres, 
                    eEmpleadoSimple.PrimerApellido,
                    eEmpleadoSimple.SegundoApellido,
                    eEmpleadoSimple.Telefono,  
                    eEmpleadoSimple.FechaRegistro, 
                    eEmpleadoSimple.FechaModificacion,
                    eEmpleadoSimple.Estado,
                    eEmpleadoSimple.IdCargo,
                    eEmpleadoSimple.FechaNacimiento,
                    eEmpleadoSimple.Ci, 
                    eEmpleadoSimple.IdCiudad, 
                    eEmpleadoSimple.LugarNacimiento,
                    eEmpleadoSimple.TelefonoRespaldo,
                    eEmpleadoSimple.Direccion,
                    eEmpleadoSimple.EstadoCivil, 
                    eEmpleadoSimple.NombresPadre, 
                    eEmpleadoSimple.PrimerApellidoPadre,
                    eEmpleadoSimple.SegundoApellidoPadre,
                    eEmpleadoSimple.OcupacionPadre, 
                    eEmpleadoSimple.NombresMadre,
                    eEmpleadoSimple.PrimerApellidoMadre, 
                    eEmpleadoSimple.SegundoApellidoMadre, 
                    eEmpleadoSimple.OcupacionMadre, 
                    eEmpleadoSimple.UltimoCurso, 
                    eEmpleadoSimple.ColegioUnidadEducativa, 
                    eEmpleadoSimple.FechaInicioTrabajo, 
                    eEmpleadoSimple.Garantia, 
                    eEmpleadoSimple.Fotografia);

            }
        }
        catch (Exception ex)
        {

            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }

    }
    public EEmpleadoSimple Obtener_Empleado_Id_Empleado(int Id_Empleado)
    {
        EEmpleadoSimple eEmpleadoSimple = new EEmpleadoSimple();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Persona_Empleado_O_IdEmpleado(Id_Empleado);
                foreach (var p in Persona)
                {
                    eEmpleadoSimple = new EEmpleadoSimple
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

                        IdEmpleado = p.IdEmpleado,
                        IdCargo = p.IdCargo,
                        FechaNacimiento = p.FechaNacimiento,
                        Ci = p.Ci,
                        IdCiudad = p.IdCiudad,

                        LugarNacimiento = p.LugarNacimiento,
                        TelefonoRespaldo = p.TelefonoRespaldo,
                        EstadoCivil = p.EstadoCivil,
                        NombresPadre = p.NombresPadre,
                        PrimerApellidoPadre = p.PrimerApellidoPadre,
                        SegundoApellidoPadre = p.SegundoApellidoPadre,
                        OcupacionPadre = p.OcupacionPadre,
                        NombresMadre = p.NombresMadre,
                        PrimerApellidoMadre = p.PrimerApellidoMadre,
                        SegundoApellidoMadre = p.SegundoApellidoMadre,
                        OcupacionMadre = p.OcupacionMadre,
                        UltimoCurso = p.UltimoCurso,
                        ColegioUnidadEducativa = p.ColegioUnidadEducativa,
                        FechaInicioTrabajo = p.FechaInicioTrabajo,
                        Garantia = p.Garantia,
                        Fotografia = p.Fotografia
                    };
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return eEmpleadoSimple;
    }



    public List<EEmpleadoSimple> Obtener_Empleado()
    {
        List<EEmpleadoSimple> lstECEmpleadoSimple = new List<EEmpleadoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Persona_Empleado_O();
                foreach (var p in Persona)
                {
                    EEmpleadoSimple eEmpleadoSimple = new EEmpleadoSimple
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

                        IdEmpleado = p.IdEmpleado,
                        IdCargo = p.IdCargo,
                        FechaNacimiento = p.FechaNacimiento,
                        Ci = p.Ci,
                        IdCiudad = p.IdCiudad,
                        LugarNacimiento = p.LugarNacimiento,
                        TelefonoRespaldo = p.TelefonoRespaldo,
                        EstadoCivil = p.EstadoCivil,
                        NombresPadre = p.NombresPadre,
                        PrimerApellidoPadre = p.PrimerApellidoPadre,
                        SegundoApellidoPadre = p.SegundoApellidoPadre,
                        OcupacionPadre = p.OcupacionPadre,
                        NombresMadre = p.NombresMadre,
                        PrimerApellidoMadre = p.PrimerApellidoMadre,
                        SegundoApellidoMadre = p.SegundoApellidoMadre,
                        OcupacionMadre = p.OcupacionMadre,
                        UltimoCurso = p.UltimoCurso,
                        ColegioUnidadEducativa = p.ColegioUnidadEducativa,
                        FechaInicioTrabajo = p.FechaInicioTrabajo,
                        Garantia = p.Garantia,

                    };
                    lstECEmpleadoSimple.Add(eEmpleadoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECEmpleadoSimple;
    }
    public List<EEmpleadoSimple> Obtener_Empleado_Buscador(string nombre)
    {
        List<EEmpleadoSimple> lstECEmpleadoSimple = new List<EEmpleadoSimple>();
        try
        {
            using (aquacorpbddEntities db = new aquacorpbddEntities())
            {
                var Persona = db.Proc_Persona_Empleado_O_Buscador(nombre);
                foreach (var p in Persona)
                {
                    EEmpleadoSimple eEmpleadoSimple = new EEmpleadoSimple
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

                        IdEmpleado = p.IdEmpleado,
                        IdCargo = p.IdCargo,
                        FechaNacimiento = p.FechaNacimiento,
                        Ci = p.Ci,
                        IdCiudad = p.IdCiudad,
                        LugarNacimiento = p.LugarNacimiento,
                        TelefonoRespaldo = p.TelefonoRespaldo,
                        EstadoCivil = p.EstadoCivil,
                        NombresPadre = p.NombresPadre,
                        PrimerApellidoPadre = p.PrimerApellidoPadre,
                        SegundoApellidoPadre = p.SegundoApellidoPadre,
                        OcupacionPadre = p.OcupacionPadre,
                        NombresMadre = p.NombresMadre,
                        PrimerApellidoMadre = p.PrimerApellidoMadre,
                        SegundoApellidoMadre = p.SegundoApellidoMadre,
                        OcupacionMadre = p.OcupacionMadre,
                        UltimoCurso = p.UltimoCurso,
                        ColegioUnidadEducativa = p.ColegioUnidadEducativa,
                        FechaInicioTrabajo = p.FechaInicioTrabajo,
                        Garantia = p.Garantia,

                    };
                    lstECEmpleadoSimple.Add(eEmpleadoSimple);
                }
            }
        }
        catch (Exception ex)
        {
            cException.Insertar_Exception_LocalDatos(new EExceptionSimple() { Fecha = DateTime.Now, IdUsuario = 1, NombreMetodo = ex.TargetSite.Name, Mensaje = ex.Message, ExceptionMensaje = ex.StackTrace });
        }
        return lstECEmpleadoSimple;
    }



    #endregion

}