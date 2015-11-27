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
            Int16 id = 1;
            String nombre = "Seminario Cintas Negras";
            List<Evento> laListaDeEventoAsistidos = new List<Evento>();
            TipoEvento tipoEvento = BDTipoEvento.DetallarTipoEvento(1);
            Ubicacion ubicacion = BDUbicacion.DetallarUbicacion(1);
            Horario horario = BDHorario.DetallarHorario(1);
            Evento evento = new Evento(id, nombre, "desc:primer evento", 200, ubicacion, tipoEvento, horario);
            laListaDeEventoAsistidos.Add(evento);

            return laListaDeEventoAsistidos;
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
            Int16 id = 1;
            String nombre = "Seminario Cintas Negras";
            List<Evento> laListaDeEventoPago = new List<Evento>();
            TipoEvento tipoEvento = BDTipoEvento.DetallarTipoEvento(1);
            Ubicacion ubicacion = BDUbicacion.DetallarUbicacion(1); 
            Horario horario = BDHorario.DetallarHorario(1);
            Evento evento = new Evento(id, nombre, "desc:primer evento", 200, ubicacion, tipoEvento, horario);
            laListaDeEventoPago.Add(evento);
            
            return laListaDeEventoPago;
        }
   /// <summary>
   /// Metodo que lista los horarios de practica del atleta
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
