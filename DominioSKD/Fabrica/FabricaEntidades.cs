using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DominioSKD.Fabrica
{
    public class FabricaEntidades
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        #endregion

        #region Modulo 3
		public Entidad ObtenerOrganizacion_M3()
        {
            return new DominioSKD.Entidades.Modulo3.Organizacion();
        }
        public Entidad ObtenerOrganizacion_M3(int elId, String elNombre)
        {
            return new DominioSKD.Entidades.Modulo3.Organizacion(elId, elNombre);
        }
        public Entidad ObtenerOrganizacion_M3(String elNombre)
        {
            return new DominioSKD.Entidades.Modulo3.Organizacion(elNombre);
        }
        public Entidad ObtenerOrganizacion_M3(int elId, String elNombre, String laDireccion, int elTelefono, String elEmail, String elEstado, String elEstilo)
        {
            return new DominioSKD.Entidades.Modulo3.Organizacion(elId, elNombre, laDireccion, elTelefono, elEmail, elEstado, elEstilo);
        }
        public Entidad ObtenerOrganizacion_M3(String elNombre, String laDireccion, int elTelefono, String elEmail, String elEstado, String elEstilo)
        {
            return new DominioSKD.Entidades.Modulo3.Organizacion(elNombre, laDireccion, elTelefono, elEmail, elEstado, elEstilo);
        }
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
		public Entidad ObtenerCinta_M5()
        {
            return new DominioSKD.Entidades.Modulo5.Cinta();
        }
        public Entidad ObtenerCinta_M5(int elId, String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, int elIdRestriccion)
        {
            return new DominioSKD.Entidades.Modulo5.Cinta(elId, elColor, elRango, laClasificacion, elOrden, elSignificado, elIdRestriccion);
        }
        public Entidad ObtenerCinta_M5(String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, int elIdRestriccion)
        {
            return new DominioSKD.Entidades.Modulo5.Cinta(elColor, elRango, laClasificacion, elOrden, elSignificado, elIdRestriccion);
        }
        public Entidad ObtenerCinta_M5(int elId, String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, DominioSKD.Entidades.Modulo3.Organizacion organizacion, Boolean status)
        {
            return new DominioSKD.Entidades.Modulo5.Cinta(elId, elColor, elRango, laClasificacion, elOrden, elSignificado, organizacion, status);
        }
        public Entidad ObtenerCinta_M5(String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, DominioSKD.Entidades.Modulo3.Organizacion organizacion, Boolean status)
        {
            return new DominioSKD.Entidades.Modulo5.Cinta(elColor, elRango, laClasificacion, elOrden, elSignificado, organizacion, status);
        }
        public Entidad ObtenerCinta_M5(int elId, String elColor)
        {
            return new DominioSKD.Entidades.Modulo5.Cinta(elId, elColor);
        }
        #endregion

        #region Modulo 6
        #endregion

        #region Modulo 7
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

        public Entidad ObtenerRestriccionCinta()
        {
            return new Entidades.Modulo8.RestriccionCinta();
        }

        /// <summary>
        /// Fabrica de Restriccion Cinta con parametro de entrada identificador de la restriccion
        /// </summary>
        /// <param name="inputId"> Parametro referente al id unico de la restriccion</param>
        /// <returns>Objeto tipo Entidad</returns>

        public Entidad ObtenerRestriccionCinta(int inputId)
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
        /// <returns> Objeto tipo Entidad</returns>

        public Entidad ObtenerRestriccionCinta(String inputDescripcion, int inputTiempoMinimo, int inputTiempoMaximo, int inputTiempoDocente, int inputPuntosMinimos)
        {
            return new Entidades.Modulo8.RestriccionCinta(inputDescripcion, inputTiempoMinimo, inputTiempoMaximo, inputTiempoDocente, inputPuntosMinimos);
        }

        /// <summary>
        /// Fabrica de Restriccion Cinta con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="inputId"> Integer, atributo correspondiente al id del objeto en bd </param>
        /// <param name="inputDescripcion">String, descripcion breve de los parametros de la restriccion</param>
        /// <param name="inputTiempoMinimo">Integer,tiempo minimo con el que se puede optar a una cinta</param>
        /// <param name="inputTiempoMaximo">Integer, tiempo maximo con el que se puede optar a una cinta</param>
        /// <param name="inputTiempoDocente">Integer, Tiempo como docente a cumplir para avanzar de cinta</param>
        /// <returns>  Objeto tipo Entidad</returns>
        public Entidad ObtenerRestriccionCinta(int inputId, String inputDescripcion, int inputTiempoMinimo, int inputTiempoMaximo, int inputTiempoDocente, int inputPuntosMinimos)
        {
            return new Entidades.Modulo8.RestriccionCinta(inputId, inputDescripcion, inputTiempoMinimo, inputTiempoMaximo, inputTiempoDocente, inputPuntosMinimos);
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
        /// <returns>  Objeto tipo Entidad</returns>

        public Entidad ObtenerRestriccionCinta(int id, int inputId, String inputDescripcion, int inputTiempoMinimo, int inputTiempoMaximo, int inputTiempoDocente, int inputPuntosMinimos)
        {
            return new Entidades.Modulo8.RestriccionCinta(id, inputId, inputDescripcion, inputTiempoMinimo, inputTiempoMaximo, inputTiempoDocente, inputPuntosMinimos);
        }

        #endregion

        #region Fabricas Restriccion Evento
        /// <summary>
        /// Fabrica de Restriccion Evento sin parametros de entrada
        /// </summary>
        /// <returns> Objeto Tipo Entidad </returns>

        public Entidad ObtenerRestriccionEvento()
        {
            return new Entidades.Modulo8.RestriccionEvento();
        }

        /// <summary>
        /// Fabrica de Restriccion Evento con parametro de entrada identificador de la restriccion
        /// </summary>
        /// <param name="inputId"> Parametro referente al id unico de la restriccion del evento</param>
        /// <returns>Objeto tipo Entidad</returns>

        public Entidad ObtenerRestriccionEvento(int inputId)
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
        /// <returns> Objeto tipo Entidad</returns>

        public Entidad ObtenerRestriccionEvento(String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo, int inputIdEvento, String inputNombreEvento)
        {
            return new Entidades.Modulo8.RestriccionEvento(inputDescripcion, inputEdadMinima, inputEdadMaxima, inputSexo, inputIdEvento, inputNombreEvento);
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
        /// <returns>  Objeto tipo Entidad</returns>
        public Entidad ObtenerRestriccionEvento(int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo, int inputIdEvento, String inputNombreEvento)
        {
            return new Entidades.Modulo8.RestriccionEvento(inputId, inputDescripcion, inputEdadMinima, inputEdadMaxima, inputSexo, inputIdEvento, inputNombreEvento);
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
        /// <returns>  Objeto tipo Entidad</returns>

        public Entidad ObtenerRestriccionEvento(int id, int inputId, String inputDescripcion, int inputEdadMinima, int inputEdadMaxima, String inputSexo, int inputIdEvento, String inputNombreEvento)
        {
            return new Entidades.Modulo8.RestriccionEvento(id, inputId, inputDescripcion, inputEdadMinima, inputEdadMaxima, inputSexo, inputIdEvento, inputNombreEvento);
        }

        #endregion

        #region Fabricas EventoSimple
        /// <summary>
        /// Fabrica de EventoSimple sin parametros de entrada
        /// </summary>
        /// <returns> Objeto Tipo Entidad </returns>
        public Entidad ObtenerEventoSimple()
        {
            return new Entidades.Modulo8.EventoSimple();
        }

        /// <summary>
        /// Fabrica de EventoSimple con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="inputId"> Integer, atributo correspondiente al id del evento en bd </param>
        /// <param name="inputNombre">String, nombre del evento</param>
        /// <returns>  Objeto tipo Entidad</returns>
        public Entidad ObtenerEventoSimple(int inputId, String inputNombre)
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
        public Entidad ObtenerEventoSimple(int id, int inputId, String inputNombre)
        {
            return new Entidades.Modulo8.EventoSimple(id, inputId, inputNombre);
        }
        #endregion

        #region Fabricas CintaSimple
        /// <summary>
        /// Fabrica de CintaSimple sin parametros de entrada
        /// </summary>
        /// <returns> Objeto Tipo Entidad </returns>
        public Entidad obtenerCintaSimple()
        {
            return new Entidades.Modulo8.CintaSimple();
        }

        /// <summary>
        /// Fabrica de CintaSimple con parametros de entrada multiples con id unico.
        /// </summary>
        /// <param name="inputId"> Integer, atributo correspondiente al id de la cinta en bd </param>
        /// <param name="inputColor">String, color de la cinta</param>
        /// <returns>  Objeto tipo Entidad</returns>
        public Entidad ObtenerCintaSimple(int inputId, String inputColor)
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
        public Entidad ObtenerCintaSimple(int id, int inputId, String inputColor)
        {
            return new Entidades.Modulo8.CintaSimple(id, inputId, inputColor);
        }
        #endregion

        #endregion

        #region Modulo 9
        #endregion

        #region Modulo 10
        #endregion

        #region Modulo 11
        #endregion

        #region Modulo 12

        public Entidad ObtenerCinta()
        {
            return new Cinta();
        }

        public Entidad ObtenerOrganizacion(int elId, String elNombre)
        {
            return new Organizacion(elId, elNombre);
        }

        public Entidad ObtenerOrganizacion(String elNombre)
        {
            return new Organizacion(elNombre);
        }

        public Entidad ObtenerOrganizacion()
        {
            return new Organizacion();
        }

        public Entidad ObtenerCategoria()
        {
            return new Categoria();
        }

        public   Entidad ObtenerUbicacion()
        {
            return new Ubicacion();
        }

        public   Entidad ObtenerCompetencia()
        {
            return new Competencia();
        }

        public   Entidad ObtenerCategoria(int laEdadIni, int laEdadFin, String laCintaIni, String laCintaFinal, String elSexo)
        {
            return new Categoria(laEdadIni, laEdadFin,laCintaIni, laCintaFinal, elSexo);
        }

        public   Entidad ObtenerCategoria(int elId, int laEdadIni, int laEdadFin, String laCintaIni, String laCintaFinal, String elSexo)
        {
            return new Categoria(elId, laEdadIni, laEdadFin, laCintaIni, laCintaFinal, elSexo);
        }

        public   Entidad ObtenerUbicacion(int elId, String laCiudad, String elEstado)
        {
            return new Ubicacion(elId, laCiudad, elEstado);
        }

        public   Entidad ObtenerUbicacion(String laLat, String laLon, String laCiudad, String elEstado, String LaDir)
        {
            return new Ubicacion(laLat, laLon, laCiudad, elEstado, LaDir);
        }

        public   Entidad ObtenerUbicacion(int elId,String laLat, String laLon, String laCiudad, String elEstado, String LaDir)
        {
            return new Ubicacion(elId, laLat, laLon, laCiudad, elEstado, LaDir);
        }

        public   Entidad ObtenerCompetencia(int elId, String elNombre, String elTipo, bool orgTodas, String elStatus)
        {
            return new Competencia(elId, elNombre, elTipo, orgTodas, elStatus);
        }
        #endregion

        #region Modulo 13
        #endregion

        #region Modulo 14
        public Entidad ObtenerPlanilla()
        {
            return new Planilla();
        }
        public Entidad ObtenerPlanilla(string nombre, Boolean status, string tipoPlanilla)
        {
            return new Planilla(nombre, status, tipoPlanilla);
        }
        public Entidad ObtenerPlanilla(int id, string nombre, Boolean status, string tipoPlanilla)
        {
            return new Planilla(id, nombre, status, tipoPlanilla);
        }
        public Entidad ObtenerPlanilla(string nombre, bool status, string tipoPlanilla, List<String> datos)
        {
            return new Planilla(nombre, status, tipoPlanilla, datos);
        }
        public Entidad ObtenerPlanilla(string nombre, bool status, int idTipoPlanilla, List<String> datos)
        {
            return new Planilla(nombre, status, idTipoPlanilla, datos);
        }
        public Entidad ObtenerPlanilla(int id, string nombre, bool status, int idTipoPlanilla, List<String> datos)
        {
            return new Planilla(id, nombre, status, idTipoPlanilla, datos);
        }
        public Entidad ObtenerPlanilla(int idTipoPlanilla, string tipoPlanilla)
        {
            return new Planilla(idTipoPlanilla, tipoPlanilla);
        }
        public Entidad ObtenerPlanilla(string nombre, bool status, int idTipoPlanilla)
        {
            return new Planilla(nombre, status, idTipoPlanilla);
        }
        public Entidad ObtenerPlanilla(List<String> datos)
        {
            return new Planilla(datos);
        }

        public Entidad ObtenerSolicitudP()
        {
            return new SolicitudP();
        }
        public Entidad ObtenerSolicitudP(String fechaRetiro, String fechaReincorporacion, String motivo, int id)
        {
            return new SolicitudP(fechaRetiro, fechaReincorporacion, motivo, id);
        }
        public Entidad ObtenerSolicitudP(String fechaRetiro, String fechaReincorporacion, String motivo, Planilla planilla, int id)
        {
            return new SolicitudP(fechaRetiro, fechaReincorporacion, motivo, planilla, id);
        }
        public Entidad ObtenerSolicitudP(int id, String nombreEvento)
        {
            return new SolicitudP(id, nombreEvento);
        }
        public Entidad ObtenerSolicitudP(int id, String fechaRetiro, String fechaReincorporacion, String motivo, Planilla planilla, int idInscripcion)
        {
            return new SolicitudP(id, fechaRetiro, fechaReincorporacion, motivo, planilla, idInscripcion);
        }
        public Entidad ObtenerSolicitudP(String fechaRetiro, String fechaReincorporacion, String motivo, int id, int idInscripcion)
        {
            return new SolicitudP(fechaRetiro, fechaReincorporacion, motivo, id, idInscripcion);
        }
        public Entidad ObtenerSolicitudP(int id, String fechaRetiro, String fechaReincorporacion, String motivo, int idInscripcion)
        {
            return new SolicitudP(id, fechaRetiro, fechaReincorporacion, motivo, idInscripcion);
        }
        public Entidad ObtenerSolicitudPlanilla()
        {
            return new SolicitudPlanilla();
        }
        public Entidad ObtenerSolicitudPlanilla(DateTime fechaCreacion, DateTime fechaRetiro, DateTime fechaReincorporacion,
            string motivo, Planilla planilla, int idInscripcion, int idPersona)
        {
            return new SolicitudPlanilla(fechaCreacion, fechaRetiro, fechaReincorporacion,
             motivo, planilla, idInscripcion, idPersona);
        }
        public Entidad ObtenerSolicitudPlanilla(int id, DateTime fechaCreacion, DateTime fechaRetiro, DateTime fechaReincorporacion,
            string motivo, Planilla planilla, int idInscripcion, int idPersona)
        {
            return new SolicitudPlanilla(id, fechaCreacion, fechaRetiro, fechaReincorporacion,
             motivo, planilla, idInscripcion, idPersona);
        }
        public Entidad ObtenerSolicitudPlanilla(DateTime fechaCreacion, Planilla planilla, int idInscripcion, int idPersona)
        {
            return new SolicitudPlanilla(fechaCreacion, planilla, idInscripcion, idPersona);
        }
        public Entidad ObtenerSolicitudPlanilla(int id, DateTime fechaCreacion, Planilla planilla, int idInscripcion, int idPersona)
        {
            return new SolicitudPlanilla(id, fechaCreacion, planilla, idInscripcion, idPersona);
        }
        public Entidad ObtenerSolicitudPlanilla(DateTime fechaRetiro, DateTime fechaReincorporacion, string motivo, Planilla planilla)
        {
            return new SolicitudPlanilla(fechaRetiro, fechaReincorporacion, motivo, planilla);
        }

        public Entidad obtenerDiseño()
        {
            return new Diseño();
        }

        public Entidad obtenerDiseño(int id, string contenido)
        {
            return new Diseño(id,contenido);
        }

        public Entidad obtenerDiseño(string contenido)
        {
            return new Diseño(contenido);
        }
        // Entidades de otros modulos que necesitamos
        public Entidad ObtenerPersona()
        {
            return new Persona();
        }
        public Entidad ObtenerDojo()
        {
            return new Dojo();
        }
        public Entidad ObtenerMatricula()
        {
            return new Matricula();
        }
        //Hasta aca
        #endregion

        #region Modulo 15
        #endregion

        #region Modulo 16

      /*  public Entidad ObtenerCarrito()
        {
            return new Carrito();
        }
        public Entidad ObtenerMatricula()
        {
            return new Matricula();
        }
        public Entidad ObtenerEvento()
        {
            return new Evento();
        }
        public Entidad ObtenerCompra()
        {
            return new Compra();
        }

        public static Entidad ObtenerPersona()
        {
            return new Persona();
        }

        public Entidad ObtenerImplemento()
        {
            return new Implemento();
        }
        */

        #endregion
    }
}
