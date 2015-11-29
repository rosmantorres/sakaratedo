using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD;
using System.Data.SqlClient;
using DominioSKD;
using ExcepcionesSKD;
using System.Data;

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
        /// Metodo que obtiene la o las ultimas matriculas pagadas por una persona en Base de Datos
        /// </summary>
        /// /// <param name="idUsuario">El id del usuario el cual se desea saber las matriculas que pago</param>
        /// <returns>Una lista con los id de las matriculas</returns>
        public List<Matricula> MatriculasPagadas(int idUsuario)
        {
            //Variable que retorna la lista
            List<Matricula> listaMatriculas = new List<Matricula>();
            try
            {
                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO,System.Data.SqlDbType.Int,
                    idUsuario.ToString(),false);
                parametros.Add(parametro);

                //Creo la conexion y ejecuto el query
                BDConexion conexion = new BDConexion();
                DataTable dt = conexion.EjecutarStoredProcedureTuplas
                    (RecursosBDModulo16.PROCEDIMIENTO_MATRICULAS_PAGADAS, parametros);

                //asigno el ID a un objeto matricula
                foreach(DataRow row in dt.Rows)
                {
                    //Creo la matricula y le asigno el ID
                    Matricula matricula = new Matricula();
                    matricula.Mat_identificador = row[RecursosBDModulo16.PARAMETRO_IDMATRICULA].ToString();

                    //Agrego a la lista
                    listaMatriculas.Add(matricula);
                }

                //Retorno la lista
                return listaMatriculas;
            }
            catch (SqlException e)
            {
                throw new ExceptionSKDConexionBD("", "", e);
            }
            catch (ParametroInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExceptionSKDConexionBD("blabla", "blabla", e);
            }
           
        }
        #endregion
    }
}
