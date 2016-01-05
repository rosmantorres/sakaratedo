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
using DominioSKD.Entidades.Modulo15;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;

namespace DatosSKD.DAO.Modulo16
{
    public class DaoCompra : DAOGeneral, IdaoCompra
    {
        #region Metodos
        /// <summary>
        /// Metodo que retorma una lista de eventos existentes
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lo que tiene actualmente el inventario de eventos</returns>
        public Entidad ConsultarXId(Entidad entidad)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Compra> laLista = new List<Compra>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Compra laCompra;
            ListaCompra lista = new ListaCompra();

            PersonaM1 p = (PersonaM1)entidad;

            try
            {
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_USUARIO, SqlDbType.Int, p._Id.ToString(), false);
                parametros.Add(parametro);
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_COMPRAS,
                    parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    laCompra = (Compra)laFabrica.ObtenerFactura();
                    laCompra.Com_id = int.Parse(row[RecursosBDModulo16.PARAMETRO_ID_COMPRA].ToString());
                    laCompra.Com_tipo_pago = row[RecursosBDModulo16.PARAMETRO_TIPO_PAGO].ToString();
                    laCompra.Com_fecha_compra = DateTime.Parse(row[RecursosBDModulo16.PARAMETRO_FECHA].ToString());
                    laCompra.Com_estado = row[RecursosBDModulo16.PARAMETRO_ESTADO_COMPRA].ToString();
                    laLista.Add(laCompra);

                }

                lista.ListaCompras = laLista;

                return lista;

            }
            #region catches
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion


        }

        /// <summary>
        /// Metodo que devueve un tipoimplemento dado su id
        /// </summary>
        /// <param name="Id_evento">Indica el objeto a detallar</param>
        /// <returns>Retorna un implemento en especifico con todos sus detalles</returns>
        public List<Entidad> ListarFactura()
        {
            return new List<Entidad>();
        }

        public List<Entidad> ConsultarTodos()
        {
            return new List<Entidad>();
        }
        /// <summary>
        /// Metodo que devueve un tipoimplemento dado su id
        /// </summary>
        /// <param name="Id_evento">Indica el objeto a detallar</param>
        /// <returns>Retorna un implemento en especifico con todos sus detalles</returns>
        public Entidad DetallarFactura(int Id_factura)
        {
            return new Persona();
        }

        #endregion
    }
}
