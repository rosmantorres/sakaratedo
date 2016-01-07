using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.DAO.Modulo16;

namespace DatosSKD.Fabrica
{
    public class FabricaDAOSqlServer
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        #endregion

        #region Modulo 6
        #endregion

        #region Modulo 7
        #endregion

        #region Modulo 8
        #endregion

        #region Modulo 9
        #endregion

        #region Modulo 10
        #endregion

        #region Modulo 11
        #endregion

        #region Modulo 12
        #endregion

        #region Modulo 13
        #endregion

        #region Modulo 14
        #endregion

        #region Modulo 15
        #endregion

        #region Modulo 16

        /// <summary>
        /// Metodo de la fabrica que instancia el DAO del evento
        /// </summary>
        /// <returns>el DaoEvento</returns>
       public InterfazDAO.Modulo16.IdaoEvento ObtenerDaoEventos()
        {
            return new DatosSKD.DAO.Modulo16.DaoEvento();
        }
        
        /// <summary>
        /// Metodo de la fabrica que instancia el DAO del carrito
        /// </summary>
        /// <returns>el DaoCarrito</returns>
        public static InterfazDAO.Modulo16.IdaoCarrito ObtenerdaoCarrito()
        {
            return new DatosSKD.DAO.Modulo16.DaoCarrito();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el DAO del evento
        /// </summary>
        /// <returns>el DaoEvento</returns>
        public InterfazDAO.Modulo16.IdaoImplemento ObtenerDaoProductos()
        {
            return new DatosSKD.DAO.Modulo16.DaoImplemento();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el DAO da la compra
        /// </summary>
        /// <returns>el DaoFactura</returns>
        public InterfazDAO.Modulo16.IdaoCompra ObtenerDaoFacturas()
        {
            return new DatosSKD.DAO.Modulo16.DaoCompra();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el DAO da la compra
        /// </summary>
        /// <returns>el DaoFactura</returns>
        public InterfazDAO.Modulo16.IdaoMensualidad ObtenerDaoMensualidades()
        {
            return new DatosSKD.DAO.Modulo16.DaoMensualidad();
        }
        #endregion


    }
}
