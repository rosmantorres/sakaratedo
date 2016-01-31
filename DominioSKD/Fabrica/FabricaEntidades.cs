using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo16;
using DominioSKD.Entidades.Modulo6;
using DominioSKD.Entidades.Modulo7;

namespace DominioSKD.Fabrica
{
    public class FabricaEntidades
    {
        #region Modulo 1
        public Entidad ObtenerPersona_M1()
        {
            return new Entidades.Modulo1.PersonaM1();
        }
        public Entidad ObtenerPersona_M1(int id, String nombre, String apellido)
        {
            return new Entidades.Modulo1.PersonaM1(id, nombre, apellido);
        }
        public Entidad ObtenerCuenta_M1()
        {
            return new Entidades.Modulo1.Cuenta();
        }
        public Entidad ObtenerCuenta_M1(String elNombreUsuario, String laContrasena, 
            List<Entidades.Modulo2.Rol> listaRoles, String laImagen, 
            Entidades.Modulo1.PersonaM1 datosPersonales)
        {
            return new Entidades.Modulo1.Cuenta(elNombreUsuario, laContrasena, listaRoles, laImagen, datosPersonales);
        }
        #endregion

        #region Modulo 2
        public Entidad ObtenerRol_M2()
        {
            return new Entidades.Modulo2.Rol();
        }
        public Entidad ObtenerRol_M2(int elId, String elNombre, String laDescripcion, DateTime laFecha)
        {
            return new Entidades.Modulo2.Rol(elId, elNombre, laDescripcion, laFecha);
        }
        #endregion

        #region Modulo 3
        public static Entidad ObtenerOrganizacion_M3()
        {
            return new DominioSKD.Entidades.Modulo3.Organizacion();
        }
        public static Entidad ObtenerOrganizacion_M3(int elId, String elNombre)
        {
            return new DominioSKD.Entidades.Modulo3.Organizacion(elId, elNombre);
        }
        public static Entidad ObtenerOrganizacion_M3(String elNombre)
        {
            return new DominioSKD.Entidades.Modulo3.Organizacion(elNombre);
        }
        public static Entidad ObtenerOrganizacion_M3(int elId, String elNombre, String laDireccion, int elTelefono, String elEmail, String elEstado, String elEstilo)
        {
            return new DominioSKD.Entidades.Modulo3.Organizacion(elId, elNombre, laDireccion, elTelefono, elEmail, elEstado, elEstilo);
        }
        public static Entidad ObtenerOrganizacion_M3(String elNombre, String laDireccion, int elTelefono, String elEmail, String elEstado, String elEstilo)
        {
            return new DominioSKD.Entidades.Modulo3.Organizacion(elNombre, laDireccion, elTelefono, elEmail, elEstado, elEstilo);
        }
        #endregion

        #region Modulo 4
 
        #endregion

        #region Modulo 5
        public static Entidad ObtenerCinta_M5()
        {
            return new DominioSKD.Entidades.Modulo5.Cinta();
        }
        public static Entidad ObtenerCinta_M5(int elId, String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, int elIdRestriccion)
        {
            return new DominioSKD.Entidades.Modulo5.Cinta(elId, elColor, elRango, laClasificacion, elOrden, elSignificado, elIdRestriccion);
        }
        public static Entidad ObtenerCinta_M5(String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, int elIdRestriccion)
        {
            return new DominioSKD.Entidades.Modulo5.Cinta(elColor, elRango, laClasificacion, elOrden, elSignificado, elIdRestriccion);
        }
        public static Entidad ObtenerCinta_M5(int elId, String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, DominioSKD.Entidades.Modulo3.Organizacion organizacion, Boolean status)
        {
            return new DominioSKD.Entidades.Modulo5.Cinta(elId, elColor, elRango, laClasificacion, elOrden, elSignificado, organizacion, status);
        }
        public static Entidad ObtenerCinta_M5(String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, DominioSKD.Entidades.Modulo3.Organizacion organizacion, Boolean status)
        {
            return new DominioSKD.Entidades.Modulo5.Cinta(elColor, elRango, laClasificacion, elOrden, elSignificado, organizacion, status);
        }
        public static Entidad ObtenerCinta_M5(int elId, String elColor)
        {
            return new DominioSKD.Entidades.Modulo5.Cinta(elId, elColor);
        }
        #endregion

        #region Modulo 6

        #endregion

        #region Modulo 7
        public static Entidad ObtenerCintaM7()
        {
            return new CintaM7();
        }
        public static Entidad ObtenerCompetenciaM7()
        {
            return new CompetenciaM7();
        }
        public static Entidad ObtenerMatriculaM7()
        {
            return new MatriculaM7();
        }
        public static Entidad ObtenerDojoM7()
        {
            return new DojoM7();
        }
        public static Entidad ObtenerEventoM7()
        {
            return new EventoM7();
        }
        public static Entidad ObtenerHorarioM7()
        {
            return new HorarioM7();
        }
        public static Entidad ObtenerOrganizacionM7()
        {
            return new OrganizacionM7();
        }
        public static Entidad ObtenerPersonaM7()
        {
            return new PersonaM7();
        }
        public static Entidad ObtenerTipoEventoM7()
        {
            return new TipoEventoM7();
        }
        public static Entidad ObtenerUbicacionM7()
        {
            return new UbicacionM7();
        }
        #endregion

