﻿using DatosSKD.InterfazDAO.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using System.Data.SqlClient;
using System.Data;

namespace DatosSKD.DAO.Modulo7
{
    public class DaoUbicacion : DAOGeneral, IDaoUbicacion
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
        /// Método para consultar el detalle de una ubicacion
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad que posee el id a consultar</param>
        /// <returns>Retorna objeto de tipo Entidad con la informacion detallada de la ubicacion</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosDAOModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion conexion;
            List<Parametro> parametros;
            Parametro parametroQuery = new Parametro();
            Ubicacion idUbicacion = (Ubicacion)parametro;
            Ubicacion ubicacion;

            try
            {
                if (idUbicacion.Id > 0)
                {
                    conexion = new BDConexion();
                    parametros = new List<Parametro>();
                    ubicacion = new Ubicacion(); //esto se debe cambiar por fabrica
                    parametroQuery = new Parametro(RecursosDAOModulo7.ParamIdUbicacion, SqlDbType.Int, idUbicacion.Id.ToString(), false);
                    parametros.Add(parametroQuery);

                    DataTable dt = conexion.EjecutarStoredProcedureTuplas(
                                   RecursosDAOModulo7.ConsultaUbicacionXId, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        ubicacion.Id = int.Parse(row[RecursosDAOModulo7.AliasIdUbicacion].ToString());
                        ubicacion.Ciudad = row[RecursosDAOModulo7.AliasCiudad].ToString();
                        ubicacion.Estado = row[RecursosDAOModulo7.AliasEstado].ToString();
                        ubicacion.Direccion = row[RecursosDAOModulo7.AliasDireccion].ToString();
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
            return ubicacion;
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
    }
}
