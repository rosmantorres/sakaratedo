using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo4;

namespace LogicaNegociosSKD.Modulo4
{
    public class LogicaHistorial_Matricula
    {
        #region Atributos

        private List<DominioSKD.Historial_Matricula> laListaHistorial_Matricula;

        #endregion

        #region Get y Set
        public List<DominioSKD.Historial_Matricula> LaListaDeMatriculas
        {
            get { return laListaHistorial_Matricula; }
            set { laListaHistorial_Matricula = value; }
        }
        #endregion

        #region Metodos Logica
        public LogicaHistorial_Matricula()
        {
        }

        public List<DominioSKD.Historial_Matricula> obtenerListaDeMatriculas(int idDojo)
        {
            try 
            {
                return BDHistorial_Matricula.ListarMatriculas(idDojo);
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
