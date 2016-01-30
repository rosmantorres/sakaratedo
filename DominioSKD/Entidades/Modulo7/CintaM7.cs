using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo7
{
    public class CintaM7 : Entidad
    {
        private String color_nombre;
        private String rango;
        private String clasificacion;
        private int orden;
        private String significado;
        private int id_restriccion;
        private Organizacion organizacion;
        private Boolean status;

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

        public int Orden
        {
            get { return orden; }
            set { orden = value; }
        }

        public String Significado
        {
            get { return significado; }
            set { significado = value; }
        }

        public int Id_restriccion
        {
            get { return id_restriccion; }
            set { id_restriccion = value; }
        }
        public Organizacion Organizacion
        {
            get { return organizacion; }
            set { organizacion = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        public CintaM7() : base()
        {
            color_nombre = "";
            rango = "";
            clasificacion = "";
            orden = 0;
            significado = "";
            id_restriccion = 0;
            organizacion = null;
            status = false;
        }    

    }

}



