using DatosSKD.Modulo7;
using DominioSKD;

namespace LogicaNegociosSKD.Modulo7
{
    /// <summary>
    /// Clase para obtener informacion acerca del atleta
    /// </summary>
    public class LogicaOrganizacionYDojo
    {
        #region Metodos
        public LogicaOrganizacionYDojo()
        {

        }
        /// <summary>
        /// Metodo que llama a consulta Organizacion 
        /// </summary>
        /// <param name="idOrg"></param>
        /// <returns></returns>
        public Organizacion obtenerDetalleOrganizacion(int idOrg)
        {
            try
            {
                BDOrganizacion baseDeDatosOrganizacion = new BDOrganizacion();
                return baseDeDatosOrganizacion.DetallarOrganizacion(idOrg);
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
        /// Metodo que llama a consulta Dojo
       /// </summary>
       /// <param name="idDojo"></param>
       /// <returns></returns>
        public Dojo obtenerDetalleDojo(int idDojo)
        {
            try
            {
                BDDojo baseDeDatosDojo = new BDDojo();
                return baseDeDatosDojo.DetallarDojo(idDojo);
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
        /// Metodo que llama a consulta Persona
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public Persona obtenerDetallePersona(int idPersona)
        {
            try
            {
                BDPersona baseDeDatosPersona = new BDPersona();
                return baseDeDatosPersona.DetallarPersona(idPersona);
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
