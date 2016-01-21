﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Cinta : Entidad
    {

        private int id_cinta;
        private String color_nombre;
        private String rango;
        private String clasificacion;
        private int orden;
        private String significado;
        private int id_restriccion;


        private Organizacion organizacion;

        private Boolean status;


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

        public Cinta() : base()
        {
            id_cinta = 0;
            color_nombre = "";
            rango = "";
            clasificacion = "";
            orden = 0;
            significado = "";
            id_restriccion = 0;
            organizacion = null;
            status = false;
        }

        
        

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



        public Cinta( String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, int elIdRestriccion)

        {
            color_nombre = elColor;
            rango = elRango;
            clasificacion = laClasificacion;
            orden = elOrden;
            significado = elSignificado;
            id_restriccion = elIdRestriccion;

        }

        //De M5
        public Cinta(int elId, String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, Organizacion organizacion, Boolean status)
        {
            id_cinta = elId;
            color_nombre = elColor;
            rango = elRango;
            clasificacion = laClasificacion;
            orden = elOrden;
            significado = elSignificado;
            organizacion = null;
            status = false;

        }

        public Cinta(String elColor, String elRango, String laClasificacion, int elOrden, String elSignificado, Organizacion organizacion,Boolean status)
        {
            color_nombre = elColor;
            rango = elRango;
            clasificacion = laClasificacion;
            orden = elOrden;
            significado = elSignificado;
            organizacion = null;
            status = false;

        }


        public Cinta(int elId, String elColor)
        {
            this.id_cinta = elId;
            this.color_nombre = elColor;

        }

    }

}