        #region Modulo 8

        #region Fabricas Restriccion Competencia
        /// <summary>
        /// Fabrica de Restriccion Competencia sin parametros de entrada
        /// </summary>
        /// <returns> Objeto Tipo Entidad </returns>

        public Entidad ObtenerRestriccionCompetencia()
        {
            return new Entidades.Modulo8.RestriccionCompetencia();
        }

        /// <summary>
        /// Fabrica de Restriccion Competencia con parametro de entrada identificador de la restriccion
        /// </summary>
        /// <param name="inputId"> Parametro referente al id unico de la restriccion</param>
        /// <returns>Objeto tipo Entidad</returns>
        
        public Entidad ObtenerRestriccionCompetencia(int inputId)
        {
            return new Entidades.Modulo8.RestriccionCompetencia(inputId);
        }

        /// <summary>
        /// Fabrica de Restriccion Competencia con parametros de entrada multiples sin id unico.
        /// </summary>
        /// <param name="inputDescripcion"> String, descripcion breve de los parametros de la restriccion</param>
        /// <param name="inputEdadMinima">Integer,edad minima con la que se puede participar el competencia</param>
        /// <param name="inputEdadMaxima">Integer, edad maxima con la que se puede participar el competencia</param>
        /// <param name="inputRangoMinimo">Integer, rango Minimo de cinta con la que se puede participar en la competencia</param>
        /// <param name="inputRangoMaximo">Integer, rango Maximo de cinta con la que se puede participar en la competencia</param>
        /// <param name="inputSexo">String, sexo permitido en la competencia {M,F,B} M para solo atletas masculinos, 
        /// F solo para atletas femeninos, B para atletas de ambos sexos</param>
        /// <param name="inputModalidad">String, modalidades que comprende la competencia. {Kumite,Kata,Ambos}</param>
        /// <returns> Objeto tipo Entidad</returns>
        
        public Entidad ObtenerRestriccionCompetencia(String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, int inputRangoMinimo,
                                                     int inputRangoMaximo, String inputSexo, String inputModalidad)
        {
            return new Entidades.Modulo8.RestriccionCompetencia(inputDescripcion, inputEdadMinima, inputEdadMaxima, inputRangoMinimo,
                                      inputRangoMaximo, inputSexo, inputModalidad);
        }

        /// <summary>
        /// Fabrica de Restriccion Competencia con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="inputId"> Integer, atributo correspondiente al id del objeto en bd </param>
        /// <param name="inputDescripcion">String, descripcion breve de los parametros de la restriccion</param>
        /// <param name="inputEdadMinima">Integer,edad minima con la que se puede participar el competencia</param>
        /// <param name="inputEdadMaxima">Integer, edad maxima con la que se puede participar el competencia</param>
        /// <param name="inputRangoMinimo">Integer, rango Minimo de cinta con la que se puede participar en la competencia</param>
        /// <param name="inputRangoMaximo">Integer, rango Maximo de cinta con la que se puede participar en la competencia</param>
        /// <param name="inputSexo">String, sexo permitido en la competencia {M,F,B} M para solo atletas masculinos, 
        /// F solo para atletas femeninos, B para atletas de ambos sexos</param>
        /// <param name="inputModalidad">String, modalidades que comprende la competencia. {Kumite,Kata,Ambos}</param>
        /// <returns> Objeto tipo Entidad</param>
        /// <returns>  Objeto tipo Entidad</returns>
        public Entidad ObtenerRestriccionCompetencia(int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, int inputRangoMinimo,
                                                     int inputRangoMaximo, String inputSexo, String inputModalidad)
        {
            return new Entidades.Modulo8.RestriccionCompetencia(inputId, inputDescripcion, inputEdadMinima, inputEdadMaxima, inputRangoMinimo,
                                      inputRangoMaximo, inputSexo, inputModalidad);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputId"></param>
        /// <param name="inputDescripcion"></param>
        /// <param name="inputEdadMinima"></param>
        /// <param name="inputEdadMaxima"></param>
        /// <param name="inputRangoMinimo"></param>
        /// <param name="inputRangoMaximo"></param>
        /// <param name="inputSexo"></param>
        /// <param name="inputModalidad"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public Entidad ObtenerRestriccionCompetencia(int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, int inputRangoMinimo,
                                                     int inputRangoMaximo, String inputSexo, String inputModalidad, int status)
        {
            return new Entidades.Modulo8.RestriccionCompetencia(inputId, inputDescripcion, inputEdadMinima, inputEdadMaxima, inputRangoMinimo,
                                      inputRangoMaximo, inputSexo, inputModalidad, status);
        }



