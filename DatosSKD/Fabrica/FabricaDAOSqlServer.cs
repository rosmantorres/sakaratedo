using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.DAO.Modulo16;
using DatosSKD.DAO.Modulo14;
using DatosSKD.DAO.Modulo12;
using DatosSKD.InterfazDAO.Modulo12;
//using DatosSKD.DAO.Modulo16;
using DatosSKD.DAO.Modulo3;
using DatosSKD.DAO.Modulo5;


namespace DatosSKD.Fabrica
{
    public class FabricaDAOSqlServer
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        #endregion

        #region Modulo 3
		public DaoOrganizacion ObtenerDaoOrganizacion()
        {
            return new DaoOrganizacion();
        }
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
		public DaoCinta ObtenerDaoCinta()
        {
            return new DaoCinta();
        } 
        #endregion

        #region Modulo 6
        #endregion

        #region Modulo 7
        /*
        /// <summary>
        /// Método que instancia el DAO de cinta de M7
        /// </summary>
        /// <returns>Retorna DaoCinta</returns>
        public DAO.Modulo7.DaoCinta ObtenerDaoCintaM7()
        {
            return new DAO.Modulo7.DaoCinta();
        }

        /// <summary>
        /// Método que instancia el DAO de competencia de M7
        /// </summary>
        /// <returns>Retorna DaoCompetencia</returns>
        public DAO.Modulo7.DaoCompetencia ObtenerDaoCompetenciaM7()
        {
            return new DAO.Modulo7.DaoCompetencia();
        }

        /// <summary>
        /// Método que instancia el DAO de dojo de M7
        /// </summary>
        /// <returns>Retorna DaoDojo</returns>
        public DAO.Modulo7.DaoDojo ObtenerDaoDojoM7()
        {
            return new DAO.Modulo7.DaoDojo();
        }

        /// <summary>
        /// Método que instancia el DAO de evento de M7
        /// </summary>
        /// <returns>Retorna DaoEvento</returns>
        public DAO.Modulo7.DaoEvento ObtenerDaoEventoM7()
        {
            return new DAO.Modulo7.DaoEvento();
        }

        /// <summary>
        /// Método que instancia el DAO de horario de M7
        /// </summary>
        /// <returns>Retorna DaoHorario</returns>
        public DAO.Modulo7.DaoHorario ObtenerDaoHorarioM7()
        {
            return new DAO.Modulo7.DaoHorario();
        }

        /// <summary>
        /// Método que instancia el DAO de matrícula de M7
        /// </summary>
        /// <returns>Retorna DaoMatricula</returns>
        public DAO.Modulo7.DaoMatricula ObtenerDaoMatriculaM7()
        {
            return new DAO.Modulo7.DaoMatricula();
        }

        /// <summary>
        /// Método que instancia el DAO de organización de M7
        /// </summary>
        /// <returns>Retorna DaoOrganizacion</returns>
        public DAO.Modulo7.DaoOrganizacion ObtenerDaoOrganizacionM7()
        {
            return new DAO.Modulo7.DaoOrganizacion();
        }

        /// <summary>
        /// Método que instancia el DAO de persona de M7
        /// </summary>
        /// <returns>Retorna DaoPersona</returns>
        public DAO.Modulo7.DaoPersona ObtenerDaoPersonaM7()
        {
            return new DAO.Modulo7.DaoPersona();
        }

        /// <summary>
        /// Método que instancia el DAO de TipoEvento de M7
        /// </summary>
        /// <returns>Retorna DaoTipoEvento</returns>
        public DAO.Modulo7.DaoTipoEvento ObtenerDaoTipoEventoM7()
        {
            return new DAO.Modulo7.DaoTipoEvento();
        }

        /// <summary>
        /// Método que instancia el DAO de Ubicación de M7
        /// </summary>
        /// <returns>Retorna DaoUbicacion</returns>
        public DAO.Modulo7.DaoUbicacion ObtenerDaoUbicacionM7()
        {
            return new DAO.Modulo7.DaoUbicacion();
        }
        */
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

        public IDaoCompetencia ObtenerDAOCompetencia()
        {
            return new DaoCompetencia();
        }

        #endregion

        #region Modulo 13
        #endregion

        #region Modulo 14
        public DAOGeneral ObtenerDAOPlanilla()
        {
            return new DaoPlanilla();
        }

        public DAOGeneral ObtenerDAOSolicitud()
        {
            return new DaoSolicitud();
        }

        public DAOGeneral ObtenerDAODiseno()
        {
            return new DaoDiseno();
        }

        public DAOGeneral ObtenerDAODatos()
        {
            return new DaoDatos();
        }
        #endregion

        #region Modulo 15
        #endregion

        #region Modulo 16

        /// <summary>
        /// Metodo de la fabrica que instancia el DAO del evento
        /// </summary>
        /// <returns>el DaoEvento</returns>
       public static InterfazDAO.Modulo16.IdaoEvento ObtenerDaoEventos()
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
        public static InterfazDAO.Modulo16.IdaoImplemento ObtenerDaoProductos()
        {
            return new DatosSKD.DAO.Modulo16.DaoImplemento();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el DAO da la compra
        /// </summary>
        /// <returns>el DaoFactura</returns>
        public static InterfazDAO.Modulo16.IdaoCompra ObtenerDaoFacturas()
        {
            return new DatosSKD.DAO.Modulo16.DaoCompra();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el DAO da la compra
        /// </summary>
        /// <returns>el DaoFactura</returns>
        public static InterfazDAO.Modulo16.IdaoMensualidad ObtenerDaoMensualidades()
        {
            return new DatosSKD.DAO.Modulo16.DaoMensualidad();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el DAO del detalleEvento
        /// </summary>
        /// <returns>el DaoEvento</returns>
        public static InterfazDAO.Modulo16.IdaoEvento ObtenerDaoDetalleEvento()
        {
            return new DatosSKD.DAO.Modulo16.DaoEvento();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el DAO del detalleMatricula
        /// </summary>
        /// <returns>el DaoCompra</returns>
        public static InterfazDAO.Modulo16.IdaoMensualidad ObtenerDaoDetalleMatricula()
        {
            return new DatosSKD.DAO.Modulo16.DaoMensualidad();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el DAO del detalleProducto
        /// </summary>
        /// <returns>el DaoImplemento</returns>
        public static InterfazDAO.Modulo16.IdaoImplemento ObtenerDaoDetalleProducto()
        {
            return new DatosSKD.DAO.Modulo16.DaoImplemento();
        }
        #endregion


    }
}
