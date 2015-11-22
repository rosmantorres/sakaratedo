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

        public static List<Evento> ListarEventosAsistidos()
        {
            List<Evento> laListaDeEventoAsistidos = new List<Evento>();
            Evento evento = new Evento(Convert.ToInt16(RecursosEvento.Id1), RecursosEvento.Nombre1, RecursosEvento.Tipo1, RecursosHorario.FechaInicio1, RecursosUbicacion.Direccion1 );
            laListaDeEventoAsistidos.Add(evento);

            return laListaDeEventoAsistidos;
        }

        public static List<Evento> ListarEventosInscritos()
        {
            List<Evento> laListaDeEventoInscrito = new List<Evento>();
            Evento evento = new Evento(Convert.ToInt16(RecursosEvento.Id2), RecursosEvento.Nombre2, RecursosEvento.Tipo2, RecursosHorario.FechaInicio2, RecursosUbicacion.Direccion2);
            laListaDeEventoInscrito.Add(evento);

            return laListaDeEventoInscrito;
        }

        public static List<Evento> ListarEventosPagos()
        {
            List<Evento> laListaDeEventoPago = new List<Evento>();
            

            return laListaDeEventoPago;
        }

        public static Evento DetallarEvento(int idEvento)
        {
            Evento elEvento = new Evento();

            return elEvento;
        }


    }
}