        /// <summary>
        /// Fabrica de Restriccion Competencia con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="id">Integer, identificador unico del objeto</param>
        /// <param name="inputId"> Integer, atributo correspondiente al id del objeto en bd </param>
        /// <param name="inputDescripcion">String, descripcion breve de los parametros de la restriccion</param>
        /// <param name="inputEdadMinima">Integer,edad minima con la que se puede participar el competencia</param>
        /// <param name="inputEdadMaxima">Integer, edad maxima con la que se puede participar el competencia</param>
        /// <param name="inputRangoMinimo">Integer, rango Minimo de cinta con la que se puede participar en la competencia</param>
        /// <param name="inputRangoMaximo">Integer, rango Maximo de cinta con la que se puede participar en la competencia</param>
        /// <param name="inputSexo">String, sexo permitido en la competencia {M,F,B} M para solo atletas masculinos, 
        /// F solo para atletas femeninos, B para atletas de ambos sexos</param>
        /// <param name="inputModalidad">String, modalidades que comprende la competencia. {Kumite,Kata,Ambos}</param>
        /// <returns> Objeto tipo Entidad</param>
        /// <returns>  Objeto tipo Entidad</returns>
        
        public Entidad ObtenerRestriccionCompetencia(int id, int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, int inputRangoMinimo,
                                                     int inputRangoMaximo, String inputSexo, String inputModalidad)
        {
            return new Entidades.Modulo8.RestriccionCompetencia(id, inputId, inputDescripcion, inputEdadMinima, inputEdadMaxima, inputRangoMinimo,
                                      inputRangoMaximo, inputSexo, inputModalidad);
        }





        #endregion

        #region Fabricas Restriccion Cinta

        /// <summary>
        /// Fabrica de Restriccion Cinta sin parametros de entrada
        /// </summary>
        /// <returns> Objeto Tipo Entidad </returns>

        public static Entidad ObtenerRestriccionCinta()
        {
            return new Entidades.Modulo8.RestriccionCinta();
        }

        /// <summary>
        /// Fabrica de Restriccion Cinta con parametro de entrada identificador de la restriccion
        /// </summary>
        /// <param name="inputId"> Parametro referente al id unico de la restriccion</param>
        /// <returns>Objeto tipo Entidad</returns>

        public static Entidad ObtenerRestriccionCinta(int inputId)
        {
            return new Entidades.Modulo8.RestriccionCinta(inputId);
        }

        /// <summary>
        /// Fabrica de Restriccion Cinta con parametros de entrada multiples sin id unico.
        /// </summary>
        /// <param name="inputDescripcion"> String, descripcion breve de los parametros de la restriccion</param>
        /// <param name="inputTiempoMinimo">Integer,tiempo minimo con el que se puede optar a una cinta</param>
        /// <param name="inputTiempoMaximo">Integer, tiempo maximo con el que se puede optar a una cinta</param>
        /// <param name="inputTiempoDocente">Integer, Tiempo como docente a cumplir para avanzar de cinta</param>
        /// <param name="inputStatus">Integer, bit de status de activacion de la restriccion de cinta</param>
        /// <returns> Objeto tipo Entidad</returns>

        public static Entidad ObtenerRestriccionCinta(String inputDescripcion, int inputTiempoMinimo, int inputTiempoMaximo, int inputTiempoDocente, int inputPuntosMinimos, int inputStatus)
        {
            return new Entidades.Modulo8.RestriccionCinta(inputDescripcion, inputTiempoMinimo, inputTiempoMaximo, inputTiempoDocente, inputPuntosMinimos, inputStatus);
        }

        /// <summary>
        /// Fabrica de Restriccion Cinta con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="inputId"> Integer, atributo correspondiente al id del objeto en bd </param>
        /// <param name="inputDescripcion">String, descripcion breve de los parametros de la restriccion</param>
        /// <param name="inputTiempoMinimo">Integer,tiempo minimo con el que se puede optar a una cinta</param>
        /// <param name="inputTiempoMaximo">Integer, tiempo maximo con el que se puede optar a una cinta</param>
        /// <param name="inputTiempoDocente">Integer, Tiempo como docente a cumplir para avanzar de cinta</param>
        /// <param name="inputStatus">Integer, bit de status de activacion de la restriccion de cinta</param>
        /// <returns>  Objeto tipo Entidad</returns>
        public static Entidad ObtenerRestriccionCinta(int inputId, String inputDescripcion, int inputTiempoMinimo, int inputTiempoMaximo, int inputTiempoDocente, int inputPuntosMinimos, int inputStatus)
        {
            return new Entidades.Modulo8.RestriccionCinta(inputId, inputDescripcion, inputTiempoMinimo, inputTiempoMaximo, inputTiempoDocente, inputPuntosMinimos, inputStatus);
        }

