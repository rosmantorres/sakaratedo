using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Evento
    {
        private int id_evento;
        private String nombre;
        public int Id_organizacion
        {
            get { return id_evento; }
            set { id_evento = value; }
        }
        
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Evento()
        {
            id_evento = 0;
            nombre = "";
        }

        public Evento(int elId, String elNombre)
        {
            id_evento = elId;
            nombre = elNombre;
        }

        public Evento(String elNombre)
        {
            nombre = elNombre;
        }
    }
}
