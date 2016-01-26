using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo3;

namespace DominioSKD.Entidades.Modulo5
{
    public class Cinta : Entidad
    {
        #region atributos
        private int id_cinta;
        private String color_nombre;
        private String rango;
        private String clasificacion;
        private int orden;
        private String significado;
        private int id_restriccion;
        private DominioSKD.Entidades.Modulo3.Organizacion organizacion;
        private Boolean status;
        #endregion

        #region propiedades
        public int Id_cinta
        {
            get { return id_cinta; }
            set { id_cinta = value; }
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
        public DominioSKD.Entidades.Modulo3.Organizacion Organizacion
        {
            get { return organizacion; }
            set { organizacion = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion

        #region constructores

        public Cinta() : base()
        {
            id_cinta = 0;
            color_nombre = "";
            rango="";
            clasificacion = "";
            orden = 0;
            significado = "";
            id_restriccion = 0;
            organizacion = null;
            status = false;
        }

        public Cinta(int elId, String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, int elIdRestriccion) : base()
        {
            id_cinta = elId;
            color_nombre = elColor;
            rango = elRango;
            clasificacion = laClasificacion;
            orden = elOrden;
            significado = elSignificado;
            id_restriccion = elIdRestriccion;

        }
        
        public Cinta(String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, int elIdRestriccion) : base()

        {
            color_nombre = elColor;
            rango = elRango;
            clasificacion = laClasificacion;
            orden = elOrden;
            significado = elSignificado;
            id_restriccion = elIdRestriccion;

        }

        //De M5
        public Cinta(int elId, String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, DominioSKD.Entidades.Modulo3.Organizacion organizacion, Boolean status)
            : base()
        {
            id_cinta = elId;
            color_nombre = elColor;
            rango = elRango;
            clasificacion = laClasificacion;
            orden = elOrden;
            significado = elSignificado;
            this.organizacion = organizacion;
            this.status = status;

        }

        public Cinta(String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, DominioSKD.Entidades.Modulo3.Organizacion organizacion,Boolean status) : base() 
        {
            color_nombre = elColor;
            rango = elRango;
            clasificacion = laClasificacion;
            orden = elOrden;
            significado = elSignificado;
            this.organizacion = organizacion;
            this.status = status;

        }

        public Cinta(int elId, String elColor) : base() 
        {
            this.id_cinta = elId;
            this.color_nombre = elColor;

        }
        #endregion
    }
}

