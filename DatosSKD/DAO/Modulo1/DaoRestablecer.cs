using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DatosSKD.InterfazDAO.Modulo1;

namespace DatosSKD.DAO.Modulo1
{
    public class DaoRestablecer: DAOGeneral, IDaoRestablecer
    {
        #region IDAO
        public Boolean Agregar(Entidad e)
        {
            return false;
        }
        public Boolean Modificar(Entidad e)
        {
            return false;
        }
        public Entidad ConsultarXId(Entidad e)
        {
            return null;
        }
        public List<Entidad> ConsultarTodos()
        {
            return null;
        }
        #endregion

        #region DaoRestablecer
        /// <summary>
        /// Se hace la conexion a la base de datos para cambiar la contraseña del usuario
        /// </summary>
        /// <param name="usuarioId"> Id del usuario que solicito el cambio de contraseña</param>
        /// <param name="contraseña">nueva contraseña del usuario</param>
        /// <returns></returns>
        public bool RestablecerContrasena(string usuarioId, string contraseña)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Cuenta laCuenta = new Cuenta();
                elParametro = new Parametro(RecursosBDModulo1.AliasIdUsuario, SqlDbType.Int, usuarioId, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo1.AliasContrasena, SqlDbType.VarChar, contraseña, false);
                parametros.Add(elParametro);

                laConexion.EjecutarStoredProcedureTuplas(
                      RecursosBDModulo1.CambiarContraseña, parametros);
                return true;
            }
            catch (SqlException e)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, e);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, e);
            }

        }

        #endregion
    }
}
