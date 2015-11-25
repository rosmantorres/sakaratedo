using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo16;

namespace LogicaNegociosSKD.Modulo16
{
    public class Logicaevento
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Logicaevento
        /// </summary>
        private BDEvento eventoBD;
        private List<DominioSKD.Evento> laListaDeEvento;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que devuelve una lista de tipo evento
        /// </summary>
        public Logicaevento()
        {
            laListaDeEvento = obtenerListaDeEvento();
        }
        #endregion

        #region Propiedades

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que obtiene todos los objetos que estan en el inventario de eventos
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lo que tiene actualmente el inventario de los eventos (filtrado por usuario logeado)</returns>
        public List<DominioSKD.Evento> obtenerListaDeEvento()
        {
            try
            {
                return BDEvento.ListarEvento();
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public DominioSKD.Evento detalleEventoXId(int elIdEvento)
        {
            try
            {
                return BDEvento.DetallarEvento(elIdEvento);
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
