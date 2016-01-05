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
    public class DaoMatricula : DAOGeneral, IDaoMatricula
    {
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            Matricula idMatricula = (Matricula)parametro;
            Matricula matricula = (Matricula)fabricaEntidades.ObtenerMatricula();

            try
            {
                if (idMatricula.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();                    
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdMatricula, SqlDbType.Int, idMatricula.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
                                    RecursosDAOModulo7.ConsultarCintaXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                  
                      matricula.Id = int.Parse(row[RecursosDAOModulo7.AliasIdMatricula].ToString());
                      matricula.Identificador = row[RecursosDAOModulo7.AliasIdentificadorMatricula].ToString();
                      matricula.FechaCreacion = DateTime.Parse(row[RecursosDAOModulo7.AliasFechaPagoMatricula].ToString());
                      matricula.UltimaFechaPago = DateTime.Parse(row[RecursosDAOModulo7.AliasFechaUltimoPagoMatricula].ToString());
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
            return matricula;
        }

    

        public bool EstadoMatricula(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ListarMatriculasPagas(Entidad persona)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();

            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            List<Entidad> listaDeMatriculas = new List<Entidad>();
            Persona idPersona = (Persona)persona;

            try
            {
                if (idPersona.ID > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ID.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarMatriculasPagas, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        Matricula matricula  = (Matricula)fabricaEntidades.ObtenerMatricula();
                    
                        matricula.Id = int.Parse(row[RecursosDAOModulo7.AliasIdMatricula].ToString());
                        matricula.Identificador = row[RecursosDAOModulo7.AliasIdentificadorMatricula].ToString();
                        matricula.FechaCreacion = DateTime.Parse(row[RecursosDAOModulo7.AliasFechaPagoMatricula].ToString());
                        matricula.UltimaFechaPago = DateTime.Parse(row[RecursosDAOModulo7.AliasFechaUltimoPagoMatricula].ToString());
                        listaDeMatriculas.Add(matricula);
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

            return listaDeMatriculas;
        }

        public int MatriculaID(Entidad persona)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public float MontoPagoMatricula(Entidad persona, Entidad matricula)
        {
            throw new NotImplementedException();
        }
    }
}
