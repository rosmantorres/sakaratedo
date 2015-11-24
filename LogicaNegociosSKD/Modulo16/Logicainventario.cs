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

        #endregion

    }
}

