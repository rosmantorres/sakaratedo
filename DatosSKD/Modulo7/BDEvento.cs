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
    public class BDEvento
    {

        /// <summary>
        /// Método para listar los eventos asistidos del atleta
        /// </summary>
        /// <returns>Lista de eventos</returns>
        public static List<Evento> ListarEventosAsistidos()
        {
            /*Int16 id = 1;
            String nombre = "Seminario Cintas Negras";
            List<Evento> laListaDeEventoAsistidos = new List<Evento>();
            TipoEvento tipoEvento = BDTipoEvento.DetallarTipoEvento(1);
            Ubicacion ubicacion = BDUbicacion.DetallarUbicacion(1);
            Horario horario = BDHorario.DetallarHorario(1);
            Evento evento = new Evento(id, nombre, "desc:primer evento", 200, ubicacion, tipoEvento, horario);
            laListaDeEventoAsistidos.Add(evento);*/

            int idPersona = 1;
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Evento> laListaDeEventoAsistidos = new List<Evento>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                

                elParametro = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(),false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarEventosAsistidos, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();
                    evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                    evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                    evento.Descripcion = row[RecursosBDModulo7.AliasDescripcionEvento].ToString();
                    evento.Costo = float.Parse(row[RecursosBDModulo7.AliasEventoCosto].ToString());
                    evento.TipoEvento = BDTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                    evento.Horario = BDHorario.DetallarHorario(int.Parse(row[RecursosBDModulo7.AliasEventoHorarioId].ToString()));
                    evento.Ubicacion = BDUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasEventoUbicacionId].ToString()));
                    laListaDeEventoAsistidos.Add(evento);
                }

                return laListaDeEventoAsistidos; 

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


            //return laListaDeEventoAsistidos;
        }

        /// <summary>
        /// Metodo que lista los eventos a los cuales estan inscritos los atletas
        /// </summary>
        /// <returns></returns>
        public static List<Evento> ListarEventosInscritos()
        {
            List<Evento> laListaDeEventoInscrito = new List<Evento>();
            Int16 id = 1;
            String nombre = "Seminario Cintas Negras";
            TipoEvento tipoEvento = BDTipoEvento.DetallarTipoEvento(1); 
            Ubicacion ubicacion = BDUbicacion.DetallarUbicacion(1);
            Horario horario = BDHorario.DetallarHorario(1);
            Evento evento = new Evento(id, nombre, "desc:primer evento", 200, ubicacion, tipoEvento, horario);
            laListaDeEventoInscrito.Add(evento);

            return laListaDeEventoInscrito;
        }

   
        public static List<Evento> ListarEventosPagos()
        {
            
            int idPersona = 1;
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();
            List<Evento> laListaDeEventoPago = new List<Evento>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                elParametro = new Parametro(RecursosBDModulo7.ParamIdPersona, SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo7.ConsultarEventosPagos,parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Evento evento = new Evento();
                    evento.Id_evento = int.Parse(row[RecursosBDModulo7.AliasIdEvento].ToString());
                    evento.Nombre = row[RecursosBDModulo7.AliasEventoNombre].ToString();
                    evento.Descripcion = row[RecursosBDModulo7.AliasDescripcionEvento].ToString();
                    evento.Costo = float.Parse(row[RecursosBDModulo7.AliasEventoCosto].ToString());
                    evento.TipoEvento = BDTipoEvento.DetallarTipoEvento(int.Parse(row[RecursosBDModulo7.AliasEventoTipoEveId].ToString()));
                    evento.Horario = BDHorario.DetallarHorario(int.Parse(row[RecursosBDModulo7.AliasEventoHorarioId].ToString()));
                    evento.Ubicacion = BDUbicacion.DetallarUbicacion(int.Parse(row[RecursosBDModulo7.AliasEventoUbicacionId].ToString()));
                    laListaDeEventoPago.Add(evento);
                }

                return laListaDeEventoPago;

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


            //return laListaDeEventosPagos;
        }

        /// <summary>
        /// Metodo que lista los eventos a los cuales estan inscritos los atletas
        /// </summary>
        /// <returns></returns>
     
        public static List<Evento> ListarHorarioPractica()
        {
            List<Evento> laListaDeHorarioPractica = new List<Evento>();
            Int16 id = 1;
            String nombre = "Seminario Cintas Negras";
            TipoEvento tipoEvento = BDTipoEvento.DetallarTipoEvento(1);
            Ubicacion ubicacion = BDUbicacion.DetallarUbicacion(1); 
            Horario horario = BDHorario.DetallarHorario(1);
            Evento evento = new Evento(id, nombre, "desc:primer evento", 200, ubicacion, tipoEvento, horario);
            laListaDeHorarioPractica.Add(evento);

            return laListaDeHorarioPractica;
        }

        /// <summary>
        /// Método que consulta en la BD para detallar un evento
        /// </summary>
        /// <param name="idEvento">Número entero que representa el ID del evento</param>
        /// <returns>Objeto de tipo Evento</returns>
        public static Evento DetallarEvento(int idEvento)
        {
            Int16 id = 1;
            String nombre = "Seminario Cintas Negras"; 
            TipoEvento tipoEvento = BDTipoEvento.DetallarTipoEvento(1);
            Ubicacion ubicacion = BDUbicacion.DetallarUbicacion(1);
            Horario horario = BDHorario.DetallarHorario(1);
            Evento evento = new Evento(id, nombre, "desc:primer evento", 200, ubicacion, tipoEvento, horario);

            return evento;
        }


    }
}
