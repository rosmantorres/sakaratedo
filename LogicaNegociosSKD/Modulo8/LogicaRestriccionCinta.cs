using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo8;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Modulo8
{
    public class LogicaRestriccionCinta
    {

        #region Atributos
        private List<DominioSKD.RestriccionCinta> ListaDeRestriccionesCinta;      

        #endregion

        #region Get y Set
        public List<DominioSKD.RestriccionCinta> listaDeRestriccionesCinta
        {
            get { return ListaDeRestriccionesCinta; }
            set { ListaDeRestriccionesCinta = value; }
        }
        #endregion

        public LogicaRestriccionCinta()
        {
        }

        public List<DominioSKD.RestriccionCinta> obtenerListaDeRestriccionCinta()
        {
             try
            {
                
                return BDRestriccionCinta.ConsultarRestriccionCintaTodas();
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }

        }
    }
}
