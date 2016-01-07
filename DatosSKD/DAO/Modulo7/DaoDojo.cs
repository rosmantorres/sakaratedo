using DatosSKD.InterfazDAO.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using ExcepcionesSKD;
using System.Data;
using ExcepcionesSKD.Modulo7;
using System.Data.SqlClient;
using DatosSKD.Fabrica;

namespace DatosSKD.DAO.Modulo7
{
    public class DaoDojo : DAOGeneral, IDaoDojo
    {
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para consultar el detalle de un dojo
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada de un dojo</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
           RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            FabricaDAOSqlServer fabricaSql = new FabricaDAOSqlServer();
            DaoUbicacion baseDeDatosUbicacion = fabricaSql.ObtenerDaoUbicacionM7();
            Dojo idDojo = (Dojo)parametro;
            Dojo dojo;

            try
            {
                if (idDojo.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    dojo = new Dojo();// se debe sustituir por fabrica

                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdDojo, SqlDbType.Int, idDojo.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultaDojoXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        dojo.Id_dojo = int.Parse(row[RecursosDAOModulo7.AliasDojoId].ToString());
                        dojo.Nombre_dojo = row[RecursosDAOModulo7.AliasDojoNombre].ToString();
                        dojo.Telefono_dojo = int.Parse(row[RecursosDAOModulo7.AliasDojoTelefono].ToString());
                        dojo.Email_dojo = row[RecursosDAOModulo7.AliasDojoEmail].ToString();

                        Ubicacion idUbicacion = new Ubicacion();//se debe sustituir por fabrica
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasDojoUbicacion].ToString());
                        dojo.Ubicacion = (Ubicacion)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

                        dojo.Organizacion_dojo = int.Parse(row[RecursosDAOModulo7.AliasDojoOrganizacionId].ToString());
                    }
                }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionSKD("No se pudo completar la operacion", ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return dojo;
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
    }
}