        /// <summary>
        /// Fabrica de Restriccion Cinta con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="id">Integer, identificador unico del objeto</param>
        /// <param name="inputId"> Integer, atributo correspondiente al id del objeto en bd </param>
        /// <param name="inputDescripcion">String, descripcion breve de los parametros de la restriccion</param>
        /// <param name="inputTiempoMinimo">Integer,tiempo minimo con el que se puede optar a una cinta</param>
        /// <param name="inputTiempoMaximo">Integer, tiempo maximo con el que se puede optar a una cinta</param>
        /// <param name="inputTiempoDocente">Integer, Tiempo como docente a cumplir para avanzar de cinta</param>
        /// <param name="inputStatus">Integer, bit de status de activacion de la restriccion de cinta</param>
        /// <returns>  Objeto tipo Entidad</returns>

        public static Entidad ObtenerRestriccionCinta(int id, int inputId, String inputDescripcion, int inputTiempoMinimo, int inputTiempoMaximo, int inputTiempoDocente, int inputPuntosMinimos, int inputStatus)
        {
            return new Entidades.Modulo8.RestriccionCinta(id, inputId, inputDescripcion, inputTiempoMinimo, inputTiempoMaximo, inputTiempoDocente, inputPuntosMinimos, inputStatus);
        }
        
        /// <summary>
        /// Fabrica de Restriccion Cinta con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="inputId"> Integer, atributo correspondiente al id del objeto en bd </param>
        /// <param name="inputStatus">Integer, bit de status de activacion de la restriccion de cinta</param>
        /// <returns>  Objeto tipo Entidad</returns>
        public static Entidad ObtenerRestriccionCinta(int inputId, int inputStatus)
        {
            return new Entidades.Modulo8.RestriccionCinta(inputId, inputStatus);
        }

        #endregion

        #region Fabricas Restriccion Evento
        /// <summary>
        /// Fabrica de Restriccion Evento sin parametros de entrada
        /// </summary>
        /// <returns> Objeto Tipo Entidad </returns>

        public static Entidad ObtenerRestriccionEvento()
        {
            return new Entidades.Modulo8.RestriccionEvento();
        }

        /// <summary>
        /// Fabrica de Restriccion Evento con parametro de entrada identificador de la restriccion
        /// </summary>
        /// <param name="inputId"> Parametro referente al id unico de la restriccion del evento</param>
        /// <returns>Objeto tipo Entidad</returns>

        public static Entidad ObtenerRestriccionEvento(int inputId)
        {
            return new Entidades.Modulo8.RestriccionEvento(inputId);
        }

        /// <summary>
        /// Fabrica de Restriccion Evento con parametros de entrada multiples sin id unico.
        /// </summary>
        /// <param name="inputDescripcion"> String, descripcion breve de los parametros de la restriccion del evento</param>
        /// <param name="inputEdadMinima">Integer,edad minima con la que se puede participar en el evento</param>
        /// <param name="inputEdadMaxima">Integer, edad maxima con la que se puede participar en el evento</param>
        /// <param name="inputSexo">String, sexo permitido en el evento {M,F,B} M para solo atletas masculinos, 
        /// F solo para atletas femeninos, B para atletas de ambos sexos</param>
        /// <param name="inputIdEvento">Integer, id del evento</param>
        /// <param name="inputNombreEvento">String, nombre del evento</param>
        /// <param name="inputStatus">Integer, estado de la restriccion evento</param>
        /// <returns> Objeto tipo Entidad</returns>

        public static Entidad ObtenerRestriccionEvento(String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo, int inputIdEvento, String inputNombreEvento, int inputStatus)
        {
            return new Entidades.Modulo8.RestriccionEvento(inputDescripcion, inputEdadMinima, inputEdadMaxima, inputSexo, inputIdEvento, inputNombreEvento, inputStatus);
        }

        /// <summary>
        /// Fabrica de Restriccion Evento con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="inputId"> Integer, atributo correspondiente al id del objeto en bd </param>
        /// <param name="inputDescripcion">String, descripcion breve de los parametros de la restriccion</param>
        /// <param name="inputEdadMinima">Integer,edad minima con la que se puede participar en el evento</param>
        /// <param name="inputEdadMaxima">Integer, edad maxima con la que se puede participar en el evento</param>
        /// <param name="inputSexo">String, sexo permitido en el evento {M,F,B} M para solo atletas masculinos, 
        /// F solo para atletas femeninos, B para atletas de ambos sexos</param>
        /// <param name="inputIdEvento">Integer, id del evento</param>
        /// <param name="inputNombreEvento">String, nombre del evento</param>
        /// <param name="inputStatus">Integer, estado de la restriccion evento</param>
        /// <returns>  Objeto tipo Entidad</returns>
        public static Entidad ObtenerRestriccionEvento(int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo, int inputIdEvento, String inputNombreEvento, int inputStatus)
        {
            return new Entidades.Modulo8.RestriccionEvento(inputId, inputDescripcion, inputEdadMinima, inputEdadMaxima, inputSexo, inputIdEvento, inputNombreEvento, inputStatus);
        }

