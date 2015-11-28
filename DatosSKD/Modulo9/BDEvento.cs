using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD;

namespace DatosSKD.Modulo9
{
    public class BDEvento
    {
        /// <summary>
        /// Metodo que permite agregar un Evento a la BD
        /// </summary>
        /// <param name="evento">El Evento a Agregar</param>
        /// <returns>Retorna true o false</returns>
        public bool CrearEvento(Evento evento)
        {
            try
            {
                //parametros para insertar un evento
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo9.ParametroNombreEvento, SqlDbType.VarChar, evento.Nombre, false);
                parametros.Add(parametro);        
                parametro = new Parametro(RecursosBDModulo9.ParametroDescripcionEvento, SqlDbType.VarChar, evento.Descripcion, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroCostoEvento, SqlDbType.Float, evento.Costo.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroEstadoEvento, SqlDbType.VarChar, evento.Estado.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroIdPersona, SqlDbType.Int,"1", false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroIdUbicacion, SqlDbType.Int, evento.Ubicacion.Id_ubicacion.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroIdTipoEvento, SqlDbType.Int, evento.TipoEvento.Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroIdCategoria, SqlDbType.Int,evento.Categoria.Id_categoria.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroFechaInicio, SqlDbType.Date, evento.Horario.FechaInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroFechaFin, SqlDbType.Date, evento.Horario.FechaFin.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroHoraInicio, SqlDbType.Int, evento.Horario.HoraInicio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo9.ParametroHoraFin, SqlDbType.Int, evento.Horario.HoraFin.ToString(), false);
                parametros.Add(parametro);

                BDConexion con = new BDConexion();
                List<Resultado> resultados = con.EjecutarStoredProcedure(RecursosBDModulo9.ProcedimientoAgregarEvento, parametros);

                //si la creacion es correcta retorna true

                if (resultados != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
        }

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los eventos de un administrador
        /// </summary>
        /// <returns>lista de eventos</returns>


        public List<Evento> ListarEventos()
        {
            BDConexion laConexion;
            List<Evento> listaEventos = new List<Evento>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo9.ProcedimientoConsultarEventos, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();
                   
                    evento.Id_evento = int.Parse(row[RecursosBDModulo9.AliasIdEvento].ToString());
                    Console.Out.WriteLine(evento.Id_evento);
                    evento.Nombre = row[RecursosBDModulo9.AliasNombreEvento].ToString();
                    evento.Descripcion = row[RecursosBDModulo9.AliasDescripcionEvento].ToString();
                    evento.Estado =  Boolean.Parse(row[RecursosBDModulo9.AliasEstadoEvento].ToString());
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo9.AliasFechaInicio].ToString());
                    horario.FechaFin = DateTime.Parse(row[RecursosBDModulo9.AliasFechaFin].ToString());
                    horario.HoraInicio = int.Parse(row[RecursosBDModulo9.AliasHoraInicio].ToString());
                    horario.HoraFin = int.Parse(row[RecursosBDModulo9.AliasHoraFin].ToString());
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Nombre = row[RecursosBDModulo9.AliasTipoEvento].ToString();
                    evento.Horario = horario;
                    evento.TipoEvento = tipoEvento;
                    listaEventos.Add(evento);
                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaEventos;

        }

    }


}

