using DatosSKD.InterfazDAO.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using System.Data;
using System.Data.SqlClient;
using DominioSKD.Fabrica;

namespace DatosSKD.DAO.Modulo7
{
    public class DaoCinta : DAOGeneral, IDaoCinta
    {
        #region IDao

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para consultar el detalle de una cinta 
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion de la cinta</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();

            FabricaEntidades fabrica = new FabricaEntidades();
            Cinta cinta = (Cinta)fabrica.ObtenerCinta();          
            Cinta idCinta = (Cinta)parametro;

            try
            {
                if (idCinta.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    cinta = new Cinta();

                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdCinta, SqlDbType.Int, idCinta.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
                                    RecursosDAOModulo7.ConsultarCintaXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        cinta.Id_cinta = int.Parse(row[RecursosDAOModulo7.AliasIdCinta].ToString());
                        cinta.Color_nombre = row[RecursosDAOModulo7.AliasCintaNombre].ToString();
                        cinta.Rango = row[RecursosDAOModulo7.AliasCintaRango].ToString();
                        cinta.Clasificacion = row[RecursosDAOModulo7.AliasCintaClasificacion].ToString();
                        cinta.Significado = row[RecursosDAOModulo7.AliasCintaSignificado].ToString();
                        cinta.Orden = int.Parse(row[RecursosDAOModulo7.AliasCintaOrden].ToString());
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
            return cinta;
        }

        public DateTime FechaCinta(Entidad persona, Entidad cinta)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para consultar las cintas obtenidas por un atleta
        /// </summary>
        /// <param name="persona">Objeto tipo Entidad que posee el id de la persona a consultar</param>
        /// <returns>Retorna lista de de las cintas obtenidas por un atleta</returns>
        public List<Entidad> ListarCintasObtenidas(Entidad persona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();

            //List<Cinta> listaDeCintas = new List<Cinta>();
            List<Entidad> listaDeCintas = new List<Entidad>();
            Persona idPersona = (Persona)persona;

            try
            {
                if (idPersona > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarCintas, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        Cinta cinta = new Cinta();
                        cinta.Id_cinta = int.Parse(row[RecursosDAOModulo7.AliasIdCinta].ToString());
                        cinta.Color_nombre = row[RecursosDAOModulo7.AliasCintaNombre].ToString();
                        cinta.Rango = row[RecursosDAOModulo7.AliasCintaRango].ToString();
                        cinta.Clasificacion = row[RecursosDAOModulo7.AliasCintaClasificacion].ToString();
                        cinta.Significado = row[RecursosDAOModulo7.AliasCintaSignificado].ToString();
                        cinta.Orden = int.Parse(row[RecursosDAOModulo7.AliasCintaOrden].ToString());
                        listaDeCintas.Add(cinta);
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

            return listaDeCintas;
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public Entidad UltimaCinta(Entidad persona)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
