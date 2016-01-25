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
using DominioSKD.Entidades.Modulo7;

namespace DatosSKD.DAO.Modulo7
{
    /// <summary>
    /// DAO para consultar matricula de atleta
    /// </summary>
    public class DaoMatricula : DAOGeneral, IDaoMatricula
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
        /// No tiene implementacion
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Método para consultar el detalle de una matricula 
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion de la matricula</returns>

        public Entidad ConsultarXId(Entidad parametro)
        {
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            MatriculaM7 idMatricula = (MatriculaM7)parametro;
            MatriculaM7 matricula = (MatriculaM7)FabricaEntidades.ObtenerMatriculaM7();


            try
            {
                if (idMatricula.Id > 0)
                {
                    parametros = new List<Parametro>();                    
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdMatricula, SqlDbType.Int, idMatricula.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
                                    RecursosDAOModulo7.ConsultarMatriculaXId, parametros);

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

            return matricula;
        }
     
        /// <summary>
        /// Método para consultar el estado de una matricula
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        /// <returns>Retorna objeto de tipo Entidad con el estado de la matricula</returns>

        public bool EstadoMatricula(Entidad persona)
        {
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroMatricula = new Parametro();
            Boolean estadoMatricula = new bool();
            PersonaM7 idPersona = (PersonaM7)persona;
          
            try
            {
                if (idPersona.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametroPersona);
                   

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarEstadoMatricula, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        estadoMatricula = Boolean.Parse(row[RecursosDAOModulo7.AliasEstadoMatricula].ToString());
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

            return estadoMatricula;
        }

        /// <summary>
        /// Método para consultar la lista de matriculas pagas
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        /// <returns>Retorna objeto de tipo Entidad con la lista de matriculas que han sido canceladas</returns>

        public List<Entidad> ListarMatriculasPagas(Entidad persona)
        {
            
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();

            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            List<Entidad> listaDeMatriculas = new List<Entidad>();
            PersonaM7 idPersona = (PersonaM7)persona;

            try
            {
                if (idPersona.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarMatriculasPagas, parametros);


                    foreach (DataRow row in dt.Rows)
                    {
                        
                        MatriculaM7 matricula = (MatriculaM7)FabricaEntidades.ObtenerMatriculaM7();
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

            return listaDeMatriculas;
        }

        /// <summary>
        /// Método para consultar el id de una matricula
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        /// <returns>Retorna objeto de tipo Entidad con el id de la matricula</returns>
        public int MatriculaID(Entidad persona)
        {
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroMatricula = new Parametro();
            int idMatricula = new int();
            PersonaM7 idPersona = (PersonaM7)persona;


            try
            {
                if (idPersona.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametroPersona);


                    DataTable dt = this.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarIdMatricula, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        idMatricula = int.Parse(row[RecursosDAOModulo7.AliasIdMatricula].ToString());
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

            return idMatricula;
        }

        /// <summary>
        /// Método para consultar el monto del pago de una matricula
        /// </summary>
        /// <param name="persona">Objeto de tipo Entidad que posee el id de la persona</param>
        ///  /// <param name="matricula">Objeto de tipo Entidad que posee el id de la matricula</param>
        /// <returns>Retorna objeto de tipo Entidad con el monto de la matricula</returns>
   
        public float MontoPagoMatricula(Entidad persona, Entidad matricula)
        {
            List<Parametro> parametros;
            Parametro parametroPersona = new Parametro();
            Parametro parametroMatricula = new Parametro();
            float monto = new float();
            PersonaM7 idPersona = (PersonaM7)persona;
            MatriculaM7 idMatricula = (MatriculaM7)matricula;
        
            try
            {
                if (idPersona.Id > 0 && idMatricula.Id > 0)
                {
                    parametros = new List<Parametro>();
                    parametroPersona = new Parametro(RecursosDAOModulo7.ParamIdPersona, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametroMatricula = new Parametro(RecursosDAOModulo7.ParamIdMatricula, SqlDbType.Int, idMatricula.Id.ToString(), false);
                    parametros.Add(parametroPersona);
                    parametros.Add(parametroMatricula);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarMontoMatricula, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        monto = float.Parse(row[RecursosDAOModulo7.AliasMontoMatricula].ToString());
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

            return monto;
        }
    }
}
