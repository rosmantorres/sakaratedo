using DatosSKD.InterfazDAO.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using ExcepcionesSKD;
using System.Data;
using System.Data.SqlClient;
using ExcepcionesSKD.Modulo7;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo7;

namespace DatosSKD.DAO.Modulo7
{
    /// <summary>
    /// DAO para consultar horario de atleta
    /// </summary>
    public class DaoHorario : DAOGeneral, IDaoHorario
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
        /// Método para consultar el detalle de un horario
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada del horario/returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            HorarioM7 idHorario = (HorarioM7)parametro;
            HorarioM7 horario;
            try
            {
                if (idHorario.Id > 0)
                {
                    parametros = new List<Parametro>();
                    horario = (HorarioM7)FabricaEntidades.ObtenerHorarioM7();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdHorario, SqlDbType.Int, idHorario.Id.ToString(), false);
                    parametros.Add(parametroQuery);
                    DataTable dt = this.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarHorarioXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        horario.Id = int.Parse(row[RecursosDAOModulo7.AliasIdHorario].ToString());
                        horario.FechaInicio = DateTime.Parse(row[RecursosDAOModulo7.AliasFechaInicioHorario].ToString());
                        horario.FechaFin = DateTime.Parse(row[RecursosDAOModulo7.AliasFechaFinHorario].ToString());
                        horario.HoraInicio = int.Parse(row[RecursosDAOModulo7.AliasHoraInicioHorario].ToString());
                        horario.HoraFin = int.Parse(row[RecursosDAOModulo7.AliasHoraFinHorario].ToString());
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

            return horario;
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
