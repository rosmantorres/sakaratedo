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
using DominioSKD.Entidades.Modulo7;
using DominioSKD.Fabrica;

namespace DatosSKD.DAO.Modulo7
{
    /// <summary>
    /// DAO para consultar tipo de evento de atleta
    /// </summary>
    public class DaoTipoEvento : DAOGeneral, IDaoTipoEvento
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
        /// Método para consultar el detalle de un tipo de evento
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada del tipo de evento</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            TipoEventoM7 idTipoEvento = (TipoEventoM7)parametro;
            TipoEventoM7 tipoEvento;

            try
            {
                if (idTipoEvento.Id > 0)
                {
                    parametros = new List<Parametro>();
                    tipoEvento = (TipoEventoM7)FabricaEntidades.ObtenerTipoEventoM7();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdTipoEvento, SqlDbType.Int, idTipoEvento.Id.ToString(), false);
                    parametros.Add(parametroQuery);
                    DataTable dt = this.EjecutarStoredProcedureTuplas(
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

            return tipoEvento;
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
