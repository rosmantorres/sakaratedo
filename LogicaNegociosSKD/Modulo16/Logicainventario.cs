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
        private List<DominioSKD.Inventario> laListaDeInventario;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase Logicainventario
        /// </summary>
        public Logicainventario()
        {

        }
        #endregion

        #region Propiedades
        public List<DominioSKD.Inventario> LaListaDeInventario
        {
            get { return laListaDeInventario; }
            set { laListaDeInventario = value; }
        }
        
        #endregion

        #region Metodos
        /*
        /// <summary>
        /// Metodo que obtiene todos productos que se encuentran en el inventario
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Retorna una lista de productos</returns>
        public Producto consultarInventario()
        {
            return List<Inventario>;
        }
        */

        /*
        /// <summary>
        /// Metodo que obtiene todos productos que se encuentran en el inventario
        /// </summary>
        /// <param name="objetoDetallar">Indica el objeto a detallar</param>
        /// <param name="idUsuario">Indica el identificador del Usuario que esta </param>
        /// <returns>Retorna un producto en especifico</returns>
        public Producto detallarInventario(int objetoDetallar, int idUsuario)
        {
            return null;
        }
        */

      /*  public List<DominioSKD.Inventario> obtenerListaDeInventario()
        {
            try
            {
                return BDInventario.ListarInventario();
            }
            catch (Exception e)
            {
                throw e;
            }

        }*/
        #endregion

    }
}
