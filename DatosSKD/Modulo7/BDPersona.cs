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
        public static Persona DetallarPersona(int idPersona)
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
                               RecursosBDModulo7.ParamIdUsuarioLogueado, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    persona..Id_cinta = int.Parse(row[RecursosBDModulo7.AliasIdCinta].ToString());
                    cinta.Color_nombre = row[RecursosBDModulo7.AliasCintaNombre].ToString();
                    cinta.Rango = row[RecursosBDModulo7.AliasCintaRango].ToString();
                    cinta.Clasificacion = row[RecursosBDModulo7.AliasCintaClasificacion].ToString();
                    cinta.Significado = row[RecursosBDModulo7.AliasCintaSignificado].ToString();
                    cinta.Orden = int.Parse(row[RecursosBDModulo7.AliasCintaOrden].ToString());

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
