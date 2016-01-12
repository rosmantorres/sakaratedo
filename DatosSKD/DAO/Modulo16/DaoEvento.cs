using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DatosSKD.DAO;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo1;
using DominioSKD.Entidades.Modulo9;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;

namespace DatosSKD.DAO.Modulo16
{
    public class DaoEvento : DAOGeneral, IdaoEvento
    {

        #region Metodos para ConsultarTodos (Listar Eventos)
        /// <summary>
        /// Metodo que retorma una lista de eventos existentes
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lo que tiene actualmente el inventario de eventos</returns>
        public List<Entidad> ConsultarTodos()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Evento elEvento;

            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_EVENTOS,
                    parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                foreach (DataRow row in resultado.Rows)
                {
                    elEvento = (Evento)laFabrica.ObtenerEvento();
                    elEvento.Id_evento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString());
                    elEvento.Nombre = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                    elEvento.Descripcion = row[RecursosBDModulo16.PARAMETRO_DESCRIPCION].ToString();
                    elEvento.Costo = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                    laLista.Add(elEvento);

                }

                //Limpio la conexion
                LimpiarSQLConnection();
                return laLista;

            }
            #region catches
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        #endregion

        #region Metodo para ConsultarXId (Detallar Evento)
        /// <summary>
        /// Metodo que retorma una entidad de tipo evento
        /// </summary>
        /// <param name=Entidad>Se pasa el id del evento a buscar</param>
        /// <returns>Todas los atributos de la clase evento para el detallar</returns>
        public Entidad ConsultarXId(Entidad evento)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Evento> laLista = new List<Evento>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Evento elEvento = new Evento();
            Evento lista = new Evento();

            Evento eve = (Evento)evento;


            try
            {
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int, eve.Id.ToString(), false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.DETALLAR_EVENTO, parametros);

                //Limpio la conexion
                LimpiarSQLConnection();

                foreach (DataRow row in resultado.Rows)
                {
                    elEvento = (Evento)laFabrica.ObtenerEvento();
                    elEvento.Id_evento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString());
                    elEvento.Nombre = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                    elEvento.Costo = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                    elEvento.Descripcion = row[RecursosBDModulo16.PARAMETRO_DESCRIPCION].ToString();

                }

                //Limpio la conexion
                LimpiarSQLConnection();

                return elEvento;

            }
            #region catches
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        #endregion 

        #region Metodo para DetallarEvento

        /// <summary>
        /// Metodo que devueve un tipoevento dado su id
        /// </summary>
        /// <param name="Id_evento">Indica el objeto a detallar</param>
        /// <returns>Retorna un evento en especifico con todos sus detalles</returns>
        public Entidad DetallarEvento(int Id_evento)
        {
            return new Persona();
        }

        #endregion

        #region Metodo para ListarEvento

        /// <summary>
        /// Metodo para el listar de evento sin parametro
        /// </summary>
        /// <returns>Retorna una lista de eventos</returns>
        public List<Entidad> ListarEvento()
        {
            return new List<Entidad>();
        }

        #endregion

    }
}
