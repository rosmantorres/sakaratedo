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
        private String descripcion;
        private int costo;

        public int Id_evento
        {
            get { return id_evento; }
            set { id_evento = value; }
        }

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

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public Evento()
        {
            id_evento = 0;
            nombre = "";
            descripcion = "";
            costo = 0;
        }

        public Evento(int elId, String elNombre, String descrip, int cost)
        {
            id_evento = elId;
            nombre = elNombre;
            descripcion = descrip;
            costo = cost;
        }

        public Evento(String elNombre)
        {
            nombre = elNombre;
        }
    }
}
