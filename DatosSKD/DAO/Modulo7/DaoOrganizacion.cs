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
using DominioSKD.Entidades.Modulo7;
using DominioSKD.Fabrica;

namespace DatosSKD.DAO.Modulo7
{
    /// <summary>
    /// DAO para consultar organizacion de atleta
    /// </summary>
    public class DaoOrganizacion : DAOGeneral, IDaoOrganizacion
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
        /// Método para consultar el detalle de una organizacion
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada de una organizacion</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            OrganizacionM7 idOrganizacion = (OrganizacionM7)parametro;
            OrganizacionM7 organizacion;

            try
            {
                if (idOrganizacion.Id > 0)
                {
                    parametros = new List<Parametro>();
                    organizacion = (OrganizacionM7)FabricaEntidades.ObtenerOrganizacionM7();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdOrganizacion, SqlDbType.Int, idOrganizacion.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
                               RecursosDAOModulo7.ConsultaOrganizacionXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        organizacion.Id = int.Parse(row[RecursosDAOModulo7.AliasOrganizacionId].ToString());
                        organizacion.Nombre = row[RecursosDAOModulo7.AliasOrganizacionNombre].ToString();
                        organizacion.Direccion = row[RecursosDAOModulo7.AliasOrganizacionDireccion].ToString();
                        organizacion.Telefono = int.Parse(row[RecursosDAOModulo7.AliasOrganizacionTelefono].ToString());
                        organizacion.Email = row[RecursosDAOModulo7.AliasOrganizacionEmail].ToString();
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
                throw new ExceptionSKD("No se pudo completar la operacion", ex);
            }

            return organizacion;
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
