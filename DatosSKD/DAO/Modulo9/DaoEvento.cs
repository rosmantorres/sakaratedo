using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo12;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



namespace DatosSKD.DAO.Modulo9
{
    public class DaoEvento:DAOGeneral        
    {
        /// <summary>
        /// Metodo que permite agregar un Evento a la BD
        /// </summary>
        /// <param name="evento">El Evento a Agregar</param>
        /// <returns>Retorna true o false</returns>
        public bool CrearEvento(Entidad eventoParametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                //parametros para insertar un evento
                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)eventoParametro;

                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosDaoEvento.ParametroNombreEvento, SqlDbType.VarChar, evento.Nombre, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroDescripcionEvento, SqlDbType.VarChar, evento.Descripcion, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroCostoEvento, SqlDbType.Float, evento.Costo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroEstadoEvento, SqlDbType.VarChar, evento.Estado.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdPersona, SqlDbType.Int, evento.Persona.ID.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdUbicacion, SqlDbType.Int,"1", false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdTipoEvento, SqlDbType.Int, evento.TipoEvento.Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroIdCategoria, SqlDbType.Int, "1", false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroFechaInicio, SqlDbType.Date, evento.Horario.FechaInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroFechaFin, SqlDbType.Date, evento.Horario.FechaFin.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroHoraInicio, SqlDbType.Int, evento.Horario.HoraInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosDaoEvento.ParametroHoraFin, SqlDbType.Int, evento.Horario.HoraFin.ToString(), false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosDaoEvento.ProcedimientoAgregarEvento, parametros);

                //si la creacion es correcta retorna true

                if (resultados != null)
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, RecursosDaoEvento.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;

                }

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosDaoEvento.CodigoErrorFormato,
                     RecursosDaoEvento.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
        }

    }
}
