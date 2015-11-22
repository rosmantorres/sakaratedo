using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Organizacion
    {
        private int id_organizacion;
        private String nombre;
        public int Id_organizacion
        {
            get { return id_organizacion; }
            set { id_organizacion = value; }
        }
        
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Organizacion()
        {
            id_organizacion = 0;
            nombre = "";
        }

        public Organizacion(int elId, String elNombre)
        {
            id_organizacion = elId;
            nombre = elNombre;
        }

        public Organizacion(String elNombre)
        {
            nombre = elNombre;
        }


    }
}
