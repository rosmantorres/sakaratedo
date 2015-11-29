using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DominioSKD;

namespace DatosSKD.Modulo16
{
    /// <summary>
    /// Clase que gestiona todo el proceso de las compras contra la Base de Datos
    /// </summary>
    public class BDCompra
    {
        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase BDCompra
        /// </summary>
        public BDCompra()
        {

        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que retorma una lista de compras por usuario
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lasfacturas que tiene el usuario logueado</returns>
        public static List<Compra> ListarCompra(int IdPersona)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            List<Compra> laListaDeCompra = new List<Compra>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_USUARIO, SqlDbType.Int, IdPersona.ToString(), false);
                parametros.Add(parametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo16.CONSULTAR_COMPRAS, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Compra laCompra = new Compra();

                    laCompra.Com_id = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO].ToString());
                    laCompra.Com_tipo_pago = row[RecursosBDModulo16.PARAMETRO_IMAGEN].ToString();
                    laCompra.Com_fecha_compra = DateTime.Parse(row[RecursosBDModulo16.aliasFechainicio].ToString());
                    laCompra.Com_estado = row[RecursosBDModulo16.PARAMETRO_DESCRIPCION].ToString();

                    laListaDeCompra.Add(laCompra);

                }

                return laListaDeCompra;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion

    }
}
