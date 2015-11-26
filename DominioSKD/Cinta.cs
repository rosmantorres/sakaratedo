using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Cinta
    {
        private int id;       
        private String color_nombre;      
        private String rango;      
        private String clasificacion;      
        private String significado;      
        private String orden;


        public Cinta(int id, String color_nombre, String rango, String clasificacion, String significado, String orden) 
        {
            this.id = id;
            this.color_nombre = color_nombre;
            this.rango = rango;
            this.clasificacion = clasificacion;
            this.significado = significado;
            this.orden = orden;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Color_nombre
        {
            get { return color_nombre; }
            set { color_nombre = value; }
        }

        public String Rango
        {
            get { return rango; }
            set { rango = value; }
        }

        public String Clasificacion
        {
            get { return clasificacion; }
            set { clasificacion = value; }
        }
        public String Significado
        {
            get { return significado; }
            set { significado = value; }
        }

        public String Orden
        {
            get { return orden; }
            set { orden = value; }
        }

    }
}
