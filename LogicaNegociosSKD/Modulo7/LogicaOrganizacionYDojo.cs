using DatosSKD.Modulo7;
using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegociosSKD.Modulo7
{
    /// <summary>
    /// Clase para obtener informacion acerca del atleta
    /// </summary>
    public class LogicaOrganizacionYDojo
    {
        #region Atributos
        private List<DominioSKD.Organizacion> laListaDeOrganizacion;
        private List<DominioSKD.Dojo> laListaDeDojo;
        private List<DominioSKD.Persona> laListaDePersona;
        private Dojo elDojo = new Dojo();
        #endregion

        #region Gets y Sets
        public List<DominioSKD.Organizacion> LaListaDeOrganizacion
        {
            get { return laListaDeOrganizacion; }
            set { laListaDeOrganizacion = value; }
        }

        public List<DominioSKD.Dojo> LaListaDeDojo
        {
            get { return laListaDeDojo; }
            set { laListaDeDojo = value; }
        }

        public List<DominioSKD.Persona> LaListaDePersona
        {
            get { return laListaDePersona; }
            set { laListaDePersona = value; }
        }
        #endregion

        #region Metodos
        public LogicaOrganizacionYDojo()
        {

        }
        /// <summary>
        /// Metodo que llama a consulta Organizacion por id
        /// </summary>
        /// <returns></returns>
        public Organizacion obtenerDetalleOrganizacion()
        {
            try
            {
                BDOrganizacion baseDeDatosOrganizacion = new BDOrganizacion();
                return baseDeDatosOrganizacion.DetallarOrganizacion(Convert.ToInt16(elDojo.Organizacion_dojo));
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }/*
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Metodo que llama a consulta dojo por id
        /// </summary>
        /// <returns></returns>
        public Dojo obtenerDetalleDojo()
        {
            try
            {
                BDDojo baseDeDatosDojo = new BDDojo();
                return baseDeDatosDojo.DetallarDojo(1);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }/*
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Metodo que llama a consulta de persona por id
        /// </summary>
        /// <returns></returns>
        public Persona obtenerDetallePersona()
        {
            try
            {
                BDPersona baseDeDatosPersona = new BDPersona();
                return baseDeDatosPersona.DetallarPersona(1);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }/*
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }

        }
        #endregion

    }
}
