using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo16;

namespace LogicaNegociosSKD.Modulo16
{
    public class Logicainventario
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Logicainventario
        /// </summary>
        private BDInventario inventarioBD;
        private List<DominioSKD.Implemento> laListaDeInventario;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que devuelve una lista de tipo implemento
        /// </summary>
        public Logicainventario()
        {
            laListaDeInventario = obtenerListaDeInventario();
        }
        #endregion

        #region Propiedades

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que obtiene todos productos o implementos que se encuentran en el inventario
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Retorna una lista de implementos</returns>
        public List<DominioSKD.Implemento> obtenerListaDeInventario()
        {
            try
            {
                return BDInventario.ListarInventario();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Metodo que devueve el detalle completo de un implemento en especifico recibiendo como parametro su id.
        /// </summary>
        /// <param name="Id_implemento">Indica el objeto a detallar</param>
        /// <returns>Retorna un implemento en especifico</returns>
        public DominioSKD.Implemento detalleImplementoXId(int Id_implemento)
        {
            try
            {
                return BDInventario.DetallarImplemento(Id_implemento);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo que obtiene todas las matriculas asociadas a una persona
        /// </summary>
        /// <param name="idUsuario">El usuario el cual se desea ver las matriculas en su carrito</param>
        /// <returns>Todas las matriculas que tiene actualmente el cliente en su carrito</returns>
        public List<DominioSKD.Matricula> mostrarMensualidadesmorosas()
        {

            try
            {
                return BDMatricula.mostrarMensualidadesmorosas();
            }



            catch (NullReferenceException ex)
            {

                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionNullReference,
                    RecursosLogicaModulo16.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionSKDConexionBD ex)
            {

                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

            }

            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosBDModulo16.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo16.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosBDModulo16.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo16.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionGeneral,
                   RecursosLogicaModulo16.Mensaje_ExcepcionGeneral, ex);

            }



        }
 




        #endregion

    }
}

