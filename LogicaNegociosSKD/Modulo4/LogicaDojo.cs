using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo4;

namespace LogicaNegociosSKD.Modulo4
{
    public class LogicaDojo
    {
        #region Atributos

        private List<DominioSKD.Dojo> laListaDeDojos;

        #endregion

        #region Get y Set
        public List<DominioSKD.Dojo> LaListaDeDojos
        {
            get { return laListaDeDojos; }
            set { laListaDeDojos = value; }
        }
        #endregion

        #region Metodos Logica
        public LogicaDojo()
        {
        }

        public List<DominioSKD.Dojo> obtenerListaDeDojos()
        {
            try 
            {
                return BDDojo.ListarDojos();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo4.FormatoIncorrectoException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }
        
        }

        /*public List<DominioSKD.Dojo> M4obtenerListaDeOrganizaciones()
        {
            try
            {
                return BDDojo.M4ListarOrganizaciones();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo4.FormatoIncorrectoException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }
        }

        */
        public DominioSKD.Dojo detalleDojoXId(int elIdDojo)
        {
            try
            {
                return BDDojo.DetallarDojo(elIdDojo);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo4.DojoInexistenteException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo4.FormatoIncorrectoException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }
        }
        public void eliminarDojo(int idDojo)
        {
            try
            {
                BDDojo.eliminarDojo(idDojo);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo4.FormatoIncorrectoException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                throw ex;
            }
        }
     
        #endregion
    }
}
