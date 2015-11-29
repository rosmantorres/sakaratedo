using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Modulo16;

namespace LogicaNegociosSKD.Modulo16
{
    /// <summary>
    /// Clase que gestiona toda la logica de las compras hechas por el usuario
    /// </summary>
    public class Logicacompra
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Logicainventario
        /// </summary>
        private BDCompra compraBD;
        private int idPersona;
        private List<DominioSKD.Compra> laListaDeCompra;

        #endregion


        #region Constructores
        /// <summary>
        /// Constructor que devuelve una lista de tipo compra
        /// </summary>
        public Logicacompra()
        {
            laListaDeCompra = obtenerListaDeCompra(idPersona);
        }
        #endregion


        #region Metodos

        /// <summary>
        /// Metodo que obtiene todas las facturas del usuario conectado
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Retorna una lista de facturas</returns>
        public List<DominioSKD.Compra> obtenerListaDeCompra(int idPersona)
        {
            try
            {
                return BDCompra.ListarCompra(idPersona);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
     
        #endregion


    }
}
