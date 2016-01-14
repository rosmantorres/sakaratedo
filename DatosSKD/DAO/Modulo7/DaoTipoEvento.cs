﻿using DatosSKD.InterfazDAO.Modulo7;
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
    public class DaoTipoEvento : DAOGeneral, IDaoTipoEvento
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
        /// Método para consultar el detalle de un tipo de evento
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada del tipo de evento</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            TipoEvento idTipoEvento = (TipoEvento)parametro;
            TipoEvento tipoEvento;

            try
            {
                if (idTipoEvento.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    tipoEvento = new TipoEvento();// se sustituye con fabrica
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdTipoEvento, SqlDbType.Int, idTipoEvento.Id.ToString(), false);
                    parametros.Add(parametroQuery);
                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultarTipoEventoXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        tipoEvento.Id = int.Parse(row[RecursosDAOModulo7.AliasIdTipoEvento].ToString());
                        tipoEvento.Nombre = row[RecursosDAOModulo7.AliasTipoEventoNombre].ToString();
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
            return tipoEvento;
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
    }
}