        /// <summary>
        /// Fabrica de Restriccion Evento con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="id">Integer, identificador unico del objeto</param>
        /// <param name="inputId"> Integer, atributo correspondiente al id del objeto en bd </param>
        /// <param name="inputDescripcion">String, descripcion breve de los parametros de la restriccion</param>
        /// <param name="inputEdadMinima">Integer,edad minima con la que se puede participar en el evento</param>
        /// <param name="inputEdadMaxima">Integer, edad maxima con la que se puede participar en el evento</param>
        /// <param name="inputSexo">String, sexo permitido en el evento {M,F,B} M para solo atletas masculinos, 
        /// F solo para atletas femeninos, B para atletas de ambos sexos</param>
        /// <param name="inputIdEvento">Integer, id del evento</param>
        /// <param name="inputNombreEvento">String, nombre del evento</param>
        /// <param name="inputStatus">Integer, estado de la restriccion evento</param>
        /// <returns>  Objeto tipo Entidad</returns>

        public static Entidad ObtenerRestriccionEvento(int id, int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo, int inputIdEvento, String inputNombreEvento, int inputStatus)
        {
            return new Entidades.Modulo8.RestriccionEvento(id, inputId, inputDescripcion, inputEdadMinima, inputEdadMaxima, inputSexo, inputIdEvento, inputNombreEvento, inputStatus);
        }

        #endregion

        #region Fabricas EventoSimple
        /// <summary>
        /// Fabrica de EventoSimple sin parametros de entrada
        /// </summary>
        /// <returns> Objeto Tipo Entidad </returns>
        public static Entidad ObtenerEventoSimple()
        {
            return new Entidades.Modulo8.EventoSimple();
        }

        /// <summary>
        /// Fabrica de EventoSimple con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="inputId"> Integer, atributo correspondiente al id del evento en bd </param>
        /// <param name="inputNombre">String, nombre del evento</param>
        /// <returns>  Objeto tipo Entidad</returns>
        public static Entidad ObtenerEventoSimple(int inputId, String inputNombre)
        {
            return new Entidades.Modulo8.EventoSimple(inputId, inputNombre);
        }

        /// <summary>
        /// Fabrica de EventoSimple con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="id">Integer, identificador unico del objeto</param>
        /// <param name="inputId"> Integer, atributo correspondiente al id del evento en bd </param>
        /// <param name="inputNombre">String, nombre del evento</param>
        /// <returns>  Objeto tipo Entidad</returns>
        public static Entidad ObtenerEventoSimple(int id, int inputId, String inputNombre)
        {
            return new Entidades.Modulo8.EventoSimple(id, inputId, inputNombre);
        }
        #endregion

        #region Fabricas CintaSimple
        /// <summary>
        /// Fabrica de CintaSimple sin parametros de entrada
        /// </summary>
        /// <returns> Objeto Tipo Entidad </returns>
        public static Entidad obtenerCintaSimple()
        {
            return new Entidades.Modulo8.CintaSimple();
        }

        /// <summary>
        /// Fabrica de CintaSimple con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="inputId"> Integer, atributo correspondiente al id de la cinta en bd </param>
        /// <param name="inputColor">String, color de la cinta</param>
        /// <returns>  Objeto tipo Entidad</returns>
        public static Entidad ObtenerCintaSimple(int inputId, String inputColor)
        {
            return new Entidades.Modulo8.CintaSimple(inputId, inputColor);
        }

        /// <summary>
        /// Fabrica de CintaSimple con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="id">Integer, identificador unico del objeto</param>
        /// <param name="inputId"> Integer, atributo correspondiente al id de la cinta en bd </param>
        /// <param name="inputColor">String, color de la cinta</param>
        /// <returns>  Objeto tipo Entidad</returns>
        public static Entidad ObtenerCintaSimple(int id, int inputId, String inputColor)
        {
            return new Entidades.Modulo8.CintaSimple(id, inputId, inputColor);
        }
        #endregion

        #endregion

        #region Modulo 9
        public static Entidad ObtenerEvento()
        {
            return new DominioSKD.Entidades.Modulo9.Evento();
        }

        public static Entidad ObtenerHorario()
        {
            return new DominioSKD.Entidades.Modulo9.Horario();
        }

        public static Entidad ObtenerTipoEvento()
        {
            return new DominioSKD.Entidades.Modulo9.TipoEvento();
        }

        #region ObtenerEventoCompletos Modulo16
        public static Entidad ObtenerEventoCompletos()
        {
            return new DominioSKD.Evento();
        }

