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

        public static List<Evento> ListarEventosInscritos()
        {
            List<Evento> laListaDeEventoInscrito = new List<Evento>();

            return laListaDeEventoInscrito;
        }

        public static List<Evento> ListarEventosAsistidos()
        {
            List<Evento> laListaDeEventoAsistidos = new List<Evento>();
            Evento evento = new Evento(1, "Pedro", "Primer evento", 5000);
            laListaDeEventoAsistidos.Add(evento);

            return laListaDeEventoAsistidos;
        }


        public static Evento DetallarEvento(int idEvento)
        {
            Evento elEvento = new Evento();

            return elEvento;
        }


    }
}
