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
    /// DAO para consultar persona de atleta
    /// </summary>
    public class DaoPersona : DAOGeneral, IDaoPersona
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
        /// Método para consultar el detalle de una persona
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada de una persona</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            PersonaM7 idPersona = (PersonaM7)parametro;
            PersonaM7 persona;

            try
            {
                if (idPersona.Id> 0)
                {
                    parametros = new List<Parametro>();
                    persona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = this.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultaPersonaXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        persona.Nombre = row[RecursosDAOModulo7.AliasPersonaNombre].ToString();
                        persona.Apellido = row[RecursosDAOModulo7.AliasPersonaApellido].ToString();
                        persona.FechaNacimiento = DateTime.Parse(row[RecursosDAOModulo7.AliasPersonaFechaNacimiento].ToString());
                        persona.Direccion = row[RecursosDAOModulo7.AliasPersonaDireccion].ToString();
                        persona.DojoPersona = int.Parse(row[RecursosDAOModulo7.AliasPersonaDojoId].ToString());
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
                throw new ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
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

            return persona;
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