        #endregion

        #endregion

        #region Modulo 10
        public static Entidad ObtenerAsistencia()
        {
            return new DominioSKD.Entidades.Modulo10.Asistencia();
        }

        public static Entidad ObtenerInscripcion()
        {
            return new DominioSKD.Entidades.Modulo10.Inscripcion();
        }

        public static Entidad ObtenerPersonaM10()
        {
            return new DominioSKD.Entidades.Modulo10.Persona();
        }

        public static Entidad ObtenerEventoM10()
        {
            return new DominioSKD.Entidades.Modulo10.Evento();
        }

        public static Entidad ObtenerHorarioM10()
        {
            return new DominioSKD.Entidades.Modulo10.Horario();
        }

        public static Entidad ObtenerTipoEventoM10()
        {
            return new DominioSKD.Entidades.Modulo10.TipoEvento();
        }

        public static Entidad ObtenerValores()
        {
            return new DominioSKD.Entidades.Modulo10.Valores();
        }
        #endregion

        #region Modulo 11
        public static Entidad ObtenerResultadoAscenso()
        {
            return new DominioSKD.Entidades.Modulo11.ResultadoAscenso();
        }
        public static Entidad ObtenerResultadoKata()
        {
            return new DominioSKD.Entidades.Modulo11.ResultadoKata();
        }
        public static Entidad ObtenerResultadoKumite()
        {
            return new DominioSKD.Entidades.Modulo11.ResultadoKumite();
        }
        #endregion

        #region Modulo 12

        public static Entidad ObtenerCinta()
        {
            return new Cinta();
        }

        public static Entidad ObtenerOrganizacion(int elId, String elNombre)
        {
            return new Organizacion(elId, elNombre);
        }

        public static Entidad ObtenerOrganizacion(String elNombre)
        {
            return new Organizacion(elNombre);
        }

        public static Entidad ObtenerOrganizacion()
        {
            return new Organizacion();
        }

        public static Entidad ObtenerCategoria()
        {
            return new DominioSKD.Entidades.Modulo12.Categoria();
        }

        public static Entidad ObtenerUbicacion()
        {
            return new DominioSKD.Entidades.Modulo12.Ubicacion();
        }

        public static Entidad ObtenerCompetencia()
        {
            return new DominioSKD.Entidades.Modulo12.Competencia();
        }

        public static Entidad ObtenerCategoria(int laEdadIni, int laEdadFin, String laCintaIni, String laCintaFinal, String elSexo)
        {
            return new DominioSKD.Entidades.Modulo12.Categoria(laEdadIni, laEdadFin, laCintaIni, laCintaFinal, elSexo);
        }

        public static Entidad ObtenerCategoria(int elId, int laEdadIni, int laEdadFin, String laCintaIni, String laCintaFinal, String elSexo)
        {
            return new DominioSKD.Entidades.Modulo12.Categoria(elId, laEdadIni, laEdadFin, laCintaIni, laCintaFinal, elSexo);
        }

        public static Entidad ObtenerUbicacion(int elId, String laCiudad, String elEstado)
        {
            return new DominioSKD.Entidades.Modulo12.Ubicacion(elId, laCiudad, elEstado);
        }

        public static Entidad ObtenerUbicacion(String laLat, String laLon, String laCiudad, String elEstado, String LaDir)
        {
            return new DominioSKD.Entidades.Modulo12.Ubicacion(laLat, laLon, laCiudad, elEstado, LaDir);
        }

        public static Entidad ObtenerUbicacion(int elId, String laLat, String laLon, String laCiudad, String elEstado, String LaDir)
        {
            return new DominioSKD.Entidades.Modulo12.Ubicacion(elId, laLat, laLon, laCiudad, elEstado, LaDir);
        }

        public static Entidad ObtenerCompetencia(int elId, String elNombre, String elTipo, bool orgTodas, String elStatus)
        {
            return new DominioSKD.Entidades.Modulo12.Competencia(elId, elNombre, elTipo, orgTodas, elStatus);
        }
        #endregion

        #region Modulo 13
        #endregion

