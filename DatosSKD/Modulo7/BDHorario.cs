using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DominioSKD;

namespace DatosSKD.Modulo7
{
    public class BDHorario
    {

        public static Horario DetallarHorario(int idHorario)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Horario horario = new Horario();

                elParametro = new Parametro(RecursosBDModulo7.ParamIdHorario, SqlDbType.Int, idHorario.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarHorarioXId, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    horario.Id= int.Parse(row[RecursosBDModulo7.AliasIdHorario].ToString());
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo7.AliasFechaInicioHorario].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosBDModulo7.AliasFechaFinHorario].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosBDModulo7.AliasHoraInicioHorario].ToString());
                    horario.HoraFin = int.Parse(row[RecursosBDModulo7.AliasHoraFinHorario].ToString());
                    
                }

                return horario;

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
