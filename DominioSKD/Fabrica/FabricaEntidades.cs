using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Fabrica
{
    public class FabricaEntidades
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
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
        #endregion

        #region Modulo 15
        #endregion

        #region Modulo 16
        #endregion
    }
}