        #region Modulo 14
        public static Entidad ObtenerPlanilla()
        {
            return new DominioSKD.Entidades.Modulo14.Planilla();
        }
        public static Entidad ObtenerPlanilla(string nombre, Boolean status, string tipoPlanilla)
        {
            return new DominioSKD.Entidades.Modulo14.Planilla(nombre, status, tipoPlanilla);
        }
        public static Entidad ObtenerPlanilla(int id, string nombre, Boolean status, string tipoPlanilla)
        {
            return new DominioSKD.Entidades.Modulo14.Planilla(id, nombre, status, tipoPlanilla);
        }
        public static Entidad ObtenerPlanilla(string nombre, bool status, string tipoPlanilla, List<String> datos)
        {
            return new DominioSKD.Entidades.Modulo14.Planilla(nombre, status, tipoPlanilla, datos);
        }
        public static Entidad ObtenerPlanilla(string nombre, bool status, int idTipoPlanilla, List<String> datos)
        {
            return new DominioSKD.Entidades.Modulo14.Planilla(nombre, status, idTipoPlanilla, datos);
        }
        public static Entidad ObtenerPlanilla(int id, string nombre, bool status, int idTipoPlanilla, List<String> datos)
        {
            return new DominioSKD.Entidades.Modulo14.Planilla(id, nombre, status, idTipoPlanilla, datos);
        }
        public static Entidad ObtenerPlanilla(int idTipoPlanilla, string tipoPlanilla)
        {
            return new DominioSKD.Entidades.Modulo14.Planilla(idTipoPlanilla, tipoPlanilla);
        }
        public static Entidad ObtenerPlanilla(string nombre, bool status, int idTipoPlanilla)
        {
            return new DominioSKD.Entidades.Modulo14.Planilla(nombre, status, idTipoPlanilla);
        }
        public static Entidad ObtenerPlanilla(List<String> datos)
        {
            return new DominioSKD.Entidades.Modulo14.Planilla(datos);
        }

