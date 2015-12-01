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
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;

namespace DatosSKD.Modulo7
{
    public class BDHorario
    {

        public Horario DetallarHorario(int idHorario)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosBDModulo7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            Horario horario;
            try
            {
                if (idHorario.GetType() == Type.GetType("System.Int32") && idHorario > 0)
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();
                    horario = new Horario();

                    elParametro = new Parametro(RecursosBDModulo7.ParamIdHorario, SqlDbType.Int, idHorario.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo7.ConsultarHorarioXId, parametros);

                foreach (DataRow row in dt.Rows)
                {

                    horario.Id= int.Parse(row[RecursosBDModulo7.AliasIdHorario].ToString());
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo7.AliasFechaInicioHorario].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosBDModulo7.AliasFechaFinHorario].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosBDModulo7.AliasHoraInicioHorario].ToString());
                    horario.HoraFin = int.Parse(row[RecursosBDModulo7.AliasHoraFinHorario].ToString());
                    
                }

               }
                else
                {
                    throw new NumeroEnteroInvalidoException(RecursosBDModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosBDModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                throw new NumeroEnteroInvalidoException(RecursosBDModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosBDModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new NumeroEnteroInvalidoException(RecursosBDModulo7.Codigo_Numero_Parametro_Invalido,
                                RecursosBDModulo7.Mensaje_Numero_Parametro_invalido, new Exception());
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
                RecursosBDModulo7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return horario;
        }
       }
}