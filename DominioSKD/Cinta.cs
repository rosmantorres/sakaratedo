using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Cinta
    {

        private int id_cinta;
        private String color_nombre;
        private String rango;
        private String clasificacion;
        private int orden;
        private String significado;
        private int id_restriccion;
<<<<<<< HEAD
        private Organizacion organizacion;

=======
        
>>>>>>> 033e8da8f4395894e63a77056fea4884783f2564
        public int Id_cinta
        {
            get { return id_cinta; }
            set { id_cinta = value; }
        }
<<<<<<< HEAD

=======
        
>>>>>>> 033e8da8f4395894e63a77056fea4884783f2564
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
<<<<<<< HEAD
            set { id_restriccion = value; }
        }
        public Organizacion Organizacion
        {
            get { return organizacion; }
            set { organizacion = value; }
        }  

=======
            set {id_restriccion = value; }
        }
>>>>>>> 033e8da8f4395894e63a77056fea4884783f2564
        public Cinta()
        {
            id_cinta = 0;
            color_nombre = "";
<<<<<<< HEAD
            rango = "";
=======
            rango="";
>>>>>>> 033e8da8f4395894e63a77056fea4884783f2564
            clasificacion = "";
            orden = 0;
            significado = "";
            id_restriccion = 0;
<<<<<<< HEAD
            organizacion = null;
        }

=======
        }
        
>>>>>>> 033e8da8f4395894e63a77056fea4884783f2564
        public Cinta(int elId, String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, int elIdRestriccion)
        {
            id_cinta = elId;
            color_nombre = elColor;
            rango = elRango;
            clasificacion = laClasificacion;
            orden = elOrden;
            significado = elSignificado;
            id_restriccion = elIdRestriccion;

        }

<<<<<<< HEAD
        public Cinta(String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, int elIdRestriccion)
=======
        public Cinta( String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, int elIdRestriccion)
>>>>>>> 033e8da8f4395894e63a77056fea4884783f2564
        {
            color_nombre = elColor;
            rango = elRango;
            clasificacion = laClasificacion;
            orden = elOrden;
            significado = elSignificado;
            id_restriccion = elIdRestriccion;

        }
<<<<<<< HEAD
        //De M5
        public Cinta(int elId,String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, Organizacion organizacion)
        {
            id_cinta = elId;
            color_nombre = elColor;
            rango = elRango;
            clasificacion = laClasificacion;
            orden = elOrden;
            significado = elSignificado;
            organizacion = null;

        }

        public Cinta(String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, Organizacion organizacion)
        {
            color_nombre = elColor;
            rango = elRango;
            clasificacion = laClasificacion;
            orden = elOrden;
            significado = elSignificado;
            organizacion = null;

        }


    }
}
=======


    }
}
>>>>>>> 033e8da8f4395894e63a77056fea4884783f2564
