using DatosSKD.InterfazDAO.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using ExcepcionesSKD;
using System.Data.SqlClient;
using ExcepcionesSKD.Modulo7;
using System.Data;
using DatosSKD.Fabrica;

namespace DatosSKD.DAO.Modulo7
{
    /// <summary>
    /// DAO para consultar competencia de atleta
    /// </summary>
    public class DaoCompetencia : DAOGeneral, IDaoCompetencia
    {
        /// <summary>
        /// No tiene implementacion
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// No tiene implementacion
        /// </summary>
        /// <returns></returns>
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para consultar el detalle de una competencia
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada de una competencia</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            FabricaDAOSqlServer fabricaSql = new FabricaDAOSqlServer();
            DaoUbicacion baseDeDatosUbicacion = fabricaSql.ObtenerDaoUbicacionM7();
            Competencia idCompetencia = (Competencia)parametro;
            Competencia competencia;
            try
            {
                if (idCompetencia.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    competencia = new Competencia();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdCompetencia, SqlDbType.Int, idCompetencia.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarCompetenciaXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        competencia.Id = int.Parse(row[RecursosDAOModulo7.AliasIdCompetencia].ToString());
                        competencia.Nombre = row[RecursosDAOModulo7.AliasCompetenciaNombre].ToString();
                        competencia.TipoCompetencia = row[RecursosDAOModulo7.AliasCompetenciaTipo].ToString();
                        competencia.FechaInicio = DateTime.Parse(row[RecursosDAOModulo7.AliasCompetenciaFechaInicio].ToString());
                        competencia.FechaFin = DateTime.Parse(row[RecursosDAOModulo7.AliasCompetenciaFechaFin].ToString());
                        competencia.Costo = float.Parse(row[RecursosDAOModulo7.AliasCompetenciaCosto].ToString());

                        Ubicacion idUbicacion = new Ubicacion();//sustituir por fabrica
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasCompetenciaUbicacionId].ToString());
                        competencia.Ubicacion = (Ubicacion)baseDeDatosUbicacion.ConsultarXId(idUbicacion);
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

            return competencia;
        }

        /// <summary>
        /// No tiene implementacion
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
    }
}
