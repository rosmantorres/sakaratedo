using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD;
using DatosSKD.Modulo16;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16.ExcepcionesDeDatos;
using ExcepcionesSKD.Modulo16;

namespace LogicaNegociosSKD.Modulo16
{
    public class Logicamatricula
    {


        #region Atributos
        private int idPersona;
        private List<DominioSKD.Matricula> laListaDeMatriculas;

        #endregion


        #region Get y Set
        public List<DominioSKD.Matricula> LaListaDeMatriculas
        {
            get { return laListaDeMatriculas; }
            set { laListaDeMatriculas = value; }
        }
        #endregion

        /// <summary>
        /// Metodo que obtiene todas las matriculas asociadas a una persona
        /// </summary>
        /// <param name="idUsuario">El usuario el cual se desea ver las matriculas en su carrito</param>
        /// <returns>Todas las matriculas que tiene actualmente el cliente en su carrito</returns>
        public List<DominioSKD.Matricula> mostrarMensualidadesmorosas(int idPersona)
        {

            try
            {
                return BDMatricula.mostrarMensualidadesmorosas(idPersona);
            }



            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo16.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo16.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo16.Codigo_ExcepcionAtributo,
                 RecursosLogicaModulo16.Mensaje_ExcepcionAtributo, ex);

            }



        }





    }
}