using DominioSKD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.Modulo7
{
    public class BDPersona
    {
        /// <summary>
        /// MNetodo que busca la informacion de la persona logueada
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public Persona DetallarPersona(int idPersona)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Persona persona = new Persona();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdUsuarioLogueado, SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultaPersonaXId, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    persona.Nombre = row[RecursosBDModulo7.AliasPersonaNombre].ToString();
                    persona.Apellido = row[RecursosBDModulo7.AliasPersonaApellido].ToString();
                    persona.FechaNacimiento = DateTime.Parse(row[RecursosBDModulo7.AliasPersonaFechaNacimiento].ToString());
                    persona.Direccion = row[RecursosBDModulo7.AliasPersonaDireccion].ToString();
                    persona.DojoPersona = int.Parse(row[RecursosBDModulo7.AliasPersonaDojoId].ToString());
                }

                return persona;

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }/*
            catch (ExcepcionesSKD.Modulo12.CompetenciaInexistenteException ex)
            {
                throw ex;
            }*/
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD("No se pudo completar la operacion", ex);
            }
        }
    }
}
