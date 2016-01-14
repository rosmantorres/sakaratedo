﻿using DatosSKD.InterfazDAO.Modulo7;
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

namespace DatosSKD.DAO.Modulo7
{
    public class DaoHorario : DAOGeneral, IDaoHorario
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
        /// Método para consultar el detalle de un horario
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada del horario/returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            Horario idHorario = (Horario)parametro;
            Horario horario;
            try
            {
                if (idHorario.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    horario = new Horario();//esto se debe cambiar por fabrica
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdHorario, SqlDbType.Int, idHorario.Id.ToString(), false);
                    parametros.Add(parametroQuery);
                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(RecursosDAOModulo7.ConsultarHorarioXId, parametros);

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
            return horario;
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
    }
}