using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<Evento> laListaDeEventoAsistidos = new List<Evento>();
            TipoEvento tipoEvento = new TipoEvento(1, "Seminario");
            Ubicacion ubicacion = new Ubicacion(1, "caracas", "distrito capital");
            DateTime fechaInicio = Convert.ToDateTime("15/08/2008");
            DateTime fechaFin = Convert.ToDateTime("16/08/2008"); 
            Horario horario = new Horario(1, fechaInicio, fechaFin, 400, 300);
            Evento evento = new Evento(Convert.ToInt16(RecursosEvento.Id1), RecursosEvento.Nombre1, "desc:primer evento", 200, ubicacion, tipoEvento, horario);
            laListaDeEventoAsistidos.Add(evento);

            return laListaDeEventoAsistidos;
        }

        public static List<Evento> ListarEventosInscritos()
        {
            /* BDConexion laConexion;
             List<Evento> laListaDeEventoInscrito = new List<Evento>();
             List<Parametro> parametros;
             try
             {
                 laConexion = new BDConexion();
                 parametros = new List<Parametro>();

                 DataTable dt = laConexion.EjecutarStoredProcedureTuplas(RecursosBDModulo12.ConsultarCompetencias, parametros);

                 foreach (DataRow row in dt.Rows)
             }*/
            List<Evento> laListaDeEventoInscrito = new List<Evento>();
            Int16 id = 1;
            String nombre = "Seminario Cintas Negras";
            TipoEvento tipoEvento = new TipoEvento(1, "Seminario");
            Ubicacion ubicacion = new Ubicacion(1, "caracas", "distrito capital");
            DateTime fechaInicio = Convert.ToDateTime("15/08/2008");
            DateTime fechaFin = Convert.ToDateTime("16/08/2008");
            Horario horario = new Horario(1, fechaInicio, fechaFin, 1300, 1500);
            Evento evento = new Evento(id, nombre, "desc:primer evento", 200, ubicacion, tipoEvento, horario);
            laListaDeEventoInscrito.Add(evento);

            return laListaDeEventoInscrito;
        }

        public static List<Evento> ListarEventosPagos()
        {
            List<Evento> laListaDeEventoPago = new List<Evento>();
            TipoEvento tipoEvento = new TipoEvento(1, "Seminario");
            Ubicacion ubicacion = new Ubicacion(1, "caracas", "distrito capital");
            DateTime fechaInicio = Convert.ToDateTime("15/08/2008");
            DateTime fechaFin = Convert.ToDateTime("16/08/2008");
            Horario horario = new Horario(1, fechaInicio, fechaFin, 1300, 1500);
            Evento evento = new Evento(Convert.ToInt16(RecursosEvento.Id1), RecursosEvento.Nombre1, "desc:primer evento", 200, ubicacion, tipoEvento, horario);
            laListaDeEventoPago.Add(evento);
            
            return laListaDeEventoPago;
        }
        
        public static List<Evento> ListarHorarioPractica()
        {
            List<Evento> laListaDeHorarioPractica = new List<Evento>();
            Int16 id = 1;
            String nombre = "Seminario Cintas Negras";
            TipoEvento tipoEvento = new TipoEvento(1, "Seminario");
            Ubicacion ubicacion = new Ubicacion(1, "caracas", "distrito capital");
            DateTime fechaInicio = Convert.ToDateTime("15/08/2008");
            DateTime fechaFin = Convert.ToDateTime("16/08/2008");
            Horario horario = new Horario(1, fechaInicio, fechaFin, 1300, 1500);
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
            TipoEvento tipoEvento = new TipoEvento(1, "Seminario");
            Ubicacion ubicacion = new Ubicacion(1, "caracas", "distrito capital");
            DateTime fechaInicio = Convert.ToDateTime("15/08/2008");
            DateTime fechaFin = Convert.ToDateTime("16/08/2008");
            Horario horario = new Horario(1, fechaInicio, fechaFin, 1300, 1500);
            Evento evento = new Evento(Convert.ToInt16(RecursosEvento.Id1), RecursosEvento.Nombre1, "desc:primer evento", 200, ubicacion, tipoEvento, horario);

            return evento;
        }


    }
}