        public static Entidad ObtenerSolicitudP()
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudP();
        }
        public static Entidad ObtenerSolicitudP(String fechaRetiro, String fechaReincorporacion, String motivo, int id)
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudP(fechaRetiro, fechaReincorporacion, motivo, id);
        }
        public static Entidad ObtenerSolicitudP(String fechaRetiro, String fechaReincorporacion, String motivo, DominioSKD.Entidades.Modulo14.Planilla planilla, int id)
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudP(fechaRetiro, fechaReincorporacion, motivo, planilla, id);
        }
        public static Entidad ObtenerSolicitudP(int id, String nombreEvento)
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudP(id, nombreEvento);
        }
        public static Entidad ObtenerSolicitudP(int id, String fechaRetiro, String fechaReincorporacion, String motivo, DominioSKD.Entidades.Modulo14.Planilla planilla, int idInscripcion)
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudP(id, fechaRetiro, fechaReincorporacion, motivo, planilla, idInscripcion);
        }
        public static Entidad ObtenerSolicitudP(String fechaRetiro, String fechaReincorporacion, String motivo, int id, int idInscripcion)
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudP(fechaRetiro, fechaReincorporacion, motivo, id, idInscripcion);
        }
        public static Entidad ObtenerSolicitudP(int id, String fechaRetiro, String fechaReincorporacion, String motivo, int idInscripcion)
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudP(id, fechaRetiro, fechaReincorporacion, motivo, idInscripcion);
        }
        public static Entidad ObtenerSolicitudPlanilla()
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudPlanilla();
        }
        public static Entidad ObtenerSolicitudPlanilla(DateTime fechaCreacion, DateTime fechaRetiro, DateTime fechaReincorporacion,
            string motivo, DominioSKD.Entidades.Modulo14.Planilla planilla, int idInscripcion, int idPersona)
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudPlanilla(fechaCreacion, fechaRetiro, fechaReincorporacion,
             motivo, planilla, idInscripcion, idPersona);
        }
        public static Entidad ObtenerSolicitudPlanilla(int id, DateTime fechaCreacion, DateTime fechaRetiro, DateTime fechaReincorporacion,
            string motivo, DominioSKD.Entidades.Modulo14.Planilla planilla, int idInscripcion, int idPersona)
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudPlanilla(id, fechaCreacion, fechaRetiro, fechaReincorporacion,
             motivo, planilla, idInscripcion, idPersona);
        }
        public static Entidad ObtenerSolicitudPlanilla(DateTime fechaCreacion, DominioSKD.Entidades.Modulo14.Planilla planilla, int idInscripcion, int idPersona)
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudPlanilla(fechaCreacion, planilla, idInscripcion, idPersona);
        }
        public static Entidad ObtenerSolicitudPlanilla(int id, DateTime fechaCreacion, DominioSKD.Entidades.Modulo14.Planilla planilla, int idInscripcion, int idPersona)
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudPlanilla(id, fechaCreacion, planilla, idInscripcion, idPersona);
        }
        public static Entidad ObtenerSolicitudPlanilla(DateTime fechaRetiro, DateTime fechaReincorporacion, string motivo, DominioSKD.Entidades.Modulo14.Planilla planilla)
        {
            return new DominioSKD.Entidades.Modulo14.SolicitudPlanilla(fechaRetiro, fechaReincorporacion, motivo, planilla);
        }

        public static Entidad obtenerDiseño()
        {
            return new DominioSKD.Entidades.Modulo14.Diseño();
        }

        public static Entidad obtenerDiseño(int id, string contenido)
        {
            return new DominioSKD.Entidades.Modulo14.Diseño(id, contenido);
        }

        public static Entidad obtenerDiseño(string contenido)
        {
            return new DominioSKD.Entidades.Modulo14.Diseño(contenido);
        }
        // Entidades de otros modulos que necesitamos
        public static Entidad ObtenerPersona()
        {
            return new Persona();
        }
        public static Entidad ObtenerDojo()
        {
            return new Dojo();
        }
        public static Entidad ObtenerMatricula()
        {
            return new Matricula();
        }
        //Hasta aca
        #endregion

        #region Modulo 15
        public static Entidad ObtenerImplemento(int id_implemento, String nombre_implemento, String tipo_implemento, String marca_implemento, String color_implemento, String talla_implemento, String imagen_implemento, int cantidad_implemento, int stock_minimo_implemento, String estatus_implemento, double precio_implemento, String descripcion_implemento, Dojo dojo)
        {
            return new Implemento(id_implemento, nombre_implemento, tipo_implemento, marca_implemento, color_implemento, talla_implemento, imagen_implemento, cantidad_implemento, stock_minimo_implemento, estatus_implemento, precio_implemento, descripcion_implemento, dojo);
        }

        public static Entidad ObtenerImplemento()
        {
            return new Implemento();
        }

        public static Entidad ObtenerUsuario()
        {
            return new Usuario();
        }
        public static Entidad tenerDojo()
        {
            return new Dojo();
        }
        #endregion

        #region Modulo 16
        /// <summary>
        /// Metodo de la fabrica que instancia un carrito vacio
        /// </summary>
        /// <returns>La entidad carrito vacia</returns>
        public static Entidad ObtenerCarrito()
        {
            return new Entidades.Modulo16.Carrito();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el carrito con todas sus listas llenas
        /// </summary>
        /// <param name="implementos">Lista con todos los implementos del carrito</param>
        /// <param name="eventos">Lista con todos los eventos del carrito</param>
        /// <param name="matriculas">Lista con todas las matriculas del carrito</param>
        /// <param name="monto">Monto que se ha pagado de ese carrito</param>
        /// <returns>La entidad carrito con todos sus datos llenos</returns>
        public static Entidad ObtenerCarrito(
           Dictionary<Entidad, int> implementos,
            Dictionary<Entidad, int> eventos,
            Dictionary<Entidad, int> matriculas, float monto)
        {
            return new Entidades.Modulo16.Carrito(implementos, eventos, matriculas, monto);
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el pago vacio
        /// </summary>
        /// <returns>La entidad pago vacio</returns>
        public static Entidad ObtenerPago()
        {
            return new Entidades.Modulo16.Pago();
        }

        /// <summary>
        /// Metodo de la fabrica que instnacia el carrito con todos sus datos llenos
        /// </summary>
        /// <param name="monto">El monto con el que se pagara la transaccion</param>
        /// <param name="tipoPago">El tipo de pago con el que se realizara la transaccion</param>
        /// <param name="datoPago">Los datos correspondientes al pago selecccionado</param>
        /// <returns></returns>
        public static Entidad ObtenerPago(float monto, String tipoPago, List<String> datoPago)
        {
            return new Entidades.Modulo16.Pago(monto, tipoPago, datoPago);
        }

       
        /// <summary>
        /// Metodo de la fabrica que instancia el Dojo
        /// </summary>
        /// <param name="NONE">Este metodo no posee parametros</param>
        /// <returns>La entidad dojo con todos sus datos llenos</returns>
        public static Entidad ObtenerDojos()
        {
            return new Dojo();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia la compra
        /// </summary>
        /// <param name="NONE">Este metodo no posee parametros</param>
        /// <returns>La entidad compra con todos sus datos llenos</returns>
        public static Entidad ObtenerFactura()
        {
            return new Compra();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia la compra
        /// </summary>
        /// <param name="NONE">Este metodo no posee parametros</param>
        /// <returns>La entidad compra con todos sus datos llenos de productos</returns>
        public static Entidad ObtenerFacturaImplemento()
        {
            return new DetalleFacturaProducto();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia la compra
        /// </summary>
        /// <param name="NONE">Este metodo no posee parametros</param>
        /// <returns>La entidad compra con todos sus datos llenos de eventos</returns>
        public static Entidad ObtenerFacturaEvento()
        {
            return new DetalleFacturaEvento();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia la compra
        /// </summary>
        /// <param name="NONE">Este metodo no posee parametros</param>
        /// <returns>La entidad compra con todos sus datos llenos de matricula</returns>
        public static Entidad ObtenerFacturaMatricula()
        {
            return new DetalleFacturaMatricula();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia la compra
        /// </summary>
        /// <param name="NONE">Este metodo no posee parametros</param>
        /// <returns>La entidad pago con todos datos de la factura</returns>
        public static Entidad ObtenerFacturaPago()
        {
            return new Pago();
        }

        #endregion
    }
}
