using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo1;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DatosSKD.InterfazDAO.Modulo1;
using DominioSKD.Fabrica;
using DominioSKD;

namespace DatosSKD.DAO.Modulo1
{
    public class DaoRestablecer: DAOGeneral, IDaoRestablecer
    {
        FabricaEntidades laFabrica = new FabricaEntidades();
        #region IDAO
        public Boolean Agregar(Entidad e)
        {
            throw new NotImplementedException();
        }
        public Boolean Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }
        public Entidad ConsultarXId(Entidad e)
        {
            throw new NotImplementedException();
        }
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
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
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                parametros = new List<Parametro>();
                Cuenta laCuenta = (Cuenta) laFabrica.ObtenerCuenta_M1();
                elParametro = new Parametro(RecursosBDM1.AliasIdUsuario, SqlDbType.Int, usuarioId, false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDM1.AliasContrasena, SqlDbType.VarChar, contraseña, false);
                parametros.Add(elParametro);

                this.EjecutarStoredProcedureTuplas(
                      RecursosBDM1.CambiarContraseña, parametros);
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
