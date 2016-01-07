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

namespace DatosSKD.DAO.Modulo7
{
    public class DaoOrganizacion : DAOGeneral, IDaoOrganizacion
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
        /// Método para consultar el detalle de una organizacion
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada de una organizacion</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            Organizacion idOrganizacion = (Organizacion)parametro;
            Organizacion organizacion;

            try
            {
                if (idOrganizacion.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    organizacion = new Organizacion();// se debe sustituir por fabrica
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdOrganizacion, SqlDbType.Int, idOrganizacion.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
                               RecursosDAOModulo7.ConsultaOrganizacionXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        organizacion.Id_organizacion = int.Parse(row[RecursosDAOModulo7.AliasOrganizacionId].ToString());
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
            return organizacion;
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
    }
}
