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
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo7;

namespace DatosSKD.DAO.Modulo7
{
    /// <summary>
    /// DAO para consultar dojo de atleta
    /// </summary>
    public class DaoDojo : DAOGeneral, IDaoDojo
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
        /// Método para consultar el detalle de un dojo
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada de un dojo</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            DaoUbicacion baseDeDatosUbicacion = FabricaDAOSqlServer.ObtenerDaoUbicacionM7();
            DojoM7 idDojo = (DojoM7)parametro;
            DojoM7 dojo;

            try
            {
                if (idDojo.Id > 0)
                {
                    parametros = new List<Parametro>();
                    dojo = (DojoM7)FabricaEntidades.ObtenerDojoM7();

                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdDojo, SqlDbType.Int, idDojo.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultaDojoXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        dojo.Id = int.Parse(row[RecursosDAOModulo7.AliasDojoId].ToString());
                        dojo.Nombre_dojo = row[RecursosDAOModulo7.AliasDojoNombre].ToString();
                        dojo.Telefono_dojo = int.Parse(row[RecursosDAOModulo7.AliasDojoTelefono].ToString());
                        dojo.Email_dojo = row[RecursosDAOModulo7.AliasDojoEmail].ToString();

                        UbicacionM7 idUbicacion = (UbicacionM7)FabricaEntidades.ObtenerUbicacionM7();
                        idUbicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasDojoUbicacion].ToString());
                        dojo.Ubicacion = (UbicacionM7)baseDeDatosUbicacion.ConsultarXId(idUbicacion);

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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,RecursoGeneralBD.Mensaje, ex);
            }
            catch (NumeroEnteroInvalidoException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                throw new NumeroEnteroInvalidoException(RecursosDAOModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosDAOModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionSKD(RecursosDAOModulo7.MensajeExceptionSKD, ex);
            }

            return dojo;
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
