using DominioSKD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosSKD.Modulo10
{
    public class BDAsistencia
    {
        
        /// <summary>
        /// Metodo que permite obtener de base de datos todos los eventos con asistencia pasada
        /// </summary>
        /// <returns>lista de eventos</returns>
        public static List<Evento> ListarEventosAsistidos()
        {
            BDConexion laConexion;
            List<Evento> listaEventos = new List<Evento>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimentoConsultarEventoAsistido, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();

                    evento.Id_evento = int.Parse(row[RecursosBDModulo10.aliasIdEvento].ToString());
                    evento.Nombre = row[RecursosBDModulo10.aliasNombreEvento].ToString();
                    Horario horario = new Horario();
                    horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo10.aliasFechaEvento].ToString());
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Nombre = row[RecursosBDModulo10.aliasTipoEvento].ToString();
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
                /*throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);*/
                throw ex;
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

        /// <summary>
        /// Metodo que permite obtener de base de datos todos los eventos con asistencia pasada
        /// </summary>
        /// <returns>lista de eventos</returns>
        public static List<Competencia> ListarCompetenciasAsistidas()
        {
            BDConexion laConexion;
            List<Competencia> listaCompetencia = new List<Competencia>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimentoConsultarCompetenciaAsistida, parametros);
                foreach (DataRow row in dt.Rows)
                {
                    Competencia competencia = new Competencia();

                    competencia.Id_competencia = int.Parse(row[RecursosBDModulo10.aliasIdCompetencia].ToString());
                    competencia.Nombre = row[RecursosBDModulo10.aliasNombreCompetencia].ToString();
                    competencia.FechaInicio = DateTime.Parse(row[RecursosBDModulo10.aliasFechaCompetencia].ToString());
                    listaCompetencia.Add(competencia);
                }

            }
            catch (SqlException ex)
            {
                throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                /*throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
                     RecursosBDModulo9.MensajeErrorFormato, ex);*/
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaCompetencia;

        }

        //public List<Persona> listaAsistentes(String idEvento)
        //{
        //    BDConexion laConexion;
        //    List<Persona> personas = new List<Persona>();
        //    try
        //    {
        //        laConexion = new BDConexion();
        //        List<Parametro> parametros = new List<Parametro>();
        //        Parametro parametro = new Parametro(RecursosBDModulo10.ParametroIdEvento, SqlDbType.Int, idEvento, false);
        //        parametros.Add(parametro);
        //        DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo10.ProcedimientoAtletasAsistentes, parametros);

        //        foreach (DataRow row in dt.Rows)
        //        {
        //            Persona persona = new Persona();
                    
        //            persona.ID = int.Parse(row[RecursosBDModulo10.aliasIdPersona].ToString());
        //            persona.Nombre = row[RecursosBDModulo10.aliasNombrePersona].ToString(); 
        //            evento.Descripcion = row[RecursosBDModulo9.AliasDescripcionEvento].ToString();
        //            evento.Estado = Boolean.Parse(row[RecursosBDModulo9.AliasEstadoEvento].ToString());
        //            evento.Costo = float.Parse(row[RecursosBDModulo9.AliasCostoEvento].ToString());
        //            Horario horario = new Horario();
        //            horario.FechaInicio = DateTime.Parse(row[RecursosBDModulo9.AliasFechaInicio].ToString());
        //            horario.FechaFin = DateTime.Parse(row[RecursosBDModulo9.AliasFechaFin].ToString());
        //            horario.HoraInicio = int.Parse(row[RecursosBDModulo9.AliasHoraInicio].ToString());
        //            horario.HoraFin = int.Parse(row[RecursosBDModulo9.AliasHoraFin].ToString());
        //            TipoEvento tipoEvento = new TipoEvento();
        //            tipoEvento.Nombre = row[RecursosBDModulo9.AliasTipoEvento].ToString();
        //            evento.Horario = horario;
        //            evento.TipoEvento = tipoEvento;
        //        }


        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new ExcepcionesSKD.ExceptionSKDConexionBD(RecursoGeneralBD.Codigo,
        //            RecursoGeneralBD.Mensaje, ex);
        //    }
        //    catch (FormatException ex)
        //    {
        //        throw new ExcepcionesSKD.Modulo12.FormatoIncorrectoException(RecursosBDModulo9.CodigoErrorFormato,
        //             RecursosBDModulo9.MensajeErrorFormato, ex);
        //    }
        //    catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
        //    {
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ExcepcionesSKD.ExceptionSKD(RecursoGeneralBD.Mensaje_Generico_Error, ex);
        //    }
        //    return evento;


        //}
    }
}
